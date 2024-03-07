using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopApi.Infrastructure.Config
{
    public interface IConfig
    {
        string ConnectionStringName { get; set; }
        string ConnectionString { get; set; }
        bool UseMySQL { get; set; }
        bool UseDb { get; set; }
    }
}
