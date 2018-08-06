﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amendment.Web.Areas.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public abstract class BaseController : Controller
    {
    }
}
