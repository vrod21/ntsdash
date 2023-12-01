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

        #region GetAllRevisionErrorRecord
        internal List<RevisionFeedbackRecordComparable> GetAllRevisionFeedbackRecord()
        {
            List<RevisionFeedbackRecordComparable> revisionRecord = new List<RevisionFeedbackRecordComparable>();

            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var revisions = from revision in dbContext.Revisions
                                orderby revision.EmployeeName
                                select CreateNewBLLRevision(revision);

                if (revisions != null)
                {
                    return revisions.ToList();
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal($"{ex.Message}");
            }

            return revisionRecord;
        }
        #endregion

        #region InsertRevisionErrorFeedback
        internal void Insert(RevisionFeedbackRecordRequest recordRequest)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                if (recordRequest != null)
                {
                    var revision = new Model.Revision()
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

                    dbContext.Revisions.Add(revision);
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

        #region GetRevisionFeedbackByWebId
        internal int GetFeedbackByWebId(string webid)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var getFeedbackById = from revisionFeedback in dbContext.Revisions
                                      where revisionFeedback.WebId == webid
                                      select revisionFeedback;

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

        #region CreateNewBLLRevision
        private static NTDataHiveGrpcService.BLL.RecordContents.RevisionFeedbackRecordComparable CreateNewBLLRevision(Revision revision)
        {
            return new BLL.RecordContents.RevisionFeedbackRecordComparable()
            {
                WebId = revision.WebId,
                SupplierName = revision.SupplierName,
                QualityAssurance = revision.QualityAssurance,
                PublisherName = revision.PublisherName,
                JournalId = revision.JournalId,
                ArticleId = revision.ArticleId,
                PageCount = revision.PageCount,
                ErrorCount = revision.ErrorCount,
                DescriptionOfError = revision.DescriptionOfError,
                Matter = revision.Matter,
                ErrorLocation = revision.ErrorLocation,
                ErrorCode = revision.ErrorCode,
                ErrorType = revision.ErrorType,
                ErrorSubtype = revision.ErrorType,
                ErrorCategory = revision.ErrorCategory,
                IntroducedOrMissed = revision.IntroducedOrMissed,
                Department = revision.Department,
                EmployeeName = revision.EmployeeName,
                CopyEditingLevel = revision.CopyEditingLevel,
                CreatedAt = revision.CreatedAt,
            };
        }
        #endregion
    }
}
