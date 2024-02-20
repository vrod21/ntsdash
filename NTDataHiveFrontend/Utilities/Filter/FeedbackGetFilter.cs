namespace NTDataHiveFrontend.Utilities.Filter
{
    public class FeedbackGetFilter
    {
        public NTDataHiveGrpcService.FeedbackRecordFilter GetFilterFor(Model.Feedback feedback)
        {
            return new NTDataHiveGrpcService.FeedbackRecordFilter()
            {
                WebId = feedback.WebId.ToString(),
                PublisherName = feedback.PublisherName,
                EmployeeName = feedback.EmployeeName,
            };
        }

        public NTDataHiveGrpcService.FeedbackRecordFilter GetFilterFor(string name)
        {
            return new NTDataHiveGrpcService.FeedbackRecordFilter()
            {
                EmployeeName = name,
            };
        }

        public NTDataHiveGrpcService.FeedbackRecordFilter GetFilterFor(Guid id)
        {
            return new NTDataHiveGrpcService.FeedbackRecordFilter()
            {
                WebId = id.ToString(),
            };
        }

    }
}
