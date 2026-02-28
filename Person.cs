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
            _name = name;
            _surname = surname;
            _dateBirth = dateBirth;
        }

        public Person() : this(name: "kiril", surname: "Kravtsov", dateBirth: DateTime.Now)
        {
        }

        public String name
        {
            get => _name;
            set => _name = value;
        }

        public String surname
        {
            get => _surname;
            set => _surname = value;
        }

        public DateTime dateBirth
        {
            get => _dateBirth;
            set => _dateBirth = value;
        }

        public override string ToString()
        {
            return $"{surname} {name}, {dateBirth.ToShortDateString()}";
        }

        public virtual string ToShortString()
        {
            return $"{surname} {name}";
        }
    }
}
