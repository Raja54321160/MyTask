using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Raja_Country.Models;

namespace Raja_Country.Controllers
{
    public class CountryController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl = "http://localhost:5219/api/Country/";

        public CountryController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            var response = httpClient.GetAsync(baseUrl + "List").Result;

            if(response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Location>>(json);
                return View(data);
            }
            return RedirectToAction("Add");
        }

        public IActionResult Add()
        {
            ViewData["Countries"] = GetCountryDts();
            ViewData["State"] = GetStateDts();
            ViewData["District"] = GetDistrictDts();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Location dts)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dts);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(baseUrl + "Add", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details");
                }

                return View(dts);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public List<Country> GetCountryDts()
        {
            var response = httpClient.GetAsync(baseUrl + "GetCountry").Result;

            if(response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Country>>(json);
                return data;
            }
            return null;
        }
        [HttpGet]

        public List<State> GetStateDts()
        {
            var response = httpClient.GetAsync(baseUrl + "GetState").Result;

            if(response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<State>>(json);
                return data;
            }
            return null;
        }

        [HttpGet]
        public List<District> GetDistrictDts()
        {
            var response = httpClient.GetAsync(baseUrl + "GetDistrict").Result;

            if(response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<District>>(json);
                return data;
            }
            return null;
        }

        public IActionResult DeletePage(int id)
        {
            ViewData["Countries"] = GetCountryDts();
            ViewData["State"] = GetStateDts();
            ViewData["District"] = GetDistrictDts();

            var response = httpClient.GetAsync($"{baseUrl}GetById?id={id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Location>(json);
                return View(data);
            }

            return RedirectToAction("Details");
        }
        public IActionResult Delete(int id)
        {
            var response = httpClient.DeleteAsync($"{baseUrl}Del?id={id}").Result;

            return RedirectToAction("Details");
        }
                
        public IActionResult Update(int id)
        {
            ViewData["Countries"] = GetCountryDts();
            ViewData["State"] = GetStateDts();
            ViewData["District"] = GetDistrictDts();

            var response = httpClient.GetAsync($"{baseUrl}GetById?id={id}").Result;

            if(response.IsSuccessStatusCode )
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Location>(json);
                return View(data);
            }

            return RedirectToAction("Details");
        }

        [HttpPost]
        public IActionResult Update(Location dts)
        {
            var json = JsonConvert.SerializeObject(dts);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = httpClient.PatchAsync(baseUrl + "Update", content).Result;

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details");
            }

            return RedirectToAction("Details");
        }
    }
}
