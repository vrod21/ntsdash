namespace NTDataHiveGrpcService.DAL.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string WebId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string SecretKey { get; set; }
        public string CompanyId { get; set; }
    }
}
