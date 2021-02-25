﻿using Autofac;
using SmartStore.Core.Data;
using SmartStore.Core.Domain.Common;
using SmartStore.Core.Events;
using SmartStore.LMS.Domain;
using SmartStore.Services.Catalog;
using System;
using System.Linq;

namespace SmartStore.LMS.Services
{
    public partial class LMSService : ILMSService
    {
        private readonly IRepository<LMSRecord> _repository;
        private readonly IDbContext _dbContext;
        private readonly AdminAreaSettings _adminAreaSettings;
        private readonly IEventPublisher _eventPublisher;

        public LMSService(
            IRepository<LMSRecord> repository,
            IDbContext dbContext,
            AdminAreaSettings adminAreaSettings,
            IEventPublisher eventPublisher,
            IComponentContext ctx)
        {
            _repository = repository;
            _dbContext = dbContext;
            _adminAreaSettings = adminAreaSettings;
            _eventPublisher = eventPublisher;
        }

        public LMSRecord GetLMSRecord(int entityId, string entityName)
        {
            if (entityId == 0)
                return null;

            var record = new LMSRecord();

            var query =
                from x in _repository.Table
                    //where x.EntityId == entityId && x.EntityName == entityName
                select x;

            record = query.FirstOrDefault();

            return record;
        }

        public LMSRecord GetLMSRecordById(int id)
        {
            if (id == 0)
                return null;

            var record = new LMSRecord();

            var query =
                from x in _repository.Table
                where x.Id == id
                select x;

            record = query.FirstOrDefault();

            return record;
        }

        public void InsertLMSRecord(LMSRecord record)
        {
            Guard.NotNull(record, nameof(record));

            var utcNow = DateTime.UtcNow;
            record.CreatedOnUtc = utcNow;

            _repository.Insert(record);
        }

        public void UpdateLMSRecord(LMSRecord record)
        {
            Guard.NotNull(record, nameof(record));

            var utcNow = DateTime.UtcNow;
            record.UpdatedOnUtc = utcNow;

            _repository.Update(record);
        }

        public void DeleteLMSRecord(LMSRecord record)
        {
            Guard.NotNull(record, nameof(record));

            _repository.Delete(record);
        }
    }
}
