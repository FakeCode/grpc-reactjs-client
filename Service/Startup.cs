using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Service
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            //Forwarded Headers Middleware KnownProxies
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                //options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
                options.KnownProxies.Add(IPAddress.Any);
            });
            */
            
            services.AddGrpc();
            services.AddGrpcReflection();

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
            }));
            services.AddStackExchangeRedisCache(options => { options.Configuration = "127.0.0.1:6379"; });
            //services.AddStackExchangeRedisCache(options => { options.Configuration = "10.90.150.109:6379"; });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            /*
            //for reverse proxy server nginx, since its reverse forwarded
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            */
            
            app.UseRouting();
            app.UseGrpcWeb();
            ////below line will enable all service as web grpc
            ////app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
            app.UseCors("AllowAll");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();
                endpoints.MapGrpcService<StudentService>().EnableGrpcWeb();
                //if (env.IsDevelopment())
                {
                    endpoints.MapGrpcReflectionService();
                }
                ////below line cause an issue :(
                // endpoints.MapGrpcService<StudentService>().RequireCors("AllowAll").EnableGrpcWeb();//as of now we are allowing all but need to restrict origin
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
