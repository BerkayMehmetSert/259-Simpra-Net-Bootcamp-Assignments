using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimApi.Data.Context;
using SimApi.Data.Repository;
using SimApi.Data.Uow;
using SimApi.Operation;
using SimApi.Schema;
using SimApi.Service.CustomService;

namespace SimApi.Service;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
        builder.RegisterType<ProductRepository>().As<IProductRepository>();
        builder.RegisterType<UserRepository>().As<IUserRepository>();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        
        builder.RegisterType<UserLogService>().As<IUserLogService>();
        builder.RegisterType<TokenService>().As<ITokenService>();
        builder.RegisterType<UserService>().As<IUserService>();
        builder.RegisterType<CustomerService>().As<ICustomerService>();
        builder.RegisterType<AccountService>().As<IAccountService>();
        builder.RegisterType<TransactionService>().As<ITransactionService>();
        builder.RegisterType<EfTransactionReportService>().As<ITransactionReportService>();
        
        builder.RegisterType<DapperAccountService>().As<IDapperAccountService>();
        builder.RegisterType<DapperCategoryService>().As<IDapperCategoryService>();
        
        builder.RegisterType<ScopedService>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<TransientService>().AsSelf().InstancePerDependency();
        builder.RegisterType<SingletonService>().AsSelf().SingleInstance();
        
        builder.RegisterType<SimDapperDbContext>().InstancePerLifetimeScope();
        builder.Register(context =>
        {
            var config = context.Resolve<IConfiguration>();
            var dbType = config.GetConnectionString("DbType");

            switch (dbType)
            {
                case "SQL":
                {
                    var dbConfig = config.GetConnectionString("MsSqlConnection");
                    return new SimEfDbContext(new DbContextOptionsBuilder<SimEfDbContext>()
                        .UseSqlServer(dbConfig)
                        .Options);
                }
                case "PostgreSql":
                {
                    var dbConfig = config.GetConnectionString("PostgreSqlConnection");
                    return new SimEfDbContext(new DbContextOptionsBuilder<SimEfDbContext>()
                        .UseNpgsql(dbConfig)
                        .Options);
                }
                default:
                    throw new Exception("DbType is not defined");
            }
        }).As<SimEfDbContext>().InstancePerLifetimeScope();
        
        builder.RegisterInstance(new MapperConfiguration(mc => mc.AddProfile(new MapperProfile())).CreateMapper())
            .SingleInstance();
    }
}