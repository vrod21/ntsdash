using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IPersonRecordRepository
    {
        List<PersonRequest> GetAllRecord();
        bool GetRecord(string WebId, out PersonFilter personFilter);
        void SavePersonRecord(PersonFilter personRecord);
    }
}