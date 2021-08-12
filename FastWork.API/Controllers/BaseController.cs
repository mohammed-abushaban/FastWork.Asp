using FastWork.Core.Vm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastWork.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        
        protected APIResponseViewModel GetRespons(object data = null,string message = "Done")
        {
            var result = new APIResponseViewModel();
            result.Status = true;
            result.Message = message;
            result.Data = data;
            return result;
        }

    }
}
