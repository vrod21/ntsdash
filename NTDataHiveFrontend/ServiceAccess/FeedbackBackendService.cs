using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using NLog;

namespace NTDataHiveFrontend.ServiceAccess
{
    public class FeedbackBackendService
    {
        GrpcChannel _channel;

        NTDataHiveGrpcService.FeedbackBackend.FeedbackBackendClient _client;

        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly string _url;

        public FeedbackBackendService(ILogger<FeedbackBackendService> logger, IConfiguration config)
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
                    HttpClient = httpClient,
                });
                _client = new NTDataHiveGrpcService.FeedbackBackend.FeedbackBackendClient(_channel);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }

        #region SavePreEditingFeedback
        public async Task<Google.Rpc.Status> SavePreEditFeedback(Model.Feedback preEditRecord)
        {
            if (_client == null)
                Connect();

            NTDataHiveGrpcService.PreEditingRecordRequest grpcPreEditingRecord = ToGrpcFormat(preEditRecord);

            Google.Rpc.Status result;
            try
            {
                result = await _client.SavePreEditingAsync(grpcPreEditingRecord);
                return result;
            }
            catch (Exception ex)
            {
                _nlog.Error($"Save pre-editing threw up: {ex.Message}, {ex}");
                return new Google.Rpc.Status { Code = 2, Message = ex.Message };
            }
        }
        #endregion

        #region ToGrpcFormat
        public NTDataHiveGrpcService.PreEditingRecordRequest ToGrpcFormat(Model.Feedback preEditRecord)
        {
            var grpcPreEditingRecord = new NTDataHiveGrpcService.PreEditingRecordRequest()
            {
                WebId = preEditRecord.id.ToString(),
                SupplierName = preEditRecord.SupplierName,
                QualityAssurance = preEditRecord.QualityAssurance,
                PublisherName = preEditRecord.PublisherName,
                JournalId = preEditRecord.JournalId,
                ArticleId = preEditRecord.ArticleId,
                CopyEditedBy = preEditRecord.CopyEditedBy,
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
                RootCause = preEditRecord.RootCause,
                CorrectiveAction = preEditRecord.CorrectiveAction,
                NatureOfCA = preEditRecord.NatureOfCA,
                OwnerOfCA = preEditRecord.OwnerOfCA,
                PreventiveMeasure = preEditRecord.PreventiveMeasure,
                NatureOfPM = preEditRecord.NatureOfPM,
                StatusOfCA = preEditRecord.StatusOfCA,
                StatusOfPM = preEditRecord.StatusOfPM,
                CopyEditingLevel = preEditRecord.CopyEditingLevel
            };

            if (preEditRecord?.CreatedAt != null)
                grpcPreEditingRecord.CreatedAt = preEditRecord.CreatedAt.Value.ToUniversalTime().ToTimestamp();

            if (preEditRecord?.TargetDateOfCompletionCA != null)
                grpcPreEditingRecord.TargetDateOfCompletionCA = preEditRecord.TargetDateOfCompletionCA.Value.ToUniversalTime().ToTimestamp();
            else
                grpcPreEditingRecord.TargetDateOfCompletionCA = null;

            if (preEditRecord?.TargetDateOfCompletionPM != null)
                grpcPreEditingRecord.TargetDateOfCompletionPM = preEditRecord.TargetDateOfCompletionPM.Value.ToUniversalTime().ToTimestamp();
            else
                grpcPreEditingRecord.TargetDateOfCompletionPM = null;

            return grpcPreEditingRecord;
        }
        #endregion
    }
}
