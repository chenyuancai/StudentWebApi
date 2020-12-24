using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StudentWebApi.JWT.JwtService;
using StudentWebApi.JWT.JwtService.JwtServiceImpl;
using StudentWebApi.MiddleWare.ExceptionMiddleware;
using StudentWebApi.Service;
using StudentWebApi.Service.ServiceImpl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi
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
            #region ��Ȩ
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = JwtClaimTypes.Name,

                        ValidAudience = this.Configuration["JWT:audience"],
                        ValidIssuer  =this.Configuration["Jwt:issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(this.Configuration["JWT:SecurityKey"]))
                    };
                });
            #endregion
            #region ������Ȩ
            services.AddAuthorization(o =>
            {
                o.AddPolicy("Director", policy => policy.RequireRole(JwtClaimTypes.Role
                    , "Director", "Teacher"));
                o.AddPolicy("Teacher", policy => policy.RequireRole(JwtClaimTypes.Role, "Teacher"));
            });
            #endregion
            //AddTransient��ÿ�����󣬶���ȡһ���µ�ʵ������ʹͬһ�������ȡ���Ҳ���ǲ�ͬ��ʵ��,������޷�����ʱ����ʹ��Transient�����̰߳�ȫ�����ݿ���ʶ������һ������
            //AddScoped��ÿ�����󣬶���ȡһ���µ�ʵ����ͬһ�������ȡ��λ�õ���ͬ��ʵ��,AddScopedΪÿ�����󴴽�һ����ʵ������һ���µ��̣߳��Ͳ��ܹ������߳������
            //AddSingleton��ÿ�ζ���ȡͬһ��ʵ��,AddSingleton��ȫ�ֶ��ǹ���ģ������������
            services.AddSingleton<ILoginService, LoginServiceImpl>();
            services.AddSingleton<IStudentService, StudentServiceImpl>();
            services.AddSingleton <IGetTokenService,GetTokenServiceImpl> ();
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                // Ϊ Swagger JSON and UI����xml�ĵ�ע��·��
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//��ȡӦ�ó�������Ŀ¼�����ԣ����ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
                var xmlPath = Path.Combine(basePath, "StudentWebApi.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            app.UseMyException();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                
            });
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();//�����֤
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
