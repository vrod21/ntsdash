using Google.Protobuf.WellKnownTypes;

namespace NTDataHiveFrontend.Mapper
{
    public class PersonGrpcFormatMapper
    {
        public NTDataHiveGrpcService.PersonRequest ToGrpcFormat(Model.Person personRecord)
        {
            var grpcPersonRecord = new NTDataHiveGrpcService.PersonRequest()
            {
                WebId = personRecord.WebId,
                EmailAddress = personRecord.EmailAddress,
                FirstName = personRecord.FirstName,
                LastName = personRecord.LastName,
                Position = personRecord.Position,
                CompanyId = personRecord.CompanyId,
                AccountName = personRecord.AccountName,
                ReportingManager = personRecord.ReportingManager,
                Department = personRecord.Department,
                Type = personRecord.Type,
            };

            if (personRecord?.Birthday != null)
                grpcPersonRecord.Birthday = personRecord.Birthday.Value.ToUniversalTime().ToTimestamp();

            return grpcPersonRecord;
        }
    }
}
