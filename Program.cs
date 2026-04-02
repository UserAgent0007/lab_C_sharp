using lab1;
using lab1.Collections;
using lab1.Event;

Student st1 = new Student
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
};

Student st2 = (Student)st1.DeepCopy();

st2.Education = Education.Master;
st2.AddExams(new Exam("Chemistry", 3, new DateTime(2023, 3, 1)));

Console.WriteLine("Original Student:");
Console.WriteLine( st1.ToString());

Console.WriteLine("Copy student");
Console.WriteLine( st2.ToString());

//st1.Save("studentData.json");

string input = Console.ReadLine() ?? "";
if (File.Exists("../../../SerializedObjects/" + input))
{
    st2.Load(input);
}
else
{
    st2.Save(input);
} 

Console.WriteLine("Loaded student:");
Console.WriteLine(st2.ToString());

while (!st2.AddFromConsole())
{
    Console.WriteLine("Enter again:");
}

st2.Save(input);

Console.WriteLine("Updated student:");
Console.WriteLine(st2.ToString());

Student.Load(input, st2);
while (!st2.AddFromConsole())
{
    Console.WriteLine("Enter again:");
}

Student.Save(input, st2);

Console.WriteLine("Update student:");
Console.WriteLine(st2.ToString());