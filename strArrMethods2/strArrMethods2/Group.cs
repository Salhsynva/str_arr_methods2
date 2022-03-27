using System;
using System.Collections.Generic;
using System.Text;

namespace strArrMethods2
{
    class Group
    {
        public string No;
        public Student[] Students;
        public int StudentLimit;

        int j = 0;
        public void AddStudent(Student student)
        {
            if (j < StudentLimit)
            {
                Students[j] = student;
                j++;
            }
            else
            {
                Console.WriteLine("telebe limiti dolub!");
            }
        }

    }
}
