using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Student
    {
        private Person _person;
        private Education _education;
        private int _group;
        private List<Exam> _exams;

        public Student(Person person, Education education, int group)
        {
            _person = person;
            _education = education;
            _group = group;      
        }

        public Student() : this(person: new Person(), education: Education.Bachelor, group: 311) { }

        public Person person
        {
            get => _person;
            init => _person = value;
        }

        public Education education
        {
            get => _education;
            init => _education = value;
        }

        public int group
        {
            get => _group;
            set => _group = value;
        }

        public List<Exam> exams
        {
            get => _exams;
            init => _exams = value;
        }

        public double AverageMark
        {
            get
            {
                if (exams == null || exams.Count == 0) return 0;

                return exams.Average(exam => exam.mark);

            }
        }
        
        public bool this[Education edu]
        {
            get => education == edu;
        }

        public void AddExams(params Exam[] exams)
        {
            if (_exams == null)
            {
                _exams = new List<Exam>();
            }

            foreach (var exam in exams)
            {
                if (exam != null)
                {
                    _exams.Add(exam);
                }
            }
        
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{person.ToString()}\n");
            sb.Append($"{group}\n");
            sb.Append($"{education}\n");

            if ( exams != null)
            {
                foreach (var exam in exams)
                {
                    sb.Append($"{exam.ToString()}\n");
                }
            }
            
           
            return sb.ToString();
        }

        public virtual string ToShortString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{person.ToString()}\n");
            sb.Append($"{group}\n");

            sb.Append($"{AverageMark}");

            return sb.ToString();
        }

    }


}
