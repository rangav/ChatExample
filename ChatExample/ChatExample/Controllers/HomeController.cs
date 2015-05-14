using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PusherServer;

namespace ChatExample.Controllers
{
    using System.Net;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult PushMessage(string msg)
        {
            var pusher = new Pusher("[App ID]", "[App Key]", "[App Secret]");
            var result = pusher.Trigger("test_channel", "new_message", new { message = msg });
            return new HttpStatusCodeResult((int)HttpStatusCode.OK);
        }

        public ActionResult PrivateChannel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PrivateMessage(string msg) 
        {
            var pusher = new Pusher("[App ID]", "[App Key]", "[App Secret]");
            var result = pusher.Trigger("private-test_channel", "new_message", new { message = msg });
            return new HttpStatusCodeResult((int)HttpStatusCode.OK);
        }


        public ActionResult Auth(string channel_name, string socket_id)
        {
            // ref:: https://pusher.com/docs/authenticating_users#/lang=cs-mvc
            var pusher = new Pusher("[App ID]", "[App Key]", "[App Secret]");

            if (User.Identity.IsAuthenticated)
            {
                var auth = pusher.Authenticate(channel_name, socket_id);
                var json = auth.ToJson();
                return new ContentResult { Content = json, ContentType = "application/json" };
            }

            return new HttpStatusCodeResult((int)HttpStatusCode.Forbidden);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}