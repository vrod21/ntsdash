namespace NTDataHiveGrpcService.DAL.Model
{
    public partial class PreEditing
    {
        public int Id { get; set; }
        public string WebId { get; set; }
        public string SupplierName { get; set; }
        public string QualityAssurance { get; set; }
        public string PublisherName { get; set; }
        public string JournalId { get; set; }
        public string ArticleId { get; set; }
        public string CopyEditedBy { get; set; }
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
        public string RootCause { get; set; }
        public string CorrectiveAction { get; set; }
        public string NatureOfCA { get; set; }
        public string OwnerOfCA { get; set; }
        public DateTime TargetDateOfCompletionCA { get; set; }
        public string PreventiveMeasure { get; set; }
        public string NatureOfPM { get; set; }
        public string OwnerOfPM { get; set; }
        public DateTime TargetDateOfCompletionPM { get; set; }
        public string StatusOfCA { get; set; }
        public string StatusOfPM { get; set; }
        public string CopyEditingLevel { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
