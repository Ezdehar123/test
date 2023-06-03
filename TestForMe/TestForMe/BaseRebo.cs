using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForMe.Entities;

namespace TestForMe
{
    public class BaseRebo


    {

        private readonly string connectionString;
        protected BaseRebo() => connectionString = ConfigurationManager.ConnectionStrings["TestHospital"].ConnectionString;
        
        

        protected SqlConnection GetConnection()
        {
            var result = new SqlConnection(connectionString);
            return result;
        }




        public List<Person> GetPerson(SqlCommand command, SqlConnection connection)
        {
            var list = new List<Person>();

            //connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var person = new Person();
                person.Id = Convert.ToInt32(reader[0]);
                person.Name = reader[1].ToString();
                person.Role = reader[2].ToString();
                person.Specialty = reader[3].ToString();
                person.Working_Hours = reader[4].ToString();
                person.Age = Convert.ToInt32(reader[5]);
                person.Gender = reader[6].ToString();
                person.Doctor_Id = Convert.ToInt32(reader[7]);
                
                list.Add(person);
            }


            return list;
        }




        public List<Description> GetDescriptions(SqlCommand command, SqlConnection connection)
        {
            var list = new List<Description>();
            try
            {
                //connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var description = new Description();
                    description.Id = Convert.ToInt32(reader[0]);
                    description.Dec_details = Convert.ToString(reader[1]);
                    description.Doctor_Id = Convert.ToInt32(reader[2]);
                    description.Pationt_Id = Convert.ToInt32(reader[3]);
                    description.date = Convert.ToString(reader[4]);

                    list.Add(description);
                }


                return list;
            }
            finally
            {
                connection.Close();
            }
        }


    }
    }
