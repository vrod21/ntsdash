namespace NTDataHiveGrpcService.DAL.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string WebId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PublisherIdentity { get; set; }
        public DateTime Create_at { get; set; }
        public int ScoreCard { get; set; }
    }
}
