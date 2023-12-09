using NLog;

namespace NTDataHiveGrpcService.BLL.RecordContents
{
    public class FeedbackFilter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        public string Webid { get; set; }

        private PreEditingRecordRequest _request;

        public PreEditingRecordRequest feedbackRecordRequest
        {
            get { return _request; }
            set
            {
                Webid = _request.WebId;
                _request = value;
            }
        }

        public FeedbackFilter(string webid)
        {
            if (string.IsNullOrEmpty(webid))
                _nlog.Error("Employee record created with an empty webId");

            Webid = webid;
            _request = new PreEditingRecordRequest();
            _request.WebId = webid;
        }

        public FeedbackFilter(PreEditingRecordRequest request)
        {
            _request = request;
            Webid = request.WebId;
        }
    }
}
