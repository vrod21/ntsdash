using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IPersonRecordPersistence
    {
        List<PersonRequest> GetAllPerson();
        List<PersonRequest> GetPersonByReportingManager(PersonFilter personRecord);
        bool Save(PersonFilter personRecord);
        bool SelectById(string webid, out PersonFilter personRecord);
    }
}