using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using NLog;
using System.Reflection;

namespace NTDataHiveGrpcService.Services
{
    public class RevisionFeedbackService : RevisionFeedbackBackend.RevisionFeedbackBackendBase
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly BLL.RecordInterfaces.IRevisionFeedbackRecordRepository _feedbackRecordRepository;

        public RevisionFeedbackService(BLL.RecordInterfaces.IRevisionFeedbackRecordRepository feedbackRecordRepository)
        {
            _feedbackRecordRepository = feedbackRecordRepository;

            _nlog.Info("{0} started", Assembly.GetExecutingAssembly().GetName().Version);
        }

        #region Save
        public override Task<Google.Rpc.Status> SaveRevisionFeedback(RevisionFeedbackRecordRequest request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.WebId))
                    return Task.FromResult(new Google.Rpc.Status { Code = 3, Message = "WebId is missed" });
                var feedbackRecord = new BLL.RecordContents.RevisionFeedbackFilter(request);

                _feedbackRecordRepository.SaveRevisionFeedbackRecord(feedbackRecord);

                return Task.FromResult(new Google.Rpc.Status { Code = 0 });
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return Task.FromResult(new Google.Rpc.Status { Code = 2, Message = ex.Message });
            }
        }
        #endregion

        #region GetAll
        public override Task<RevisionFeedbackRecordArray> GetAll(RevisionFeedbackEmpty request, ServerCallContext context)
        {
            try
            {
                var record = new RevisionFeedbackRecordArray();
                record.Status = new Google.Rpc.Status { Code = 0, Message = "Revision is queryable" };

                var list = _feedbackRecordRepository.GeAllRecord();

                foreach (var item in list)
                {
                    record.Items.Add(new RevisionFeedbackRecordRequest
                    {
                        WebId = item.WebId,
                        SupplierName = item.SupplierName,
                        QualityAssurance = item.QualityAssurance,
                        PublisherName = item.PublisherName,
                        JournalId = item.JournalId,
                        ArticleId = item.ArticleId,
                        PageCount = item.PageCount,
                        ErrorCount = item.ErrorCount,
                        DescriptionOfError = item.DescriptionOfError,
                        Matter = item.Matter,
                        ErrorLocation = item.ErrorLocation,
                        ErrorCode = item.ErrorCode,
                        ErrorType = item.ErrorType,
                        ErrorSubtype = item.ErrorType,
                        ErrorCategory = item.ErrorType,
                        IntroducedOrMissed = item.IntroducedOrMissed,
                        Department = item.Department,
                        EmployeeName = item.EmployeeName,
                        CopyEditingLevel = item.CopyEditingLevel,
                        CreatedAt = item.CreatedAt.ToUniversalTime().ToTimestamp(),
                    });
                }
                return Task.FromResult(record);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return Task.FromResult(new RevisionFeedbackRecordArray { Status = new Google.Rpc.Status { Code = 2, Message = ex.Message } });
            }
        }
        #endregion

        #region GetRevisionRecord
        public override Task<RevisionFeedbackRecordRequest> GetRevisionRecord(RevisionRecordFilter request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.WebId))
                    return Task.FromResult(new RevisionFeedbackRecordRequest { Status = new Google.Rpc.Status { Code = 3, Message = "WebId missed" } });

                if (_feedbackRecordRepository.GetRecord(request.WebId, out BLL.RecordContents.RevisionFeedbackFilter revisionFilter))
                {
                    var revisionList = revisionFilter.feedbackRecordRequest;
                    revisionList.Status = new Google.Rpc.Status() { Code = 0, Message = "Revision Record found" };
                    return Task.FromResult(revisionList);
                }
                else
                {
                    var revisionList = new RevisionFeedbackRecordRequest();
                    revisionList.Status = new Google.Rpc.Status { Code = 5, Message = "Revision Record not found" };
                    return Task.FromResult(revisionList);
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return Task.FromResult(new RevisionFeedbackRecordRequest { Status = new Google.Rpc.Status { Code = 2, Message = ex.Message } });
            }
        }    
        #endregion
    }
}
