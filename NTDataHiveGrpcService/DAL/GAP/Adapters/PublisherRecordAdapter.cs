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

                var Feedback = from Feedbacks in dbContext.Feedback
                                orderby Feedbacks.Credit.JournalId
                                select CreateNewBllDropdown(Feedbacks);
            }
            catch (Exception ex)
            {
                _nlog.Fatal($"{ex.Message}");
            }

            return FeedbackRecord;
        }
        #endregion

        #region CreateNewBLLDropdown
        private static BLL.RecordContents.FeedbackComparable CreateNewBllDropdown(Feedback feedback)
        {
            return new BLL.RecordContents.FeedbackComparable()
            {
                SupplierName = feedback.Credit.SupplierName,
                QualityAssurance = feedback.Credit.QualityAssurance,
                PublisherName = feedback.Credit.PublisherName,
                JournalId = feedback.Credit.SupplierName,
                CopyEditedBy = feedback.Credit.CopyEditedBy,
                Matter = feedback.Error.Matter,
                ErrorLocation = feedback.Error.ErrorLocation,
                ErrorCode = feedback.Error.ErrorCode,
                ErrorType = feedback.Error.ErrorType,
                ErrorSubtype = feedback.Error.ErrorSubtype,
                ErrorCategory = feedback.Error.ErrorCategory,
                IntroducedOrMissed = feedback.Error.IntroducedOrMissed,
                Department = feedback.Credit.Department,
                NatureOfCA = feedback.NatureOfCA,
                NatureOfPM = feedback.NatureOfPM,
                StatusOfCA = feedback.StatusOfCA,
                StatusOfPM = feedback.StatusOfPM,
            };
        }
        #endregion

    }
}
