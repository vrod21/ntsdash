using NLog;

namespace NTDataHiveGrpcService.BLL.RecordContents
{
    public class PersonFilter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();

        public string Webid { get; set; }

        private PersonNotExistRequest _request;

        public PersonNotExistRequest personNotExistRequest
        {
            get { return _request; }
            set 
            {
                Webid = _request.WebId;
                _request = value; 
            }
        }

        public PersonFilter(string webid)
        {
            if (string.IsNullOrEmpty(webid))
                _nlog.Error("Person record created with an empty webId");

            Webid = webid;
            _request = new PersonNotExistRequest();
            _request.WebId = webid;
        }

        public PersonFilter(PersonNotExistRequest request)
        {
            _request = request;
            Webid = request.WebId;            
        }
    }
}
