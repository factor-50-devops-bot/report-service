﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingService.Core.Domains.Entities
{
    public class FunctionARequest : IRequest<FunctionAResponse>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}
