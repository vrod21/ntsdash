namespace NTDataHiveGrpcService.DAL.Model
{
    public partial class Evaluation
    {
        public Evaluation()
        {
            InverseMegaEvaluationNavigation = new HashSet<Evaluation>();
        }
        public int Id { get; set; }
        public string WebId { get; set; }        
        public string Stage { get; set; }
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
        public string CopyEditingLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime YearMonth { get; set; }
        public int? MegaEvaluation { get; set; }

        public virtual Evaluation MegaEvaluationNavigation { get; set; }
        public virtual Approval Approval { get; set; }

        public virtual ICollection<Evaluation> InverseMegaEvaluationNavigation { get; set; }
    }
}
