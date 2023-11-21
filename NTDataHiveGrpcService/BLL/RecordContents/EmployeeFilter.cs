using NLog;
using NTDataHiveGrpcService;

namespace NTDataHiveGrpcService.BLL.RecordContents
{
    public class EmployeeFilter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        public string Webid { get; set; }

        private EmployeeRecordRequest _request;

        public EmployeeRecordRequest employeeRecordRequest
        {
            get { return _request; }
            set
            {
                Webid = _request.WebId;
                _request = value;
            }
        }

        public EmployeeFilter(string webid)
        {
            if (string.IsNullOrEmpty(webid))
                _nlog.Error("Employee record created with an empty webId");

            Webid = webid;
            _request = new EmployeeRecordRequest();
            _request.WebId = webid;
        }

        public EmployeeFilter(EmployeeRecordRequest request)
        {
            _request = request;
            Webid = request.WebId;
        }
    }
}
