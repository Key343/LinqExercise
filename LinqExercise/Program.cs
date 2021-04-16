using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());


            //Order numbers in ascending order and decsending order. Print each to console.

            var methodSyntaxExample1 = numbers.OrderBy(num => num);

            foreach (var num in methodSyntaxExample1)
            {
                Console.WriteLine(num);

            }

            var syntaxEx = numbers.OrderByDescending(num => num);

            foreach (var num in syntaxEx)
            {
                Console.WriteLine(num);
            }



            //Print to the console only the numbers greater than 6

            var methodSyntaxExample2 = numbers.Where(num => num > 6);

            foreach (var num in methodSyntaxExample2)
            {
                Console.WriteLine(num);
            }




            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            var first4 = numbers.Take(4);
            foreach (var num in first4)
            {
                Console.WriteLine(num);
            }


            //Change the value at index 4 to your age, then print the numbers in decsending order


            numbers[4] = 29;
            var methodSyntaxEx3 = numbers.OrderByDescending(num => num);

            foreach (var num in methodSyntaxEx3)
            {
                Console.WriteLine(num);
            }


            // List of employees ***Do not remove this***

            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var firstName = employees.FindAll(name => (name.FirstName[0] == 'c' || name.FirstName[0] == 'S')).OrderBy(x => x.FirstName);
            foreach (var fName in firstName)
            {
                Console.WriteLine(fName.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.

            var over26 = employees.Where(age => age.Age > 26);
            foreach (var age in over26)
            {
                Console.WriteLine($" {age.FullName} {age.Age}");
            }



            //Order this by Age first and then by FirstName in the same result.

            var ageFname = over26.OrderBy(age => age.Age).ThenBy(fname => fname.FirstName);


            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            int yrsOfExp = 0;
            var beginner = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35);
            foreach (var i in beginner)
            {
                yrsOfExp += i.YearsOfExperience;
            }
            int numOfEmp = beginner.Count();
            Console.WriteLine("YearsofExperience: " + yrsOfExp);
            Console.WriteLine("Average of YearsofExperience: " + yrsOfExp / numOfEmp);



            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Jackie","Chan", 11, 11)).ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FullName);
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
