using System.Diagnostics.CodeAnalysis;

namespace NTDataHiveGrpcService.BLL.RecordContents
{
    public class EmployeeRecordComparable
    {
        public int Id { get; set; }
        public string WebId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PublisherIdentity { get; set; }
        public DateTime Created_at { get; set; }
        public int ScoreCard { get; set; }
        public int CompareTo([AllowNull] EmployeeRecordComparable other)
        {
            if (other == null)
                return 1;

            return FirstName.CompareTo(other.FirstName);
        }

        public override bool Equals(object obj)
        {
            var other = obj as EmployeeRecordComparable;
            if (other == null)
                return false;

            return this.WebId == other.WebId;
        }
    }
}
