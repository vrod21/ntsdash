using Google.Protobuf.WellKnownTypes;

namespace NTDataHiveFrontend.Mapper
{
    public class FeedbackGrpcFormatMapper
    {
        public NTDataHiveGrpcService.FeedbackRecordRequest ToGrpcFormat(Model.Feedback feedback)
        {
            var grpcFeedbackRecord = new NTDataHiveGrpcService.FeedbackRecordRequest()
            {
                WebId = feedback.id.ToString(),
                Stage = feedback.Stage,
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
                Validate = feedback.Validate,
                State = feedback.State,
                CopyEditingLevel = feedback.CopyEditingLevel,
                Component = feedback.Component,
                PageType = feedback.PageType,
                FinalErrorPoints = feedback.FinalErrorPoints,
                TotalErrorPoints = feedback.TotalErrorPoints,
                TotalTSPages = feedback.TotalTSPages,
                ErrorPerPages = feedback.ErrorPerPages,
                AccuracyRating = feedback.AccuracyRating,
                AccuracyRatingFC = feedback.AccuracyRatingFC,
                WeghtPercentFC = feedback.WeightPercentFC,
                WeightedRatingFC = feedback.WeightedRatingFC,
                AccuracyRatingIPF = feedback.AccuracyRatingIPF,
                WeightPercentIPF = feedback.WeightPercentIPF,
                WeightedRatingIPF = feedback.WeightedRatingIPF,
                DCF = feedback.DCF,
                OverallAccuracyRating = feedback.OverallAccuracyRating,
            };

            if (feedback?.CreatedAt != null)
                grpcFeedbackRecord.CreatedAt = feedback.CreatedAt.Value.ToUniversalTime().ToTimestamp();

            if (feedback?.TargetDateOfCompletionCA != null)
                grpcFeedbackRecord.TargetDateOfCompletionCA = feedback.TargetDateOfCompletionCA.Value.ToUniversalTime().ToTimestamp();

            if (feedback.TargetDateOfCompletionPM != null)
                grpcFeedbackRecord.TargetDateOfCompletionPM = feedback.TargetDateOfCompletionPM.Value.ToUniversalTime().ToTimestamp();

            if (feedback?.DateProcessed != null)
                grpcFeedbackRecord.DateProcessed = feedback.DateProcessed.Value.ToUniversalTime().ToTimestamp();

            if (feedback?.DateChecked != null)
                grpcFeedbackRecord.DateChecked = feedback.DateChecked.Value.ToUniversalTime().ToTimestamp();

            return grpcFeedbackRecord;

        }
    }
}
