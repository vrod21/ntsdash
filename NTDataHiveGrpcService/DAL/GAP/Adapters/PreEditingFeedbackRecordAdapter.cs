using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.BLL.RecordContents;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Model;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters
{
    public class PreEditingFeedbackRecordAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private DbContextOptions<NTDataHiveContext> _contextOptions;

        public PreEditingFeedbackRecordAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }

        #region GetAllPreEditingErrorRecord
        internal List<FeedbackComparable> GetAllPreEditingFeedbackRecord()
        {
            List<FeedbackComparable> preEditingRecord = new List<FeedbackComparable>();

            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var preEdited = from preEdit in dbContext.PreEditing
                                orderby preEdit.EmployeeName
                                select CreateNewBLLPreEditing(preEdit);

                if (preEdited != null)
                {
                    return preEdited.ToList();
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal($"{ex.Message}");
            }

            return preEditingRecord;
        }
        #endregion
        
        #region InsertPreEditingErrorFeedback
        internal void Insert(PreEditingFeedbackRecordRequest recordRequest)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                if (recordRequest != null)
                {
                    var preEdit = new Model.PreEditing()
                    {
                        WebId = recordRequest.WebId,
                        SupplierName = recordRequest.SupplierName,
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
                        ErrorSubtype = recordRequest.ErrorType,
                        ErrorCategory = recordRequest.ErrorCategory,
                        IntroducedOrMissed = recordRequest.IntroducedOrMissed,
                        Department = recordRequest.Department,
                        EmployeeName = recordRequest.EmployeeName,
                        RootCause = recordRequest.RootCause,
                        CorrectiveAction = recordRequest.CorrectiveAction,
                        NatureOfCA = recordRequest.NatureOfCA,
                        OwnerOfCA = recordRequest.OwnerOfCA,
                        TargetDateOfCompletionCA = recordRequest.TargetDateOfCompletionCA.ToDateTime().ToLocalTime(),
                        PreventiveMeasure = recordRequest.PreventiveMeasure,
                        NatureOfPM = recordRequest.NatureOfPM,
                        TargetDateOfCompletionPM = recordRequest.TargetDateOfCompletionPM.ToDateTime().ToLocalTime(),
                        StatusOfCA = recordRequest.StatusOfCA,
                        StatusOfPM = recordRequest.StatusOfPM,
                        CopyEditingLevel = recordRequest.CopyEditingLevel,
                        CreatedAt = recordRequest.CreatedAt.ToDateTime().ToLocalTime(),
                    };

                    dbContext.PreEditing.Add(preEdit);
                }
                _ = dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }
        #endregion

        #region SelectPreEditFeedbackPart
        //internal bool SelectPreEditFeedbackPart(NTDataHiveGrpcService.PreEditingFeedbackRecordRequest recordRequest)
        //{
        //    try
        //    {
        //        using var dbContext = new NTDataHiveContext(_contextOptions);

        //        var feedbackRecord = (from preEdit in dbContext.PreEditing
        //                       where preEdit.WebId == recordRequest.WebId
        //                       select preEdit).ToList();

        //        if (feedbackRecord.Count == 0)
        //        {
        //            _nlog.Error("No data found");
        //            return false;
        //        }
        //        else if (feedbackRecord.Count == 1)
        //        {
        //            var feedbackList = feedbackRecord[0];
        //            recordRequest.
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _nlog.Fatal(ex); 
        //        return false;
        //    }
        //}
        #endregion




        #region GetPreEditingFeedbackByWebId
        internal int GetFeedbackByWebId(string webid)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var getFeedbackById = from preEditingFeedback in dbContext.PreEditing
                                      where preEditingFeedback.WebId == webid
                                      select preEditingFeedback;

                if (getFeedbackById.Count() > 0)
                    return getFeedbackById.FirstOrDefault().Id;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return 0;
            }
        }
        #endregion

        #region
        private static NTDataHiveGrpcService.BLL.RecordContents.FeedbackComparable CreateNewBLLPreEditing(PreEditing preEditing)
        {
            return new BLL.RecordContents.FeedbackComparable()
            {
                WebId = preEditing.WebId,
                SupplierName = preEditing.SupplierName,
                QualityAssurance = preEditing.QualityAssurance,
                PublisherName = preEditing.PublisherName,
                JournalId = preEditing.JournalId,
                ArticleId = preEditing.ArticleId,
                CopyEditedBy = preEditing.CopyEditedBy,
                PageCount = preEditing.PageCount,
                ErrorCount = preEditing.ErrorCount,
                DescriptionOfError = preEditing.DescriptionOfError,
                Matter = preEditing.Matter,
                ErrorLocation = preEditing.ErrorLocation,
                ErrorCode = preEditing.ErrorCode,
                ErrorType = preEditing.ErrorType,
                ErrorSubtype = preEditing.ErrorType,
                ErrorCategory = preEditing.ErrorCategory,
                IntroducedOrMissed = preEditing.IntroducedOrMissed,
                Department = preEditing.Department,
                EmployeeName = preEditing.EmployeeName,
                RootCause = preEditing.RootCause,
                CorrectiveAction = preEditing.CorrectiveAction,
                NatureOfCA = preEditing.NatureOfCA,
                OwnerOfCA = preEditing.OwnerOfCA,
                TargetDateOfCompletionCA = preEditing.TargetDateOfCompletionCA,
                PreventiveMeasure = preEditing.PreventiveMeasure,
                NatureOfPM = preEditing.NatureOfPM,
                TargetDateOfCompletionPM = preEditing.TargetDateOfCompletionPM,
                StatusOfCA = preEditing.StatusOfCA,
                StatusOfPM = preEditing.StatusOfPM,
                CopyEditingLevel = preEditing.CopyEditingLevel,
                CreatedAt = preEditing.CreatedAt,
            };
        }
        #endregion
    }
}
