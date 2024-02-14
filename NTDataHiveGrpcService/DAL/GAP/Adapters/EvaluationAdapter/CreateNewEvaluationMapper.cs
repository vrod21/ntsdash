using Google.Protobuf.WellKnownTypes;
using NTDataHiveGrpcService.DAL.Model;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters.EvaluationAdapter
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
                CopyEditingLevel = evaluation.CopyEditingLevel,
                CreatedAt = evaluation.CreatedAt.ToUniversalTime().ToTimestamp(),
                YearMonth = evaluation.YearMonth.ToUniversalTime().ToTimestamp(),
            };
        }

        public PersonRequest CreateNewPesonMapper(Person person)
        {
            return new PersonRequest
            {
                WebId = person.WebId,
                EmailAddress = person.EmailAddress,
                FirstName = person.FirstName,
                LastName = person.LastName,
                FullName = person.FullName,
                Position = person.Position,
                CompanyId = person.CompanyId,
                AccountName = person.AccountName,
                ReportingManager = person.ReportingManager,
                Department = person.Department,
                Type = person.Type,
                Birthday = person.Birthday.ToUniversalTime().ToTimestamp(),
            };
        }
    }
}
