using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IRevisionFeedbackRecordRepository
    {
        List<FeedbackComparable> GeAllRecord();
        bool GetRecord(string WebId, out RevisionFeedbackFilter revisionFilter);
        void SaveRevisionFeedbackRecord(RevisionFeedbackFilter revisionRecord);
    }
}