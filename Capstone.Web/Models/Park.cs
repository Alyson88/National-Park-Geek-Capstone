using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Capstone.Web.Models
{
    public class Park
    {
        // parkCode(10)
        [DisplayName("Park")]
        public string ParkCode { get; set; }

        // parkName(200)
        [DisplayName("Park")]
        public string ParkName { get; set; }

        // state(30)
        [DisplayName("Park State")]
        public string ParkState { get; set; }

        // acreage
        public int Acreage { get; set; }

        // elevationInFeet
        [DisplayName("Elevation")]
        public int ElevationInFeet { get; set; }

        // milesOfTrail
        [DisplayName("Trails")]
        public double MilesOfTrail { get; set; }

        // numberOfCampsites
        [DisplayName("Campsites")]
        public int NumberOfCampsites { get; set; }

        // climate(100)
        public string Climate { get; set; }

        // yearFounded
        [DisplayName("Founded")]
        public int YearFounded { get; set; }

        // annualVisitorCount
        [DisplayName("Visitors")]
        public int AnnualVisitorCount { get; set; }

        // inspirationalQuote(max)
        public string InspirationalQuote { get; set; }

        // (inspirationalQuoteSource(200)
        public string InspirationalQuoteSource { get; set; }

        // parkDescription(max)
        [DisplayName("Description")]
        public string ParkDescription { get; set; }

        // entryFee
        [DisplayName("Entry Fee")]
        public int EntryFeeInDollars { get; set; }

        // numberOfAnimalSpecies
        [DisplayName("Animals")]
        public int NumberOfAnimalSpecies { get; set; }

        // From Weather Model
        [DisplayName("Five Day Forecast")]
        public List<Weather> FiveDayForecast { get; set; } = new List<Weather>();

        // Count of Surveys
        [DisplayName("Votes")]
        public int? SurveyCount { get; set; }
    }
}