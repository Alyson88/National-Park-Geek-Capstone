using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {
        
        public string ParkCode { get; set; } // parkCode(10)
        public int FiveDayForecastValue { get; set; } // fiveDayForecastValue
        public int LowTempInFahrenheit { get; set; } // low
        public int HighTempInFahrenheit { get; set; } // high
        public string Forecast { get; set; } // forecast(100)
        public string FahrenheitOrCelsius { get; set; } // To determine view of F or C in weather forecast on park details view

        
        public string ForecastDate // Turn fiveDayForecastValue (1,2,etc.) into weekday name (today, mon, tues, etc.)
        {
            get
            {
                if (FiveDayForecastValue == 1)
                {
                    return "Today";
                }
                else
                {
                    return DateTime.Now.AddDays(FiveDayForecastValue - 1).ToString("dddd");
                }
            }
        }
        
        public int GetLowTempInCelsius(int lowTempInFahrenheit) // Convert low to celsius
        {
            int lowTempInCelsius = (int)((lowTempInFahrenheit - 32) * (5.0 / 9.0));
            return lowTempInCelsius;
        }
        
        public int GetHighTempInCelsius(int highTempInFahrenheit) // Convert high to celsius
        {
            int highTempInCelsius = (int)((highTempInFahrenheit - 32) * (5.0 / 9.0));
            return highTempInCelsius;
        }

        public string ForecastDisplay
        {
            get
            {
                string forecastNameToDisplay = "";

                if (Forecast == "cloudy")
                {
                    forecastNameToDisplay = "Cloudy";
                }
                else if (Forecast == "partlycloudy")
                {
                    forecastNameToDisplay = "Partly Cloudy";
                }
                else if (Forecast == "sunny")
                {
                    forecastNameToDisplay = "Sunny";
                }
                else if (Forecast == "rain")
                {
                    forecastNameToDisplay = "Rain Likely";
                }
                else if (Forecast == "snow")
                {
                    forecastNameToDisplay = "Snow Likely";
                }
                else if (Forecast == "thunderstorms")
                {
                    forecastNameToDisplay = "Thunderstorms Likely";
                }

                return forecastNameToDisplay;
            }
        }
        
        public string Recommendations // Generate recommendations based on temperature and forecast
        {
            get
            {
                string recommendation = "Have a nice day!";

                if (Forecast.ToLower() == "snow")
                {
                    recommendation = "Pack snowshoes. ";
                }
                else if (Forecast.ToLower() == "rain")
                {
                    recommendation = "Pack rain gear and wear waterproof shoes. ";
                }
                else if (Forecast.ToLower() == "thunderstorms")
                {
                    recommendation = "Seek shelter and avoid hiking on exposed ridges. ";
                }
                else if (Forecast.ToLower() == "sunny")
                {
                    recommendation = "Pack sunblock. It's going to be a great day! ";
                }

                if (HighTempInFahrenheit > 75)
                {
                    recommendation += "Bring an extra gallon of water. ";
                }
                if (Math.Abs(HighTempInFahrenheit - LowTempInFahrenheit) > 20)
                {
                    recommendation += "Wear breathable layers. ";
                }
                if (LowTempInFahrenheit < 20)
                {
                    recommendation += "Beware of the dangers of exposure to frigid temperatures!! ";
                }

                return recommendation;
            }
        }
    }
}