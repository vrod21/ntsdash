using NLog;
using NTDataHiveGrpcService.DAL.GAP.Adapters;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;

namespace NTDataHiveGrpcService.DAL.GAP.Persistence
{
    public class EmployeeRecordPersistence : IEmployeeRecordPersistence
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;

        public EmployeeRecordPersistence(IConfiguration config)
        {
            _config = config;
        }

        #region GetAllEmployee
        public List<BLL.RecordContents.EmployeeRecordComparable> GetAllEmployee()
        {
            List<BLL.RecordContents.EmployeeRecordComparable> selectEmployee = new RecordAdapter(_config).GetAllEmployeeRecord();

            if (selectEmployee.Count() >= 1)
            {
                return selectEmployee;
            }
            throw new Exception("There is no value");
        }
        #endregion

        #region Save
        public bool Save(BLL.RecordContents.EmployeeFilter employeeRecord)
        {
            var createRecord = new RecordAdapter(_config);
            int empId = createRecord.GetEmployeeByWebId(employeeRecord.employeeRecordRequest.WebId);

            if (empId == 0)
            {
                createRecord.InsertEmployee(employeeRecord.employeeRecordRequest);
            }
            else
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
