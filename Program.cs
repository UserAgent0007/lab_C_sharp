using lab1;

Person p1  = new Person();
Person p2 = new Person("Ivan", "Ivanov", new DateTime(2000, 1, 1));
Person p3 = new Person();
Person p4 = p1;

Console.WriteLine(p1 == p2); // False
Console.WriteLine(p1 == p3); 
Console.WriteLine(p1 == p4);

Console.WriteLine("\nHash codes");
Console.WriteLine(p1.GetHashCode());
Console.WriteLine(p3.GetHashCode());

Student s1 = new Student(p1, Education.Bachelor, 301);
s1.AddExams(new Exam[] {
    new Exam("Math", 5, new DateTime(2023, 6, 1)),
    new Exam("Physics", 4, new DateTime(2023, 6, 2)),
    new Exam("English", 1, new DateTime(2024, 6, 2)),});
Console.WriteLine("\nStudent:");
Console.WriteLine(s1);

Console.WriteLine("\nStudent's personality: ");
Console.WriteLine(s1.Person);

Student s1Copy = (Student)s1.DeepCopy();
s1.Group = 311;

Console.WriteLine($"\nDifferences:\n{s1Copy.Group}\n{s1.Group}");

Console.WriteLine("\nErrors");
try
{
    s1.Group = 700;
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\nSubjects with mark Grater");

foreach (var subject in s1.GetExamsByMinGrade(3))
{
    Console.WriteLine(subject);
}

s1.AddTests(new Test[]
{
    new Test("Math", true, new DateTime(2023, 6, 1)),
    new Test("Physicshasjdhas", false, new DateTime(2023, 6, 1)),
    //new Test("English", true),
});

Console.WriteLine("\nExams and Tests:");
foreach (var element in s1.GetStudentEnumerator())
{
    Console.WriteLine(element);
}

Console.WriteLine("\nPassed exams and tests:");
foreach (var element in s1.GetPassedExamsAndTests())
{
    Console.WriteLine(element);
}

Console.WriteLine("\nPassed exams with tests:");
foreach(var element in s1.GetPassedTestsWithExam())
{
    Console.WriteLine(element);
}