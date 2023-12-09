using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IPreEditingFeedbackRecordRepository
    {
        List<FeedbackComparable> GeAllRecord();
        void SavePreEditingFeedbackRecord(PreEditingFeedbackFilter preEditRecord);
    }
}