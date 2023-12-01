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

                var list = _feedbackRecordRepository.GeAllRecord();

                foreach (var item in list)
                {
                    record.Items.Add(new PreEditingFeedbackRecordRequest
                    {
                        WebId = item.WebId,
                        SupplierName = item.SupplierName,
                        QualityAssurance = item.QualityAssurance,
                        PublisherName = item.PublisherName,
                        JournalId = item.JournalId,
                        ArticleId = item.ArticleId,
                        CopyEditedBy = item.CopyEditedBy,
                        PageCount = item.PageCount,
                        ErrorCount = item.ErrorCount,
                        DescriptionOfError = item.DescriptionOfError,
                        Matter = item.Matter,
                        ErrorLocation = item.ErrorLocation,
                        ErrorCode = item.ErrorCode,
                        ErrorType = item.ErrorType,
                        ErrorSubtype = item.ErrorSubtype,
                        ErrorCategory = item.ErrorCategory,
                        IntroducedOrMissed = item.IntroducedOrMissed,
                        Department = item.Department,
                        EmployeeName = item.EmployeeName,
                        RootCause = item.RootCause,
                        CorrectiveAction = item.CorrectiveAction,
                        NatureOfCA = item.NatureOfCA,
                        OwnerOfCA = item.OwnerOfCA,
                        TargetDateOfCompletionCA = item.TargetDateOfCompletionCA.ToUniversalTime().ToTimestamp(),
                        PreventiveMeasure = item.PreventiveMeasure,
                        NatureOfPM = item.NatureOfPM,
                        TargetDateOfCompletionPM = item.TargetDateOfCompletionPM.ToUniversalTime().ToTimestamp(),
                        StatusOfCA = item.StatusOfCA,
                        StatusOfPM = item.StatusOfPM,
                        CopyEditingLevel = item.CopyEditingLevel,
                        CreatedAt = item.CreatedAt.ToUniversalTime().ToTimestamp(),
                    });
                }
                return Task.FromResult(record);
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return Task.FromResult(new PreEditingFeedbackRecordArray { Status = new Google.Rpc.Status { Code = 2, Message = ex.Message } });
            }
        }
        #endregion

        public override Task<Google.Rpc.Status> SavePreEditFeedback(PreEditingFeedbackRecordRequest request, ServerCallContext context)
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
                return Task.FromResult(new Google.Rpc.Status { Code= 2, Message = ex.Message });
            }
        }
    }
}
