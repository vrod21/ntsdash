namespace NTDataHiveFrontend.Utilities.Filter
{
    public class PersonGetFilter
    {
        public NTDataHiveGrpcService.PersonRecordFilter GetFilterFor(string id)
        {
            return new NTDataHiveGrpcService.PersonRecordFilter()
            {
                WebId = id.ToString(),
            };
        }
    }
}
