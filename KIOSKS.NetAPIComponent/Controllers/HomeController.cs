using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KIOSKS.NetAPIComponent.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            API_Caller.ServiceClient restClient = new API_Caller.ServiceClient();
            restClient.GetServiceResponse<object>(); //Using RestClient
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> Index2()
        {
            API_Caller.APIClient apiClient = new API_Caller.APIClient();
            await apiClient.GetAPIResponse(); //Using APIClient
            return View();
        }
    }
}