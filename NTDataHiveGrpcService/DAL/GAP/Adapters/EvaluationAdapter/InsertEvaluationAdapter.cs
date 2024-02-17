using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Mapper;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters.EvaluationAdapter
{
    public class InsertEvaluationAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private readonly DbContextOptions<NTDataHiveContext> _contextOptions;
        private CreateNewEvaluationMapper _mapper;

        public InsertEvaluationAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }

        internal void Insert(FeedbackRecordRequest recordRequest, out int feedbackId)
        {
            feedbackId = 0;

            try
            {
                if (recordRequest != null)
                {
                    using var dbContext = new NTDataHiveContext(_contextOptions);

                    var feedback = new Model.Evaluation()
                    {
                        WebId = recordRequest.WebId,
                        Stage = recordRequest.Stage,
                        QualityAssurance = recordRequest.QualityAssurance,
                        PublisherName = recordRequest.PublisherName,
                        JournalId = recordRequest.JournalId,
                        ArticleId = recordRequest.ArticleId,
                        CopyEditedBy = recordRequest.CopyEditedBy,
                        PageCount = recordRequest.PageCount,
                        ErrorCount = recordRequest.ErrorCount,
                        DescriptionOfError = recordRequest.DescriptionOfError,
                        Matter = recordRequest.Matter,
                        ErrorLocation = recordRequest.ErrorLocation,
                        ErrorCode = recordRequest.ErrorCode,
                        ErrorType = recordRequest.ErrorType,
                        ErrorSubtype = recordRequest.ErrorSubtype,
                        ErrorCategory = recordRequest.ErrorCategory,
                        IntroducedOrMissed = recordRequest.IntroducedOrMissed,
                        Department = recordRequest.Department,
                        EmployeeName = recordRequest.EmployeeName,
                        CopyEditingLevel = recordRequest.CopyEditingLevel,
                        CreatedAt = recordRequest.CreatedAt.ToDateTime(),
                        MegaEvaluation = feedbackId,
                    };
                    dbContext.Evaluation.Add(feedback);
                    _ = dbContext.SaveChanges();

                    feedbackId = feedback.Id;

                    var approval = new Model.Approval()
                    {
                        ApprovalIdExt = feedbackId,
                        RootCause = recordRequest.RootCause,
                        CorrectiveAction = recordRequest.CorrectiveAction,
                        NatureOfCA = recordRequest.NatureOfCA,
                        OwnerOfCA = recordRequest.OwnerOfCA,
                        PreventiveMeasure = recordRequest.PreventiveMeasure,
                        NatureOfPM = recordRequest.NatureOfPM,
                        OwnerOfPM = recordRequest.OwnerOfPM,
                        StatusOfCA = recordRequest.StatusOfCA,
                        StatusOfPM = recordRequest.StatusOfPM,
                        Validate = recordRequest.Validate,
                        State = recordRequest.State,
                    };
                    dbContext.Approval.Add(approval);
                    _ = dbContext.SaveChanges();

                    feedbackId = feedback.Id;

                    var quality = new Model.Quality()
                    {
                        QualityIdExt = feedbackId,
                        Component = recordRequest.Component,
                        PageType = recordRequest.PageType,
                        FinalErrorPoints = recordRequest.FinalErrorPoints,
                        TotalErrorPoints = recordRequest.TotalErrorPoints,
                        TotalTSPages = recordRequest.TotalTSPages,
                        ErrorPerPages = recordRequest.ErrorPerPages,
                        AccuracyRating = recordRequest.AccuracyRating,
                        AccuracyRatingFC = recordRequest.AccuracyRatingFC,
                        WeightPercentFC = recordRequest.WeightPercentFC,
                        WeightedRatingFC = recordRequest.WeightedRatingFC,
                        AccuracyRatingIPF = recordRequest.AccuracyRatingIPF,
                        WeightPercentIPF = recordRequest.WeightPercentIPF,
                        WeightedRatingIPF = recordRequest.WeightedRatingIPF,
                        DCF = recordRequest.DCF,
                        OverallAccuracyRating = recordRequest.OverallAccuracyRating,
                    };
                    dbContext.Quality.Add(quality);
                    _ = dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }
    }
}
