using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab1
{ 
    public class Student : Person
    {
        //private Person _person;
        private Education _education;
        private int _group;
// Масив 
        private List<Exam> _exams;
        private List<Test> _tests;

        private SortedList<string, Exam> _examsSortedBySubject;
        private SortedList<string, Test> _testsSortedBySubject;

        private ImmutableList<Exam> _examsImmutable = ImmutableList<Exam>.Empty;
        private ImmutableList<Test> _testsImmutable = ImmutableList<Test>.Empty;

        public Student(Person person, Education education, int group)
            : base(person.Name, person.Surname, person.Date)
        {
            Education = education;
            Group = group;
            if (Exams is not null && Exams.Count > 0 || Tests is not null && Tests.Count > 0)
            {
                InitCollections();
            }
        }

        public Student() : this(person : new Person(), education: Education.Bachelor, group: 311) { }

        public void InitCollections()
        {
            _examsSortedBySubject = new SortedList<string, Exam>();
            _testsSortedBySubject = new SortedList<string, Test>();

            if (Exams != null)
            {
                foreach (var exam in Exams)
                {
                    ExamsSorted[exam.SubjectName] = exam;
                }

                _examsImmutable = _exams.ToImmutableList();
            }

            if (Tests != null)
            {
                foreach (var test in Tests)
                {
                    TestsSorted[test.SubjectName] = test;
                }

                _testsImmutable = _tests.ToImmutableList();
            }
        }

        public SortedList<string, Exam> ExamsSorted { get => _examsSortedBySubject; private set => _examsSortedBySubject = value; }

        public SortedList<string, Test> TestsSorted { get => _testsSortedBySubject; private set => _testsSortedBySubject = value; }

        public ImmutableList<Exam> ExamsImmutable { get => _examsImmutable; private set => _examsImmutable = value; }

        public ImmutableList<Test> TestsImmutable { get => _testsImmutable; private set => _testsImmutable = value; }

        public Person Person
        {
            get => this;
            init {
                Name = value.Name;
                Surname = value.Surname;
                Date = value.Date;
            }
        }

        public Education Education
        {
            get => _education;
            set => _education = value;
        }

        public int Group
        {
            get => _group;
            set
            {
                if (value <= 100 || value > 699)
                {
                    throw new ArgumentOutOfRangeException(
                        "Group",
                        "Group number mast be from 101 to 699 inclusive."
                    );
                }
                _group = value;
            }
        }

        public List<Exam> Exams
        {
            get => _exams;
            init => _exams = value;
        }

        public List<Test> Tests
        {
            get=> _tests;
            init => _tests = value;
        }

        public double AverageMarkSorted
        {
            get
            {
                if (ExamsSorted is null || ExamsSorted.Count == 0)
                    return 0;

                return ExamsSorted.Values.Average(e => e.Mark);
            }
        }

        public double AverageMarkImmutable
        {
            get
            {
                if (ExamsImmutable is null || ExamsImmutable.Count == 0)
                    return 0;

                return ExamsImmutable.Average(e => e.Mark);
            }
        }

        public double AverageMark
        {
            get
            {
                double sum = 0;

                if (Exams is null || Exams.Count == 0) return 0;

                foreach (Exam element in Exams)
                {
                    if (element is null)
                    {
                        throw new InvalidOperationException("All elements in Exams must be of type Exam.");
                    }
                    sum += element.Mark;
                }

                return sum / Exams.Count;

            }
        }
        
        public bool this[Education edu] => Education == edu;
       

        public void AddExams(params Exam[] exams)
        {
            if (exams is null || exams.Length == 0)
            {
                return;
            }
            //{
            //    _exams = new Exam[exams.Length];
            //}

            if (Exams is null || Exams.Count == 0)
            {
                _exams = [];
            }

            _examsSortedBySubject ??= new SortedList<string, Exam>();

            //int currentLength = _exams.Length;
            //Array.Resize(ref _exams, currentLength + exams.Length);

            for (int i = 0; i < exams.Length; i++)
            {
                Exams.Add(exams[i]);
                ExamsSorted.Add(exams[i].SubjectName, exams[i]);
            }

            _examsImmutable = Exams.ToImmutableList();

        }

        public void AddTests(params Test[] tests)
        {
            if (tests is null || tests.Length == 0)
            {
                return;
            }

            if (Tests is null || Tests.Count == 0)
            {
                _tests = [];
            }

            _testsSortedBySubject ??= new SortedList<string, Test>();

            for (int i = 0; i < tests.Length; i++)
            {              
                Tests.Add(tests[i]);
                TestsSorted.Add(tests[i].SubjectName, tests[i]);
            }
            _testsImmutable = _tests.ToImmutableList();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{base.ToString()}\n");
            sb.Append($"{Group}\n");
            sb.Append($"{Education}\n");

            if ( Exams != null)
            {
                foreach (var exam in Exams)
                {
                    sb.Append($"{exam.ToString()}\n");
                }
            }
            

            if (Tests != null)
            {
                sb.Append("\n\n");
                foreach (var test in Tests)
                {
                    sb.Append($"{test.ToString()}\n");
                }
            }

            return sb.ToString();
        }

        public override string ToShortString()
        {
            StringBuilder sb = new();

            sb.Append($"{Person.ToString()}\n");
            sb.Append($"{Group}\n");
            sb.Append($"{Education}\n");
            sb.Append($"{AverageMark}");
            sb.Append($"\nExams count: {Exams?.Count ?? 0}\n");
            sb.Append($"Tests count: {Tests?.Count ?? 0}");

            return sb.ToString();
        }
// Поелементно зробити копії
        public override object DeepCopy()
        {
            using MemoryStream ms = new();
            JsonSerializer.Serialize(ms, this);
            ms.Position = 0;
            return JsonSerializer.Deserialize<Student>(ms)!;
        }

        public bool Save(string filename)
        {
            FileStream? fs = null;
            try
            {
                fs = new FileStream("../../../SerializedObjects/" + filename, FileMode.Create);
                JsonSerializer.Serialize(fs, this); // напряму у FileStream
                return true;
            }
            catch (UnauthorizedAccessException) { return false; }  // немає прав на читання
            catch (IOException) { return false; }  // файл зайнятий іншим процесом
            catch (JsonException) { return false; }  // файл пошкоджений або невірний формат
            catch (Exception) { return false; }            
            finally
            {
                fs?.Dispose();
            }
        }

        public bool Load(string filename)
        {
            FileStream fs = null;

            //Person savedPerson = this.Person;
            //int savedGroup = this.Group;
            //Education savedEducation = this.Education;
            //List<Exam> savedExams = this.Exams;
            //List<Test> savedTests = this.Tests;

            try
            {
                fs = new FileStream("../../../SerializedObjects/" + filename, FileMode.Open);
                Student temp = JsonSerializer.Deserialize<Student>(fs)!;
                //Person savedPerson = temp.Person;
                //int savedGroup = temp.Group;
                //Education savedEducation = temp.Education;
                //List<Exam> savedExams = temp.Exams;
                //List<Test> savedTests = temp.Tests;

                if (temp is null || temp.Person is null || temp.Group <= 100 || temp.Group > 699)
                {
                    return false;
                }

                _name = temp.Name;
                _surname = temp.Surname;
                _dateBirth = temp.Date;
                Group = temp.Group;
                Education = temp.Education;
                _exams = temp.Exams;         
                _tests = temp.Tests;

                InitCollections();

                return true;
            }
            catch (FileNotFoundException) 
            { 
                return false; 
            }  // файл не існує
            catch (UnauthorizedAccessException) { return false; }  // немає прав на читання
            catch (IOException) { return false; }  // файл зайнятий іншим процесом
            catch (JsonException) { return false; }  // файл пошкоджений або невірний формат
            catch (Exception) { return false; }
            finally
            {
                fs?.Dispose();
            }
        }

        public static bool Save(string filename, Student obj)
        {
            return obj.Save(filename);
        }

        public static bool Load(string filename, Student obj)
        {
            return obj.Load(filename);
        }

        public bool AddFromConsole()
        {
            Console.WriteLine("Введіть дані екзамену у форматі:");
            Console.WriteLine("Назва предмету / Оцінка / Дата (дд.мм.рррр)");
            Console.WriteLine("Розділювачі: '/' або ',' або ';'");
            Console.Write(">>> ");

            string input = Console.ReadLine() ?? "";

            try
            {

                string[] parts = input.Split(new char[] { '/', ',', ';' },
                                             StringSplitOptions.TrimEntries);

                if (parts.Length != 3)
                    throw new FormatException("Невірна кількість елементів.");

                string subject = parts[0];
                int grade = int.Parse(parts[1]);
                DateTime date = DateTime.Parse(parts[2]);

                Exams.Add(new Exam(subject, grade, date));
                return true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Помилка формату: {ex.Message}");
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Помилка: значення оцінки виходить за межі допустимого діапазону.");
                return false;
            }
        }

        public IEnumerable GetAllElements()
        {
            foreach (Exam element in Exams)
            {
                yield return element;
            }
            foreach (Test element in Tests)
            {
                yield return element;
            }
        }

        public IEnumerable<Exam> GetExamsByMinGrade(int minGrade)
        {
            foreach (Exam exam in Exams)
            {
                if (exam.Mark >= minGrade)
                {
                    yield return exam;
                }
            }
        }

        public IEnumerable GetStudentEnumerator()
        {
            return new StudentEnumerator(Tests, Exams);
        }

        public IEnumerable GetPassedExamsAndTests()
        {
            foreach (Test test in Tests)
            {
                if (test.IsPassed) 
                    yield return test;
            }

            foreach (Exam exam in Exams)
            {
                if (exam.Mark > 2) 
                    yield return exam;
            }
        }

        public IEnumerable GetPassedTestsWithExam()
        {
            foreach (Test test in Tests)
            {
                if (!test.IsPassed) continue; 

                
                foreach (Exam exam in Exams)
                {
                    if (exam.SubjectName == test.SubjectName && exam.Mark > 2)
                    {
                        yield return test.SubjectName; 
                        break;
                    }
                }
            }
        }
    }


}
