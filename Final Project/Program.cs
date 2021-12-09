/***************************************************************
* Name : Final Project
* Author: Andrew Dowd
* Created : ##/##/2021
* Course: CIS 152 - Data Structure
* Version: 1.0
* OS: Windows 10
* IDE: Visual Studio 19,
* Copyright : This is my own original work 
* based onspecifications issued by our instructor
* Description : An app that .... ADD HERE....
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/
using System;
using System.IO;
using System.Text;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string converter = "";
            int decision = 0;
            Employee emp = new Employee();
            string employeeName = "";
            int employeeId = 0;


            int workCounter = 0;
            int workDif = 0;
            int workId = 0;
            double workCompTime = 0.00;
            int difTotal = 0;
            Work work = new Work(workDif, workId, workCompTime);


            MakeRecords<Work> workRecord = new MakeRecords<Work>();
            while (decision != 5)
            {

                decision = 0;

                Console.WriteLine("|-------------------------------------------------------------------------------------|");
                Console.WriteLine("|                          Andrew Dowd's Software Recorder                            |");
                Console.WriteLine("|-------------------------------------------------------------------------------------|");
                Console.WriteLine("| 1. create an employee                                                               |");
                Console.WriteLine("| 2. add a completed work assignment                                                  |");
                Console.WriteLine("| 3. remove the most recent inputed assignment                                       |");
                Console.WriteLine("| 4. convert the record into a file                                                   |");
                Console.WriteLine("| 5. exit the program                                                                 |");
                Console.WriteLine("|-------------------------------------------------------------------------------------|\n");

                converter = Console.ReadLine();
                decision = Convert.ToInt32(converter);

                if (decision == 1) //only 1 at a time will work for this
                {
                   
                    Console.Write("What's the employees name? ");
                    employeeName = Console.ReadLine();
                    Console.Write("What's the employees id? ");
                    converter = Console.ReadLine();
                    employeeId = Convert.ToInt32(converter);

                    emp = new Employee(employeeName,employeeId);

                    Console.WriteLine("The employee you entered is: " + emp.ToString());
                    
                }
                else if (decision == 2)
                {
                    Console.Write("What's the assignments difficulty (on scale of 1 - 3)? ");
                    converter = Console.ReadLine();
                    workDif = Convert.ToInt32(converter);
                    Console.Write("What's the assignments id? ");
                    converter = Console.ReadLine();
                    workId = Convert.ToInt32(converter);
                    Console.Write("How long did the assignment take? ");
                    converter = Console.ReadLine();
                    workCompTime = Convert.ToDouble(converter);

                    difTotal = difTotal + workDif; 
                    work = new Work(workDif, workId, workCompTime);

                    Console.WriteLine("The finished assignment you submitted is: " + work.ToString());

                    workCounter++;
                    workRecord.Enqueue(workDif,work);
                   
                }
                else if (decision == 3)
                {
                    workRecord.Dequeue();
                    difTotal = difTotal - workDif;
                    workCounter--;
                    Console.WriteLine("It has been removed");

                }
                else if (decision == 4)
                {
                    string storage = " ";
                    string path = @"C:\Temp\" + employeeName + "EmployeeRecords.txt";
                    try
                    {

                        StreamWriter sw = new StreamWriter(path);
                      
                        //writing stuff into the file
                        sw.WriteLine("---------------------------");
                        sw.WriteLine(emp.ToString());
                        sw.WriteLine("---------------------------");

                        for (int i = 0; i < workCounter; i++)
                        {
                            sw.WriteLine(workRecord.Dequeue());
                        }
                        sw.WriteLine("---------------------------");
                        //Close the file
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Executing finally block.");
                    }

                }
                else if (decision == 5)
                {
                    Console.WriteLine("Thank you for using the program!");
                    Console.WriteLine("The program will exit now");
                }
                else
                {
                    Console.WriteLine("Error you entered an invalid option");
                }








            }













        }
    }
}
