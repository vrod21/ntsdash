namespace NTDataHiveGrpcService.DAL.Model
{
    public partial class Approval
    {
        public int ApprovalIdExt { get; set; }
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
        public string Validate { get; set; }
        public string State { get; set; }

        public virtual Evaluation EvaluationNavigation { get; set; }
    }
}
