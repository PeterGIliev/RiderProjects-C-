using System.Collections.Generic;

namespace OOP0011UniqueStudentNames
{
    public class StudentGroup
    {
        public static HashSet<Student> uniqueStudents;

        static StudentGroup()
        {
            uniqueStudents = new HashSet<Student>();
        }
        
//        public HashSet<Student> UniqueStudents => uniqueStudents;
    }
}