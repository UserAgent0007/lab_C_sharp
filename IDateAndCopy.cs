using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public interface IDateAndCopy
    {
        DateTime Date { get; init; }

        object DeepCopy();
    }
}
