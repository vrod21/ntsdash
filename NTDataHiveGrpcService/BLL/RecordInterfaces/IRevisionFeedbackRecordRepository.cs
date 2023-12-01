using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IRevisionFeedbackRecordRepository
    {
        List<RevisionFeedbackRecordComparable> GeAllRecord();
        void SaveRevisionFeedbackRecord(RevisionFeedbackFilter revisionRecord);
    }
}