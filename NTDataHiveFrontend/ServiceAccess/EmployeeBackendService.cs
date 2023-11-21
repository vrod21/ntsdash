using Grpc.Net.Client;
using NLog;

namespace NTDataHiveFrontend.ServiceAccess
{
    public class EmployeeBackendService
    {
        GrpcChannel _channel;

        NTDataHiveGrpcService.EmployeeBackend.EmployeeBackendClient _client;

        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly string _url;

        public EmployeeBackendService(ILogger<EmployeeBackendService> logger, IConfiguration config)
        {
            _url = config.GetValue<string>("ServiceData:BackendService:URL");
        }

        private void Connect()
        {
            try
            {
                HttpClientHandler httpHandler = new HttpClientHandler();

                HttpClient httpClient = new HttpClient(httpHandler);

                _channel = GrpcChannel.ForAddress(_url, new GrpcChannelOptions
                {
                    HttpClient = httpClient,
                });

                _client = new NTDataHiveGrpcService.EmployeeBackend.EmployeeBackendClient(_channel);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }

        #region GetAll
        public async Task<List<NTDataHiveFrontend.Model.Employee>> GetAllEmployee()
        {
            if (_client == null)
                Connect();

            NTDataHiveGrpcService.EmployeeArray employeeList = await _client.GetAllAsync(new NTDataHiveGrpcService.EmployeeEmpty());

            List<NTDataHiveFrontend.Model.Employee> employees = new List<Model.Employee>();

            foreach (var employeeRecord in employeeList.Items)
            {
                employees.Add(ToFrontendFormat(employeeRecord));
            }
            return employees;
        }
        #endregion

        #region SaveEmployee
        public async Task<Google.Rpc.Status> SaveEmployee(NTDataHiveFrontend.Model.Employee empRecord)
        {
            if (_client == null)
                Connect();

            NTDataHiveGrpcService.EmployeeRecordRequest grpcEmployeeRecord = ToGrpcFromat(empRecord);

            Google.Rpc.Status result;
            try
            {
                result = await _client.SaveEmployeeAsync(grpcEmployeeRecord);
                return result;
            }
            catch (Exception ex)
            {
                _nlog.Error($"Save rule threw up: {ex.Message}, {ex}");
                return new Google.Rpc.Status { Code = 2, Message = ex.Message };
            }
        }
        #endregion


        #region ToGrpcFormat
        public NTDataHiveGrpcService.EmployeeRecordRequest ToGrpcFromat(NTDataHiveFrontend.Model.Employee empRecord)
        {
            var GrpcStudentRecord = new NTDataHiveGrpcService.EmployeeRecordRequest()
            {
                WebId = empRecord.id.ToString(),
                FirstName = empRecord.FirstName,
                LastName = empRecord.LastName,
                PublisherIdentity = empRecord.PublisherIdentity,
            };

            return GrpcStudentRecord;
        }
        #endregion

        #region ToFrontendFormat
        public NTDataHiveFrontend.Model.Employee ToFrontendFormat(NTDataHiveGrpcService.EmployeeRecordRequest employeeRequest)
        {
            NTDataHiveFrontend.Model.Employee frontendStudentRecord = new NTDataHiveFrontend.Model.Employee()
            {

                WebId = employeeRequest.WebId,
                FirstName = employeeRequest.FirstName,
                LastName = employeeRequest.LastName,
                PublisherIdentity = employeeRequest.PublisherIdentity,
                Created_at = employeeRequest.CreatedAt.ToDateTime(),
                ScoreCard = employeeRequest.ScoreCard,
            };
            try
            {
                frontendStudentRecord.id = Guid.Parse(employeeRequest.WebId);
            }
            catch (Exception ex)
            {
                _nlog.Error(ex, "Received student record has an invalid ID");
                throw;
            }

            return frontendStudentRecord;
        }
        #endregion
    }
}
