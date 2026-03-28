using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Event
{
    public class JournalEntry
    {
        public string CollectionName { get; init; }
        public string ChangeType { get; init; }
        public string StudentInfo { get; init; }

        public JournalEntry(string collectionName, string changeType, string studentInfo)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            StudentInfo = studentInfo;
        }

        public override string ToString() 
        { 
            return $"\nCollection: {CollectionName} | Changes Type: {ChangeType} | Student: {StudentInfo}";
        }
    }
}
