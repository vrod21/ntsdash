using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.DAL.Data;
using System.Net.Quic;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters
{
    public class QualityRecordAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private DbContextOptions<NTDataHiveContext> _contextOptions;

        public QualityRecordAdapter(IConfiguration config)
        {
            _config = config;

            var optionsBuilder =  new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionsString"));
            _contextOptions = optionsBuilder.Options;
        }

        //internal void Update(QualityFeedbackRecordRequest recordRequest)
        //{
        //    try
        //    {
        //        using var dbContext = new NTDataHiveContext(_contextOptions);

        //        //var evals = from evaluation in dbContext.Evaluation
        //        //                    join qualityExt in dbContext.Quality on evaluation.EmployeeName 

        //        //var quality = new Model.Quality()
        //        //{
        //        //    WebId = recordRequest.WebId,
        //        //    EmployeeName = recordRequest.EmployeeName,
        //        //    Component = recordRequest.Component,
        //        //    PageType = recordRequest.PageType,
        //        //    FinalErrorPoints = recordRequest.FinalErrorPoints,
        //        //    DateProcessed = recordRequest.DateProcessed.ToDateTime(),
        //        //    TotalErrorPoints = recordRequest.TotalErrorPoints,
        //        //    TotalTSPages = recordRequest.TotalTSPages,
        //        //    ErrorPerPages = recordRequest.ErrorPerPages,
        //        //    AccuracyRating = recordRequest.AccuracyRating,
        //        //    AccuracyRatingFC = recordRequest.AccuracyRatingFC,
        //        //    WeightPercentFC = recordRequest.WeightPercentFC,
        //        //    WeightedRatingFC = recordRequest.WeightedRatingFC,
        //        //    AccuracyRatingIPF = recordRequest.AccuracyRatingIPF,
        //        //    WeightPercentIPF = recordRequest.WeightPercentIPF,
        //        //    WeightedRatingIPF = recordRequest.WeightedRatingIPF,
        //        //    DCF = recordRequest.DCF,
        //        //    OverallAccuracyRating = recordRequest.OverallAccuracyRating,
        //        //};
        //        //dbContext.Quality.Add(quality);
        //        //_ = dbContext.SaveChanges();

        //        //quality
        //    }
        //    catch (Exception ex )
        //    {
        //        _nlog.Fatal(ex);
        //        throw;
        //    }
        //}
    }
}
