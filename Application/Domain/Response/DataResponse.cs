using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Response
{
  public class DataResponse <T> where T : class
  {
    public bool success { get; set; } = true;
    public T? data { get; set; } = null;
    public string message { get; set; } = string.Empty;
  }
}
