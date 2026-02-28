using lab1;

Student[][] JaggedArray(int rows, int totalElements, Random rand)
{
    Student[][] array = new Student[rows][];
    int baseSize = totalElements / rows;
    int remainder = totalElements % rows;

    int[] rowSizes = new int[rows];
    for (int i = 0; i < rows; i++) rowSizes[i] = baseSize;
    for (int i = 0; i < remainder; i++) rowSizes[i]++;

    for (int k = 0; k < 1000; k++)
    {
        int from = rand.Next(rows);
        int to = rand.Next(rows);
        if (from != to && rowSizes[from] > 1 && rowSizes[to] < totalElements / 2)
        {
            rowSizes[from]--;
            rowSizes[to]++;
        }
    }

    for (int i = 0; i < rows; i++)
    {
        array[i] = new Student[rowSizes[i]];
        for (int j = 0; j < rowSizes[i]; j++)
        {
            array[i][j] = new Student();
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
    education = Education.Master,
    exams = new List<Exam> { new Exam(), new Exam(), new Exam(), new Exam() },
    group = 301,
    person = new Person()
};

Console.WriteLine(st2);

// ===
Console.WriteLine("\n");

st2.AddExams(new Exam[] { new Exam(), new Exam(), new Exam(), new Exam() });

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

Student[][] stud_jagged = JaggedArray(nRows, total, new Random());

int start = 0;
int end = 0;

start = Environment.TickCount;
foreach (var student in stud_vector) student.group = 100;
end = Environment.TickCount;

int d1_array_time = end - start;

start = Environment.TickCount;
foreach (var student in stud_matr)
{
    for (int j = 0; j < nCols; j++)
    {
        student.group = 100;
    }
}
end = Environment.TickCount;

int d2_array_time = end - start;

start = Environment.TickCount;
foreach(var student in stud_jagged)
{
    for (int j = 0; j < student.Length; j++)
    {
        student[j].group = 100;
    }
}
end = Environment.TickCount;

int d2Jagged_time = end - start;

Console.WriteLine($"1d time = {d1_array_time}\n2d time = {d2_array_time}\n2d jagged = {d2Jagged_time}");