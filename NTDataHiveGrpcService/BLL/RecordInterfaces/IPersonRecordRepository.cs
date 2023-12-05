using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IPersonRecordRepository
    {
        List<PersonRecordComparable> GetAllRecord();
        void SavePersonRecord(PersonFilter personRecord);
    }
}