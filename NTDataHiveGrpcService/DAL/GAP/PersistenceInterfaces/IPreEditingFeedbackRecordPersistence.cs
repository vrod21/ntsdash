using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IPreEditingFeedbackRecordPersistence
    {
        bool Save(PreEditingFeedbackFilter feedbackRecord);
    }
}