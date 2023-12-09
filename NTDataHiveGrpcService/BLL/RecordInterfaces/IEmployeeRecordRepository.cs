using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IEmployeeRecordRepository
    {
        List<EmployeeRecordRequest> GetAllRecord();
        void SaveEmployeeRecord(EmployeeFilter empRecord);
    }
}