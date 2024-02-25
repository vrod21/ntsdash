using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Fluent;
using NTDataHiveGrpcService.DAL.Data;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters.EvaluationAdapter
{
    public class GetFeedbackByWebIdEvaluationAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private readonly DbContextOptions<NTDataHiveContext> _contextOptions;

        public GetFeedbackByWebIdEvaluationAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }
        internal int GetFeedbackByWebId(string webid)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var getFeedbackById = from feedback in dbContext.Approval
                                      where feedback.EvaluationNavigation.WebId == webid
                                      select feedback;

                if (getFeedbackById.Count() > 0)
                    return getFeedbackById.FirstOrDefault().ApprovalIdExt;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return 0;
            }
        }
    }
}
