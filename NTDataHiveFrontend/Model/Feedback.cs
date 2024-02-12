using System.ComponentModel.DataAnnotations;

namespace NTDataHiveFrontend.Model
{
    public class Feedback
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string WebId { get; set; } = "";
        public string Stage { get; set; } = "";
        public string QualityAssurance { get; set; } = "";
        public string PublisherName { get; set; } = "";
        public string JournalId { get; set; } = "";
        public string ArticleId { get; set; } = "";
        public string CopyEditedBy { get; set; } = "";
        public double PageCount { get; set; } = 0;
        public double ErrorCount { get; set; } = 0;
        public string DescriptionOfError { get; set; } = "";
        public string Matter { get; set; } = "";
        public string ErrorLocation { get; set; } = "";
        public string ErrorCode { get; set; } = "";
        public string ErrorType { get; set; } = "";
        public string ErrorSubtype { get; set; } = "";
        public string ErrorCategory { get; set; } = "";
        public string IntroducedOrMissed { get; set; } = "";
        public string Department { get; set; } = "";
        public string EmployeeName { get; set; } = "";
        public string RootCause { get; set; } = "";
        public string CorrectiveAction { get; set; } = "";
        public string NatureOfCA { get; set; } = "";
        public string OwnerOfCA { get; set; } = "";
        public DateTime? TargetDateOfCompletionCA { get; set; }
        public string PreventiveMeasure { get; set; } = "";
        public string NatureOfPM { get; set; } = "";
        public string OwnerOfPM { get; set; } = "";
        public DateTime? TargetDateOfCompletionPM { get; set; }
        public string StatusOfCA { get; set; } = "";
        public string StatusOfPM { get; set; } = "";
        public string Validate { get; set; } = "";
        public string CopyEditingLevel { get; set; } = "";
        public DateTime? CreatedAt { get; set; }
        public DateTime? YearMonth { get; set; }
        public string Component { get; set; } = "";
        public string PageType { get; set; } = "";
        public double FinalErrorPoints { get; set; } = 0;
        public DateTime? DateProcessed { get; set; }
        public DateTime? DateChecked { get; set; }
        public double TotalErrorPoints { get; set; } = 0;
        public double TotalTSPages { get; set; } = 0;
        public double ErrorPerPages { get; set; } = 0;
        public double AccuracyRating { get; set; } = 0;
        public double AccuracyRatingFC { get; set; } = 0;
        public double WeightPercentFC { get; set; } = 0;
        public double WeightedRatingFC { get; set; } = 0;
        public double AccuracyRatingIPF { get; set; } = 0;
        public double WeightPercentIPF { get; set; } = 0;
        public double WeightedRatingIPF { get; set; } = 0;
        public string DCF { get; set; } = "";
        public double OverallAccuracyRating { get; set; } = 0;
    }
}
