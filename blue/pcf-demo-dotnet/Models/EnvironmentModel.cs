using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pcf_demo.Models
{
    public class EnvironmentModel
    {
        public IEnumerable<KeyValuePair<string, string>> VcapVariables { get; set; }
    }
}