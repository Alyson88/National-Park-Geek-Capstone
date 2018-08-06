using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Survey
    {
        // surveyId
        public int SurveyID { get; set; }

        // parkCode(10)
        [Required]
        [DisplayName("Your Favorite Park")]
        public string ParkCode { get; set; }

        // emailAddress(100)
        [Required]
        [DisplayName("Email Address")]
        [StringLength(100)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        // state(30)
        [Required]
        [DisplayName("State of Residence")]
        [StringLength(30)]
        public string ResidenceState { get; set; }

        // activityLevel(100)
        [Required]
        [DisplayName("Activity Level")]
        [StringLength(100)]
        public string ActivityLevel { get; set; }
    }
}