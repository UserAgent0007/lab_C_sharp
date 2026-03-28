using lab1;
using lab1.Event;
using lab1.Сomparers;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace lab1.Collections
{
    public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);
    internal class StudentCollection
    {
        public string CollectionName { get; set; } = "StudentCollection";
        public event StudentListHandler StudentCountChanged;
        public event StudentListHandler StudentReferenceChanged;

        private List<Student>? _studentList;
        public List<Student> StudentList { get => _studentList ?? []; }
       
        public void AddDefaults()
        {
            _studentList ??= [];           
            Student st1 = new Student();
            Student st2 = new Student();

            StudentList.Add(st1);
            StudentList.Add(st2);
            OnStudentCountChanged(new StudentListHandlerEventArgs(CollectionName, "Added new Student", st1));
            OnStudentCountChanged(new StudentListHandlerEventArgs(CollectionName, "Added new Student", st2));
        }

        public void AddStudents(params Student[] students)
        {
            _studentList ??= [];
            StudentList.AddRange(students.Where(s=> s is not null));

            foreach (Student st in students.Where(s => s is not null))
            {
                OnStudentCountChanged(new StudentListHandlerEventArgs(CollectionName, "Added new Student", st));
            }
                   
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("StudentCollection:\n");

            foreach (Student st in StudentList ?? [])
            {
                sb.AppendLine(st.ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string ToShortString()
        {
            StringBuilder sb = new();
            sb.AppendLine("StudentCollection:\n");

            foreach (Student st in StudentList ?? [])
            {
                sb.AppendLine(st.ToShortString());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void SortBySurname() 
        { 
            StudentList?.Sort();
        }
        public void SortByDate()
        { 
            StudentList?.Sort(new Person());
        }
        public void SortByAverageMark()
        {
            StudentList?.Sort(new StudentAverageMarkComparer());
        }


        public double MaxAverageMark { get => StudentList?.Select(s => s.AverageMark).DefaultIfEmpty().Max() ?? 0;}
        public IEnumerable<Student> EducationMaster  { get => StudentList.Where(st => st.Education == Education.Master);}        
        public List<Student> AverageMarkGroup(double value)
        {
            return StudentList
                .GroupBy(s => s.AverageMark)
                .Where(g => g.Key == value)
                .SelectMany(g => g)
                .ToList();
        }
        public void AvarageMarkGroupPrint()
        {
            var groups = StudentList.GroupBy(s => s.AverageMark);

            foreach (var group in groups)
            {
                Console.WriteLine($"AverageMark: {group.Key}");

                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }

                Console.WriteLine();
            }
        }

        public bool Remove(int j)
        {
            if (j < 0 || j >= StudentList.Count)
            {
                return false;
            }
            Student st = StudentList[j];
            StudentList.RemoveAt(j);
            OnStudentCountChanged(new StudentListHandlerEventArgs(CollectionName, $"Removed {j} student", st));
            return true;
        }

        public Student this[int index]
        {
            get
            {
                if (index < 0 || index >= StudentList.Count)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }
                Student student = StudentList[index];
                return student;
            }
            set
            {
                if (index >= 0 && index < StudentList.Count)
                {
                    StudentList[index] = value;
                    OnStudentReferenceChanged(new StudentListHandlerEventArgs(CollectionName, $"New reference. {index} student", value));
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index does not exists");
                }
            }
        }

        protected virtual void OnStudentCountChanged(StudentListHandlerEventArgs e) => StudentCountChanged?.Invoke(this, e);
        protected virtual void OnStudentReferenceChanged(StudentListHandlerEventArgs e) => StudentReferenceChanged?.Invoke(this, e);
    }
}
