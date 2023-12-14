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
                _client = new NTDataHiveGrpcService.PreEditingFeedbackBackend.PreEditingFeedbackBackendClient(_channel);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }

        #region GetAll
        public async Task<List<Model.PreEditingErrorFeedback>> GetAllPreEditingRecord()
        {
            if (_client == null)
                Connect();

            var preEditingList = await _client.GetAllAsync(new NTDataHiveGrpcService.PreEditingFeedbackEmpty());

            List<Model.PreEditingErrorFeedback> preEditing = new List<Model.PreEditingErrorFeedback>();

            foreach (var preEditingRecord in preEditingList.Items)
            {
                preEditing.Add(ToFrontendFormat(preEditingRecord));
            }
            return preEditing;
        }
        #endregion


        #region ToGrpcFormat
        public NTDataHiveGrpcService.PreEditingFeedbackRecordRequest ToGrpcFormat(Model.PreEditingErrorFeedback preEditRecord)
        {
            var grpcPreEditingRecord = new NTDataHiveGrpcService.PreEditingFeedbackRecordRequest()
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

            if (preEditRecord?.TargetDateOfCompletionPM != null)
                grpcPreEditingRecord.TargetDateOfCompletionPM = preEditRecord.TargetDateOfCompletionPM.Value.ToUniversalTime().ToTimestamp();

            //if (preEditRecord?.CreatedAt == null && preEditRecord?.TargetDateOfCompletionCA == null && preEditRecord?.TargetDateOfCompletionPM == null)
            //    grpcPreEditingRecord = null;

            return grpcPreEditingRecord;
        }
        #endregion

        #region ToFrontendFormat
        public Model.PreEditingErrorFeedback ToFrontendFormat(NTDataHiveGrpcService.PreEditingFeedbackRecordRequest preEditingRequest)
        {
            Model.PreEditingErrorFeedback frontendPreEditingRecord = new Model.PreEditingErrorFeedback()
            {
                WebId = preEditingRequest.WebId,
                SupplierName = preEditingRequest.SupplierName,
                QualityAssurance = preEditingRequest.QualityAssurance,
                PublisherName = preEditingRequest.PublisherName,
                JournalId = preEditingRequest.JournalId,
                ArticleId = preEditingRequest.ArticleId,
                CopyEditedBy = preEditingRequest.CopyEditedBy,
                PageCount = preEditingRequest.PageCount,
                ErrorCount = preEditingRequest.ErrorCount,
                DescriptionOfError = preEditingRequest.DescriptionOfError,
                Matter = preEditingRequest.Matter,
                ErrorLocation = preEditingRequest.ErrorLocation,
                ErrorCode = preEditingRequest.ErrorCode,
                ErrorType = preEditingRequest.ErrorType,
                ErrorSubtype = preEditingRequest.ErrorType,
                ErrorCategory = preEditingRequest.ErrorType,
                IntroducedOrMissed = preEditingRequest.IntroducedOrMissed,
                Department = preEditingRequest.Department,
                EmployeeName = preEditingRequest.EmployeeName,
                RootCause = preEditingRequest.RootCause,
                CorrectiveAction = preEditingRequest.CorrectiveAction,
                NatureOfCA = preEditingRequest.NatureOfCA,
                OwnerOfCA = preEditingRequest.OwnerOfCA,
                PreventiveMeasure = preEditingRequest.PreventiveMeasure,
                NatureOfPM = preEditingRequest.NatureOfPM,
                StatusOfCA = preEditingRequest.StatusOfCA,
                StatusOfPM = preEditingRequest.StatusOfPM,
                CopyEditingLevel = preEditingRequest.CopyEditingLevel,
                TargetDateOfCompletionCA = preEditingRequest.TargetDateOfCompletionCA.ToDateTime(),
                TargetDateOfCompletionPM = preEditingRequest.TargetDateOfCompletionPM.ToDateTime(),
                CreatedAt = preEditingRequest.CreatedAt.ToDateTime()                
            };
            try
            {
                frontendPreEditingRecord.id = Guid.Parse(preEditingRequest.WebId);
            }
            catch (Exception ex)
            {
                _nlog.Error(ex, "Received pre-editing record has an invalid ID");
                throw;
            }

            return frontendPreEditingRecord;
        }
        #endregion
    }
}
