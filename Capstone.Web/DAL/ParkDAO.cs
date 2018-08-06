using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkDAO : IParkDAO
    {
        private string connectionString;
        private const string sql_GetAllParks = @"SELECT parkCode, parkName, parkDescription 
                                                    FROM park 
                                                    ORDER BY parkName;";

        private const string sql_GetParkDetail = @"SELECT p.*, w.* 
                                                    FROM park p 
                                                    JOIN weather w ON p.parkCode = w.parkCode 
                                                    WHERE p.parkCode = @parkCode 
                                                    ORDER BY w.fiveDayForecastValue;";

        private const string sql_GetFavoriteParks = @"SELECT COUNT(*) AS surveyCount, sr.parkCode, p.parkName 
                                                        FROM survey_result sr
                                                        JOIN park p ON sr.parkCode = p.parkCode
                                                        GROUP BY sr.parkCode, p.parkName
                                                        ORDER BY surveyCount DESC, p.parkName;";

        //Constructor
        public ParkDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //For homepage and drop down list in survey
        public List<Park> GetAllParks()
        {
            List<Park> allParksList = new List<Park>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql_GetAllParks, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = new Park();

                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        
                        allParksList.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return allParksList;
        }

        //For park details page
        public Park GetParkDetail(string parkCode)
        {
            Park selectedPark = new Park();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql_GetParkDetail, connection);
                    command.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        selectedPark.ParkCode = Convert.ToString(reader["parkCode"]);
                        selectedPark.ParkName = Convert.ToString(reader["parkName"]);
                        selectedPark.ParkState = Convert.ToString(reader["state"]);
                        selectedPark.Acreage = Convert.ToInt32(reader["acreage"]);
                        selectedPark.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        selectedPark.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        selectedPark.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        selectedPark.Climate = Convert.ToString(reader["climate"]);
                        selectedPark.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        selectedPark.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        selectedPark.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        selectedPark.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        selectedPark.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        selectedPark.EntryFeeInDollars = Convert.ToInt32(reader["entryFee"]);
                        selectedPark.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                        Weather forecast = new Weather();

                        forecast.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        forecast.LowTempInFahrenheit = Convert.ToInt32(reader["low"]);
                        forecast.HighTempInFahrenheit = Convert.ToInt32(reader["high"]);
                        if (Convert.ToString(reader["forecast"]) == "partly cloudy")
                        {
                            forecast.Forecast = "partlycloudy";
                        }
                        else
                        {
                            forecast.Forecast = Convert.ToString(reader["forecast"]);
                        }

                        selectedPark.FiveDayForecast.Add(forecast);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return selectedPark;
        }

        //For Survey Results/Favorite Parks page
        public List<Park> GetFavoriteParks()
        {
            List<Park> favoriteParks = new List<Park>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql_GetFavoriteParks, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = new Park();

                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.SurveyCount = Convert.ToInt32(reader["surveyCount"]);

                        favoriteParks.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return favoriteParks;
        }
    }
}