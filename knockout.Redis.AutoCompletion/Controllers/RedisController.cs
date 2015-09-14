using System;
using System.Linq;
using System.Web.Mvc;
using RedisAuto;

namespace RedisList.Web.Controllers
{
    public class RedisController : Controller
    {
        // GET: Redis
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCity()
        {
            var take = string.IsNullOrEmpty(Request.QueryString["take"]) ? 1000 : Convert.ToInt32(Request.QueryString["take"]);
            var skip = string.IsNullOrEmpty(Request.QueryString["skip"]) ? 1000 : Convert.ToInt32(Request.QueryString["skip"]);
            
            var city = RedisHelper.GetCityByCode("ZA").Skip(skip).Take(take);
            
            return this.Json(city, JsonRequestBehavior.AllowGet);
        }
    }
}