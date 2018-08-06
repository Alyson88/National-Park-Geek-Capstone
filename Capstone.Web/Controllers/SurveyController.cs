using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IParkDAO parkDAO;
        private readonly ISurveyDAO surveyDAO;

        //Constructor
        public SurveyController(IParkDAO parkDAO, ISurveyDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.surveyDAO = surveyDAO;
        }

        [HttpGet]
        public ActionResult Survey()
        {
            Session["ParkCodesAndNames"] = parkDAO.GetAllParks();
            return View();
        }

        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            if (ModelState.IsValid)
            {
                surveyDAO.AddSurvey(survey);
                return RedirectToAction("FavoriteParks", "Home");
            }
            else
            {
                return View("Survey", survey);
            }
        }
    }
}