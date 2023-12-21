using NLog;
using NTDataHiveGrpcService.DAL.GAP.Adapters;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;

namespace NTDataHiveGrpcService.DAL.GAP.Persistence
{
    public class EvaluationRecordPersistence : IEvaluationRecordPersistence
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;

        public EvaluationRecordPersistence(IConfiguration config)
        {
            _config = config;
        }

        #region Save
        public bool Save(BLL.RecordContents.EvaluationFilter evaluationRecord)
        {
            bool newFeedback = false;
            var createRecord = new EvaluationRecordAdapter(_config);
            int feedbackId = createRecord.GetFeedbackByWebId(evaluationRecord.feedbackRecordRequest.WebId);

            if (feedbackId == 0)
            {
                createRecord.Insert(evaluationRecord.feedbackRecordRequest, out int recordId);
                feedbackId = recordId;
                newFeedback = true;
            }
            if (newFeedback == false && feedbackId >= 1)
            {
                createRecord.UpdateFeedback(evaluationRecord.feedbackRecordRequest);
                return true;
            }
            return true;
        }
        #endregion

        #region GetAll
        public List<NTDataHiveGrpcService.FeedbackRecordRequest> GetFeedbackRecords()
        {
            var selectEvaluation = new EvaluationRecordAdapter(_config).GetAllFeedbackRecord();

            if (selectEvaluation.Count > 0)
            {
                return selectEvaluation;
            }

            _nlog.Error($"The Selected feedback value {selectEvaluation} is null");

            return selectEvaluation;
        }
        #endregion

        #region SelectById
        public bool SelectById(string webId, out BLL.RecordContents.EvaluationFilter evaluationRecord)
        {
            if (CreateFeedbackRecordByWebId(webId, out BLL.RecordContents.EvaluationFilter feedbackRecordLocal))
            {
                evaluationRecord = feedbackRecordLocal;
                return true;
            }
            else
            {
                evaluationRecord = new BLL.RecordContents.EvaluationFilter(webId);
                return false;
            }
        }
        #endregion

        #region CreateFeedbackRecordByWebId
        private bool CreateFeedbackRecordByWebId(string webId, out BLL.RecordContents.EvaluationFilter feedbackRecord)
        {
            feedbackRecord = new BLL.RecordContents.EvaluationFilter(webId);

            var feedbackAdapter = new EvaluationRecordAdapter(_config);

            if (!feedbackAdapter.SelectFeedbackPart(feedbackRecord.feedbackRecordRequest))
                return false;

            return true;
        }
        #endregion
    }
}
