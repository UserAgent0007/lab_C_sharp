using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public class StudentEnumerator : IEnumerator, IEnumerable
    {

        private ArrayList _subjects;
        private int _index = -1;

        public StudentEnumerator(List<Test> tests, List<Exam> exams)
        {
            _subjects = new ArrayList();

            // Збираємо назви предметів із заліків
            foreach (Test test in tests)
            {
                if (!_subjects.Contains(test.SubjectName))
                    _subjects.Add(test.SubjectName);
            }

            // Залишаємо тільки ті, що є і в іспитах (перетин)
            ArrayList intersection = new ArrayList();
            foreach (Exam exam in exams)
            {
                if (_subjects.Contains(exam.SubjectName) &&
                    !intersection.Contains(exam.SubjectName))
                {
                    intersection.Add(exam.SubjectName);
                }
            }

            _subjects = intersection;
        }

        public object Current => _subjects[_index];

        public bool MoveNext()
        {
            _index++;
            return _index < _subjects.Count;
        }

        public void Reset() => _index = -1;

        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }
    }
}
