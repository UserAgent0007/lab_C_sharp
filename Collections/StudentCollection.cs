using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using lab1;
using lab1.Сomparers;

namespace lab1.Collections
{
    internal class StudentCollection
    {
        private List<Student>? _studentList;
        private SortedList<Person, Student> _studentsSorted;
        private SortedList<Person, Student> _studentsSortedByDate;
        private SortedList<Student, Student> _studentsSortedByAverageMark;

        private ImmutableList<Student> _studentsImmutable;

        public List<Student> StudentList { get => _studentList ?? []; }

        public ImmutableList<Student> StudentIm
        {
            get => _studentsImmutable ?? ImmutableList<Student>.Empty;

        }

        public SortedList<Person, Student> StudentsSortedByDate
        {
            get => _studentsSortedByDate;
        }

        public SortedList<Student, Student> StudentsSortedByAverageMark
        {
            get => _studentsSortedByAverageMark;
        }

        public SortedList<Person, Student> DefaultSortedList
        {
            get => _studentsSorted;
        }

        public void SetStudentImAsOrig()
        {
            if (StudentList is null)
            {
                _studentsImmutable = ImmutableList<Student>.Empty;
                
            }
            else
            {
                _studentsImmutable = StudentList.Where(s => s is not null).ToImmutableList();
            }
            
        }

        public void AddDefaults()
        {
            _studentList ??= [];

            _studentsSorted ??= [];
            _studentsSortedByDate ??= new SortedList<Person, Student>(new Person());
            _studentsSortedByAverageMark ??= new SortedList<Student, Student>(new StudentAverageMarkComparer());

            Student st1 = new Student();
            Student st2 = new Student();

            StudentList.Add(st1);
            StudentList.Add(st2);

            DefaultSortedList.Add(st1.Person, st1);
            DefaultSortedList.Add(st2.Person, st2);

            StudentsSortedByDate.Add(st1.Person, st1);
            StudentsSortedByDate.Add(st2.Person, st2);

            StudentsSortedByAverageMark.Add(st1, st1);
            StudentsSortedByAverageMark.Add(st2, st2);

            SetStudentImAsOrig();
        }

        public void AddStudents(params Student[] students)
        {
            _studentList ??= [];

            _studentsSorted ??= [];
            _studentsSortedByDate ??= new SortedList<Person, Student>(new Person());
            _studentsSortedByAverageMark ??= new SortedList<Student, Student>(new StudentAverageMarkComparer());

            StudentList.AddRange(students.Where(s=> s is not null));

            foreach (Student st in students.Where(s => s is not null))
            {
                DefaultSortedList.Add(st.Person, st);
                StudentsSortedByDate.Add(st.Person, st);
                StudentsSortedByAverageMark.Add(st, st);               
            }

            SetStudentImAsOrig();
        }

        public string ToStringSotedLists()
        {
            StringBuilder sb = new();
            sb.AppendLine("StudentCollections Sorted By Default:\n");

            foreach (Student st in DefaultSortedList.Values ?? [])
            {
                sb.AppendLine(st.ToString());
                sb.AppendLine();
            }

            sb.AppendLine("\nStudentCollections Sorted By Date:\n");
            foreach (Student st in StudentsSortedByDate.Values ?? [])
            {
                sb.AppendLine(st.ToString());
                sb.AppendLine();
            }
            sb.AppendLine("\nStudentCollections Sorted By AverageMark:\n");
            foreach (Student st in StudentsSortedByAverageMark.Values ?? [])
            {
                sb.AppendLine(st.ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string ToShortStringSorted()
        {
            StringBuilder sb = new();
            sb.AppendLine("StudentCollections Sorted By Default:\n");

            foreach (Student st in DefaultSortedList.Values ?? [])
            {
                sb.AppendLine(st.ToShortString());
                sb.AppendLine();
            }

            sb.AppendLine("\nStudentCollections Sorted By Date:\n");
            foreach (Student st in StudentsSortedByDate.Values ?? [])
            {
                sb.AppendLine(st.ToShortString());
                sb.AppendLine();
            }
            sb.AppendLine("\nStudentCollections Sorted By AverageMark:\n");
            foreach (Student st in StudentsSortedByAverageMark.Values ?? [])
            {
                sb.AppendLine(st.ToShortString());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string ToStringImmutable()
        {
            StringBuilder sb = new();
            sb.AppendLine("StudentCollection Immutable:\n");

            foreach (Student st in StudentIm ?? [])
            {
                sb.AppendLine(st.ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string ToShortStringImmutable()
        {
            StringBuilder sb = new();
            sb.AppendLine("StudentCollection Immutable:\n");

            foreach (Student st in StudentIm ?? [])
            {
                sb.AppendLine(st.ToShortString());
                sb.AppendLine();
            }

            return sb.ToString();
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
            _studentsImmutable = _studentsImmutable.Sort();
        }
        public void SortByDate()
        { 
            StudentList?.Sort(new Person());
            _studentsImmutable = _studentsImmutable.Sort(new Person());
        }

        public void SortByAverageMark()
        {
            StudentList?.Sort(new StudentAverageMarkComparer());
            _studentsImmutable = _studentsImmutable.Sort(new StudentAverageMarkComparer());
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

        public double MaxAverageMarkSorted { get => DefaultSortedList?.Values.Select(s => s.AverageMark).DefaultIfEmpty().Max() ?? 0; }
        public IEnumerable<Student> EducationMasterSorted { get => DefaultSortedList.Values.Where(st => st.Education == Education.Master); }
        public List<Student> AverageMarkGroupSorted (double value)
        {
            return DefaultSortedList.Values
                .GroupBy(s => s.AverageMark)
                .Where(g => g.Key == value)
                .SelectMany(g => g)
                .ToList();
        }

        public double MaxAverageMarkImmutable { get => StudentIm?.Select(s => s.AverageMark).DefaultIfEmpty().Max() ?? 0; }
        public IEnumerable<Student> EducationMasterImmutable { get => StudentIm.Where(st => st.Education == Education.Master); }
        public List<Student> AverageMarkGroupImmutable(double value)
        {
            return StudentIm
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
    }
}
