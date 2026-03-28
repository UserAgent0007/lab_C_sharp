using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Event
{
    public class StudentListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; init; }
        public string ChangeType { get; init; }
        public Student StudentReference { get; init; }

        public StudentListHandlerEventArgs (string collectionName, string chageType, Student studentReference)
        {
            CollectionName = collectionName;
            ChangeType = chageType;
            StudentReference = studentReference;
        }

        public override string ToString()
        {
            return $"\nCollection: {CollectionName} | Changes Type: {ChangeType} | Student: {StudentReference}";
        }
    }

}
