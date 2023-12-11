namespace NTDataHiveGrpcService.DAL.Model
{
    public partial class Feedback
    {
        public Feedback()
        {
            InverseMegaFeedbackNavigation = new HashSet<Feedback>();
        }
        public int Id { get; set; }
        public string WebId { get; set; }
        public double? PageCount { get; set; }
        public string RootCause { get; set; }
        public string CorrectiveAction { get; set; }
        public string NatureOfCA { get; set; }
        public string OwnerOfCA { get; set; }
        public DateTime? TargetDateOfCompletionCA { get; set; }
        public string PreventiveMeasure { get; set; }
        public string NatureOfPM { get; set; }
        public string OwnerOfPM { get; set; }
        public DateTime? TargetDateOfCompletionPM { get; set; }
        public string StatusOfCA { get; set; }
        public string StatusOfPM { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? MegaFeedback { get; set; }

        public virtual Feedback MegaFeedbackNavigation { get; set; }
        public virtual Credit Credit { get; set; }
        public virtual Error Error { get; set; }

        public virtual ICollection<Feedback> InverseMegaFeedbackNavigation { get; set; }
    }
}
