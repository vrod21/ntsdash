using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using NLog;

namespace NTDataHiveFrontend.ServiceAccess
{
    public class PreEditingFeedbackBackendService
    {
        GrpcChannel _channel;

        NTDataHiveGrpcService.PreEditingFeedbackBackend.PreEditingFeedbackBackendClient _client;

        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly string _url;

        public PreEditingFeedbackBackendService(ILogger<PreEditingFeedbackBackendService> logger, IConfiguration config)
        {
            _url = config.GetValue<string>("ServiceData: BackendService:URL");
        }

        private void Connect()
        {
            try
            {
                HttpClientHandler httpHandler = new HttpClientHandler();

                HttpClient httpClient = new HttpClient(httpHandler);

                _channel = GrpcChannel.ForAddress(_url, new GrpcChannelOptions()
                {
                    HttpClient = httpClient,
                });
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }

        #region SavePreEditingFeedback
        public async Task<Google.Rpc.Status> SavePreEditFeedback(NTDataHiveFrontend.Model.PreEditingErrorFeedback preEditRecord)
        {
            if (_client == null)
                Connect();

            NTDataHiveGrpcService.PreEditingFeedbackRecordRequest grpcPreEditingRecord = ToGrpcFormat(preEditRecord);

            Google.Rpc.Status result;
            try
            {
                result = await _client.SavePreEditFeedbackAsync(grpcPreEditingRecord);
                return result;
            }
            catch (Exception ex)
            {
                _nlog.Error($"Save pre-editing feedback threw up: {ex.Message}, {ex}");
                return new Google.Rpc.Status { Code = 2, Message = ex.Message };
            }
        }
        #endregion

        #region ToGrpcFormat
        public NTDataHiveGrpcService.PreEditingFeedbackRecordRequest ToGrpcFormat(NTDataHiveFrontend.Model.PreEditingErrorFeedback preEditRecord)
        {
            var grpcPreEditingRecord = new NTDataHiveGrpcService.PreEditingFeedbackRecordRequest()
            {
                WebId = preEditRecord.id.ToString(),
                SupplierName = preEditRecord.SupplierName,
                QualityAssurance = preEditRecord.QualityAssurance,
                PublisherName = preEditRecord.PublisherName,
                JournalId = preEditRecord.JournalId,
                ArticleId = preEditRecord.ArticleId,
                PageCount = preEditRecord.PageCount,
                ErrorCount = preEditRecord.ErrorCount,
                DescriptionOfError = preEditRecord.DescriptionOfError,
                Matter = preEditRecord.Matter,
                ErrorLocation = preEditRecord.ErrorLocation,
                ErrorCode = preEditRecord.ErrorCode,
                ErrorType = preEditRecord.ErrorType,
                ErrorSubtype = preEditRecord.ErrorType,
                ErrorCategory = preEditRecord.ErrorType,
                IntroducedOrMissed = preEditRecord.IntroducedOrMissed,
                Department = preEditRecord.Department,
                EmployeeName = preEditRecord.EmployeeName,
                CopyEditingLevel = preEditRecord.CopyEditingLevel
            };

            if (preEditRecord?.CreatedAt != null)
                grpcPreEditingRecord.CreatedAt = preEditRecord.CreatedAt.ToUniversalTime().ToTimestamp();

            return grpcPreEditingRecord;
        }
        #endregion




    }
}
