using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IPreEditingFeedbackRecordRepository
    {
        List<PreEditingFeedbackRecordComparable> GeAllRecord();
        void SavePreEditingFeedbackRecord(PreEditingFeedbackFilter preEditRecord);
    }
}