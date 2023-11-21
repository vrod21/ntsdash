using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IEmployeeRecordRepository
    {
        List<EmployeeRecordComparable> GetAllRecord();
        void SaveRuleRecord(EmployeeFilter empRecord);
    }
}