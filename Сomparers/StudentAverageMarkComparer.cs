using System;
using System.Collections.Generic;
using System.Text;
using lab1;

namespace lab1.Сomparers
{
    public class StudentAverageMarkComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            if (x is null || y is null) return 0;
            double xAverage = x.AverageMark;
            double yAverage = y.AverageMark;
            return xAverage.CompareTo(yAverage);
        }
    }
}
