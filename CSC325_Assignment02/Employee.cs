using System;
using System.Globalization;

namespace CSC325_Assignment02
{
    struct Employee
    {
        public string name { get; private set; }
        public double salary { get; private set; }

        public static Func<Employee, Employee, bool> BySalary = (Employee i, Employee j) => i.salary < j.salary;
        public static Func<Employee, Employee, bool> ByName = (Employee i, Employee j) => i.name.CompareTo(j.name) < 0 ? true : false;
        public static Func<Employee, Employee, bool> equal = (Employee i, Employee j) => i.Equals(j);

        public Employee(string name, double salary) : this()
        {
            this.name = name;
            this.salary = salary;
        }

        public override string ToString()
        {
            return name + " " + salary.ToString("C", CultureInfo.CurrentCulture);
        }

        public override bool Equals(object obj)
        {
            Employee e1 = (Employee)obj;

            if (this.name.Equals(e1.name))
                if (this.salary == e1.salary)
                    return true;
            return false;
        }
    }
}
