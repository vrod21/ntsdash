using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.DAL.Data;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters
{
    public class PublisherRecordAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private DbContextOptions<NTDataHiveContext> _contextOptions;

        public PublisherRecordAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }

        #region GetPublisher
        internal NTDataHiveGrpcService.PublisherRecordRequest GetAllPublisherRecord()
        {
            var publisherRecord = new NTDataHiveGrpcService.PublisherRecordRequest();
            var publisherModel = new Model.Publisher();
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);

                var pub = from publisher in dbContext.Publishers orderby publisher.PublisherName
                          select publisher;

                if (pub != null)
                {
                    
                    var pubList = new NTDataHiveGrpcService.PublisherRecordRequest()
                    {
                        PublisherName = publisherModel.PublisherName,
                    };

                    return pubList;
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal($"{ex.Message}");
            }

            return publisherRecord;
        }
        #endregion
    }
}
