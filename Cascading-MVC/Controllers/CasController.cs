using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cascading_MVC.Controllers
{
    public class CasController : Controller
    {
        // GET: Cas
        public ActionResult Index()
        {
            SampleDBEntities sd = new SampleDBEntities();
            ViewBag.CountryList = new SelectList(GetCountryList(), "Cid", "Cname");
            return View();
        }
        public List<Country> GetCountryList()
        {
            SampleDBEntities sd = new SampleDBEntities();
            List<Country> countries = sd.Countries.ToList();
            return countries;
        }
        public ActionResult GetStateList(int Cid) 
        {
            SampleDBEntities sd = new SampleDBEntities();
            List<State> selectList = sd.States.Where(x => x.Cid == Cid).ToList();
            ViewBag.SList = new SelectList(selectList, "Sid", "Sname");
            return PartialView("DisplayStates");
        }

    }
}