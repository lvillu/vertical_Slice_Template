using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Response
{
  public class DataResponseList <T>: BaseResponse where T : class
  {
    public List<T>? data { get; set; } = [];
  }
}
