using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SmartStore.LMS.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SmartStore.LMS.Data.LMSObjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Data\Migrations";
            ContextKey = "SmartStore.LMS"; // DO NOT CHANGE!
        }

        protected override void Seed(SmartStore.LMS.Data.LMSObjectContext context)
        {
        }
    }
}
