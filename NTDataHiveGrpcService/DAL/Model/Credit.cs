namespace NTDataHiveGrpcService.DAL.Model
{
    public class Credit
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string QualityAssurance { get; set; }
        public string PublisherName { get; set; }
        public string JournalId { get; set; }
        public string ArticleId { get; set; }
        public string CopyEditedBy { get; set; }
        public string Department { get; set; }
        public string EmployeeName { get; set; }
        public string CopyEditingLevel { get; set; }

        public Feedback Feedbacks { get; set; }
    }
}
