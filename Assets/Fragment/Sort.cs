using System;

/// <summary>
/// 排序演演算法類。
/// </summary>
public class Sort<T> where T : IComparable
{
    #region 基礎公有方法
    /// <summary>
    /// 陣列快速排序。
    /// </summary>
    /// <param name="array">待排序陣列。</param>
    /// <param name="low">排序起點。</param>
    /// <param name="high">排序終點。</param>
    public void QuickSort(T[] array, int low, int high)
    {
        if (low >= high)
            return;
        int first = low;
        int last = high;
        T key = array[low];
        while (first < last)
        {
            while (first < last && CompareGeneric(array[last], key) >= 0)
                last--;
            array[first] = array[last];
            while (first < last && CompareGeneric(array[first], key) <= 0)
                first++;
            array[last] = array[first];
        }
        array[first] = key;
        QuickSort(array, low, first - 1);
        QuickSort(array, first + 1, high);
    }
    #endregion

    #region 靜態私有方法
    /// <summary>
    /// 泛型物件比較大小。
    /// </summary>
    /// <param name="t1">待比較物件。</param>
    /// <param name="t2">待比較物件。</param>
    /// <returns>大於0則前者的值更大，小於0則反之，等於0則二者的值相等。</returns>
    private static int CompareGeneric(T t1, T t2)
    {
        if (t1.CompareTo(t2) > 0)
            return 1;
        else if (t1.CompareTo(t2) == 0)
            return 0;
        else
            return -1;
    }
    #endregion
}