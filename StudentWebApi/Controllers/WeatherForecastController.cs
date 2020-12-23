using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StudentWebApi.Entity;
using StudentWebApi.Util.Mysql.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("/api")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [Route("getsource")]
        [HttpGet]
        public string getsource()
        {
            string msg = "Hello";
            int a = 0;
            //try
            //{
                int b = 1 / a;
            //}
            //catch (Exception e)
            //{
            //    msg = "出错了...";
            //    this._logger.LogInformation(e.Message);
            //    throw new Exception(e.Message);
            //}
            return msg;
        }
        [HttpGet]
        [Route("getcon")]
        public object getCon()
        {
            
            return "";
        }
    }
}
