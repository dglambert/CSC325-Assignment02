using System;
using System.Threading;
using System.Collections.Generic;
using System.Globalization;

namespace CSC325_Assignment02
{
    class Program
    {
        private static Random rnd = new Random();
        
        static void Main(string[] args)
        {
            const int ELEMENTS = 5;
            Employee[] employees = null;
            Student[] students = null;

            employees = populateEmployees(employees, ELEMENTS);
            Thread.Sleep(500);
            students = populateStudents(students, ELEMENTS);
            
            outputStudents(students);
            outputMinStudent(students);
            Console.WriteLine();

            outputEmployees(employees);
            outputMinEmployee(employees);
            Console.WriteLine();

            searchStudents(students);
            Console.WriteLine();
            searchEmployees(employees);
            Console.WriteLine();    
        }
        
        static Student[] populateStudents(Student[] students, int elements)
        {
            students = new Student[elements];
            for (int i = 0; i < elements; i++)
                students[i] = new Student(NameGenerator(), SIDGenerator());
            return students;
        }

        static Employee[] populateEmployees(Employee[] employees, int elements)
        {
            employees = new Employee[elements];
            for (int i = 0; i < elements; i++)
                employees[i] = new Employee(NameGenerator(), SalaryGenerator());
            return employees;
        }

        static void outputStudents(Student[] students)
        {
            Console.WriteLine("Students:\n\n" + "SID\t\tName");
            foreach (Student s1 in students)
                Console.WriteLine(s1.sid + "\t\t" + s1.name);
        }

        static void outputEmployees(Employee[] employees)
        {
            Console.WriteLine("Employees:\n\n" + "Salary\t\tName");
            foreach (Employee e1 in employees)
                Console.WriteLine(String.Format("{0, 10}\t{1, -1}", e1.salary.ToString("C", CultureInfo.CurrentCulture), e1.name));
        }

        static void outputMinStudent(Student[] students)
        {
            Console.WriteLine("\nMin Student");
            Console.WriteLine("By SID: " + ArrayUtil<Student>.findMin<Student>(students, Student.BySID));
        }

        static void outputMinEmployee(Employee[] employees)
        {
            Console.WriteLine("\nMin Employee");
            Console.WriteLine("By Salary: \t" + ArrayUtil<Employee>.findMin<Employee>(employees, Employee.BySalary));
            Console.WriteLine("By Name: \t" + ArrayUtil<Employee>.findMin<Employee>(employees, Employee.ByName));
        }

        static void searchStudents(Student[] students)
        {
            Console.WriteLine("Search Students");
            Student searchTerms = inputStudent();

            int index = ArrayUtil<Student>.find<Student>(students, searchTerms, Student.equal);

            if (index != -1)
                Console.WriteLine(students[index] + " Found at index " + index);
            else
                Console.WriteLine("Student not in collection");

        }

        static void searchEmployees(Employee[] employees)
        {
            Console.WriteLine("Search Employees");
            Employee searchTerms = inputEmployee();

            int index = ArrayUtil<Employee>.find<Employee>(employees, searchTerms, Employee.equal);

            if (index != -1)
                Console.WriteLine(employees[index] + " Found at index " + index);
            else
                Console.WriteLine("Employee not in collection");

        }

        static Student inputStudent()
        {
            string name, sid;

            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            Console.Write("Enter SID: ");
            sid = Console.ReadLine();

            return new Student(name, sid);
        }

        static Employee inputEmployee()
        {
            string name;
            double salary;

            Console.Write("Enter Name: ");
            name = Console.ReadLine();

            do
            {
                Console.Write("Enter Salary: ");
            } while (!Double.TryParse(Console.ReadLine(), out salary));
            
            return new Employee(name, salary);
        }

        private static string NameGenerator()
        {
            string[] firsts = new[] { "devin", "beth", "albert", "mikhail", "frank", "mike", "steve", "joe", "beifang", "bo"};
            string[] lasts = new[] { "gleason-lambert", "van belle", "beltran", "brikman", "dalton", "hedel", "cutler", "kasprzyk", "yi", "hatfield" };

            return firsts[rnd.Next(firsts.Length-1)] + " " + lasts[rnd.Next(lasts.Length-1)];
        }

        private static double SalaryGenerator()
        {
            return Math.Round(rnd.NextDouble() * 100000, 2);
        }

        private static string SIDGenerator()
        {
            return rnd.Next(10000, 99999).ToString();
        }
    }
}
