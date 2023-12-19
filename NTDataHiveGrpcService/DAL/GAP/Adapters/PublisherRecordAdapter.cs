using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Model;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters
{
    public class FeedbackRecordAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private DbContextOptions<NTDataHiveContext> _contextOptions;

        public FeedbackRecordAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }

        #region GetFeedback
        internal List<BLL.RecordContents.FeedbackComparable> GetAllDropdownRecord()
        {
            var FeedbackRecord = new List<BLL.RecordContents.FeedbackComparable>();
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);


                var Feedback = from Evaluations in dbContext.Evaluation
                                orderby Evaluations.Approval.TargetDateOfCompletionCA >= DateTime.Now descending
                                select CreateNewBllDropdown(Evaluations);

            }
            catch (Exception ex)
            {
                _nlog.Fatal($"{ex.Message}");
            }

            return FeedbackRecord;
        }
        #endregion

        #region CreateNewBLLDropdown
        private static BLL.RecordContents.FeedbackComparable CreateNewBllDropdown(Evaluation evaluation)
        {
            return new BLL.RecordContents.FeedbackComparable()
            {

                SupplierName = evaluation.SupplierName,
                QualityAssurance = evaluation.QualityAssurance,
                PublisherName = evaluation.PublisherName,
                JournalId = evaluation.SupplierName,
                CopyEditedBy = evaluation.CopyEditedBy,
                Matter = evaluation.Matter,
                ErrorLocation = evaluation.ErrorLocation,
                ErrorCode = evaluation.ErrorCode,
                ErrorType = evaluation.ErrorType,
                ErrorSubtype = evaluation.ErrorSubtype,
                ErrorCategory = evaluation.ErrorCategory,
                IntroducedOrMissed = evaluation.IntroducedOrMissed,
                Department = evaluation.Department,
                NatureOfCA = evaluation.Approval.NatureOfCA,
                NatureOfPM = evaluation.Approval.NatureOfPM,
                StatusOfCA = evaluation.Approval.StatusOfCA,
                StatusOfPM = evaluation.Approval.StatusOfPM

            };
        }
        #endregion

    }
}
