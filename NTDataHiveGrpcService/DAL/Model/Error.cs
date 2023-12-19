namespace NTDataHiveGrpcService.DAL.Model
{
    public partial class Error
    {        
        public int ErrorId { get; set; }
        public string WebId { get; set; }
        public double? ErrorCount { get; set; }
        public string DescriptionOfError { get; set; }
        public string Matter { get; set; }
        public string ErrorLocation { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorType { get; set; }
        public string ErrorSubtype { get; set; }
        public string ErrorCategory { get; set; }
        public string IntroducedOrMissed { get; set; }

        //public ICollection<Feedback> FeedbackErrorNavigation { get; set; }

    }
}
