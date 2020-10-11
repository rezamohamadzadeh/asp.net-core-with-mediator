using FluentValidation;
using MediatorApiExample.Application.Pipelines;
using MediatorApiExample.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;

namespace MediatorApiExample.Application
{
    public class AppConfig
    {
        public string MongoConnection { get; set; }
        public string MongoDatabaseName { get; set; }
    }

    public static class Configure
    {
        public static void AddApplication(this IServiceCollection services, Action<AppConfig> configureApp)
        {
            MongoMapping.RegisterMapping();

            var config = new AppConfig();
            configureApp(config);
            services.AddSingleton(config);

            var assembly = typeof(Configure).Assembly;

            services.AddMediatR(assembly);
            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient<Repository>();
            
            var client = new MongoClient(config.MongoConnection);
            services.AddSingleton(client.GetDatabase(config.MongoDatabaseName));


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));
        }
    }
}