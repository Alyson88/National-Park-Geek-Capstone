using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParkDAO parkDAO;
        private readonly ISurveyDAO surveyDAO;

        //Constructor
        public HomeController(IParkDAO parkDAO, ISurveyDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.surveyDAO = surveyDAO;
        }

        [HttpGet]
        public ActionResult Index()
        {
            //if (Session["fahrenheitOrCelsius"] as string == null)
            //{
            //    Session["fahrenheitOrCelsius"] = "fahrenheit";
            //}

            List<Park> parks = parkDAO.GetAllParks();
            return View(parks);
        }

        [HttpGet]
        public ActionResult ParkDetail(string id)
        {
            Park selectedPark = parkDAO.GetParkDetail(id);
            return View(selectedPark);
        }
        
        [HttpGet]
        public ActionResult FavoriteParks()
        {
            List<Park> favoriteParks = parkDAO.GetFavoriteParks();
            return View(favoriteParks);
        }
    }
}