using lab1;
using lab1.Collections;

StudentCollection studentCollection = new();
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
Console.WriteLine("--- Sort by surname ---");
studentCollection.SortBySurname();
Console.WriteLine(studentCollection);
Console.WriteLine("\n- compare with immutable -\n");
Console.WriteLine(studentCollection.ToStringImmutable());

Console.WriteLine("\n--- Sort by date ---");
studentCollection.SortByDate();
Console.WriteLine(studentCollection);
Console.WriteLine("\n- compare with immutable -\n");
Console.WriteLine(studentCollection.ToStringImmutable());

Console.WriteLine("\n--- Sort by average mark ---");
studentCollection.SortByAverageMark();
Console.WriteLine(studentCollection);
Console.WriteLine("\n- compare with immutable -\n");
Console.WriteLine(studentCollection.ToStringImmutable());

Console.WriteLine("\n- compare with sorted one (sorted) -");
Console.WriteLine(studentCollection.ToStringSotedLists());

Console.WriteLine("\n--- Max average mark ---");
Console.WriteLine(studentCollection.MaxAverageMark);
Console.WriteLine("\n--- Max average mark sorted ---");
Console.WriteLine(studentCollection.MaxAverageMarkSorted);
Console.WriteLine("\n--- Max average mark immutable ---");
Console.WriteLine(studentCollection.MaxAverageMarkImmutable);

Console.WriteLine("\n--- Education Master ---");
foreach (Student st in studentCollection.EducationMaster)
{
    Console.WriteLine(st);
    Console.WriteLine();
}
Console.WriteLine("\n--- Education Master Sorted ---");
foreach (Student st in studentCollection.EducationMasterSorted)
{
    Console.WriteLine(st);
    Console.WriteLine();
}
Console.WriteLine("\n--- Education Master Immutable ---");
foreach (Student st in studentCollection.EducationMasterImmutable)
{
    Console.WriteLine(st);
    Console.WriteLine();
}

Console.WriteLine("\n--- Average mark Group ---");
foreach (Student st in studentCollection.AverageMarkGroup(4.5))
{
    Console.WriteLine(st);
    Console.WriteLine();
}
Console.WriteLine("\n--- Average mark Group Sorted ---");
foreach (Student st in studentCollection.AverageMarkGroupSorted(4.5))
{
    Console.WriteLine(st);
    Console.WriteLine();
}
Console.WriteLine("\n--- Average mark Group Immutable ---");
foreach (Student st in studentCollection.AverageMarkGroupImmutable(4.5))
{
    Console.WriteLine(st);
    Console.WriteLine();
}

Console.WriteLine("--- Average mark Group Print ---");
studentCollection.AvarageMarkGroupPrint();

Console.WriteLine("\n\n--- TESTS ---");

int count;

while (true)
{
    try
    {
        Console.WriteLine("Введіть кількість елементів:");

        string input = Console.ReadLine();

        if (!int.TryParse(input, out count))
            throw new Exception("Введено не число.");

        if (count < 0)
            throw new Exception("Число не може бути від'ємним.");

        break; // якщо все добре — виходимо з циклу
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Помилка: {ex.Message}");
        Console.WriteLine("Спробуйте ще раз.\n");
    }
}

TestCollections testCollections = new(count);
Console.WriteLine("\n--- Search Tests Normal ---\n");
testCollections.SearchTests();
Console.WriteLine("\n--- Search Tests Immutable ---\n");
testCollections.SearchTestsImmutable();
Console.WriteLine("\n--- Search Tests Sorted ---\n");
testCollections.SearchTestsSorted();