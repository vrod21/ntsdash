using Google.Protobuf.WellKnownTypes;
using NTDataHiveGrpcService.DAL.Model;

namespace NTDataHiveGrpcService.DAL.Mapper
{
    internal class CreateNewEvaluationMapper
    {
        public FeedbackRecordRequest CreateNewEvaluationApprovalMapper(Evaluation evaluation, Approval approval)
        {
            return new FeedbackRecordRequest()
            {
                WebId = evaluation.WebId,
                Stage = evaluation.Stage,
                QualityAssurance = evaluation.QualityAssurance,
                PublisherName = evaluation.PublisherName,
                JournalId = evaluation.JournalId,
                ArticleId = evaluation.ArticleId,
                CopyEditedBy = evaluation.CopyEditedBy,
                PageCount = evaluation.PageCount,
                ErrorCount = evaluation.ErrorCount,
                DescriptionOfError = evaluation.DescriptionOfError,
                Matter = evaluation.Matter,
                ErrorLocation = evaluation.ErrorLocation,
                ErrorCode = evaluation.ErrorCode,
                ErrorType = evaluation.ErrorType,
                ErrorSubtype = evaluation.ErrorSubtype,
                ErrorCategory = evaluation.ErrorCategory,
                IntroducedOrMissed = evaluation.IntroducedOrMissed,
                Department = evaluation.Department,
                EmployeeName = evaluation.EmployeeName,
                RootCause = approval.RootCause,
                CorrectiveAction = approval.CorrectiveAction,
                NatureOfCA = approval.NatureOfCA,
                OwnerOfCA = approval.OwnerOfCA,
                TargetDateOfCompletionCA = approval.TargetDateOfCompletionCA.ToUniversalTime().ToTimestamp(),
                PreventiveMeasure = approval.PreventiveMeasure,
                NatureOfPM = approval.NatureOfPM,
                OwnerOfPM = approval.OwnerOfPM,
                TargetDateOfCompletionPM = approval.TargetDateOfCompletionPM.ToUniversalTime().ToTimestamp(),
                StatusOfCA = approval.StatusOfCA,
                StatusOfPM = approval.StatusOfPM,
                Validate = approval.Validate,
                State = approval.State,
                CopyEditingLevel = evaluation.CopyEditingLevel,
                CreatedAt = evaluation.CreatedAt.ToUniversalTime().ToTimestamp(),
                YearMonth = evaluation.YearMonth.ToUniversalTime().ToTimestamp(),
            };
        }
    }
}
