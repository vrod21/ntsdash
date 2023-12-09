using Grpc.Net.Client;
using NLog;

namespace NTDataHiveFrontend.ServiceAccess
{
    public class DropdownBackendService
    {
        GrpcChannel _channel;

        NTDataHiveGrpcService.DropdownbackBackend.DropdownbackBackendClient _client;

        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly string _url;

        public DropdownBackendService(ILogger<DropdownBackendService> logger, IConfiguration config)
        {
            _url = config.GetValue<string>("ServiceData:BackendService:URL");
        }

        private void Connect()
        {
            try
            {
                HttpClientHandler httpHandler = new HttpClientHandler();

                HttpClient httpClient = new HttpClient(httpHandler);

                _channel = GrpcChannel.ForAddress(_url, new GrpcChannelOptions()
                {
                    HttpClient = httpClient
                });

                _client = new NTDataHiveGrpcService.DropdownbackBackend.DropdownbackBackendClient(_channel);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }

        #region GetAll
        public async Task<List<Model.Publisher>> GetAllPublisher()
        {
            if (_client == null)
                Connect();

            NTDataHiveGrpcService.PublisherNameArray publisherName = await _client.GetPublisherNameAsync(new NTDataHiveGrpcService.PublisherNameEmpty());

            List<Model.Publisher> publisher = new List<Model.Publisher>();

            foreach (var publisherRecord in publisherName.Items)
            {
                publisher.Add(ToFrontendFormat(publisherRecord));
            }

            return publisher;
        }
        #endregion

        #region ToFronendFormat
        public Model.Publisher ToFrontendFormat(NTDataHiveGrpcService.PublisherRecordRequest publisherRecord)
        {
            Model.Publisher frontendPublisherRecord = new Model.Publisher()
            {
                PublisherName = publisherRecord.PublisherName,
            };

            return frontendPublisherRecord;
        }
        #endregion
    }
}
