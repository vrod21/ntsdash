using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IEmployeeRecordPersistence
    {
        List<EmployeeRecordRequest> GetAllEmployee();
        bool Save(EmployeeFilter employeeRecord);
    }
}