using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IPreEditingFeedbackRecordRepository
    {
        List<PreEditingFeedbackRecordRequest> GeAllRecord();
        void SavePreEditingFeedbackRecord(FeedbackFilter preEditRecord);
    }
}