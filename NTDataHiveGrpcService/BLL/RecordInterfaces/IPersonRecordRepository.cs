using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IPersonRecordRepository
    {
        void SavePersonRecord(PersonFilter personRecord);
    }
}