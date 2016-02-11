using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using pcf_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace pcf_demo.Controllers 
{
    public class HomeController : Controller 
    {
        public void KillApp()
        {
            Environment.Exit(-1);
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Index() 
        {
            ViewBag.AppIndex = Environment.GetEnvironmentVariable("CF_INSTANCE_INDEX");
            ViewBag.AppIp = Environment.GetEnvironmentVariable("CF_INSTANCE_ADDR");
            //ViewBag.AppIndex = Environment.GetEnvironmentVariable("INSTANCE_INDEX");
            //ViewBag.AppIp = Environment.GetEnvironmentVariable("PORT");
            return View(RenderChart());
        }

        [OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 3)] // every 3 sec
        public ActionResult GetChart()
        {
            ViewBag.AppIndex = Environment.GetEnvironmentVariable("CF_INSTANCE_INDEX");
            ViewBag.AppIp = Environment.GetEnvironmentVariable("CF_INSTANCE_ADDR");
            //ViewBag.AppIndex = Environment.GetEnvironmentVariable("INSTANCE_INDEX");
            //ViewBag.AppIp = Environment.GetEnvironmentVariable("PORT");
            return PartialView("Chart", RenderChart());
        }

        private Highcharts RenderChart()
        {
            Random rand = new Random();

            var transactionCounts = new List<VolumeModel> 
            { 
                new VolumeModel(){  Month="January", Volume=rand.Next(1001)},
                new VolumeModel(){  Month="February", Volume=rand.Next(1001)},
                new VolumeModel(){  Month="March", Volume=rand.Next(1001)},
                new VolumeModel(){  Month="April", Volume=rand.Next(1001)},
                new VolumeModel(){  Month="May", Volume=rand.Next(1001)},
                new VolumeModel(){  Month="June", Volume=rand.Next(1001)},
                new VolumeModel(){  Month="July", Volume=rand.Next(1001)},
                new VolumeModel(){  Month="August", Volume=rand.Next(1001)},
                new VolumeModel(){  Month="September", Volume=rand.Next(1001)},
                new VolumeModel(){  Month="October", Volume=rand.Next(1001)},
                new VolumeModel(){  Month="November", Volume=rand.Next(1001)},
                new VolumeModel(){  Month="December", Volume=rand.Next(1001)}
            };

            var xDataMonths = transactionCounts.Select(i => i.Month).ToArray();
            var yDataCounts = transactionCounts.Select(i => new object[] { i.Volume }).ToArray();

            var chart = new Highcharts("chart")

                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })

                        .SetTitle(new Title { Text = "Average Trading Volume per Day" })
             
                        .SetSubtitle(new Subtitle { Text = "Light-Sweet Crude Oil" })
             
                        .SetXAxis(new XAxis { Categories = xDataMonths })

                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Volume x 10,000" } })
                        
                        .SetTooltip(new Tooltip
                        {
                            Enabled = true,
                            Formatter = @"function() { return '<b>'+ this.series.name +'</b><br/>'+ this.x +': '+ this.y; }"
                        })
                       
                        .SetPlotOptions(new PlotOptions
                        {
                            Line = new PlotOptionsLine
                            {
                                DataLabels = new PlotOptionsLineDataLabels
                                {
                                    Enabled = true
                                },
                                EnableMouseTracking = false
                            }
                        })
     
                        .SetSeries(new[]
                        {
                            new Series {Name = "2015", Data = new Data(yDataCounts)}
                        });

            return chart;
        }
    }
}
