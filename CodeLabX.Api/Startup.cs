using CodeLabX.Api.Extensions;
using CodeLabX.Api.Models;
using CodeLabX.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace CodeLabX.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScopes();

            WrapperInject.ServicesInject(services);
            WrapperInject.DbContextInject(services, Configuration["ConnectionStrings:Database"], b => b.MigrationsAssembly("CodeLabX.Api"));

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            services.AddOData(opt => opt.AddModel("api", GetEdmModel()).Select().Filter().Expand().Count().OrderBy().SkipToken().SetMaxTop(100));
            services.AddSwaggerGen();
            AddFormatters(services);
        }

        IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Notebook>("Notebook");
            odataBuilder.EntitySet<Models.Dictionary>("Dictionary");

            return odataBuilder.GetEdmModel();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "api");
            });

            app.UseSwagger();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddFormatters(IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                var outputFormatters = options.OutputFormatters.OfType<ODataOutputFormatter>()
                        .Where(_ => _.SupportedMediaTypes.Count == 0);

                foreach (var outputFormatter in outputFormatters)
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));

                var inputFormatters = options.OutputFormatters.OfType<ODataInputFormatter>()
                        .Where(_ => _.SupportedMediaTypes.Count == 0);

                foreach (var inputFormatter in inputFormatters)
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
            });
        }
    }
}
