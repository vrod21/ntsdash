using System.Diagnostics.CodeAnalysis;

namespace NTDataHiveGrpcService.BLL.RecordContents
{
    public class PreEditingFeedbackRecordComparable : IComparable<PreEditingFeedbackRecordComparable>
    {
        public string WebId { get; set; }
        public string SupplierName { get; set; }
        public string QualityAssurance { get; set; }
        public string PublisherName { get; set; }
        public string JournalId { get; set; }
        public string ArticleId { get; set; }
        public int PageCount { get; set; }
        public int ErrorCount { get; set; }
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
        public string CopyEditingLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CompareTo([AllowNull] PreEditingFeedbackRecordComparable other)
        {
            if (other == null)
                return 1;

            return EmployeeName.CompareTo(other.EmployeeName);
        }

        public override bool Equals(object obj)
        {
            var other = obj as PreEditingFeedbackRecordComparable;

            if (other == null) return false;

            return this.WebId == other.WebId;
        }
    }
}