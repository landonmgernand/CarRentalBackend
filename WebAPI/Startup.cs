using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

//200 - OK --> Tamam, ba�ar�l�
//201 - CREATED --> Olu�turuldu
//301 - MOVED PERMANENTLY --> Y�nlendirme
//400 - BAD REQUEST --> Sunucu istenilen i�lemi tamamlayamad���nda kar��la��lan hata
//401 - UNAUTHORIZED --> Yetkisiz
//403 - FORBIDDEN --> Yasakland�
//404 - NOT FOUND --> Sayfa bulunamad�
//500 - INTERNAL SERVER ERROR --> Beklenmedik sunucu hatas�
//502 - BAD GATEWAY --> �ki sunucu aras�ndaki beklenmedik hata