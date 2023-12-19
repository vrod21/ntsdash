using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using NLog;

namespace NTDataHiveFrontend.ServiceAccess
{
    public class EvaluationBackendService
    {
        GrpcChannel _channel;

        NTDataHiveGrpcService.EvaluationBackend.EvaluationBackendClient _client;

        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly string _url;

        public EvaluationBackendService(ILogger<EvaluationBackendService> logger, IConfiguration config)
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
                _client = new NTDataHiveGrpcService.EvaluationBackend.EvaluationBackendClient(_channel);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }

        #region SaveFeedback
        public async Task<Google.Rpc.Status> SaveFeedback(Model.Feedback feedbackRecord)
        {
            if (_client == null)
                Connect();

            NTDataHiveGrpcService.FeedbackRecordRequest grpcFeedbackRecord = ToGrpcFormat(feedbackRecord);

            Google.Rpc.Status result;
            try
            {
                result = await _client.SaveFeedbackAsync(grpcFeedbackRecord);
                return result;
            }
            catch (Exception ex)
            {
                _nlog.Error($"Save feedback threw up: {ex.Message}, {ex}");
                return new Google.Rpc.Status { Code = 2, Message = ex.Message };
            }
        }
        #endregion

        #region GetFeedbackRecord
        public async Task<Model.Feedback> GetFeedbackRecord(Guid id)
        {
            if (_client == null)
                Connect();

            try
            {
                NTDataHiveGrpcService.FeedbackRecordRequest result;
                try
                {
                    result = await _client.GetFeedbackRecordAsync(GetFilterFor(id));
                }
                catch (Exception ex)
                {
                    _nlog.Error("Get feedback record threw up: " + ex.Message);
                    return null;
                }

                if (result.Status.Code == 0)
                {
                    Model.Feedback revision = ToFrontendFormat(result);

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
        public NTDataHiveGrpcService.FeedbackRecordFilter GetFilterFor(Guid id)
        {
            return new NTDataHiveGrpcService.FeedbackRecordFilter()
            {
                WebId = id.ToString(),
            };
        }
        #endregion

        #region
        public async Task<List<Model.Feedback>> GetAllFeedback()
        {
            if (_client == null)
                Connect();

            var feedback = await _client.GetAllFeedbackAsync(new NTDataHiveGrpcService.FeedbackEmpty());

            List<Model.Feedback> evaluationFeedback = new List<Model.Feedback>();

            foreach (var feedbackRecord in feedback.Items)
            {
                evaluationFeedback.Add(ToFrontendFormat(feedbackRecord));
            }
            return evaluationFeedback;
        }
        #endregion

        #region ToGrpcFormat
        public NTDataHiveGrpcService.FeedbackRecordRequest ToGrpcFormat(Model.Feedback feedback)
        {
            var grpcFeedbackRecord = new NTDataHiveGrpcService.FeedbackRecordRequest()
            {
                WebId = feedback.id.ToString(),
                SupplierName = feedback.SupplierName,
                QualityAssurance = feedback.QualityAssurance,
                PublisherName = feedback.PublisherName,
                JournalId = feedback.JournalId,
                ArticleId = feedback.ArticleId,
                CopyEditedBy = feedback.CopyEditedBy,
                PageCount = feedback.PageCount,
                ErrorCount = feedback.ErrorCount,
                DescriptionOfError = feedback.DescriptionOfError,
                Matter = feedback.Matter,
                ErrorLocation = feedback.ErrorLocation,
                ErrorCode = feedback.ErrorCode,
                ErrorType = feedback.ErrorType,
                ErrorSubtype = feedback.ErrorSubtype,
                ErrorCategory = feedback.ErrorCategory,
                IntroducedOrMissed = feedback.IntroducedOrMissed,
                Department = feedback.Department,
                EmployeeName = feedback.EmployeeName,
                RootCause = feedback.RootCause,
                CorrectiveAction = feedback.CorrectiveAction,
                NatureOfCA = feedback.NatureOfCA,
                OwnerOfCA = feedback.OwnerOfCA,
                PreventiveMeasure = feedback.PreventiveMeasure,
                NatureOfPM = feedback.NatureOfPM,
                OwnerOfPM = feedback.OwnerOfPM,
                StatusOfCA = feedback.StatusOfCA,
                StatusOfPM = feedback.StatusOfPM,
                CopyEditingLevel = feedback.CopyEditingLevel,                
            };
            if (feedback?.CreatedAt != null)
                grpcFeedbackRecord.CreatedAt = feedback.CreatedAt.Value.ToUniversalTime().ToTimestamp();

            if (feedback?.TargetDateOfCompletionCA != null && feedback?.TargetDateOfCompletionPM != null)
            {
                grpcFeedbackRecord.TargetDateOfCompletionCA = feedback.TargetDateOfCompletionCA.Value.ToUniversalTime().ToTimestamp();
                grpcFeedbackRecord.TargetDateOfCompletionPM = feedback.TargetDateOfCompletionPM.Value.ToUniversalTime().ToTimestamp();
            }
            else
            {
                grpcFeedbackRecord.TargetDateOfCompletionCA = null;
                grpcFeedbackRecord.TargetDateOfCompletionPM = null;
            }

            return grpcFeedbackRecord;
        }
        #endregion

        #region
        public Model.Feedback ToFrontendFormat(NTDataHiveGrpcService.FeedbackRecordRequest feedbackRequest)
        {
            Model.Feedback frontendFeedbackRecord = new Model.Feedback()
            {
                WebId = feedbackRequest.WebId,
                SupplierName = feedbackRequest.SupplierName,
                QualityAssurance = feedbackRequest.QualityAssurance,
                PublisherName = feedbackRequest.PublisherName,
                JournalId = feedbackRequest.JournalId,
                ArticleId = feedbackRequest.ArticleId,
                CopyEditedBy = feedbackRequest.CopyEditedBy,
                PageCount = feedbackRequest.PageCount,
                ErrorCount = feedbackRequest.ErrorCount,
                DescriptionOfError = feedbackRequest.DescriptionOfError,
                Matter = feedbackRequest.Matter,
                ErrorLocation = feedbackRequest.ErrorLocation,
                ErrorCode = feedbackRequest.ErrorCode,
                ErrorType = feedbackRequest.ErrorType,
                ErrorSubtype = feedbackRequest.ErrorSubtype,
                ErrorCategory = feedbackRequest.ErrorCategory,
                IntroducedOrMissed = feedbackRequest.IntroducedOrMissed,
                Department = feedbackRequest.Department,
                EmployeeName = feedbackRequest.EmployeeName,
                RootCause = feedbackRequest.RootCause,
                CorrectiveAction = feedbackRequest.CorrectiveAction,
                NatureOfCA = feedbackRequest.NatureOfCA,
                OwnerOfCA = feedbackRequest.OwnerOfCA,
                PreventiveMeasure = feedbackRequest.PreventiveMeasure,
                NatureOfPM = feedbackRequest.NatureOfPM,
                OwnerOfPM = feedbackRequest.OwnerOfPM,
                StatusOfCA = feedbackRequest.StatusOfCA,
                StatusOfPM = feedbackRequest.StatusOfPM,
                CopyEditingLevel = feedbackRequest.CopyEditingLevel,
                TargetDateOfCompletionCA = feedbackRequest.TargetDateOfCompletionCA.ToDateTime(),
                TargetDateOfCompletionPM = feedbackRequest.TargetDateOfCompletionPM.ToDateTime(),
                CreatedAt = feedbackRequest.CreatedAt.ToDateTime()
            };
            try
            {
                frontendFeedbackRecord.id = Guid.Parse(feedbackRequest.WebId);
            }
            catch (Exception ex)
            {
                _nlog.Error(ex, "Received feedback record has an invalid ID");
                throw;
            }

            return frontendFeedbackRecord;
        }
        #endregion
    }
}
