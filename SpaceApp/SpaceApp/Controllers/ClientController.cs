using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace SpaceApp.Controllers
{

    public class ClientController : Controller
    {
       
        public ActionResult Index(
                         int id,
                         string name,
                         string net,
                         float parogee,
                         float appogee,
                         float loan,
                         float argument_of_periapsis,   int idp,
                         string namep,
                         float latitude,
                         float longitude)
        {
            Trajectory.Location location = new Trajectory.Location(idp,namep,latitude,longitude);
            LaunchesController.trajectories.Add(new Trajectory(id, name, net, parogee, appogee, loan, argument_of_periapsis,location));
            return View();
        }
       
    }
    public class Trajectory
    {
        public int id;
        public string name;
        public string net;
        public float parogee;
        public float appogee;
        public float loan;
        public float argument_of_periapsis;
        public Location location;

        public Trajectory(int id, string name, string net, float parogee,float appogee,float loan, float argument_of_periapsis,Location location)
        {
            this.id = id;
            this.name = name;
            this.net = net;
            this.parogee = parogee;
            this.appogee = appogee;
            this.loan = loan;
            this.argument_of_periapsis = argument_of_periapsis;
            this.location = location;
        }

        public class Location
        {
            public List<Pads> pads;
            private int idp;
            private string namep;
            private float latitude;
            private float longitude;

            public Location(int idp, string namep, float latitude, float longitude)
            {
                pads = new List<Pads>();
                pads.Add(new Pads(idp, namep, latitude, longitude));
            }
            public class Pads
            {
                public int id;
                public string name;
                public float latitude;
                public float longitude;
                private int idp;
                private string namep;

                public Pads(int idp, string namep, float latitude, float longitude)
                {
                    this.id = idp;
                    this.name = namep;
                    this.latitude = latitude;
                    this.longitude = longitude;
                }
            }
        }
    }
}