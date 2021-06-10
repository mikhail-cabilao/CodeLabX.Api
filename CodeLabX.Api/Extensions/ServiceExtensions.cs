using CodeLabX.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLabX.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddScopes(this IServiceCollection services)
        {
            services.AddScoped<NotebookService>();
            services.AddScoped<DictionaryService>();
        }
    }
}
