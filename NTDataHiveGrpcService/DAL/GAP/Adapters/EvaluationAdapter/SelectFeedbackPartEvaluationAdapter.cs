using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Mapper;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters.EvaluationAdapter
{
    public class SelectFeedbackPartEvaluationAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private readonly DbContextOptions<NTDataHiveContext> _contextOptions;
        private readonly CreateNewEvaluationMapper _mapper;

        public SelectFeedbackPartEvaluationAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }
        internal bool SelectFeedbackPart(FeedbackRecordRequest recordRequest)
        {
			try
			{
                using var dbContext = new NTDataHiveContext(_contextOptions);

                var evals = (from eval in dbContext.Evaluation
                             join appExt in dbContext.Approval on eval.Id equals appExt.ApprovalIdExt
                             where appExt.EvaluationNavigation.WebId == recordRequest.WebId
                             select eval).ToList();

                if (evals.Count == 0)
                {
                    _nlog.Error($"No data found");
                    return false;
                }
                else if (evals.Count == 1)
                {
                    var eval = evals[0];
                    recordRequest.Stage = eval.Stage?.Trim() ?? "";
                    recordRequest.QualityAssurance = eval.QualityAssurance?.Trim() ?? "";
                    recordRequest.PublisherName = eval.PublisherName?.Trim() ?? "";
                    recordRequest.JournalId = eval.JournalId?.Trim() ?? "";
                    recordRequest.ArticleId = eval.ArticleId?.Trim() ?? "";
                    recordRequest.CopyEditedBy = eval.CopyEditedBy?.Trim() ?? "";
                    recordRequest.PageCount = eval.PageCount;
                    recordRequest.ErrorCount = eval.ErrorCount;
                    recordRequest.DescriptionOfError = eval.DescriptionOfError?.Trim() ?? "";
                    recordRequest.Matter = eval.Matter?.Trim() ?? "";
                    recordRequest.ErrorLocation = eval.ErrorLocation?.Trim() ?? "";
                    recordRequest.ErrorCode = eval.ErrorCode?.Trim() ?? "";
                    recordRequest.ErrorType = eval.ErrorType?.Trim() ?? "";
                    recordRequest.ErrorSubtype = eval.ErrorSubtype?.Trim() ?? "";
                    recordRequest.ErrorCategory = eval.ErrorCategory?.Trim() ?? "";
                    recordRequest.IntroducedOrMissed = eval.IntroducedOrMissed?.Trim() ?? "";
                    recordRequest.Department = eval.Department?.Trim() ?? "";
                    recordRequest.EmployeeName = eval.EmployeeName?.Trim() ?? "";
                    recordRequest.CopyEditingLevel = eval.CopyEditingLevel?.Trim() ?? "";
                    recordRequest.CreatedAt = eval.CreatedAt.ToUniversalTime().ToTimestamp();
                    recordRequest.YearMonth = eval.YearMonth.ToUniversalTime().ToTimestamp();

                    var appExt = (from approval in dbContext.Approval
                                  where approval.EvaluationNavigation.WebId == recordRequest.WebId
                                  select approval).Single();

                    recordRequest.RootCause = appExt.RootCause?.Trim() ?? "";
                    recordRequest.CorrectiveAction = appExt.CorrectiveAction?.Trim() ?? "";
                    recordRequest.NatureOfCA = appExt.NatureOfCA?.Trim() ?? "";
                    recordRequest.OwnerOfCA = appExt.OwnerOfCA?.Trim() ?? "";
                    recordRequest.TargetDateOfCompletionCA = appExt.TargetDateOfCompletionCA.ToUniversalTime().ToTimestamp();
                    recordRequest.PreventiveMeasure = appExt.PreventiveMeasure?.Trim() ?? "";
                    recordRequest.NatureOfPM = appExt.NatureOfPM?.Trim() ?? "";
                    recordRequest.OwnerOfPM = appExt.OwnerOfPM?.Trim() ?? "";
                    recordRequest.TargetDateOfCompletionPM = appExt.TargetDateOfCompletionPM.ToUniversalTime().ToTimestamp();
                    recordRequest.StatusOfCA = appExt.StatusOfCA?.Trim() ?? "";
                    recordRequest.StatusOfPM = appExt.StatusOfPM?.Trim() ?? "";
                    recordRequest.Validate = appExt.Validate?.Trim() ?? "";

                    return true;
                }
                else
                {
                    _nlog.Error($"Webid {recordRequest.WebId} duplicate feedback");
                    return false;
                }
			}
			catch (Exception ex)
			{
				_nlog.Fatal($"{ex.Message}");
				return false;
			}
        }
    }
}
