using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceApp.Controllers
{

    public class LaunchesController : Controller
    {
        public static List<Trajectory> trajectories = new List<Trajectory>();
        // GET: Launches
        public JsonResult Index(string dateFrom, string dateTo)
        {
            DateTime dateF = DateTime.ParseExact(dateFrom,"yyyy-mm-dd",null);
            DateTime dateT = DateTime.ParseExact(dateTo, "yyyy-mm-dd", null);

            List<Trajectory> launches = new List<Trajectory>();
            foreach (Trajectory traj in trajectories)
            {
                DateTime myDate = DateTime.ParseExact(traj.net, "yyyy-mm-dd", null);

                if ((myDate.Date > dateF.Date) && (myDate < dateT.Date))
                {
                    launches.Add(traj);
                }
            }

            //return JsonConvert.SerializeObject(launches);
            return Json(new LaunchResult() { launches = launches }, JsonRequestBehavior.AllowGet);
        }

        public class LaunchResult
        {
            public List<Trajectory> launches;
        }
    }
}