using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.BLL.RecordContents;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Model;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters
{
    public class RevisionFeedbackRecordAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private DbContextOptions<NTDataHiveContext> _contextOptions;

        public RevisionFeedbackRecordAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }

        #region GetAllPreEditingErrorRecord
        internal List<RevisionFeedbackRecordComparable> GetAllPreEditingFeedbackRecord()
        {
            List<RevisionFeedbackRecordComparable> preEditingRecord = new List<RevisionFeedbackRecordComparable>();

            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var preEdited = from preEdit in dbContext.PreEditingErrorFeedbacks
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
        internal void Insert(RevisionFeedbackRecordRequest recordRequest)
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
                        CopyEditingLevel = recordRequest.CopyEditingLevel,
                        CreatedAt = recordRequest.CreatedAt.ToDateTime().ToLocalTime(),
                    };

                    dbContext.PreEditingErrorFeedbacks.Add(preEdit);
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

        #region GetPreEditingFeedbackByWebId
        internal int GetFeedbackByWebId(string webid)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var getFeedbackById = from preEditingFeedback in dbContext.PreEditingErrorFeedbacks
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
        private static NTDataHiveGrpcService.BLL.RecordContents.RevisionFeedbackRecordComparable CreateNewBLLPreEditing(PreEditing preEditing)
        {
            return new BLL.RecordContents.RevisionFeedbackRecordComparable()
            {
                WebId = preEditing.WebId,
                SupplierName = preEditing.SupplierName,
                QualityAssurance = preEditing.QualityAssurance,
                PublisherName = preEditing.PublisherName,
                JournalId = preEditing.JournalId,
                ArticleId = preEditing.ArticleId,
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
                CopyEditingLevel = preEditing.CopyEditingLevel,
                CreatedAt = preEditing.CreatedAt,
            };
        }
        #endregion
    }
}
