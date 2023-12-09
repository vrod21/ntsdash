using Grpc.Core;
using NLog;
using System.Reflection;

namespace NTDataHiveGrpcService.Services
{
    public class FeedbackService : FeedbackBackend.FeedbackBackendBase
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly BLL.RecordInterfaces.IPreEditingFeedbackRecordRepository _feedbackRecordRepository;

        public FeedbackService(BLL.RecordInterfaces.IPreEditingFeedbackRecordRepository feedbackRecordRepository)
        {
            _feedbackRecordRepository = feedbackRecordRepository;

            _nlog.Info("{0} started", Assembly.GetExecutingAssembly().GetName().Version);
        }

        #region SaveFeedback
        public override Task<Google.Rpc.Status> SavePreEditing(PreEditingRecordRequest request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.WebId))
                    return Task.FromResult(new Google.Rpc.Status { Code = 3, Message = "WebId is missed" });

                var feedbackRecord = new BLL.RecordContents.FeedbackFilter(request);

                _feedbackRecordRepository.SavePreEditingFeedbackRecord(feedbackRecord);

                return Task.FromResult(new Google.Rpc.Status { Code = 0 });
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return Task.FromResult(new Google.Rpc.Status { Code = 2, Message = ex.Message });
            }
        }
        #endregion
    }
}
