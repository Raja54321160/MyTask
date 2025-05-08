using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Raja_File.Models;

namespace Raja_File.Controllers
{
    public class FileController : Controller
    {
        // GET: File

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile(HttpPostedFileBase file)
        {
            if(file != null && file.ContentLength > 0)
            {
                using (var client = new HttpClient())
                using (var content = new MultipartFormDataContent())
                {
                    var streamContent = new StreamContent(file.InputStream);
                    content.Add(streamContent, "file", file.FileName);

                    var response =await client.PostAsync("https://localhost:44311/api/file/upload", content);

                    if(response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var records = JsonConvert.DeserializeObject<List<DataRecord>>(json);

                        TempData["Records"] = records;
                        TempData.Keep("Records");
                        return RedirectToAction("ViewData");
                    }
                }
            }

            return RedirectToAction("UploadFile");
        }
        public ActionResult ViewData()
        {
            var data = TempData["Records"] as List<DataRecord> ?? new List<DataRecord>();
            return View(data);
        }
    }
}