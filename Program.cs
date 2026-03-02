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

Student[] stud_vector = new Student[total];
Student[,] stud_matr = new Student[nRows, nCols];

for (int i = 0; i < nRows; i++)
{
    for (int j = 0; j < nCols; j++)
    {
        Student student = new Student();
        stud_vector[i * nCols + j] = student;
        stud_matr[i, j] = student;
    }
}

Student[][] stud_jagged = JaggedArray(total);

int start = 0;
int end = 0;

start = Environment.TickCount;
foreach (var student in stud_vector) student.Group = 100;
end = Environment.TickCount;

int d1_array_time = end - start;

start = Environment.TickCount;
foreach (var student in stud_matr)
{
    for (int j = 0; j < nCols; j++)
    {
        student.Group = 100;
    }
}
end = Environment.TickCount;

int d2_array_time = end - start;

start = Environment.TickCount;
foreach(var student in stud_jagged)
{
    for (int j = 0; j < student.Length; j++)
    {
        student[j].Group = 100;
    }
}
end = Environment.TickCount;

int d2Jagged_time = end - start;

Console.WriteLine($"1d time = {d1_array_time}\n2d time = {d2_array_time}\n2d jagged = {d2Jagged_time}");