using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IPersonRecordPersistence
    {
        List<PersonRecordComparable> GetAllPerson();
        bool Save(PersonFilter personRecord);
    }
}