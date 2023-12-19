using NLog;

namespace NTDataHiveGrpcService.BLL.RecordContents
{
    public class EvaluationFilter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        public string Webid { get; set; }

        private FeedbackRecordRequest _request;

        public FeedbackRecordRequest feedbackRecordRequest
        {
            get { return _request; }
            set
            {
                Webid = _request.WebId;
                _request = value;
            }
        }

        public EvaluationFilter(string webid)
        {
            if (string.IsNullOrEmpty(webid))
                _nlog.Error("Employee record created with an empty webId");

            Webid = webid;
            _request = new FeedbackRecordRequest();
            _request.WebId = webid;
        }

        public EvaluationFilter(FeedbackRecordRequest request)
        {
            _request = request;
            Webid = request.WebId;
        }
    }
}
