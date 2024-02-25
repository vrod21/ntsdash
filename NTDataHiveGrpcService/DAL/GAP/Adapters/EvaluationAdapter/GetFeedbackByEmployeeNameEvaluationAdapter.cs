using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Mapper;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters.EvaluationAdapter
{
    public class GetFeedbackByEmployeeNameEvaluationAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private readonly DbContextOptions<NTDataHiveContext> _contextOptions;
        private readonly CreateNewEvaluationMapper _mapper;

        public GetFeedbackByEmployeeNameEvaluationAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
            _mapper = new CreateNewEvaluationMapper();
        }

        internal List<FeedbackRecordRequest> GetFeedbackByEmployeeNameRecord(string feedbackRecord)
        {
            List<FeedbackRecordRequest> feedback = new List<FeedbackRecordRequest>();
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var employeeFeedback = (from evaluation in dbContext.Evaluation
                                        join appExt in dbContext.Approval on evaluation.Id equals appExt.ApprovalIdExt
                                        where appExt.EvaluationNavigation.EmployeeName == feedbackRecord
                                        orderby appExt.EvaluationNavigation.CreatedAt descending
                                        select _mapper.CreateNewEvaluationApprovalMapper(evaluation, appExt)).ToList();

                if (employeeFeedback.Count > 0)
                {
                    return employeeFeedback;
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
