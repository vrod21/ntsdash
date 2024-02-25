using NLog;
using NTDataHiveGrpcService.DAL.GAP.Adapters;
using NTDataHiveGrpcService.DAL.GAP.Adapters.EvaluationAdapter;
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
            var record = new GetFeedbackByWebIdEvaluationAdapter(_config);
            int feedbackId = record.GetFeedbackByWebId(evaluationRecord.feedbackRecordRequest.WebId);

            if (feedbackId == 0)
            {
                var createRecord = new InsertEvaluationAdapter(_config);
                createRecord.Insert(evaluationRecord.feedbackRecordRequest, out int recordId);
                feedbackId = recordId;
                newFeedback = true;
            }
            if (newFeedback == false && feedbackId >= 1)
            {
                var updateRecord = new UpdateFeedbackEvaluationAdapter(_config);
                updateRecord.UpdateFeedback(evaluationRecord.feedbackRecordRequest);
                return true;
            }
            return true;
        }
        #endregion

        #region GetAll
        public List<NTDataHiveGrpcService.FeedbackRecordRequest> GetFeedbackRecords()
        {
            var selectEvaluation = new GetAllFeedbackRecordEvaluationAdapter(_config).GetAllFeedbackRecord();

            if (selectEvaluation.Count > 0)
            {
                return selectEvaluation;
            }

            _nlog.Error($"The Selected feedback value {selectEvaluation} is null");

            return selectEvaluation;
        }
        #endregion

        #region GetFeedBackByEmployeeName
        public List<FeedbackRecordRequest> GetFeedBackByEmployeeName(BLL.RecordContents.EvaluationFilter evaluationRecord)
        {
            var getRecord = new GetFeedbackByEmployeeNameEvaluationAdapter(_config);
            var selectFeedback = getRecord.GetFeedbackByEmployeeNameRecord(evaluationRecord.feedbackRecordRequest.WebId);

            if (selectFeedback.Count > 0)
            {

                return selectFeedback;
            }

            _nlog.Error($"The selected feedback value {selectFeedback} is null");

            return selectFeedback;
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

            var feedbackAdapter = new SelectFeedbackPartEvaluationAdapter(_config);

            if (!feedbackAdapter.SelectFeedbackPart(feedbackRecord.feedbackRecordRequest))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
