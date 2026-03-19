using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Person : IDateAndCopy, IComparable, IComparer<Person>
    {
        protected String _name;
        protected String _surname;
        protected DateTime _dateBirth;

        public Person(string name, string surname, DateTime dateBirth)
        {
            Name = name;
            Surname = surname;
            Date = dateBirth;
        }

        public Person() : this(name: "kiril", surname: "Kravtsov", dateBirth: new DateTime(2000, 1, 15))
        {
        }

        public int Compare(Person? x, Person? y)
        {
            if (x is null || y is null) return 0;

            return x.Date.CompareTo(y.Date);
        }

        public int CompareTo(object? obj)
        {
            if (obj is null) return 1;
            if (obj is Person person)
            {
                int surnameComparison = string.Compare(Surname, person.Surname, StringComparison.Ordinal);
                if (surnameComparison != 0) return surnameComparison;
                return 0;
            }
            throw new ArgumentException("Object is not a Person");
        }

        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }

        public DateTime Date 
        { 
            get => _dateBirth; 
            init => _dateBirth = value; 
        }
        public String Name
        {
            get => _name;
            init => _name = value;
        }

        public String Surname
        {
            get => _surname;
            set => _surname = value;
        }

        //public DateTime DateBirth
        //{
        //    get => dateBirth;
        //    set => dateBirth = value;
        //}

        public override string ToString()
        {
            return $"{Surname} {Name}, {Date.ToShortDateString()}";
        }

        public virtual string ToShortString()
        {
            return $"{Surname} {Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (obj is Person person)
            {
                return Name == person.Name && Surname == person.Surname && Date == person.Date;
            }
            return false;

           
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (p1 is null || p2 is null) return false;
            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, Date);
        }
    }
}
