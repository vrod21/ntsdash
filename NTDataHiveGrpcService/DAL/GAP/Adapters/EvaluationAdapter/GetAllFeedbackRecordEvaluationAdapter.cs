using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Mapper;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters.EvaluationAdapter
{
    public class GetAllFeedbackRecordEvaluationAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private readonly DbContextOptions<NTDataHiveContext> _contextOptions;
        private readonly CreateNewEvaluationMapper _mapper;

        public GetAllFeedbackRecordEvaluationAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
            _mapper = new CreateNewEvaluationMapper();
        }

        internal List<FeedbackRecordRequest> GetAllFeedbackRecord()
        {
            List<FeedbackRecordRequest> feedback = new List<FeedbackRecordRequest>();
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var evaluations = (from evaluation in dbContext.Evaluation
                                  join appExt in dbContext.Approval on evaluation.Id equals appExt.ApprovalIdExt
                                  orderby appExt.EvaluationNavigation.CreatedAt descending
                                  select _mapper.CreateNewEvaluationApprovalMapper(evaluation, appExt)).ToList();

                if (evaluations.Count > 0)
                {
                    return evaluations;
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal($"{ex.Message}");
            }

            return feedback;
        }
    }
}
