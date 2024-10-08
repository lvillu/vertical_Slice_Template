﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Response
{
  public class DataResponse<T> : BaseResponse where T : class
  {
    public T? data { get; set; } = null;
  }
}
