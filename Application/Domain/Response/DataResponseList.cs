using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Response
{
  public class DataResponseList <T> where T : class
  {
    public bool success { get; set; } = true;
    public List<T>? data { get; set; } = [];
    public string message { get; set; } = string.Empty;
  }
}
