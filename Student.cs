using System;
using System.Collections;
using System.Collections.Generic;
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
        private ArrayList _exams;
        private ArrayList _tests;

        public Student(Person person, Education education, int group)
            : base(person.Name, person.Surname, person.Date)
        {
            //_person = person;
            Education = education;
            Group = group;      
        }

        public Student() : this(person : new Person(), education: Education.Bachelor, group: 311) { }

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
            init => _education = value;
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

        public ArrayList Exams
        {
            get => _exams;
            init => _exams = value;
        }

        public ArrayList Tests
        {
            get=> _tests;
            init => _tests = value;
        }

        public double AverageMark
        {
            get
            {
                double sum = 0;

                if (Exams == null || Exams.Count == 0) return 0;

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
            if (exams == null || exams.Length == 0)
            {
                return;
            }
            //{
            //    _exams = new Exam[exams.Length];
            //}

            if (_exams == null || _exams.Count == 0)
            {
                _exams = [];
            }

            //int currentLength = _exams.Length;
            //Array.Resize(ref _exams, currentLength + exams.Length);

            for (int i = 0; i < exams.Length; i++)
            {
                _exams.Add(exams[i]);
            }
        
        }

        public void AddTests(params Test[] tests)
        {
            if (tests == null || tests.Length == 0)
            {
                return;
            }

            if (_tests == null || _tests.Count == 0)
            {
                _tests = [];
            }
            
            for (int i = 0; i < tests.Length; i++)
            {              
                _tests.Add(tests[i]);
            }
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
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Person.ToString()}\n");
            sb.Append($"{Group}\n");
            sb.Append($"{Education}\n");
            sb.Append($"{AverageMark}");

            return sb.ToString();
        }
// Поелементно зробити копії
        public override object DeepCopy()
        {
            Student copy = new()
            {
                Exams = [],
                Tests = [],
                Person = this.Person,
                Group = this.Group,
                Education = this.Education
            };
            if (Exams != null)
            {
                foreach(Exam elem in Exams)
                {
                    copy.Exams.Add(elem.DeepCopy());
                }                
            }
            if (Tests != null)
            {
                foreach (Test elem in Tests)
                {
                    copy.Tests.Add(elem.DeepCopy());
                }
            }
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
            foreach (Test test in _tests)
            {
                if (test.IsPassed) 
                    yield return test;
            }

            foreach (Exam exam in _exams)
            {
                if (exam.Mark > 2) 
                    yield return exam;
            }
        }

        public IEnumerable GetPassedTestsWithExam()
        {
            foreach (Test test in _tests)
            {
                if (!test.IsPassed) continue; 

                
                foreach (Exam exam in _exams)
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
