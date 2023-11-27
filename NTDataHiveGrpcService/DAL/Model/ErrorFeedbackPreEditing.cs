namespace NTDataHiveGrpcService.DAL.Model
{
    public class ErrorFeedbackPreEditing
    {
        public int MyProperty { get; set; }
        public string WebId { get; set; }
        public string SupplierName { get; set; }
        public string QA { get; set; }
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
        public string Employee { get; set; }
        public string CopyEditingLevel { get; set; }
    }
}
