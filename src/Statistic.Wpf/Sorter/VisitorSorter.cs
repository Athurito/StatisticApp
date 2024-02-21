using System.Collections;
using Statistic.Application.DTOs;

namespace Statistic.Wpf.Sorter;

public class VisitorSorter : IComparer
{
    public int Compare(object? x, object? y)
    {
        if (x is not VisitorDto v1 || y is not VisitorDto v2)
        {
            return 0;
        }

        return v2.CreateDate.TimeOfDay.CompareTo(v1.CreateDate.TimeOfDay);
    }
}