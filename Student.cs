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
// Масив 
        private Exam[] _exams;

        public Student(Person person, Education education, int group)
        {
            _person = person;
            _education = education;
            _group = group;      
        }

        public Student() : this(person: new Person(), education: Education.Bachelor, group: 311) { }

        public Person Person
        {
            get => _person;
            init => _person = value;
        }

        public Education Education
        {
            get => _education;
            init => _education = value;
        }

        public int Group
        {
            get => _group;
            set => _group = value;
        }

        public Exam[] Exams
        {
            get => _exams;
            init => _exams = value;
        }

        public double AverageMark
        {
            get
            {
                if (Exams == null || Exams.Length == 0) return 0;

                return Exams.Average(exam => exam.Mark);

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

            if (_exams == null || _exams.Length == 0)
            {
                _exams = exams;
            }

            int currentLength = _exams.Length;
            Array.Resize(ref _exams, currentLength + exams.Length);

            for (int i = currentLength; i < _exams.Length; i++)
            {
                _exams[i] = exams[i - currentLength];
            }
        
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Person.ToString()}\n");
            sb.Append($"{Group}\n");
            sb.Append($"{Education}\n");

            if ( Exams != null)
            {
                foreach (var exam in Exams)
                {
                    sb.Append($"{exam.ToString()}\n");
                }
            }
            
           
            return sb.ToString();
        }

        public virtual string ToShortString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Person.ToString()}\n");
            sb.Append($"{Group}\n");

            sb.Append($"{AverageMark}");

            return sb.ToString();
        }

    }


}
