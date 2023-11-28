using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IPreEditingFeedbackRecordRepository
    {
        void SavePreEditingFeedbackRecord(PreEditingFeedbackFilter preEditRecord);
    }
}