﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [AutoValidateAntiforgeryToken]
    [HandleError]
    public abstract class BaseController: Microsoft.AspNetCore.Mvc.Controller
    {
    }
}
