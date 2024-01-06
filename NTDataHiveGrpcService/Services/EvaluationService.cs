using Grpc.Core;
using NLog;
using NLog.Fluent;
using System.Reflection;

namespace NTDataHiveGrpcService.Services
{
    public class EvaluationService : EvaluationBackend.EvaluationBackendBase
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly BLL.RecordInterfaces.IEvaluationRecordRepository _feedbackRecordRepository;
        public EvaluationService(BLL.RecordInterfaces.IEvaluationRecordRepository feedbackRecordRepository)
        {
            _feedbackRecordRepository = feedbackRecordRepository;

            _nlog.Info("{0} started", Assembly.GetExecutingAssembly().GetName().Version);
        }

        #region SaveFeedback
        public override Task<Google.Rpc.Status> SaveFeedback(FeedbackRecordRequest request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.WebId))
                    return Task.FromResult(new Google.Rpc.Status { Code = 3, Message = "WebId is missed" });
                var feedbackRecord = new BLL.RecordContents.EvaluationFilter(request);

                _feedbackRecordRepository.SaveEvaluationFeedbackRecord(feedbackRecord);

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
        public override Task<FeedbackRecordArray> GetAllFeedback(FeedbackEmpty request, ServerCallContext context)
        {
            try
            {
                var record = new FeedbackRecordArray();
                record.Status = new Google.Rpc.Status { Code = 0, Message = "Feedback is queryable" };

                var feedback = _feedbackRecordRepository.GetAllRecord();

                record.Items.Add(feedback);

                return Task.FromResult(record);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return Task.FromResult(new FeedbackRecordArray { Status = new Google.Rpc.Status { Code = 2, Message = ex.Message } });
            }
        }
        #endregion

        #region GetFeedbackRecord
        public override Task<FeedbackRecordRequest> GetFeedbackRecord(FeebackRecordFilter request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.WebId))
                    return Task.FromResult(new FeedbackRecordRequest { Status = new Google.Rpc.Status { Code = 3, Message = "WebId missed" } });

                if (_feedbackRecordRepository.GetRecord(request.WebId, out BLL.RecordContents.EvaluationFilter feedbackFilter))
                {
                    var feedbackList = feedbackFilter.feedbackRecordRequest;
                    feedbackList.Status = new Google.Rpc.Status() { Code = 0, Message = "Feedback Record found" };
                    return Task.FromResult(feedbackList);
                }
                else
                {
                    var feedbackList = new FeedbackRecordRequest();
                    feedbackList.Status = new Google.Rpc.Status { Code = 5, Message = "Feedback Record not found" };
                    return Task.FromResult(feedbackList);
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return Task.FromResult(new FeedbackRecordRequest { Status = new Google.Rpc.Status { Code = 2, Message = ex.Message } });
            }
        }
        #endregion

    }
}