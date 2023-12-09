using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IPreEditingFeedbackRecordPersistence
    {
        List<FeedbackComparable> GetAllPreEdited();
        bool Save(PreEditingFeedbackFilter feedbackRecord);
    }
}