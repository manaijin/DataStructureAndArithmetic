using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.String
{
    interface IString
    {
        char this[int index] { get; }
        int GetLength();
        int Compare(StringDS str);
        StringDS SubString(int index, int len);
        StringDS Concat(StringDS s);
        StringDS Insert(int index, StringDS str);
        StringDS Delete(int index, int len);
        int IndexOf(StringDS str);
    }
}
