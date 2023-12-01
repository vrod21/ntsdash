using NLog;

namespace NTDataHiveGrpcService.BLL.RecordContents
{
    public class RevisionFeedbackFilter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        public string Webid { get; set; }

        private RevisionFeedbackRecordRequest _request;

        public RevisionFeedbackRecordRequest feedbackRecordRequest
        {
            get { return _request; }
            set
            {
                Webid = _request.WebId;
                _request = value;
            }
        }

        public RevisionFeedbackFilter(string webid)
        {
            if (string.IsNullOrEmpty(webid))
                _nlog.Error("Employee record created with an empty webId");

            Webid = webid;
            _request = new RevisionFeedbackRecordRequest();
            _request.WebId = webid;
        }

        public RevisionFeedbackFilter(RevisionFeedbackRecordRequest request)
        {
            _request = request;
            Webid = request.WebId;
        }
    }
}
}
