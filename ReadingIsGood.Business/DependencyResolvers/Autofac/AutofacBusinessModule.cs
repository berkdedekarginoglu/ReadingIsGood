using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Business.Adapters.ISBNService;
using ReadingIsGood.Business.Concrete;
using ReadingIsGood.Core.Utilities.Interceptors;
using ReadingIsGood.Core.Utilities.Security.Jwt;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.DataAccess.Concrete.EntityFramework;

namespace ReadingIsGood.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfUserDal>().As<IUserDal>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();

            builder.RegisterType<EfAuthorDal>().As<IAuthorDal>().InstancePerLifetimeScope();
            builder.RegisterType<AuthorManager>().As<IAuthorService>().InstancePerLifetimeScope();

            builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerLifetimeScope();
           
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerLifetimeScope();

            builder.RegisterType<EfBookDal>().As<IBookDal>().InstancePerLifetimeScope();
            builder.RegisterType<BookManager>().As<IBookService>().InstancePerLifetimeScope();

            builder.RegisterType<AddressManager>().As<IAddressService>().InstancePerLifetimeScope();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>().InstancePerLifetimeScope();

            builder.RegisterType<BookCategoryManager>().As<IBookCategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<EfBookCategoryDal>().As<IBookCategoryDal>().InstancePerLifetimeScope();

            builder.RegisterType<DataFlexServiceManager>().As<IISBNService>().InstancePerLifetimeScope();

            builder.RegisterType<BookImageManager>().As<IBookImageService>().InstancePerLifetimeScope();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerLifetimeScope();

            builder.RegisterType<UserAddressManager>().As<IUserAddressService>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserAddressDal>().As<IUserAddressDal>().InstancePerLifetimeScope();

            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>().InstancePerLifetimeScope();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>().InstancePerLifetimeScope();

            builder.RegisterType<OrderManager>().As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().InstancePerLifetimeScope();

            builder.RegisterType<OrderStatusManager>().As<IOrderStatusService>().InstancePerLifetimeScope();
            builder.RegisterType<EfOrderStatusDal>().As<IOrderStatusDal>().InstancePerLifetimeScope();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().InstancePerLifetimeScope();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().InstancePerLifetimeScope();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().InstancePerLifetimeScope();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                           .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                           {
                               Selector = new AspectInterceptorSelector()
                           }).SingleInstance().InstancePerDependency();
        }
    }
}
