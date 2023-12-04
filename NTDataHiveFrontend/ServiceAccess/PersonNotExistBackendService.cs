using Grpc.Net.Client;
using NLog;

namespace NTDataHiveFrontend.ServiceAccess
{
    public class PersonNotExistBackendService
    {
        GrpcChannel _channel;

        NTDataHiveGrpcService.PersonBackend.PersonBackendClient _client;

        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly string _url;

        public PersonNotExistBackendService(ILogger<PersonNotExistBackendService> logger, IConfiguration config)
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

            NTDataHiveGrpcService.PersonNotExistRequest grpcPersonRecord = ToGrpcFromat(personRecord);

            Google.Rpc.Status result;
            try
            {
                result = await _client.SavePersonNotExistAsync(grpcPersonRecord);
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

        public NTDataHiveGrpcService.PersonNotExistRequest ToGrpcFromat(Model.Person personRecord)
        {
            var GrpcPersonRecord = new NTDataHiveGrpcService.PersonNotExistRequest()
            {
                WebId = personRecord.WebId,
                EmailAddress = personRecord.EmailAddress,
                Username = personRecord.Username,
            };

            return GrpcPersonRecord;
        }
        #endregion
    }
}