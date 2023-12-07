using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IRevisionFeedbackRecordRepository
    {
        List<RevisionFeedbackRecordComparable> GeAllRecord();
        bool GetRecord(string WebId, out RevisionFeedbackFilter revisionFilter);
        void SaveRevisionFeedbackRecord(RevisionFeedbackFilter revisionRecord);
    }
}