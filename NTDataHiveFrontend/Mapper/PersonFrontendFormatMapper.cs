namespace NTDataHiveFrontend.Mapper
{
    public class PersonFrontendFormatMapper
    {
        public Model.Person ToFrontendFormat(NTDataHiveGrpcService.PersonRequest personRecord)
        {
            Model.Person frontendPersonRecord = new Model.Person()
            {
                WebId = personRecord.WebId,
                EmailAddress = personRecord.EmailAddress,
                FirstName = personRecord.FirstName,
                LastName = personRecord.LastName,
                FullName = personRecord.FullName,
                Birthday = personRecord.Birthday.ToDateTime(),
                Position = personRecord.Position,
                CompanyId = personRecord.CompanyId,
                AccountName = personRecord.AccountName,
                ReportingManager = personRecord.ReportingManager,
                Department = personRecord.Department,
                Type = personRecord.Type,
            };

            return frontendPersonRecord;
        }
    }
}
