using System.Web.Mvc;


namespace WhiteValley.Controllers
{

    [RoutePrefix("status"), Route("{action=index}")]
    public class StatusController : Controller
    {
        
        public JsonResult Index()
        {
            var status = new
            {
                Status = "OK"
            };
            return Json(status, JsonRequestBehavior.AllowGet);
        }

    }
}