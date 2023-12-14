using Google.Protobuf.WellKnownTypes;
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
        private TimeZoneInfo _currentTimeZone;

        public PreEditingFeedbackRecordAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }

        private void LoadConfiguration()
        {
            var tz = _config.GetValue<string>("UTC");
            _currentTimeZone = TimeZoneInfo.FindSystemTimeZoneById(tz);
        }

        #region GetAllPreEditingErrorRecord
        internal List<PreEditingFeedbackRecordRequest> GetAllPreEditingFeedbackRecord()
        {
            List<PreEditingFeedbackRecordRequest> preEditingRecord = new List<PreEditingFeedbackRecordRequest>();

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
        internal void Insert(PreEditingRecordRequest recordRequest, out int feedbackId)
        {
            feedbackId = 0;
            var feedbackChecked = new Model.Feedback();
            try
            {                
                if (recordRequest != null)
                {
                    using var dbContext = new NTDataHiveContext(_contextOptions);

                    var feedback = new Model.Feedback()
                    {
                        WebId = recordRequest.WebId.Trim(),
                        PageCount = recordRequest.PageCount,
                        RootCause = recordRequest.RootCause,
                        CorrectiveAction = recordRequest.CorrectiveAction,
                        NatureOfCA = recordRequest.NatureOfCA,
                        OwnerOfCA = recordRequest.OwnerOfCA,                        
                        PreventiveMeasure = recordRequest.PreventiveMeasure,
                        NatureOfPM = recordRequest.NatureOfPM,
                        OwnerOfPM = recordRequest.OwnerOfPM,
                        StatusOfCA = recordRequest.StatusOfCA,
                        StatusOfPM = recordRequest.StatusOfPM,
                        CreatedAt = recordRequest.CreatedAt.ToDateTime(),                                                  
                    };
                    dbContext.Feedback.Add(feedback); 
                    _ = dbContext.SaveChanges();

                    feedbackId = feedback.Id;

                    var errors = new Model.Error()
                    {
                        ErrorIdExt = feedbackId,
                        WebId = recordRequest.WebId.Trim(),
                        ErrorCount = recordRequest.ErrorCount,
                        DescriptionOfError = recordRequest.DescriptionOfError.Trim(),
                        Matter = recordRequest.Matter.Trim(),
                        ErrorLocation = recordRequest.ErrorLocation.Trim(),
                        ErrorCode = recordRequest.ErrorCode.Trim(),
                        ErrorType = recordRequest.ErrorType.Trim(),
                        ErrorSubtype = recordRequest.ErrorSubtype.Trim(),
                        ErrorCategory = recordRequest.ErrorCategory.Trim(),
                        IntroducedOrMissed = recordRequest.IntroducedOrMissed.Trim(),
                    };
                    dbContext.Error.Add(errors);
                    _ = dbContext.SaveChanges();

                    feedbackId = errors.ErrorIdExt;

                    var preEditCredits = new Model.Credit()
                    {
                        CreditIdExt = feedbackId,
                        SupplierName = recordRequest.SupplierName.Trim(),
                        QualityAssurance = recordRequest.QualityAssurance.Trim(),
                        PublisherName = recordRequest.PublisherName.Trim(),
                        JournalId = recordRequest.JournalId.Trim(),
                        ArticleId = recordRequest.ArticleId.Trim(),
                        CopyEditedBy = recordRequest.CopyEditedBy.Trim(),
                        Department = recordRequest.Department.Trim(),
                        EmployeeName = recordRequest.EmployeeName.Trim(),
                        CopyEditingLevel = recordRequest.CopyEditingLevel.Trim(),
                    };
                    dbContext.Credit.Add(preEditCredits); 
                    _ = dbContext.SaveChanges();
                }                
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }
        #endregion

        #region UpdatePreEditingFeedBack

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
        internal int GetFeedbackIdByWebId(string webid)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var getFeedbackById = from preEditingFeedback in dbContext.Feedback
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

        #region CreateNewBLLPreEditing
        private static PreEditingFeedbackRecordRequest CreateNewBLLPreEditing(PreEditing preEditing)
        {
            return new PreEditingFeedbackRecordRequest()
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
                TargetDateOfCompletionCA = preEditing.TargetDateOfCompletionCA.ToUniversalTime().ToTimestamp(),
                PreventiveMeasure = preEditing.PreventiveMeasure,
                NatureOfPM = preEditing.NatureOfPM,
                TargetDateOfCompletionPM = preEditing.TargetDateOfCompletionPM.ToUniversalTime().ToTimestamp(),
                StatusOfCA = preEditing.StatusOfCA,
                StatusOfPM = preEditing.StatusOfPM,
                CopyEditingLevel = preEditing.CopyEditingLevel,
                CreatedAt = preEditing.CreatedAt.ToUniversalTime().ToTimestamp(),
            };
        }
        #endregion

        #region GetTargetTimeFromUTC
        private DateTime? GetTargetTimeFromUtc(PreEditingRecordRequest preEditingRecord)
        {
            DateTime? targetDate = null;

            if (preEditingRecord != null)
                targetDate = TimeZoneInfo.ConvertTimeFromUtc(preEditingRecord.TargetDateOfCompletionCA.ToDateTime(), _currentTimeZone);                
            
            if (preEditingRecord != null)
                targetDate = TimeZoneInfo.ConvertTimeFromUtc(preEditingRecord.TargetDateOfCompletionCA.ToDateTime(), _currentTimeZone);

            return targetDate;
        }
        #endregion
    }
}
