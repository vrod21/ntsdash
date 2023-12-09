namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IDropdownRecordPersistence
    {
        List<BLL.RecordContents.FeedbackComparable> GetAllPublisher();
    }
}