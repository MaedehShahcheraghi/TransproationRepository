using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Constants;
using TransportationSystem.Applciation.Contracts.Persistence.PermissionRepository;
using TransportationSystem.Applciation.Responses.AttribiuteResponse;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TransportationSystem.Applciation.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PermissionCheckerAttribute : ActionFilterAttribute
    {
        private int _permissionId;
        private IPermissionRepository PermissionService;
        public PermissionCheckerAttribute(int permissionId)
        {
            _permissionId = Convert.ToInt16(permissionId);
        }
        public override  void OnActionExecuting(ActionExecutingContext context)
        {
            PermissionService = (IPermissionRepository)context.HttpContext.RequestServices.GetService(typeof(IPermissionRepository));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = context.HttpContext.User.Claims.FirstOrDefault(u => u.Type == CustomClaimTypes.UName).Value.ToString();
                var xxxxxx =  PermissionService.CheckPermissionUser(userName, _permissionId);
                var t = xxxxxx.Result;
                if (!t)
                {
                    var result = new BaseAttribiuteResponse() { StatusCode="403",ErrorMessage="You dont have permission",
                    StatusMessage="Permission Daiend" };

                    context.Result = new JsonResult(result)
                    {
                        StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status200OK
                    };
                    return;

                }
              
            }
            else
            {
                context.Result = new RedirectResult("/Login");
            }
        }
        //public   void OnAuthorization(AuthorizationFilterContext context)
        //{
        //    PermissionService = (IPermissionRepository)context.HttpContext.RequestServices.GetService(typeof(IPermissionRepository));
        //    if (context.HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        string userName = context.HttpContext.User.Claims.FirstOrDefault(u=> u.Type==CustomClaimTypes.UName).Value.ToString();
        //        var pp = Task.Run(() =>
        //        {
        //            PermissionService.CheckPermissionUser(userName, 3);
        //        });
        //        if (! )
        //        {
        //            var result = new { Status = 500, Message = "errorrrr" };

        //                context.Result = new JsonResult(result)
        //                {
        //                    StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status200OK
        //                };

                     
        //        }
        //    }
        //    else
        //    {
        //        context.Result = new RedirectResult("/Login");
        //    }
        //}
    }
}
