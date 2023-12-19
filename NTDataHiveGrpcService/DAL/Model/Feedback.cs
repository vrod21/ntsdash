﻿namespace NTDataHiveGrpcService.DAL.Model
{
    public class Feedback
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
        public string CopyEditingLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? MegaFeedback { get; set; }

        public virtual Feedback MegaFeedbackNavigation { get; set; }
        public virtual Credit Credit { get; set; }
        public int CreditId { get; set; }
        public virtual Error Error { get; set; }
        public int ErrorId { get; set; }

        public virtual ICollection<Feedback> InverseMegaFeedbackNavigation { get; set; }
    }
}
