using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IEvaluationRecordRepository
    {
        List<FeedbackRecordRequest> GetAllRecord();
        bool GetRecord(string webId, out EvaluationFilter evaluationFilter);
        bool GetRecordByEmployeeName(string employeeName, out EvaluationFilter evaluationFilter);
        void SaveEvaluationFeedbackRecord(EvaluationFilter evaluationRecord);
    }
}