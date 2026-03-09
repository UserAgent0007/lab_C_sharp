using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public class Test : IDateAndCopy
    {
        public string SubjectName {  get; init; }
        public bool IsPassed { get; init; }

        public DateTime Date { get; init; }

        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }

        public Test(string subjectName, bool isPassed, DateTime date)
        {
            SubjectName = subjectName;
            IsPassed = isPassed;
            Date = date;
        }
        public Test() : this(subjectName : "Math", isPassed: true, date: DateTime.Now) { }

        public override string ToString()
        {
            return $"{SubjectName}: {IsPassed}. Date: {Date}";
        }


    }
}
