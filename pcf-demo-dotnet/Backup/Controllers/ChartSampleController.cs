using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using HighlightsChartSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace HighlightsChartSample.Controllers 
{
    public class ChartSampleController : Controller 
    {
        public ActionResult Index() 
        {
            //create a collection of data
            var transactionCounts = new List<TransactionCount> 
            { 
                new TransactionCount(){  MonthName="January", Count=30},
                new TransactionCount(){  MonthName="February", Count=40},
                new TransactionCount(){  MonthName="March", Count=4},
                new TransactionCount(){  MonthName="April", Count=35}
            };

            //modify data type to make it of array type
            var xDataMonths = transactionCounts.Select(i => i.MonthName).ToArray();
            var yDataCounts = transactionCounts.Select(i => new object[] { i.Count }).ToArray();

            //instanciate an object of the Highcharts type
            var chart = new Highcharts("chart")
                //define the type of chart 
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
                //overall Title of the chart 
                        .SetTitle(new Title { Text = "Incoming Transacions per hour" })
                //small label below the main Title
                        .SetSubtitle(new Subtitle { Text = "Accounting" })
                //load the X values
                        .SetXAxis(new XAxis { Categories = xDataMonths })
                //set the Y title
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Number of Transactions" } })
                        .SetTooltip(new Tooltip {
                            Enabled = true,
                            Formatter = @"function() { return '<b>'+ this.series.name +'</b><br/>'+ this.x +': '+ this.y; }"
                        })
                        .SetPlotOptions(new PlotOptions {
                            Line = new PlotOptionsLine {
                                DataLabels = new PlotOptionsLineDataLabels {
                                    Enabled = true
                                },
                                EnableMouseTracking = false
                            }
                        })
                //load the Y values 
                        .SetSeries(new[]
                    {
                        new Series {Name = "Hour", Data = new Data(yDataCounts)},
                            //you can add more y data to create a second line
                            // new Series { Name = "Other Name", Data = new Data(OtherData) }
                    });


            return View(chart);
        }

        [OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 3)] // every 3 sec
        public ActionResult GetContributor()
        {
            Random rand = new Random();

            //create a collection of data
            var transactionCounts = new List<TransactionCount> 
            { 
                new TransactionCount(){  MonthName="January", Count=rand.Next(101)},
                new TransactionCount(){  MonthName="February", Count=rand.Next(101)},
                new TransactionCount(){  MonthName="March", Count=rand.Next(101)},
                new TransactionCount(){  MonthName="April", Count=rand.Next(101)}
            };

            //modify data type to make it of array type
            var xDataMonths = transactionCounts.Select(i => i.MonthName).ToArray();
            var yDataCounts = transactionCounts.Select(i => new object[] { i.Count }).ToArray();

            //instanciate an object of the Highcharts type
            var chart = new Highcharts("chart")
                //define the type of chart 
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
                //overall Title of the chart 
                        .SetTitle(new Title { Text = "Incoming Transacions per hour" })
                //small label below the main Title
                        .SetSubtitle(new Subtitle { Text = "Accounting" })
                //load the X values
                        .SetXAxis(new XAxis { Categories = xDataMonths })
                //set the Y title
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Number of Transactions" } })
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
                //load the Y values 
                        .SetSeries(new[]
                    {
                        new Series {Name = "Hour", Data = new Data(yDataCounts)},
                            //you can add more y data to create a second line
                            // new Series { Name = "Other Name", Data = new Data(OtherData) }
                    });


            return PartialView("Contributor", chart);
        }

    }
}
