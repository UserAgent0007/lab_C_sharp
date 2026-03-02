using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Person
    {
        private String _name;
        private String _surname;
        private DateTime _dateBirth;

        public Person(string name, string surname, DateTime dateBirth)
        {
// =========
            Name = name;
            Surname = surname;
            DateBirth = dateBirth;
        }

        public Person() : this(name: "kiril", surname: "Kravtsov", dateBirth: DateTime.Now)
        {
        }

        public String Name
        {
            get => _name;
            init => _name = value;
        }

// ========================
        public String Surname
        {
            get => _surname;
            set => _surname = value;
        }

        public DateTime DateBirth
        {
            get => _dateBirth;
            set => _dateBirth = value;
        }

        public override string ToString()
        {
            return $"{Surname} {Name}, {DateBirth.ToShortDateString()}";
        }

        public virtual string ToShortString()
        {
            return $"{Surname} {Name}";
        }
    }
}
