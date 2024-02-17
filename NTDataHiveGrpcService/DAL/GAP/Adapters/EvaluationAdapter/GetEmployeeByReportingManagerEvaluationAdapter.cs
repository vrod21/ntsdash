using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Mapper;
namespace NTDataHiveGrpcService.DAL.GAP.Adapters.EvaluationAdapter
{
    public class GetEmployeeByReportingManagerEvaluationAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private DbContextOptions<NTDataHiveContext> _contextOptions;
        private TimeZoneInfo _currentTimeZone;
        private CreateNewPersonMapper _mapper;

        public GetEmployeeByReportingManagerEvaluationAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }

        internal List<PersonRequest> GetEmployeeByReportingManager(string feedbackRecord)
        {
            List<PersonRequest> record = new List<PersonRequest>();
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var managerRecord = (from person in dbContext.Person
                                     where person.ReportingManager == feedbackRecord
                                     orderby person.FirstName descending
                                     select _mapper.CreateNewPesonMapper(person)).ToList();

                if (managerRecord.Count > 0)
                {
                    return managerRecord;
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal($"{ex.Message}");
            }
            return record;
        }
    }
}
