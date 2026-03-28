using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Event
{
    public class Journal
    {
        private List<JournalEntry> _entries = new List<JournalEntry>();

        public void OnStudentCountChanged(object source, StudentListHandlerEventArgs e)
        {
            _entries.Add(new JournalEntry(
            
                e.CollectionName,
                e.ChangeType,
                e.StudentReference.ToString()
            ));
            Console.WriteLine($"Updated journal (CountChanged): {e.ChangeType}");
        }
        public void OnStudentReferenceChanged(object source, StudentListHandlerEventArgs e)
        {
            _entries.Add(new JournalEntry(

                e.CollectionName,
                e.ChangeType,
                e.StudentReference.ToString()
            ));
            Console.WriteLine($"Updated journal (ReferenceChanged): {e.ChangeType}");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nJournal History");
            foreach (var entry in _entries)
            {
                sb.Append(entry);
            }
            return sb.ToString();
        }
    }
}
