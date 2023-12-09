using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IPersonRecordPersistence
    {
        List<FeedbackComparable> GetAllPerson();
        bool Save(PersonFilter personRecord);
    }
}