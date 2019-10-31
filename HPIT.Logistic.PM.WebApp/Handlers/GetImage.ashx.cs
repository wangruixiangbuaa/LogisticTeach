using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPIT.Logistic.PM.WebApp.Handlers
{
    /// <summary>
    /// GetImage 的摘要说明
    /// </summary>
    public class GetImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["path"] != null)
            {
                context.Response.ContentType = "image/jpg";
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.BufferOutput = false;
                context.Response.WriteFile("..\\Upload\\" + context.Request.QueryString["path"]);
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}