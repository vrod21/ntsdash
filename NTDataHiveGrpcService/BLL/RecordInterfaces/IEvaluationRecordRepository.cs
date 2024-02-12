using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IEvaluationRecordRepository
    {
        List<FeedbackRecordRequest> GetAllRecord();
        bool GetRecord(string webId, out EvaluationFilter evaluationFilter);
        List<FeedbackRecordRequest> GetRecordByEmployeeName(EvaluationFilter evaluationFilter);
        void SaveEvaluationFeedbackRecord(EvaluationFilter evaluationRecord);
    }
}