using System.Diagnostics.CodeAnalysis;

namespace NTDataHiveGrpcService.BLL.RecordContents
{
    public class FeedbackComparable : IComparable<FeedbackComparable>
    {
        // employee
        public int Id { get; set; }
        public string PublisherIdentity { get; set; }
        public DateTime Created_at { get; set; }
        public int ScoreCard { get; set; }



        // person
        public string WebId { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Position { get; set; }
        public string CompanyId { get; set; }



        // feedback
        public int CreditId { get; set; }
        public int ErrorId { get; set; }
        public string SupplierName { get; set; }
        public string QualityAssurance { get; set; }
        public string PublisherName { get; set; }
        public string JournalId { get; set; }
        public string ArticleId { get; set; }
        public string CopyEditedBy { get; set; }
        public double PageCount { get; set; }
        public double ErrorCount { get; set; }
        public string DescriptionOfError { get; set; }
        public string Matter { get; set; }
        public string ErrorLocation { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorType { get; set; }
        public string ErrorSubtype { get; set; }
        public string ErrorCategory { get; set; }
        public string IntroducedOrMissed { get; set; }
        public string Department { get; set; }
        public string EmployeeName { get; set; }
        public string RootCause { get; set; }
        public string CorrectiveAction { get; set; }
        public string NatureOfCA { get; set; }
        public string OwnerOfCA { get; set; }
        public DateTime TargetDateOfCompletionCA { get; set; }
        public string PreventiveMeasure { get; set; }
        public string NatureOfPM { get; set; }
        public DateTime TargetDateOfCompletionPM { get; set; }
        public string StatusOfCA { get; set; }
        public string StatusOfPM { get; set; }
        public string CopyEditingLevel { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CompareTo([AllowNull] FeedbackComparable other)
        {
            if (other == null)
                return 1;

            return CreatedAt.CompareTo(other.CreatedAt);
        }

        public override bool Equals(object obj)
        {
            var other = obj as FeedbackComparable;

            if (other == null) return false;

            return WebId == other.WebId;
        }
    }
}
