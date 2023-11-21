using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IEmployeeRecordPersistence
    {
        List<EmployeeRecordComparable> GetAllEmployee();
        bool Save(EmployeeFilter employeeRecord);
    }
}