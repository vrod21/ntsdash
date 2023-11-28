using Grpc.Core;
using NLog;
using NTDataHiveGrpcService.BLL.RecordInterfaces;

namespace NTDataHiveGrpcService.Services
{
    public class PreEditingFeedbackService : PreEditingFeedbackBackend.PreEditingFeedbackBackendBase
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IPreEditingFeedbackRecordRepository _feedbackRecordRepository;

        public PreEditingFeedbackService(BLL.RecordInterfaces.IPreEditingFeedbackRecordRepository feedbackRecordRepository)
        {
            _feedbackRecordRepository = feedbackRecordRepository;
        }

        public override Task<Google.Rpc.Status> SaveEmployee(PreEditingFeedbackRecordRequest request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.WebId))
                    return Task.FromResult(new Google.Rpc.Status { Code = 3, Message = "WebId is missed" });

                var feedbackRecord = new BLL.RecordContents.PreEditingFeedbackFilter(request);

                _feedbackRecordRepository.SavePreEditingFeedbackRecord(feedbackRecord);

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
