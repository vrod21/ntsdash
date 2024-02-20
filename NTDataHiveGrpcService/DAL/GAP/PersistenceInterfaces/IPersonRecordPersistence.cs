using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IPersonRecordPersistence
    {
        List<PersonRequest> GetAllPerson();
        List<PersonRequest> GetPersonByReportingManager(PersonFilter personRecord);
        List<PersonRequest> GetPersonByType();
        bool Save(PersonFilter personRecord);
        bool SelectById(string webid, out PersonFilter personRecord);
    }
}