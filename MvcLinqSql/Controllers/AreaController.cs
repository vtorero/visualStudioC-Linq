using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLinqSql.Models;

namespace MvcLinqSql.Controllers
{
    public class AreaController : Controller
    {
        //
        // GET: /Area/
        public ModelArea model = new ModelArea();


        public ActionResult Index()
        {
            return View(model.ListarArea());
        }

       public ActionResult Datails(int id){
        
           var area = model.BuscarArea(id);
             return View(area);  
        }

        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        public  ActionResult Create(area a)
        {

        try{

            if(model.InsertarArea(a).Equals("OK"))
            {
                return RedirectToAction("Index");
            }else{
            return RedirectToAction("Create");
            }
           }
     catch{
            return View();
         }
        }

        public ActionResult Edit(int id) {
            var area = model.BuscarArea(id);
            return View(area);
        }

        [HttpPost]
        public ActionResult Edit(int id, area a) {

            try
            {
                area area = new area();
                area.area_cod = id;
                area.area_des = a.area_des;

                if (model.ActualizarArea(area).Equals("OK"))
                {

                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("Edit");
                }
            }
            catch {

                return View();
            
            }
        
        
        }

        public ActionResult Delete(int id) {

            var area = model.BuscarArea(id);
            return View(area);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {

            try {
                if (model.eliminarArea(id).Equals("OK"))
                {
                    return RedirectToAction("Index");
                }
                else {
                    return RedirectToAction("Delete");
                }

            }
            catch {
                return View();
            }
        
        }


    }
}
