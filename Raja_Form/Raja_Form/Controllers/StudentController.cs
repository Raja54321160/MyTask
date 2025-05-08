using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Raja_Form.Models;

namespace Raja_Form.Controllers
{
    public class StudentController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly string baseUrl = "http://localhost:5142/api/Student/";

        public StudentController(HttpClient httpClient, IWebHostEnvironment _hostEnvironment)
        {
            this.httpClient = httpClient;
            this._hostEnvironment = _hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Form(Student dts)
        {
            try
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;

                if (dts.Image != null)
                {
                    string imageFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads/images");

                    if (!Directory.Exists(imageFolder))
                    {
                        Directory.CreateDirectory(imageFolder);
                    }

                    string imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(dts.Image.FileName);
                    string imagePath = Path.Combine(imageFolder, imageFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await dts.Image.CopyToAsync(stream);
                    }

                    dts.ImagePath = "/uploads/images/" + imageFileName;
                }

                if (dts.Video != null)
                {
                    string videoFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads/videos");

                    if (!Directory.Exists(videoFolder))
                    {
                        Directory.CreateDirectory(videoFolder);
                    }

                    string videoFileName = Guid.NewGuid().ToString() + Path.GetExtension(dts.Video.FileName);
                    string videoPath = Path.Combine(videoFolder, videoFileName);

                    using (var stream = new FileStream(videoPath, FileMode.Create))
                    {
                        await dts.Video.CopyToAsync(stream);
                    }

                    dts.VideoPath = "/uploads/videos/" + videoFileName;
                }

                if (dts.Audio != null)
                {
                    string audioFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads/audios");
                    if (!Directory.Exists(audioFolder))
                    {
                        Directory.CreateDirectory(audioFolder);
                    }
                    string audioFileName = Guid.NewGuid().ToString() + Path.GetExtension(dts.Video.FileName);
                    string audioPath = Path.Combine(wwwRootPath + "/uploads/audios/", audioFileName);
                    using (var stream = new FileStream(audioPath, FileMode.Create))
                    {
                        await dts.Audio.CopyToAsync(stream);
                    }
                    dts.AudioPath = "/uploads/audios/" + audioFileName;
                }

                dts.Image = null;
                dts.Video = null;
                dts.Audio = null;

                var json = JsonConvert.SerializeObject(dts);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync($"{baseUrl}Create", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details");
                }

                return View(dts);

            }
            catch (Exception ex)
            {
                return View(dts);
            }

        }

        [HttpGet]
        public IActionResult Details()
        {
            var response = httpClient.GetAsync(baseUrl + "List").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(json);
                return View(data);
            }
            return RedirectToAction("Form");
        }
        public IActionResult DeletePage(int id)
        {
            var response = httpClient.GetAsync($"{baseUrl}GetById?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(json);
                return View(data);
            }
            return RedirectToAction("Details");
        }
        public IActionResult Delete(int id)
        {
            var response = httpClient.DeleteAsync($"{baseUrl}Delete?id={id}");

            return RedirectToAction("Details");
        }

        public IActionResult Update(int id)
        {
            var response = httpClient.GetAsync($"{baseUrl}GetById?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(json);
                return View(data);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student dts)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (dts.Image != null)
            {
                string imageFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads/images");

                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }

                string imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(dts.Image.FileName);
                string imagePath = Path.Combine(imageFolder, imageFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await dts.Image.CopyToAsync(stream);
                }

                dts.ImagePath = "/uploads/images/" + imageFileName;
            }

            if (dts.Video != null)
            {
                string videoFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads/videos");

                if (!Directory.Exists(videoFolder))
                {
                    Directory.CreateDirectory(videoFolder);
                }

                string videoFileName = Guid.NewGuid().ToString() + Path.GetExtension(dts.Video.FileName);
                string videoPath = Path.Combine(videoFolder, videoFileName);

                using (var stream = new FileStream(videoPath, FileMode.Create))
                {
                    await dts.Video.CopyToAsync(stream);
                }

                dts.VideoPath = "/uploads/videos/" + videoFileName;
            }

            if (dts.Audio != null)
            {
                string audioFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads/audios");
                if (!Directory.Exists(audioFolder))
                {
                    Directory.CreateDirectory(audioFolder);
                }
                string audioFileName = Guid.NewGuid().ToString() + Path.GetExtension(dts.Video.FileName);
                string audioPath = Path.Combine(wwwRootPath + "/uploads/audios/", audioFileName);
                using (var stream = new FileStream(audioPath, FileMode.Create))
                {
                    await dts.Audio.CopyToAsync(stream);
                }
                dts.AudioPath = "/uploads/audios/" + audioFileName;
            }

            dts.Image = null;
            dts.Video = null;
            dts.Audio = null;

            var json = JsonConvert.SerializeObject(dts);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = httpClient.PatchAsync(baseUrl + "Update", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details");
            }

            return View(dts);
        }


    }
}
