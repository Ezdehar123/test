using System;
using TestForMe;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using TestForMe.Entities;
using System.Configuration;

namespace BL
{
    public class CRUD : BaseRebo
    {

        public static readonly CRUD Instance = new CRUD();


                    

        public List<Person>GetList(string id , string Role)//params string[] Arguments
        {
            //string id = Arguments[0];
            //string Role = Arguments[1];
            var con = GetConnection();
            //return data from person table acording to the role if it is sa doctor or patiant
             var queries1 = "SELECT * FROM Person WHERE ID=" + id+ "AND Role =\'"+Role+"\'"; 
             var command = new SqlCommand(queries1, con);
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                    string any = String.Format("{0}", reader[0]);
                    string any2 = String.Format(" {0}", reader[1]);
                    Console.WriteLine("Welcome " + any2);
                }
                }
            
            //if the role is doctor this qry returns all patiants profile, if the role is patiant the qry returns patiant file
            var queries2 = "SELECT * FROM Person WHERE (Doctor_Id =" + id+ "AND Role =\'" + Role + "\') OR (ID=" +id+ "AND Role =\'" + Role + "\')" ;
            var cmd1 = new SqlCommand(queries2, con);
            var result2 = GetPerson(cmd1, con);
           
            return result2;
           

        }

        // the method accepts 3 parameters 
        public List<Description> GetList3( string P_ID, string Doctor_Id, string description)//params string[] Arguments)
        {
            /*for (int i = 1; i < Arguments.Length; i++)
            {
                string Doctor_Id = Arguments[1];
                string description = Arguments[2];
            }
            */
               // always returns all descri no matter what the role is
               // if did it with reader because it is not allowed to make 2 results for the list
               
                var con = GetConnection();
            //only one parameter needed
                var query = "SELECT * FROM Description2 WHERE Pationt_Id = " + P_ID;
                var cmd1 = new SqlCommand(query, con);
            
            var result2 = GetDescriptions(cmd1, con);
            return result2;
            /* con.Open();
             using (var reader = cmd1.ExecuteReader())
             {
                 while (reader.Read())
                 {
                     string any = String.Format("{0}", reader[0]);
                     string any2 = String.Format(" {0}", reader[1]);
                     string any3 = String.Format(" {0}", reader[4]);
                     Console.WriteLine(any2 + "\t" + any3 + "\n");
                 }
             }*/


            // allows the dr to insert description
            string local = DateTime.Now.ToString();

            // three parameters needed
                var queries = "INSERT INTO Description2(Doctor_Id,Pationt_Id, Dec_details, date)  VALUES(" + Doctor_Id + " , " + P_ID + "  ,\'  " + description + " \', \' " + local + "\' )";// DateTime.Now +

                var cmd = new SqlCommand(queries, con);
                var result = GetDescriptions(cmd, con);
                return result;


            



        }

       
    }
}
