using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using SmartStore.Core.Data;
using SmartStore.Core.Infrastructure;
using SmartStore.Core.Infrastructure.DependencyManagement;
using SmartStore.Data;
using SmartStore.LMS.Data;
using SmartStore.LMS.Domain;
using SmartStore.LMS.Filters;
using SmartStore.LMS.Services;
using SmartStore.Web.Controllers;

namespace SmartStore.LMS
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
            builder.RegisterType<LMSService>().As<ILMSService>().InstancePerRequest();

            //register named context
            builder.Register<IDbContext>(c => new LMSObjectContext(DataSettings.Current.DataConnectionString))
                .Named<IDbContext>(LMSObjectContext.ALIASKEY)
                .InstancePerRequest();

            builder.Register(c => new LMSObjectContext(DataSettings.Current.DataConnectionString))
                .InstancePerRequest();

            //override required repository with our custom context
            builder.RegisterType<EfRepository<LMSRecord>>()
                .As<IRepository<LMSRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(LMSObjectContext.ALIASKEY))
                .InstancePerRequest();

            builder.RegisterType<SampleActionFilter>()
                .AsActionFilterFor<ProductController>(x => x.ProductDetails(default(int), default(string), null))
                .InstancePerRequest();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
