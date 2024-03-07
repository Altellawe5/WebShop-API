using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopApi.Infrastructure.Config
{
    public class MyConfig : IConfig
    {
        public string ConnectionStringName { get; set; }
        public string ConnectionString { get; set; }
        public bool UseDb { get; set; }
        public bool UseMySQL { get; set; }
    }

}
