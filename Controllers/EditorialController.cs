using CrudSimple_Editorials.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CrudSimple_Editorials.Controllers
{
    public class EditorialController : Controller
    {
        Uri urlAPI = new Uri("https://localhost:7172/api");
        HttpClient Editoriales;

        public EditorialController()
        {
            Editoriales = new HttpClient();
            Editoriales.BaseAddress = urlAPI;
        }
        public ActionResult Index()
        {
            List<EditoralModel> ListEditorials = new List<EditoralModel>();
            HttpResponseMessage response = Editoriales.GetAsync(Editoriales.BaseAddress + "/Editorials").Result;
            if (response.IsSuccessStatusCode)
            {
                string dataEdit = response.Content.ReadAsStringAsync().Result;
                ListEditorials = JsonConvert.DeserializeObject<List<EditoralModel>>(dataEdit);
            }
            return View(ListEditorials);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EditoralModel Editorial)
        {
            string dataEdit = JsonConvert.SerializeObject(Editorial);
            StringContent content = new StringContent(dataEdit, Encoding.UTF8, "application/json");

            HttpResponseMessage response = Editoriales.PostAsync(Editoriales.BaseAddress + "/Editorials", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            EditoralModel Editorials = new EditoralModel();
            HttpResponseMessage response = Editoriales.GetAsync(Editoriales.BaseAddress + "/Editorials/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string dataEdit = response.Content.ReadAsStringAsync().Result;
                Editorials = JsonConvert.DeserializeObject<EditoralModel>(dataEdit);
            }
            return View("Edit", Editorials);
        }

        [HttpPost]
        public ActionResult Edit(EditoralModel Editorials)
        {
            string dataEdit = JsonConvert.SerializeObject(Editorials);
            StringContent content = new StringContent(dataEdit, Encoding.UTF8, "application/json");

            HttpResponseMessage response = Editoriales.PutAsync(Editoriales.BaseAddress + "/Editorials/" + Editorials.CodEditorial, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit", Editorials);
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Editoriales.DeleteAsync(Editoriales.BaseAddress + "/Editorials/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}
