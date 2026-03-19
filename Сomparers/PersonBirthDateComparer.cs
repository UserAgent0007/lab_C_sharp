using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Сomparers
{
    public class PersonBirthDateComparer : IComparer<Person>
    {
        public int  Compare(Person? x, Person? y)
        {
            if (x is null || y is null) return 0;

            return x.Date.CompareTo(y.Date);
        }
    }
}
