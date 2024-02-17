using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Fluent;
using NTDataHiveGrpcService.DAL.Data;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters.EvaluationAdapter
{
    public class UpdateFeedbackEvaluationAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private readonly DbContextOptions<NTDataHiveContext> _contextOptions;

        public UpdateFeedbackEvaluationAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }

        internal void UpdateFeedback(FeedbackRecordRequest recordRequest)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);

                var evals = from evaluation in dbContext.Evaluation
                            join appEx in dbContext.Approval on evaluation.Id equals appEx.ApprovalIdExt
                            where appEx.EvaluationNavigation.WebId == recordRequest.WebId
                            select evaluation;

                var eval = evals.Single();
                eval.Stage = recordRequest.Stage.Trim();
                eval.QualityAssurance = recordRequest.QualityAssurance.Trim();
                eval.PublisherName = recordRequest.PublisherName.Trim();
                eval.JournalId = recordRequest.JournalId.Trim();
                eval.ArticleId = recordRequest.ArticleId.Trim();
                eval.CopyEditedBy = recordRequest.CopyEditedBy.Trim();
                eval.PageCount = recordRequest.PageCount;
                eval.ErrorCount = recordRequest.ErrorCount;
                eval.DescriptionOfError = recordRequest.DescriptionOfError.Trim();
                eval.Matter = recordRequest.Matter.Trim();
                eval.ErrorLocation = recordRequest.ErrorLocation.Trim();
                eval.ErrorCode = recordRequest.ErrorCode.Trim();
                eval.ErrorType = recordRequest.ErrorType.Trim();
                eval.ErrorSubtype = recordRequest.ErrorSubtype.Trim();
                eval.ErrorCategory = recordRequest.ErrorCategory.Trim();
                eval.IntroducedOrMissed = recordRequest.IntroducedOrMissed.Trim();
                eval.Department = recordRequest.Department.Trim();
                eval.EmployeeName = recordRequest.EmployeeName.Trim();
                eval.CopyEditingLevel = recordRequest.CopyEditingLevel.Trim();

                dbContext.Evaluation.Update(eval);

                var appExts = from approval in dbContext.Approval
                              where approval.EvaluationNavigation.WebId == recordRequest.WebId
                              select approval;

                var appExt = appExts.Single();

                appExt.RootCause = recordRequest.RootCause.Trim();
                appExt.CorrectiveAction = recordRequest.CorrectiveAction.Trim();
                appExt.NatureOfCA = recordRequest.NatureOfCA.Trim();
                appExt.OwnerOfCA = recordRequest.OwnerOfCA.Trim();
                appExt.TargetDateOfCompletionCA = recordRequest.TargetDateOfCompletionCA.ToDateTime();
                appExt.PreventiveMeasure = recordRequest.PreventiveMeasure.Trim();
                appExt.NatureOfPM = recordRequest.NatureOfPM.Trim();
                appExt.OwnerOfPM = recordRequest.OwnerOfPM.Trim();
                appExt.TargetDateOfCompletionPM = recordRequest.TargetDateOfCompletionPM.ToDateTime();
                appExt.StatusOfCA = recordRequest.StatusOfCA.Trim();
                appExt.StatusOfPM = recordRequest.StatusOfPM.Trim();
                appExt.Validate = recordRequest.Validate.Trim();
                appExt.State = recordRequest.State.Trim();

                dbContext.Approval.Update(appExt);

                _ = dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
            }
        }
    }
}
