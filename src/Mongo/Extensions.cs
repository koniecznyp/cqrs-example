using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Mongo
{
    public static class Extensions
    {
        public static void AddMongoDb(this ContainerBuilder builder)
        {
            builder.Register(context => {
                var configuration = context.Resolve<IConfiguration>();
                var mongoSettings = new MongoSettings();
                configuration.GetSection("mongo").Bind(mongoSettings);
                return mongoSettings;
            }).SingleInstance();

            builder.Register((c, p) =>
			{
				var settings = c.Resolve<MongoSettings>();
				return new MongoClient(settings.ConnectionString);
			}).SingleInstance();
            
            builder.Register((c, p) =>
			{
				var mongoClient = c.Resolve<MongoClient>();
				var settings = c.Resolve<MongoSettings>();
				var database = mongoClient.GetDatabase(settings.Database);
				return database;
			}).As<IMongoDatabase>();

            builder.RegisterType<MongoConfigurator>()
                .As<IMongoConfigurator>();
        }
    }
} 