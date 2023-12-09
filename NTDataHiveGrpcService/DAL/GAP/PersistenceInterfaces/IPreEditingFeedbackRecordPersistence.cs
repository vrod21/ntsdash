namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IPreEditingFeedbackRecordPersistence
    {
        List<PreEditingFeedbackRecordRequest> GetAllPreEdited();
        bool Save(BLL.RecordContents.FeedbackFilter feedbackRecord);
    }
}