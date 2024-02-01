namespace NTDataHiveGrpcService.DAL.Model
{
    public class Quality
    {
        public int QualityIdExt { get; set; }
        public string Component { get; set; }
        public string PageType { get; set; }
        public double FinalErrorPoints { get; set; }
        public DateTime DateProcessed { get; set; }
        public DateTime DateChecked { get; set; }
        public double TotalErrorPoints { get; set; }
        public double TotalTSPages { get; set; }
        public double ErrorPerPages { get; set; }
        public double AccuracyRating { get; set; }
        public double AccuracyRatingFC { get; set; }
        public double WeightPercentFC { get; set; }
        public double WeightedRatingFC { get; set; }
        public double AccuracyRatingIPF { get; set; }
        public double WeightPercentIPF { get; set; }
        public double WeightedRatingIPF { get; set; }
        public string DCF { get; set; }
        public double OverallAccuracyRating { get; set; }

        public virtual Evaluation EvaluationNavigation { get; set; }
    }
}
