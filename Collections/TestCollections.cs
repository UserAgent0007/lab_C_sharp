using lab1;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace lab1.Collections
{
    public  class TestCollections
    {
        private List<Person> _keyPersonList;
        private List<string> _keyStringList;
        private Dictionary<string, Student> _keyStringDictionary;
        private Dictionary<Person, Student> _keyPersonDictionary;

        private ImmutableList<Person> _keyPersonListImmutable;
        private ImmutableList<string> _keyStringListImmutable;
        private ImmutableDictionary<string, Student> _keyStringDictionaryImmutable;
        private ImmutableDictionary<Person, Student> _keyPersonDictionaryImmutable;

        private SortedList<Person, Student> _keyPersonListSorted;
        private SortedList<string, Student> _keyStringListSorted;
        private SortedDictionary<Person, Student> _keyPersonDictionarySorted;
        private SortedDictionary<string, Student> _keyStringDictionarySorted;

        public static Student GenerateStudent(int value)
        {
            Student student = new()
            {
                Person = new Person($"Name{value}", $"Surname{value}", new DateTime(2000 + (int)(value % 1000), 1, 1)),
                Education = (Education)(value % 3),
                Group = 311,
                Exams = new List<Exam>
                {
                    new Exam($"Subject", value % 5 + 1, new DateTime(2023, 1, 1))
                },
                Tests = new List<Test>
                {
                    new Test($"TestSubject{value}", true, new DateTime(2022, 1, 1))
                }
            };

            return student;
        }

        public TestCollections(int count)
        {
            _keyPersonList = [];
            _keyStringList = [];
            _keyStringDictionary = [];
            _keyPersonDictionary = [];

            _keyPersonListSorted = [];
            _keyStringListSorted = [];
            _keyPersonDictionarySorted = [];
            _keyStringDictionarySorted = [];
            
            for (int i = 0; i < count; i++)
            {
                Student student = GenerateStudent(i);
                _keyPersonList.Add(student.Person);
                _keyStringList.Add(student.Person.ToString());
                _keyStringDictionary.Add(student.Person.ToString(), student);
                _keyPersonDictionary.Add(student.Person, student);

                _keyPersonListSorted.Add(student.Person, student);
                _keyStringListSorted.Add(student.Person.ToString(), student);
                _keyPersonDictionarySorted.Add(student.Person, student);
                _keyStringDictionarySorted.Add(student.Person.ToString(), student);
            }

            _keyPersonListImmutable = _keyPersonList.ToImmutableList();
            _keyStringListImmutable = _keyStringList.ToImmutableList();
            _keyStringDictionaryImmutable = _keyStringDictionary.ToImmutableDictionary();
            _keyPersonDictionaryImmutable = _keyPersonDictionary.ToImmutableDictionary();

        }

        public void SearchTestsSorted()
        {
            int count = _keyPersonListSorted.Count;

            Person firstPerson = GenerateStudent(0);
            Person middlePerson = GenerateStudent(count / 2);
            Person lastPerson = GenerateStudent(count - 1);
            Person notExistingPerson = GenerateStudent(count + 1);

            string firstString = firstPerson.ToString();
            string middleString = middlePerson.ToString();
            string lastString = lastPerson.ToString();
            string notExistingString = "NotExisting";

            Student firstStudent = _keyPersonDictionarySorted[firstPerson];
            Student middleStudent = _keyPersonDictionarySorted[middlePerson];
            Student lastStudent = _keyPersonDictionarySorted[lastPerson];
            Student notExistingStudent = GenerateStudent(count + 100);

            Stopwatch sw = new Stopwatch();

            Console.WriteLine("ListSorted<string, Student>.ContainsKey");

            sw.Restart();
            _keyStringListSorted.ContainsKey(firstString);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringListSorted.ContainsKey(middleString);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringListSorted.ContainsKey(lastString);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringListSorted.ContainsKey(notExistingString);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nListSorted<Person, Student>.ContainsKey");
            sw.Restart();
            _keyPersonListSorted.ContainsKey(firstPerson);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonListSorted.ContainsKey(middlePerson);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonListSorted.ContainsKey(lastPerson);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");


            Console.WriteLine("\nDictionarySorted<string,Student>.ContainsKey");

            sw.Restart();
            _keyStringDictionarySorted.ContainsKey(firstString);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionarySorted.ContainsKey(middleString);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionarySorted.ContainsKey(lastString);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionarySorted.ContainsKey(notExistingString);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nDictionarySorted<Person,Student>.ContainsKey");

            sw.Restart();
            _keyPersonDictionarySorted.ContainsKey(firstPerson);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionarySorted.ContainsKey(middlePerson);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionarySorted.ContainsKey(lastPerson);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionarySorted.ContainsKey(notExistingPerson);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nDictionarySorted<Person,Student>.ContainsValue");

            sw.Restart();
            _keyPersonDictionarySorted.ContainsValue(firstStudent);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionarySorted.ContainsValue(middleStudent);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionarySorted.ContainsValue(lastStudent);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionarySorted.ContainsValue(notExistingStudent);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nDictionarySorted<string,Student>.ContainsValue");

            sw.Restart();
            _keyStringDictionarySorted.ContainsValue(firstStudent);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionarySorted.ContainsValue(middleStudent);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionarySorted.ContainsValue(lastStudent);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionarySorted.ContainsValue(notExistingStudent);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");
        }

        public void SearchTestsImmutable()
        {
            int count = _keyPersonList.Count;

            Person firstPerson = GenerateStudent(0);
            Person middlePerson = GenerateStudent(count / 2);
            Person lastPerson = GenerateStudent(count - 1);
            Person notExistingPerson = new Person("X", "Y", DateTime.Now);

            string firstString = firstPerson.ToString();
            string middleString = middlePerson.ToString();
            string lastString = lastPerson.ToString();
            string notExistingString = "NotExisting";

            Student firstStudent = _keyPersonDictionaryImmutable[firstPerson];
            Student middleStudent = _keyPersonDictionaryImmutable[middlePerson];
            Student lastStudent = _keyPersonDictionaryImmutable[lastPerson];
            Student notExistingStudent = GenerateStudent(count + 100);

            Stopwatch sw = new Stopwatch();

            Console.WriteLine("ImmutableList<string>.Contains");

            sw.Restart();
            _keyStringListImmutable.Contains(firstString);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringListImmutable.Contains(middleString);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringListImmutable.Contains(lastString);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringListImmutable.Contains(notExistingString);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nImmutableList<Person>.Contains");
            sw.Restart();
            _keyPersonListImmutable.Contains(firstPerson);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonListImmutable.Contains(middlePerson);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonListImmutable.Contains(lastPerson);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");


            Console.WriteLine("\nImmutableDictionary<string,Student>.ContainsKey");

            sw.Restart();
            _keyStringDictionaryImmutable.ContainsKey(firstString);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionaryImmutable.ContainsKey(middleString);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionaryImmutable.ContainsKey(lastString);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionaryImmutable.ContainsKey(notExistingString);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nImmutableDictionary<Person,Student>.ContainsKey");

            sw.Restart();
            _keyPersonDictionaryImmutable.ContainsKey(firstPerson);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionaryImmutable.ContainsKey(middlePerson);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionaryImmutable.ContainsKey(lastPerson);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionaryImmutable.ContainsKey(notExistingPerson);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nImmutableDictionary<Person,Student>.ContainsValue");

            sw.Restart();
            _keyPersonDictionaryImmutable.ContainsValue(firstStudent);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionaryImmutable.ContainsValue(middleStudent);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionaryImmutable.ContainsValue(lastStudent);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionaryImmutable.ContainsValue(notExistingStudent);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nImmutableDictionary<string,Student>.ContainsValue");

            sw.Restart();
            _keyStringDictionaryImmutable.ContainsValue(firstStudent);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionaryImmutable.ContainsValue(middleStudent);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionaryImmutable.ContainsValue(lastStudent);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionaryImmutable.ContainsValue(notExistingStudent);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");
        }

        public void SearchTests()
        {
            int count = _keyPersonList.Count;

            Person firstPerson = GenerateStudent(0);
            Person middlePerson = GenerateStudent(count / 2);
            Person lastPerson = GenerateStudent(count - 1);
            Person notExistingPerson = new Person("X", "Y", DateTime.Now);

            string firstString = firstPerson.ToString();
            string middleString = middlePerson.ToString();
            string lastString = lastPerson.ToString();
            string notExistingString = "NotExisting";

            Student firstStudent = _keyPersonDictionary[firstPerson];
            Student middleStudent = _keyPersonDictionary[middlePerson];
            Student lastStudent = _keyPersonDictionary[lastPerson];
            Student notExistingStudent = GenerateStudent(count+100);

            Stopwatch sw = new Stopwatch();

            Console.WriteLine("List<string>.Contains");

            sw.Restart();
            _keyStringList.Contains(firstString);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringList.Contains(middleString);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringList.Contains(lastString);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringList.Contains(notExistingString);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nList<Person>.Contains");
            sw.Restart();
            _keyPersonList.Contains(firstPerson);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonList.Contains(middlePerson);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonList.Contains(lastPerson);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");


            Console.WriteLine("\nDictionary<string,Student>.ContainsKey");

            sw.Restart();
            _keyStringDictionary.ContainsKey(firstString);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionary.ContainsKey(middleString);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionary.ContainsKey(lastString);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionary.ContainsKey(notExistingString);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nDictionary<Person,Student>.ContainsKey");

            sw.Restart();
            _keyPersonDictionary.ContainsKey(firstPerson);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionary.ContainsKey(middlePerson);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionary.ContainsKey(lastPerson);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionary.ContainsKey(notExistingPerson);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nDictionary<Person,Student>.ContainsValue");

            sw.Restart();
            _keyPersonDictionary.ContainsValue(firstStudent);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionary.ContainsValue(middleStudent);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionary.ContainsValue(lastStudent);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyPersonDictionary.ContainsValue(notExistingStudent);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");



            Console.WriteLine("\nDictionary<string,Student>.ContainsValue");

            sw.Restart();
            _keyStringDictionary.ContainsValue(firstStudent);
            sw.Stop();
            Console.WriteLine($"First: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionary.ContainsValue(middleStudent);
            sw.Stop();
            Console.WriteLine($"Middle: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionary.ContainsValue(lastStudent);
            sw.Stop();
            Console.WriteLine($"Last: {sw.ElapsedMilliseconds}");

            sw.Restart();
            _keyStringDictionary.ContainsValue(notExistingStudent);
            sw.Stop();
            Console.WriteLine($"Not existing: {sw.ElapsedMilliseconds}");
        }
    }
}
