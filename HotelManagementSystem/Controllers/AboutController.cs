using HotelManagementSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class AboutController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:49570/";
        public async Task<ActionResult> Index()
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

        // GET: About/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            About about = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49570/api/");
                //HTTP GET
                var responseTask = client.GetAsync("about?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<About>();
                    readTask.Wait();

                    about = readTask.Result;
                }
            }

            return View(about);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Body,AboutImage,ImageSource,HeaderContent,Content")] About about, HttpPostedFileBase fileOne, HttpPostedFileBase fileTwo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49570/api/about");

                var pathOne = "";

                var pathTwo = "";


              
                    if (fileOne != null)
                    {
                        if (fileOne.ContentLength > 0)
                        {
                            if (Path.GetExtension(fileOne.FileName).ToLower() == ".jpg"

                              || Path.GetExtension(fileOne.FileName).ToLower() == ".png"
                              || Path.GetExtension(fileOne.FileName).ToLower() == ".gif"
                              || Path.GetExtension(fileOne.FileName).ToLower() == ".jpeg")
                            {
                                pathOne = Path.Combine(Server.MapPath("~/images"), fileOne.FileName);
                                fileOne.SaveAs(pathOne);
                                about.AboutImage = fileOne.FileName;

                            }
                        }

                    }

                if (fileTwo != null)
                {
                    if (fileTwo.ContentLength > 0)
                    {
                        if (Path.GetExtension(fileTwo.FileName).ToLower() == ".jpg"

                          || Path.GetExtension(fileTwo.FileName).ToLower() == ".png"
                          || Path.GetExtension(fileTwo.FileName).ToLower() == ".gif"
                          || Path.GetExtension(fileTwo.FileName).ToLower() == ".jpeg")
                        {
                            pathTwo = Path.Combine(Server.MapPath("~/images"), fileTwo.FileName);
                            fileTwo.SaveAs(pathTwo);
                            about.ImageSource = fileTwo.FileName;

                        }
                    }

                }


                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<About>("about", about);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return View(about);
            }
        


        [HttpGet]
        public ActionResult Edit(int id)
        {
            About about = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49570/api/");
                //HTTP GET
                var responseTask = client.GetAsync("about?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<About>();
                    readTask.Wait();

                    about = readTask.Result;
                }
            }

            return View(about);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(About about)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49570/api/about");

                //HTTP PUT
                var putTask = client.PutAsJsonAsync<About>("about/" + about.AboutID, about);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(about);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            About about = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49570/api/");
                //HTTP GET
                var responseTask = client.GetAsync("about?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<About>();
                    readTask.Wait();

                    about = readTask.Result;
                }
            }

            return View(about);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49570/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("about/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }


    }
}