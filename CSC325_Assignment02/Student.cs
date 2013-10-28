using System;
using System.Collections.Generic;

namespace CSC325_Assignment02
{
    struct Student
    {
        public string name { get; private set; }
        public string sid {get; private set;} //student ID
        private static Random rnd = new Random();

        public static Func<Student, Student, bool> BySID = (Student i, Student j) => i.sid.CompareTo(j.sid) < 0 ? true : false;
        public static Func<Student, Student, bool> equal = (Student i, Student j) => i.Equals(j);

        public Student(string name, string sid) : this()
        {
            this.name = name;
            this.sid = sid;
        }

        public override string ToString()
        {
            return name + " " + sid;
        }

        public override bool Equals(object obj)
        {
            Student s1 = (Student) obj;

            if (this.sid.Equals(s1.sid))
                if (this.name.Equals(s1.name))
                    return true;
            return false;
        }

    }
}
