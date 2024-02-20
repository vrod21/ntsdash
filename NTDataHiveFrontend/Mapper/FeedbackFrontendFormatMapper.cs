using NLog;

namespace NTDataHiveFrontend.Mapper
{
    public class FeedbackFrontendFormatMapper
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        public Model.Feedback ToFrontendFormat(NTDataHiveGrpcService.FeedbackRecordRequest feedbackRequest)
        {
            Model.Feedback frontendFeedbackRecord = new Model.Feedback()
            {
                WebId = feedbackRequest.WebId,
                Stage = feedbackRequest.Stage,
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
                Validate = feedbackRequest.Validate,
                State = feedbackRequest.State,
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
                _nlog.Error(ex, "Received feedback record has a invalid ID");
                throw;
            }

            return frontendFeedbackRecord;
        }
    }
}
