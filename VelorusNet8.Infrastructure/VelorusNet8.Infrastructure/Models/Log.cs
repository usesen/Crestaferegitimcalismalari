using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelorusNet8.Infrastructure.Models;

public class Log
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string Request { get; set; }
    public string Response { get; set; }
    public string Status { get; set; }
}