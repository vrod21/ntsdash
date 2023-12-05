namespace NTDataHiveGrpcService.BLL.RecordContents
{
    public class PersonRecordComparable : IComparable<PersonRecordComparable>
    {
        public string WebId { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Position { get; set; }
        public string CompanyId { get; set; }

        public int CompareTo(PersonRecordComparable other)
        {
            if (other == null)
                return 1;

            return FirstName.CompareTo(other.FirstName);
        }

        public override bool Equals(object obj)
        {
            var other = obj as PersonRecordComparable;

            if (other == null) return false;

            return WebId == other.WebId;
        }
    }
}
