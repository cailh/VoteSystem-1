using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoteSystem.Logic.Services;

namespace VoteSystem.WebClient.Controllers
{
    public class VoteController : Controller
    {
        // GET: Vote
        public ActionResult Index()
        {
            //1.获取活动数据
            VoteService service = new VoteService();
            var activities = service.GetVoteActivities();

            return View(activities);
        }

        public ActionResult Login(string userName,string password)
        {
            UserService userService = new UserService();
            try
            {
                userService.Login(userName, password);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("LoginError", ex);
            }

            return View();
        }
    }
}