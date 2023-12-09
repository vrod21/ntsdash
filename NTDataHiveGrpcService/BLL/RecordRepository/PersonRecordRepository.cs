using NLog;
using NTDataHiveGrpcService.BLL.RecordInterfaces;
using NTDataHiveGrpcService.DAL.GAP.Persistence;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace NTDataHiveGrpcService.BLL.RecordRepository
{
    public class PersonRecordRepository : IPersonRecordRepository
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IPersonRecordPersistence _recordPersistence;
        private ConcurrentDictionary<string, RecordContents.PersonFilter> _personRecordCache = new ConcurrentDictionary<string, RecordContents.PersonFilter>();

        public PersonRecordRepository(IPersonRecordPersistence recordPersistence)
        {
            _recordPersistence = recordPersistence;
        }

        #region SavePersonRecord
        public void SavePersonRecord(RecordContents.PersonFilter personRecord)
        {
            if (_personRecordCache.ContainsKey(personRecord.Webid))
            {
                _personRecordCache.TryRemove(personRecord.Webid, out RecordContents.PersonFilter personFilter);
                if (!_personRecordCache.TryAdd(personRecord.Webid, personFilter))
                    throw new Exception($"Person Record couldn't add to the person: {personRecord.Webid}");
                _nlog.Trace("Webid {0} Update is Cache", personRecord.Webid);
            }
            else
            {
                if (_personRecordCache.TryAdd(personRecord.Webid, personRecord))
                    _nlog.Trace($"Webid {personRecord.Webid} Added in Cache");
                else
                    _nlog.Warn($"Webid {personRecord.Webid} 2nd try to Add");
            }

            _recordPersistence.Save(personRecord);
            _nlog.Trace($"Webid {personRecord.Webid} Saved in gap");
        }
        #endregion

        #region GetAllRecord
        public List<PersonNotExistRequest> GetAllRecord()
        {
            List<PersonNotExistRequest> personList = _recordPersistence.GetAllPerson();

            _nlog.Trace("Employee are order by name");

            return personList;
        }
        #endregion
    }
}
