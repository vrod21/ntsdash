using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IRevisionFeedbackRecordPersistence
    {
        List<RevisionFeedbackRecordComparable> GetAllRevision();
        bool Save(RevisionFeedbackFilter feedbackRecord);
    }
}