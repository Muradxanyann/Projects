/*
    List<T>ի համար ընդլայնել
    void Shuffle() - պատահականության սկզբունքով խառնել բոլոր տարրերի դիրքերը
    void Reverse() - շրջել List-ը
    List<T> Slice(int start, int end) - կտրում և վերադարձնում է start-ից end հատվածի տարրերը:
    T At(int index) - վերադարձնում է index-րդ տարրը.  եթե index<0, հաշվարկը հակառակ կողմից իրականացնել
*/

using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

static class ListExtentions
{
    public static void MyShuffle<T>(this List<T> list)
    {
        Random rand = new Random();

        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1);

            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public static void MyReverse<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count / 2 ; i++)
        {
            T temp = list[i];
            list[i] = list[list.Count - i - 1];
            list[list.Count - i - 1] = temp;
        }
    }

    public static List<T>  MySlice<T> (this List<T> list, int start, int length)
    {
        if (start < 0 || length < 0 || length > list.Count)
            throw new ArgumentOutOfRangeException("invalid argument");
        List<T> newList = new();
        for (int i = start; i < start + length; i++)
        {
            newList.Add(list[i]);
        }
        return newList;
    }

    public static T MyAt<T> (this List<T> list , int index)
    {
        if (Math.Abs(index) > list.Count)
            throw new ArgumentException("index out of rangefrfr");
        if (index < 0)
            return list[list.Count - 1 + index];
        return list[index];
    }

    
}