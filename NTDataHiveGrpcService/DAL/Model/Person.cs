using System.Text.Json;

namespace NTDataHiveGrpcService.DAL.Model
{
    public partial class Person
    {
        public int Id { get; set; }
        public string WebId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Position { get; set; }
        public string CompanyId { get; set; }
        public string AccountName { get; set; }
        public string ReportingManager { get; set; }
        public string Department { get; set; }
        public string Type { get; set; }
    }
}
