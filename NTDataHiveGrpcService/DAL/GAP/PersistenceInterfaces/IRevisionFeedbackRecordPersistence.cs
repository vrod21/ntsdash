using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IRevisionFeedbackRecordPersistence
    {
        List<FeedbackComparable> GetAllRevision();
        bool Save(RevisionFeedbackFilter feedbackRecord);
        bool SelectById(string webid, out RevisionFeedbackFilter revisionRecord);
    }
}