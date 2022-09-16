using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Features.Auth.Rules;
using Application.Features.Languages.Rules;
using Application.Features.LanguageTechnologies.Rules;
using Application.Services.Auth;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using Core.Security.JWT;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<LanguageBusinessRules>();
            services.AddScoped<LanguageTechnologyBusinessRules>();
            services.AddScoped<AuthBusinessRules>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped<IAuthService, AuthManager>();
            services.AddTransient<ITokenHelper, JwtHelper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;

        }
    }
}
