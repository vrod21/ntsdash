namespace NTDataHiveFrontend.Model
{
    public class Quality
    {
        public string Component { get; set; } = "";
        public string PageType { get; set; } = "";
        public double FinalErrorPoints { get; set; } = 0;
        public DateTime? DateProcessed { get; set; }
        public DateTime? DateChecked { get; set; }
        public double TotalErrorPoints { get; set; } = 0;
        public double TotalTSPages { get; set; } = 0;
        public double ErrorPerPages { get; set; } = 0;
        public double AccuracyRating { get; set; } = 0;
        public double AccuracyRatingFC { get; set; } = 0;
        public double WeightPercentFC { get; set; } = 0;
        public double WeightedRatingFC { get; set; } = 0;
        public double AccuracyRatingIPF { get; set; } = 0;
        public double WeightPercentIPF { get; set; } = 0;
        public double WeightedRatingIPF { get; set; } = 0;
        public string DCF { get; set; } = "";
        public double OverallAccuracyRating { get; set; } = 0;
    }
}
