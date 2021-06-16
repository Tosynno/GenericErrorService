using Application.Helper;
using Application.Interface;
using Application.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Validators;
using Application.Models;

namespace Presentation.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
            services.AddScoped<IMongoClient>(serverpro =>
            {
                var settings = config.GetSection(nameof(MongDbSettings)).Get<MongDbSettings>();
                return new MongoClient(settings.ConnectionString);
            });
            services.AddScoped<IErrorLogRepo, MongoDBContextRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            // DI for FluentValidator
            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ErrorLogRequestValidator>());

            services.AddTransient<IValidator<ErrorLogRequest>, ErrorLogRequestValidator>();

            return services;
        }
    }
}
