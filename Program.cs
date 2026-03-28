using lab1;
using lab1.Collections;
using lab1.Event;

StudentCollection studentCollection = new();
StudentCollection studentCollection2 = new();
studentCollection.CollectionName = "Test";
studentCollection2.CollectionName = "Test Test";

Journal journal = new Journal();
Journal journal2 = new Journal();
studentCollection2.StudentReferenceChanged += journal2.OnStudentReferenceChanged;
studentCollection2.StudentCountChanged += journal2.OnStudentCountChanged;

studentCollection.StudentReferenceChanged += journal2.OnStudentReferenceChanged;
studentCollection.StudentCountChanged += journal2.OnStudentCountChanged;

studentCollection.StudentCountChanged += journal.OnStudentCountChanged;
studentCollection.StudentReferenceChanged += journal.OnStudentReferenceChanged;

studentCollection.AddStudents(
    new Student
    {
        Person = new Person("John", "Doe", new DateTime(2000, 1, 1)),
        Education = Education.Bachelor,
        Group = 311,
        Exams = new List<Exam>
        {
            new Exam("Math", 5, new DateTime(2023, 1, 1)),
            new Exam("Physics", 4, new DateTime(2023, 2, 1))
        },
        Tests = new List<Test>
        {
            new Test("Programming", true, DateTime.Now)
        }
    },
    new Student
    {
        Person = new Person("Jane", "Smith", new DateTime(1999, 5, 15)),
        Education = Education.Master,
        Group = 312,
        Exams = new List<Exam>
        {
            new Exam("Math", 4, new DateTime(2023, 1, 1)),
            new Exam("Chemistry", 2, new DateTime(2023, 2, 1))
        },
        Tests = new List<Test>
        {
            new Test("Programming", true, DateTime.Now)
        }
    },
    new Student
    {
        Person = new Person("Alice", "Johnson", new DateTime(2001, 3, 10)),
        Education = Education.Bachelor,
        Group = 311,
        Exams = new List<Exam>
        {
            new Exam("Math", 1, new DateTime(2023, 1, 1)),
            new Exam("Biology", 1, new DateTime(2023, 2, 1))
        },
        Tests = new List<Test>
        {
            new Test("Programming", false, DateTime.Now)
        }
    }
);
studentCollection.Remove(1);

studentCollection2.AddStudents(
    new Student
    {
        Person = new Person("John", "Doe", new DateTime(2000, 1, 1)),
        Education = Education.Bachelor,
        Group = 311,
        Exams = new List<Exam>
        {
            new Exam("Math", 5, new DateTime(2023, 1, 1)),
            new Exam("Physics", 4, new DateTime(2023, 2, 1))
        },
        Tests = new List<Test>
        {
            new Test("Programming", true, DateTime.Now)
        }
    },
    new Student
    {
        Person = new Person("Jane", "Smith", new DateTime(1999, 5, 15)),
        Education = Education.Master,
        Group = 312,
        Exams = new List<Exam>
        {
            new Exam("Math", 4, new DateTime(2023, 1, 1)),
            new Exam("Chemistry", 2, new DateTime(2023, 2, 1))
        },
        Tests = new List<Test>
        {
            new Test("Programming", true, DateTime.Now)
        }
    },
    new Student
    {
        Person = new Person("Alice", "Johnson", new DateTime(2001, 3, 10)),
        Education = Education.Bachelor,
        Group = 311,
        Exams = new List<Exam>
        {
            new Exam("Math", 1, new DateTime(2023, 1, 1)),
            new Exam("Biology", 1, new DateTime(2023, 2, 1))
        },
        Tests = new List<Test>
        {
            new Test("Programming", false, DateTime.Now)
        }
    }
);
studentCollection2[1].Education = Education.SecondEducation;
studentCollection2[0] = new Student();
Console.WriteLine("\nFirst Journal");
Console.WriteLine(journal);
Console.WriteLine("\nSecond Journal");
Console.WriteLine(journal2);