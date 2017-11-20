using HotelManagementSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

      
            //Hosted web API REST Service base url  
            string Baseurl = "http://localhost:49570/";
        public async Task<ActionResult> About()
        {
            List<About> abouts = new List<About>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAbouts using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/about");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var AbResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the About list  
                    abouts = JsonConvert.DeserializeObject<List<About>>(AbResponse);

                }
                //returning the employee list to view  
                return View(abouts);
            }


        }

        public ActionResult Team()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Rooms()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}