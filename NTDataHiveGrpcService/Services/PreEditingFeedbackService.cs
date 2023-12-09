using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using NLog;
using System;
using System.Reflection;

namespace NTDataHiveGrpcService.Services
{
    public class PreEditingFeedbackService : PreEditingFeedbackBackend.PreEditingFeedbackBackendBase
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly BLL.RecordInterfaces.IPreEditingFeedbackRecordRepository _feedbackRecordRepository;

        public PreEditingFeedbackService(BLL.RecordInterfaces.IPreEditingFeedbackRecordRepository feedbackRecordRepository)
        {
            _feedbackRecordRepository = feedbackRecordRepository;

            _nlog.Info("{0} started", Assembly.GetExecutingAssembly().GetName().Version);
        }

        #region GetAll
        public override Task<PreEditingFeedbackRecordArray> GetAll(PreEditingFeedbackEmpty request, ServerCallContext context)
        {
            try
            {
                var record = new PreEditingFeedbackRecordArray();
                record.Status = new Google.Rpc.Status { Code = 0, Message = "Pre-Edited is queryable" };

                var allRecord = _feedbackRecordRepository.GeAllRecord();

                record.Items.Add(allRecord);

                return Task.FromResult(record);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return Task.FromResult(new PreEditingFeedbackRecordArray { Status = new Google.Rpc.Status { Code = 2, Message = ex.Message } });
            }
        }
        #endregion

        //public override Task<Google.Rpc.Status> SavePreEditFeedback(PreEditingRecordRequest request, ServerCallContext context)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(request.WebId))
        //            return Task.FromResult(new Google.Rpc.Status { Code = 3, Message = "WebId is missed" });
        //        var feedbackRecord = new BLL.RecordContents.FeedbackFilter(request);

        //        _feedbackRecordRepository.SavePreEditingFeedbackRecord(feedbackRecord);

        //        return Task.FromResult(new Google.Rpc.Status { Code = 0 });
        //    }
        //    catch (Exception ex)
        //    {
        //        _nlog.Fatal(ex);
        //        return Task.FromResult(new Google.Rpc.Status { Code= 2, Message = ex.Message });
        //    }
        //}
    }
}
