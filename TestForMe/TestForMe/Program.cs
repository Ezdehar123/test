using BL;
using System;
using System.Data;
using TestForMe.Entities;

namespace TestForMe
{
    class Program
    {
        public static readonly CRUD operation = CRUD.Instance;

        static void Main(string[] args)
        {
            string P_ID;
            string Role;
            string description;
            int role, option, choice;


            Console.WriteLine("Welcome to our Hospetal System \n  If you are a docor press 1 , and if you are a patient press 2");
            role = Convert.ToInt32(Console.ReadLine());


            do
            {

                if (role == 1) // if the user is a doctor
                {
                    Role = "Doctor";

                    Console.WriteLine("Hello Doctor, Please enter your Id:");
                    P_ID = Console.ReadLine();


                    var result2 = operation.GetList(P_ID, Role);
                    Console.WriteLine("Your Patiants are:");

                    Console.WriteLine("ID \t Name \t\t\t\t\t\t Age \t Gender");
                    foreach (var item in result2)
                    {
                        Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Age + "\t" + item.Gender);
                    }



                    Console.WriteLine("\n choose a service:\n 1- Add description\n 2- Confirm an appointment");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        string Doctor_Id = P_ID;
                        Console.WriteLine("please provide your patient ID:");
                        P_ID = Console.ReadLine();

                        Console.WriteLine("Please provide the description:");
                        description = Console.ReadLine();

                        var result3 = operation.GetList3( P_ID, Doctor_Id, description); // add description to the DB for a specific patiant related to a doctor
                        if (result3 != null)
                        {
                            Console.WriteLine("description added successfully");
                        }

                    }
                    if (choice == 2)
                    { }


                }




                if (role == 2)
                {
                    Role = "Patiant";

                    Console.WriteLine("Hello , Please enter your Id:");
                    P_ID = Console.ReadLine();


                    Console.WriteLine("Your profile:");
                    var result2 = operation.GetList(P_ID, Role);

                    Console.WriteLine("ID \t Name \t\t\t\t\t\t Age \t Gender");
                    foreach (var item in result2)
                    {
                        Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Age + "\t" + item.Gender);
                    }



                    Console.WriteLine("\n choose a service:\n 1- View description \n2- Book an appointment");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        var result3 = operation.GetList3(P_ID," ","");


                    }

                }
            }
            while (role != 1 | role != 2);
                            {
                                 Console.WriteLine("Invaled number");
                                 option = 0;
                                 Console.Read();
                            }
            }
        }
   }

