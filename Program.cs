using lab1;
using System.Security.Cryptography;

Student[][] JaggedArray(int totalElements)
{
    
    int countRows = 0;
    int currentElements = 0;
    int right = 0;
    int delta = 0;

    while (currentElements < totalElements)
    {
        right += 1;

        delta = 0;

        for (int i = 0; i < right; i++)
        {
            currentElements++;
            delta++;

            if (currentElements == totalElements)
            {
                break;
            }
        }

        countRows++;
    }

    Student[][] array = new Student[countRows][];

    for (int i = 0; i < countRows - 1; i++)
    {
        array[i] = new Student[i + 1];

        for (int j = 0; j < i + 1; j++)
        {
            array[i][j] = new Student();
        }
    }

    if (delta != 0)
    {
        array[countRows - 1] = new Student[delta];

        for (int i =0; i < delta; i++)
        {
            array[countRows - 1][i] = new Student();
        }
    }

    return array;
    
}

Student st1 = new Student();

Console.WriteLine(st1);

Console.WriteLine(st1.ToShortString());

// ===

Console.WriteLine(st1[Education.Master]);
Console.WriteLine(st1[Education.Bachelor]);
Console.WriteLine(st1[Education.SecondEducation]);

// ===
Console.WriteLine("\n");
Student st2 = new Student()
{
    Education = Education.Master,
    Exams = new Exam[] { new Exam(), new Exam(), new Exam(), new Exam() },
    Group = 301,
    Person = new Person()
};

Console.WriteLine(st2);

// ===
Console.WriteLine("\n");

//Student st3 = new Student();
st2.AddExams(new Exam[] { new Exam(), new Exam(), new Exam() });

Console.WriteLine(st2);


// ===

var line = Console.ReadLine() ?? "";
var parts = line.Split([' ', ',', ';', '\t'], StringSplitOptions.RemoveEmptyEntries);

var nRows = int.Parse(parts[0]);
var nCols = int.Parse(parts[1]);

int total = nRows * nCols;

Student[] studVector = new Student[total];
Student[,] studMatr = new Student[nRows, nCols];

for (int i = 0; i < nRows; i++)
{
    for (int j = 0; j < nCols; j++)
    {
        Student student1 = new Student();
        Student student2 = new Student();
        studVector[i * nCols + j] = student1;
        studMatr[i, j] = student2;
    }
}

Student[][] studJagged = JaggedArray(total);

int start = 0;
int end = 0;

start = Environment.TickCount;
foreach (var student in studVector) student.Group = 100;
end = Environment.TickCount;

int d1ArrayTime = end - start;

start = Environment.TickCount;
for (int i = 0; i < nRows; i++)
{
    for (int j = 0; j < nCols; j++)
    {
        studMatr[i,j].Group = 100;
    }
}
end = Environment.TickCount;

int d2ArrayTime = end - start;

start = Environment.TickCount;
foreach(var student in studJagged)
{
    for (int j = 0; j < student.Length; j++)
    {
        student[j].Group = 100;
    }
}
end = Environment.TickCount;

int d2JaggedTime = end - start;

Console.WriteLine($"1d time = {d1ArrayTime}\n2d time = {d2ArrayTime}\n2d jagged = {d2JaggedTime}");