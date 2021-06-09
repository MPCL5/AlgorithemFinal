using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace AlgorithemFinal.Utiles.Extensions
{
    // Special Thanks to ashkanABD.
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ControllerExtension : ControllerBase, IResponseExtension
    {
        protected JsonResult Ok(object data = null, string msg = null)
        {
            return (this as IResponseExtension).Ok(data, msg);
        }

        protected JsonResult OkMsg(string msg = null)
        {
            return (this as IResponseExtension).OkMsg(msg);
        }

        protected JsonResult NotFound(object data = null, string msg = "داده پیدا نشد.")
        {
            return (this as IResponseExtension).NotFound(data, msg);
        }

        protected JsonResult NotFoundMsg(string msg = "داده پیدا نشد.")
        {
            return (this as IResponseExtension).NotFoundMsg(msg);
        }

        protected JsonResult PermissionDenied(object data = null, string msg = null)
        {
            return (this as IResponseExtension).PermissionDenied(data, msg);
        }

        protected JsonResult PermissionDeniedMsg(string msg = null)
        {
            return (this as IResponseExtension).PermissionDeniedMsg(msg);
        }

        protected JsonResult NotAuth(object data = null, string msg = "لطفا وارد سیستم شوید.")
        {
            return (this as IResponseExtension).NotAuth(data, msg);
        }

        protected JsonResult NotAuthMsg(string msg = "لطفا وارد سیستم شوید.")
        {
            return (this as IResponseExtension).NotAuthMsg(msg);
        }

        protected JsonResult BadRequest(object data = null, string msg = null)
        {
            return (this as IResponseExtension).BadRequest(data, msg);
        }

        protected JsonResult BadRequestMsg(string msg = null)
        {
            return (this as IResponseExtension).BadRequestMsg(msg);
        }

        protected JsonResult InternalError(object data = null, string msg = null)
        {
            return (this as IResponseExtension).InternalError(data, msg);
        }

        protected JsonResult InternalErrorMsg(string msg = null)
        {
            return (this as IResponseExtension).InternalErrorMsg(msg);
        }
    }
}
