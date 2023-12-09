using NLog;
using NTDataHiveGrpcService.BLL.RecordInterfaces;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;
using System.Collections.Concurrent;

namespace NTDataHiveGrpcService.BLL.RecordRepository
{
    public class EmployeeRecordRepository : IEmployeeRecordRepository
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IEmployeeRecordPersistence _employeeRecordPersistence;
        private ConcurrentDictionary<string, RecordContents.EmployeeFilter> _employeeRecordCache = new ConcurrentDictionary<string, RecordContents.EmployeeFilter>();

        public EmployeeRecordRepository(IEmployeeRecordPersistence employeeRecordPersistence)
        {
            _employeeRecordPersistence = employeeRecordPersistence;
        }

        #region GetAllRecord
        public List<EmployeeRecordRequest> GetAllRecord()
        {
            List<EmployeeRecordRequest> employeeList = _employeeRecordPersistence.GetAllEmployee();

            _nlog.Trace("Employee are order by name");

            return employeeList;
        }
        #endregion

        #region SaveRuleRecord
        public void SaveEmployeeRecord(RecordContents.EmployeeFilter empRecord)
        {
            if (_employeeRecordCache.ContainsKey(empRecord.Webid))
            {
                _employeeRecordCache.TryRemove(empRecord.Webid, out RecordContents.EmployeeFilter empFilter);
                if (!_employeeRecordCache.TryAdd(empRecord.Webid, empFilter))
                    throw new Exception($"Employee Record couldn't add to the employee: {empRecord.Webid}");
                _nlog.Trace("Webid {0} Update is Cache", empRecord.Webid);
            }
            else
            {
                if (_employeeRecordCache.TryAdd(empRecord.Webid, empRecord))
                    _nlog.Trace($"Webid {empRecord.Webid} Added in Cache");
                else
                    _nlog.Warn($"Webid {empRecord.Webid} 2nd try to Add");
            }
            _employeeRecordPersistence.Save(empRecord);
            _nlog.Trace($"Webid {empRecord.Webid} Saved in gap");
        }
        #endregion
    }
}
