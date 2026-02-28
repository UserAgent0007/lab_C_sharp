using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Exam
    {
        public string subjectName;
        public int mark;
        public DateTime date;

        public Exam(string subjectName, int mark, DateTime date)
        {
            this.subjectName = subjectName;
            this.mark = mark;
            this.date = date;
        }

        public Exam() : this(subjectName: "Math", mark: 5, date: DateTime.Now) { }

        public override string ToString()
        {
            return $"{subjectName}, mark: {mark}, date: {date.ToShortDateString()}";
        }
    }
}
