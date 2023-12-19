using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IPersonRecordPersistence
    {
        List<PersonRequest> GetAllPerson();
        bool Save(PersonFilter personRecord);
        bool SelectById(string webid, out PersonFilter personRecord);
    }
}