using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IPersonRecordRepository
    {
        List<FeedbackComparable> GetAllRecord();
        void SavePersonRecord(PersonFilter personRecord);
    }
}