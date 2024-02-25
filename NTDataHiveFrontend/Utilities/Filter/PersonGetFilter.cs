namespace NTDataHiveFrontend.Utilities.Filter
{
    public class PersonGetFilter
    {
        public NTDataHiveGrpcService.PersonRecordFilter GetFilterFor(Model.Person person)
        {
            return new NTDataHiveGrpcService.PersonRecordFilter()
            {
                WebId = person.WebId,
                FullName = person.FullName,
                Type = person.Type,
            };
        }

        public NTDataHiveGrpcService.PersonRecordFilter GetFilterFor(string id)
        {
            return new NTDataHiveGrpcService.PersonRecordFilter()
            {
                FullName = id,
                WebId = id.ToString(),
            };
        }

        public NTDataHiveGrpcService.PersonRecordFilter GetFilterFor(Guid id)
        {
            return new NTDataHiveGrpcService.PersonRecordFilter()
            {
                WebId = id.ToString(),
            };
        }
    }
}
