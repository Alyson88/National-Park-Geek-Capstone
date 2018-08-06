using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public class SurveyDAO : ISurveyDAO
    {
        private string connectionString;
        private const string sql_AddSurvey = @"INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel);";

        //Constructor
        public SurveyDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //To add survey data to the database
        public bool AddSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql_AddSurvey, connection);
                    command.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    command.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    command.Parameters.AddWithValue("@state", survey.ResidenceState);
                    command.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
        }
    }
}