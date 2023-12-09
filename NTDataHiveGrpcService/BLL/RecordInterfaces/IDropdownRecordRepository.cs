namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IDropdownRecordRepository
    {
        List<BLL.RecordContents.FeedbackComparable> GetAllRecord();
    }
}