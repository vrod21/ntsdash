namespace NTDataHiveGrpcService.DAL.Model
{
    public partial class Credit
    {            
        public int CreditIdExt { get; set; }
        public string WebId { get; set; }
        public string SupplierName { get; set; }
        public string QualityAssurance { get; set; }
        public string PublisherName { get; set; }
        public string JournalId { get; set; }
        public string ArticleId { get; set; }
        public string CopyEditedBy { get; set; }
        public string Department { get; set; }
        public string EmployeeName { get; set; }
        public string CopyEditingLevel { get; set; }

        public virtual Feedback FeedbackCreditNavigation { get; set; }
    }
}
