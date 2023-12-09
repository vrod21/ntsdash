using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IPersonRecordRepository
    {
        List<PersonNotExistRequest> GetAllRecord();
        void SavePersonRecord(PersonFilter personRecord);
    }
}