using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
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

        public SortedList<string, Exam> ExamsSorted => _examsSortedBySubject;

        public SortedList<string, Test> TestsSorted => _testsSortedBySubject;

        public ImmutableList<Exam> ExamsImmutable => _examsImmutable;

        public ImmutableList<Test> TestsImmutable => _testsImmutable;

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
            Student copy = new()
            {
                Exams = [],
                Tests = [],
                Person = (Person) this.Person.DeepCopy(),
                Group = this.Group,
                Education = this.Education
            };
            if (Exams != null)
            {
                foreach(Exam elem in Exams)
                {
                    copy.Exams.Add((Exam)elem.DeepCopy());
                }                
            }
            if (Tests != null)
            {
                foreach (Test elem in Tests)
                {
                    copy.Tests.Add((Test)elem.DeepCopy());
                }
            }
            copy.InitCollections();
            return copy;
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
