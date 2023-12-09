namespace NTDataHiveGrpcService.DAL.Model
{
    public class Feedback
    {
        public int Id { get; set; }
        public string WebId { get; set; }
        public double PageCount { get; set; }
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
        public DateTime CreatedAt { get; set; }

        public virtual Credit Credits { get; set; }
        public virtual Error Errors { get; set; }

    }
}
