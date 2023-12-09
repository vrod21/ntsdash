using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.BLL.RecordContents;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Model;


namespace NTDataHiveGrpcService.DAL.GAP.Adapters
{
    public class RecordAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private DbContextOptions<NTDataHiveContext> _contextOptions;

        public RecordAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }

        #region GetAllEmployeeRecord
        internal List<EmployeeRecordRequest> GetAllEmployeeRecord()
        {
            List<EmployeeRecordRequest> employeeRecord = new List<EmployeeRecordRequest>();
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var emp = from employee in dbContext.Employees
                          orderby employee.Create_at
                          select CreateBNewBllEmployee(employee);

                if (emp != null)
                {
                    return emp.ToList();
                }

            }
            catch (Exception ex)
            {
                _nlog.Fatal($"{ex.Message}");
            }

            return employeeRecord;
        }
        #endregion

        #region InsertEmployee
        internal void InsertEmployee(EmployeeRecordRequest recordRequest)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                if (recordRequest != null)
                {
                    var emp = new Model.Employee()
                    {
                        WebId = recordRequest.WebId,
                        FirstName = recordRequest.FirstName,
                        LastName = recordRequest.LastName,
                        PublisherIdentity = recordRequest.PublisherIdentity,                        
                    };

                    dbContext.Employees.Add(emp);
                }
                _ = dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }
        #endregion

        #region GetEmployeeByWebId
        internal int GetEmployeeByWebId(string webid)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var getEmployeeById = from employee in dbContext.Employees
                                      where employee.WebId == webid
                                      select employee;

                if (getEmployeeById.Count() > 0)
                    return getEmployeeById.FirstOrDefault().Id;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return 0;
            }
        }
        #endregion

        #region CreateNewBllEmployee
        private static EmployeeRecordRequest CreateBNewBllEmployee(Employee employee)
        {
            return new EmployeeRecordRequest()
            {
                Id = employee.Id,
                WebId = employee.WebId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PublisherIdentity = employee.PublisherIdentity,
                CreatedAt = employee.Create_at.ToUniversalTime().ToTimestamp(),
                ScoreCard = employee.ScoreCard,
            };
        }
        #endregion
    }
}
