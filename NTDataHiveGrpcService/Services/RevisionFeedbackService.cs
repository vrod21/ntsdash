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
    }
}
