using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> todoList = new List<string>();
        bool runtime = true;

        Console.WriteLine("Welcome to the Todo List Application!");

        
        while (runtime)
        {
            
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. View all tasks");
            Console.WriteLine("3. Remove a task");
            Console.WriteLine("4. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the task you want to add:");
                    string task = Console.ReadLine();
                    todoList.Add(task);
                    Console.WriteLine("Task added!");
                    break;

                case 2:
                    Console.WriteLine("Your tasks are:");
                    if (todoList.Count == 0)
                        Console.WriteLine("No tasks available.");
                    else
                    {
                        int index = 1;
                        foreach (string t in todoList)
                        {
                            Console.WriteLine($"{index}. {t}");
                            index++;
                        }
                    }
                    break;

                case 3:
                    Console.WriteLine("Enter the task you want to remove:");
                    string taskToRemove = Console.ReadLine();
                    if (todoList.Remove(taskToRemove))
                    {
                        Console.WriteLine("Task removed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Task not found!");
                    }
                    break;

                case 4:
                    Console.WriteLine("Exiting the application. Goodbye!");
                    runtime = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (runtime)
            {
                Console.WriteLine("\nDo you want to continue?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                int continueChoice = Convert.ToInt32(Console.ReadLine());

                if (continueChoice == 2)
                {
                    runtime = false;
                    Console.WriteLine("Exiting the application. Goodbye!");
                }
            }
        }
    }
}
