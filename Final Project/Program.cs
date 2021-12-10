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
* Description : An app that gets user input for employee data, their assignments they've completed and then creates a file of all the info given.
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/
using System;
using System.Collections.Generic;
using System.IO;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            /* inital testing section for inputs
             * 
            // Test 2
            Employee emp = new Employee("Bob", 1);

            Work assignment1 = new Work(1, 3, 1.2);
            Work assignment2 = new Work(3, 14, 7.5);
            Work assignment3 = new Work(2, 1, 4.3);

            MakeRecords<Work> BobWorkRecord = new MakeRecords<Work>();
            BobWorkRecord.Enqueue(1,assignment1);
            BobWorkRecord.Enqueue(3,assignment2);
            BobWorkRecord.Enqueue(2,assignment3);

            Console.WriteLine(assignment1.Dequeue());
            Console.WriteLine(assignment2.Dequeue());
            Console.WriteLine(assignment3.Dequeue());.

            // Test 2
            Employee emp = new Employee("Tom", 2);

            Work assignment4 = new Work(1, 3, 2.4);
            Work assignment5 = new Work(3, 14, 8.6);
            Work assignment6 = new Work(2, 1, 5.3);

            MakeRecords<Work> TomWorkRecord = new MakeRecords<Work>();
            BobWorkRecord.Enqueue(4,assignment1);
            BobWorkRecord.Enqueue(5,assignment2);
            BobWorkRecord.Enqueue(6,assignment3);

            Console.WriteLine(assignment4.Dequeue());
            Console.WriteLine(assignment5.Dequeue());
            Console.WriteLine(assignment6.Dequeue());
            */

            //actual program that needs user input, has working gui and only accepts 1 employee at a time to keep records simple and straight forward
            string converter = "";
            int decision = 0;
            Employee emp = new Employee(); //acts as a container to store data of the current employee
            string employeeName = "";
            int employeeId = 0;
            string empOverride = "";


            double timeCounter = 0.00;
            int workCounter = 0;
            int workDif = 0;
            int workId = 0;
            double workCompTime = 0.00;
            int difTotal = 0;
            Work work = new Work(workDif, workId, workCompTime); //acts as a container to store a assignment when its inserted so it can be emported to the make record program

            double average = timeCounter / workCounter;
            Stack<Employee> employeeStack = new Stack<Employee>(1); //to store emloyee
            MakeRecords<Work> empWorkRecord = new MakeRecords<Work>();
            
            while (decision != 5) //menu looper
            {

                decision = 0;

                Console.WriteLine("|-------------------------------------------------------------------------------------|");
                Console.WriteLine("|                          Andrew Dowd's Software Recorder                            |");
                Console.WriteLine("|-------------------------------------------------------------------------------------|");
                Console.WriteLine("| 1 - create an employee                                                               |");
                Console.WriteLine("| 2 - add a completed work assignment to the record                                    |");
                Console.WriteLine("| 3 - get a preview of the record                                                      |");                                               
                Console.WriteLine("| 4 - convert the record into a file                                                   |");
                Console.WriteLine("| 5 - exit the program                                                                 |");
                Console.WriteLine("|-------------------------------------------------------------------------------------|");
                Console.WriteLine("| Enter the number corrosponding to the option to select it                           |");
                Console.WriteLine("|-------------------------------------------------------------------------------------|\n");


                //verifiying block for the main menu//
                while (decision == 0)
                {
                    converter = Console.ReadLine();


                    if (int.TryParse(converter, out decision))
                    {
                        decision = Convert.ToInt32(converter);
                    }
                    else
                    {
                        Console.WriteLine("Error: your input needs to contain only numbers");
                        decision = 0;
                    }

                    
                }

                if (decision == 1) //only 1 at a time will work for this
                {
                    if (employeeId != 0) //override section
                    {
                        Console.WriteLine("Warning inserting another employee will overwrite the current employees information");
                        Console.WriteLine("If you wish to overwrite the current employee and also delete any data currently stored for that employee");
                        Console.WriteLine("if you are ok with this enter Y if you don't enter N");

                        empOverride = Console.ReadLine();



                        if (empOverride.Equals("Y"))
                        {
                            Console.WriteLine("You selected to overwrite the current employee and erase all data associated with it");

                            Console.Write("What's the employees name? ");
                            employeeName = Console.ReadLine();

                            while (employeeId < 0 || employeeId == 0) //makes sure employee id isnt 0 or less than 0 and a number
                            {
                                Console.Write("What's the employees id? ");
                                converter = Console.ReadLine();

                                if (int.TryParse(converter, out employeeId))
                                {
                                    employeeId = Convert.ToInt32(converter);
                                }
                                else if (employeeId < 0 || employeeId == 0)
                                {
                                    Console.WriteLine("Error: the employee id cannot be a value less than 1");
                                }
                                else
                                {
                                    Console.WriteLine("Error: your input needs to contain only numbers");
                                    employeeId = 0;
                                }

                            }

                            emp = new Employee(employeeName, employeeId);

                            for (int i = 0; i < workCounter; i++)
                            {
                                empWorkRecord.Dequeue(); //the printed class
                            }
                            workCounter = 0;
                            difTotal = 0;

                            employeeStack.Pop(); //removes old stored employee data

                            Console.WriteLine("The old employee you entered has been overwritten and its old assignments have been removed as well");

                            Console.WriteLine("The employee you entered is: " + emp.ToString());


                        }
                        else if (empOverride.Equals("N"))
                        {
                            Console.WriteLine("You selected the option to not overwrite the current employee");
                            Console.WriteLine("You will be returned to the main selection menu now");
                        }
                        else
                        {
                            Console.WriteLine("Error your input didnt match Y or N, returning you to the main selection menu");
                        }

                    }
                    else //normal input section
                    {
                        while (employeeName == "")
                        {
                            Console.Write("What's the employees name? ");
                            employeeName = Console.ReadLine();

                            if (employeeName == "")
                            {
                                Console.WriteLine("Error: you didn't input a name");
                            }
                            else
                            {
                                employeeName = char.ToUpper(employeeName[0]) + employeeName.Substring(1);
                            }
                        }


                        while (employeeId < 0 || employeeId == 0) //makes sure employee id isnt 0 or less than 0
                        {
                            Console.Write("What's the employees id? ");
                            converter = Console.ReadLine();

                            if (int.TryParse(converter, out employeeId))
                            {
                                employeeId = Convert.ToInt32(converter);

                                if (employeeId < 0 || employeeId == 0)
                                {
                                    Console.WriteLine("Error: the employee id cannot be a value less than 1");
                                    employeeId = 0;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Error: your input isn't a number");

                            }

                        }


                        emp = new Employee(employeeName, employeeId);
                        employeeStack.Push(emp);


                        Console.WriteLine("The employee you entered is: " + emp.ToString());
                    }
                }


                else if (decision == 2) //assignment maker  (no limit)
                {
                    bool workDiffVerification = false;
                    workDif = 0;
                    workId = 0;
                    workCompTime = 0.00;

                    while (workDiffVerification == false)
                    {
                        Console.Write("What's the assignments difficulty (on scale of 1 - 3)? ");
                        converter = Console.ReadLine();

                        if (int.TryParse(converter, out workDif))
                        {

                            workDif = Convert.ToInt32(converter); // layered so it still protects against values outside accepted limits
                            if (workDif < 1 || workDif > 3)
                            {

                                Console.WriteLine("Error: the assignment's difficulty cannot be lower than 1 or higher than 3");
                            }
                            else
                            {
                                workDiffVerification = true;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Error: your input must be a number not a letter");
                        }

                    }


                    while (workId < 0 || workId == 0) //makes sure assignment id isnt 0 or less than 0
                    {
                        Console.Write("What's the assignments id? ");
                        converter = Console.ReadLine();

                        if (int.TryParse(converter, out workId))
                        {
                            workId = Convert.ToInt32(converter);

                            if (workId < 0 || workId == 0)
                            {
                                Console.WriteLine("Error: the assignment id cannot be a value less than 1");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Error: your input must be a number not a letter");
                        }


                    }

                    while (workCompTime < 0 || workCompTime == 0) //makes sure work time record isnt 0 or less than 0
                    {
                        Console.Write("How long did the assignment take? ");
                        converter = Console.ReadLine();

                        if (double.TryParse(converter, out workCompTime))
                        {
                            workCompTime = Convert.ToDouble(converter);

                            if (workCompTime < 0 || workCompTime == 0)
                            {
                                Console.WriteLine("Error the assignment id cannot be a value less than 1");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Error: your input must be a number or decimal not a letter");
                        }

                    }


                    difTotal = difTotal + workDif;
                    timeCounter = workCompTime + timeCounter;
                    work = new Work(workDif, workId, workCompTime);

                    Console.WriteLine("The finished assignment you submitted is: " + work.ToString());

                    workCounter++;
                    empWorkRecord.Enqueue(workDif, work);
                }
                //end of 2nd section

                else if (decision == 3) //preview the record
                {
                    if (workCounter == 0)
                    {
                        Console.WriteLine("Error: You haven't entered any assignments yet");
                    }
                    else
                    {

                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine(employeeStack.Peek());
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Employee Assignments:");
                        Console.WriteLine("-------------------------------------------------");

                        empWorkRecord.PrintAll();

                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Total difficulty of all assignments: " + difTotal);
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Total number of assignments: " + workCounter);
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Total hours of work done on all assignments: " + timeCounter);
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine(" Total average hours per assignment: " + average);
                        Console.WriteLine("-------------------------------------------------");
                    }

                }
                else if (decision == 4) //file maker
                {
                    if ( workCounter == 0)
                    {
                        Console.WriteLine("Error: You haven't inputed any assignments yet");
                    }
                    else 
                    { 
                    string date = DateTime.UtcNow.ToString("MM-dd-yyyy");


                    string path = @"C:\Temp\" + employeeName + date + "EmployeeRecords.txt";
                    try
                    {

                        StreamWriter sw = new StreamWriter(path);

                        //writing stuff into the file
                        sw.WriteLine("-------------------------------------------------");
                        sw.WriteLine(employeeStack.Peek());
                        sw.WriteLine("-------------------------------------------------");
                        sw.WriteLine("-------------------------------------------------");
                        sw.WriteLine("Employee Assignments:");
                        sw.WriteLine("-------------------------------------------------");

                        empWorkRecord.PrintAll();

                        sw.WriteLine("-------------------------------------------------");
                        sw.WriteLine("Total difficulty of all assignments: " + difTotal);
                        sw.WriteLine("-------------------------------------------------");
                        sw.WriteLine("Total number of assignments: " + workCounter);
                        sw.WriteLine("-------------------------------------------------");
                        sw.WriteLine("Total hours of work done on all assignments: " + timeCounter);
                        sw.WriteLine("-------------------------------------------------");
                        sw.WriteLine(" Total average hours per assignment: " + average);
                        sw.WriteLine("-------------------------------------------------");

                        //Close the file
                        sw.Close();


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("File Created.");
                        Console.WriteLine("Thank you for using the program!");

                    }
                }

                }
                else if (decision == 5) //program exiter
                {
                    Console.WriteLine("Thank you for using the program!");
                    Console.WriteLine("The program will exit now");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Error you entered an invalid option");
                }








            }













        }
    }
}
