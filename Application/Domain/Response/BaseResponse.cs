﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Response
{
  public abstract class BaseResponse
  {
    public bool success { get; set; } = true;
    public string message { get; set; } = string.Empty;

  }
}
