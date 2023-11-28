using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.DAL.Data;

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

        #region InsertPreEditingErrorFeedback
        internal void Insert(PreEditingFeedbackRecordRequest recordRequest)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                if (recordRequest != null)
                {
                    var emp = new Model.PreEditingErrorFeedback()
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

                    dbContext.PreEditingErrorFeedbacks.Add(emp);
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
    }
}
