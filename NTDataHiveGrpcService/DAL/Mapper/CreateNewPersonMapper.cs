using Google.Protobuf.WellKnownTypes;
using NTDataHiveGrpcService.DAL.Model;

namespace NTDataHiveGrpcService.DAL.Mapper
{
    internal class CreateNewPersonMapper
    {
        public PersonRequest CreateNewPesonMapper(Person person)
        {
            return new PersonRequest
            {
                WebId = person.WebId,
                EmailAddress = person.EmailAddress,
                FirstName = person.FirstName,
                LastName = person.LastName,
                FullName = person.FullName,
                Position = person.Position,
                CompanyId = person.CompanyId,
                AccountName = person.AccountName,
                ReportingManager = person.ReportingManager,
                Department = person.Department,
                Type = person.Type,
                Birthday = person.Birthday.ToUniversalTime().ToTimestamp(),
            };
        }
    }
}
