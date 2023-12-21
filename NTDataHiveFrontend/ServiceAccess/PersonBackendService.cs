using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using NLog;
using NLog.Fluent;
using System.Reflection.PortableExecutable;

namespace NTDataHiveFrontend.ServiceAccess
{
    public class PersonBackendService
    {
        GrpcChannel _channel;

        NTDataHiveGrpcService.PersonBackend.PersonBackendClient _client;

        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly string _url;

        public PersonBackendService(ILogger<PersonBackendService> logger, IConfiguration config)
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

                _client = new NTDataHiveGrpcService.PersonBackend.PersonBackendClient(_channel);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }

        #region SavePerson
        public async Task<Google.Rpc.Status> SavePerson(Model.Person personRecord)
        {
            if (_client == null)
                Connect();

            NTDataHiveGrpcService.PersonRequest grpcPersonRecord = ToGrpcFromat(personRecord);

            Google.Rpc.Status result;
            try
            {
                result = await _client.SavePersonAsync(grpcPersonRecord);
                return result;
            }
            catch (Exception ex)
            {
                _nlog.Error($"Save rule threw up: {ex.Message}, {ex}");
                return new Google.Rpc.Status { Code = 2, Message = ex.Message };
            }
        }
        #endregion

        #region GetRevisionRecord
        public async Task<Model.Person> GetPersonRecord(string id)
        {
            if (_client == null)
                Connect();

            try
            {
                NTDataHiveGrpcService.PersonRequest result;
                try
                {
                    result = await _client.GetPersonRecordAsync(GetFilterFor(id));
                }
                catch (Exception ex)
                {
                    _nlog.Error("Get revision record threw up: " + ex.Message);
                    return null;
                }

                if (result.Status.Code == 0)
                {
                    Model.Person revision = ToFrontendFormat(result);

                    if (result.WebId != "")
                        return revision;

                }
                _nlog.Error(result.Status.Message);
                return null;
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }
        #endregion

        #region GetFilterFor
        public NTDataHiveGrpcService.PersonRecordFilter GetFilterFor(string id)
        {

            return new NTDataHiveGrpcService.PersonRecordFilter()
            {
                WebId = id.ToString(),
            };
        }
        #endregion

        #region ToGrpcFormat
        public NTDataHiveGrpcService.PersonRequest ToGrpcFromat(Model.Person personRecord)
        {
            var grpcPersonRecord = new NTDataHiveGrpcService.PersonRequest()
            {
                WebId = personRecord.WebId,
                Username = personRecord.Username,
                EmailAddress = personRecord.EmailAddress,
                FirstName = personRecord.FirstName,
                LastName = personRecord.LastName,
                Position = personRecord.Position,
                CompanyId = personRecord.CompanyId,
                AccountName = personRecord.AccountName,
                ReportingManager = personRecord.ReportingManager,
                Department = personRecord.Department,
                Type = personRecord.Type,
            };

            if (personRecord?.Birthday != null)
                grpcPersonRecord.Birthday = personRecord.Birthday.Value.ToUniversalTime().ToTimestamp();

            return grpcPersonRecord;
        }
        #endregion

        #region ToFrontendFormat
        public Model.Person ToFrontendFormat(NTDataHiveGrpcService.PersonRequest personRecord)
        {
            Model.Person frontendPersonRecord = new Model.Person()
            {
                WebId = personRecord.WebId,
                EmailAddress = personRecord.EmailAddress,
                Username = personRecord.Username,
                FirstName = personRecord.FirstName,
                LastName = personRecord.LastName,
                Birthday = personRecord.Birthday.ToDateTime(),
                Position = personRecord.Position,
                CompanyId = personRecord.CompanyId,
                AccountName = personRecord.AccountName,
                ReportingManager = personRecord.ReportingManager,
                Department = personRecord.Department,
                Type = personRecord.Type,
            };

            return frontendPersonRecord;
        }
        #endregion
    }
}
