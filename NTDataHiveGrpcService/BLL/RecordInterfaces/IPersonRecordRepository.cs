﻿using NTDataHiveGrpcService.BLL.RecordContents;

namespace NTDataHiveGrpcService.BLL.RecordInterfaces
{
    public interface IPersonRecordRepository
    {
        List<PersonRequest> GetAllRecord();
        bool GetRecord(string WebId, out PersonFilter personFilter);
        List<PersonRequest> GetRecordByReportingManager(PersonFilter personFilter);
        List<PersonRequest> GetRecordByType();
        void SavePersonRecord(PersonFilter personRecord);
    }
}