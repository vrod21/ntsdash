using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces
{
    public interface IEvaluationRecordPersistence
    {
        List<FeedbackRecordRequest> GetFeedbackRecords();
        bool Save(EvaluationFilter evaluationRecord);
        bool SelectById(string webId, out EvaluationFilter evaluationRecord);
    }
}