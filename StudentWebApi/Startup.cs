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
            #region 鉴权
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
            #region 策略授权
            services.AddAuthorization(o =>
            {
                o.AddPolicy("Director", policy => policy.RequireRole(JwtClaimTypes.Role
                    , "Director", "Teacher"));
                o.AddPolicy("Teacher", policy => policy.RequireRole(JwtClaimTypes.Role, "Teacher"));
            });
            #endregion
            //AddTransient：每次请求，都获取一个新的实例。即使同一个请求获取多次也会是不同的实例,当组件无法共享时，将使用Transient。非线程安全的数据库访问对象就是一个例子
            //AddScoped：每次请求，都获取一个新的实例。同一个请求获取多次会得到相同的实例,AddScoped为每个请求创建一个新实例，开一个新的线程，就不能共享主线程里的了
            //AddSingleton：每次都获取同一个实例,AddSingleton在全局都是共享的，其生命周期最长
            services.AddSingleton<ILoginService, LoginServiceImpl>();
            services.AddSingleton<IStudentService, StudentServiceImpl>();
            services.AddSingleton <IGetTokenService,GetTokenServiceImpl> ();
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
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

            app.UseAuthentication();//身份认证
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
