using SmartStore.Core;
using SmartStore.Data;
using SmartStore.Data.Setup;
using SmartStore.LMS.Data.Migrations;
using SmartStore.LMS.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace SmartStore.LMS.Data
{
    /// <summary>
    /// Object context
    /// </summary>
    public class LMSObjectContext : ObjectContextBase
    {
        public const string ALIASKEY = "sm_object_context_LMS";

        static LMSObjectContext()
        {
            var initializer = new MigrateDatabaseInitializer<LMSObjectContext, Configuration>
            {
                TablesToCheck = new[] { "LMS" }
            };
            Database.SetInitializer(initializer);
        }

        /// <summary>
        /// For tooling support, e.g. EF Migrations
        /// </summary>
        public LMSObjectContext()
            : base()
        {
        }

        public LMSObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString, ALIASKEY)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LMSRecord>();

            //disable EdmMetadata generation
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}