using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class IssueController : Controller
    {
        // GET: Issue
        public ActionResult Index(int id = 1)
        {
            try
            {
                string filename = id + ".pdf";
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Content/Issues/" + filename;
                byte[] filedata = System.IO.File.ReadAllBytes(filepath);
                string contentType = MimeMapping.GetMimeMapping(filepath);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = filename,
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(filedata, contentType);
            }
            catch
            {
                return View();
            }
            
        }
    }
}