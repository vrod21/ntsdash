using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IPreEditingFeedbackRecordPersistence
    {
        List<PreEditingFeedbackRecordComparable> GetAllPreEdited();
        bool Save(PreEditingFeedbackFilter feedbackRecord);
    }
}