using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Exam : IDateAndCopy
    {
        public string SubjectName { get; init; }
        public int Mark { get; init; }
        public DateTime Date { get; init; }

        public object DeepCopy()
        {
            //return new Exam(SubjectName, Mark, Date);
            return MemberwiseClone();
        }

        public Exam(string subjectName, int mark, DateTime date)
        {
            SubjectName = subjectName;
            Mark = mark;
            Date = date;
        }

        public Exam() : this(subjectName: "Math", mark: 5, date: DateTime.Now) { }

        public override string ToString()
        {
            return $"{SubjectName}, mark: {Mark}, date: {Date.ToShortDateString()}";
        }
    }
}
