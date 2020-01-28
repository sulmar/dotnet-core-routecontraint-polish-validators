using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using validators;

namespace webapi
{
    public class NipRouteConstraint : ValidatorRouteContraint
    {
        public NipRouteConstraint() : base(new NIPValidator())
        {
        }
    }

    public class PeselRouteConstraint : ValidatorRouteContraint
    {
        public PeselRouteConstraint() : base(new PeselValidator())
        {
        }
    }

    public abstract class ValidatorRouteContraint : IRouteConstraint
    {
        private readonly IValidator validator;

        public ValidatorRouteContraint(IValidator validator)
        {
            this.validator = validator;
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out object routeValue))
            {
                string number = routeValue.ToString();

                try
                {
                    return validator.IsValid(number);
                }
                catch(FormatException)
                {
                    return false;
                }
            }

            return false;
            
        }
    }

    public static class ConstraintExtensions
    {
        public static IServiceCollection AddPeselValidator(this IServiceCollection services)
        {
            return services.Configure<RouteOptions>(options => options.ConstraintMap.Add("pesel", typeof(PeselRouteConstraint)));
        }

        public static IServiceCollection AddNipValidator(this IServiceCollection services)
        {
            return services.Configure<RouteOptions>(options => options.ConstraintMap.Add("nip", typeof(NipRouteConstraint)));
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddPeselValidator();
            services.AddNipValidator();

            return services;
        }

    }
}
