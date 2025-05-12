/* Comparison:
    String տիպի համար ընդլայնել հետևյալ մեթոդները
    string [] Split(string seperator)
    int IndexOf(string str)
    bool Contains(string str)
    string Substring(int start, int count)
 */

using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

static class StingExtentions
{
    
    public static string[] MySplit(this string str, char seperator)
    {
        

        StringBuilder sb = new StringBuilder();
        int count = 0;
        string [] result = new string[count];
        foreach (var item in str)
        {
            if (item != seperator)
                sb.Append(item);
            else
            {
                string[] newString = new string [++count];
                Array.Copy(result, newString, result.Length);
                newString[count - 1] = sb.ToString();
                sb.Clear();
                result = newString;
            }
        }
        if (sb.Length > 0)
        {
                string[] newString = new string [++count];
                Array.Copy(result, newString, result.Length);
                newString[count - 1] = sb.ToString();
                sb.Clear();
                result = newString;
        }
        return result;
    }
    
    public static int MyIndexOf(this string str, char ch)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (i == ch)
                return i;
        }
        return -1;
    }

    public static bool MyContains(this string str, string value)
    {
        if (value.Length > str.Length) return false;
        int start = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == value[start])
            {
                for (int j = 0; j < value.Length; j++, i++)
                {
                    if (value[j] != str[i])
                        break;
                    if (j == value.Length - 1)
                        return true;
                }
            }
        }
        return false;
    }

    public static string MySubstring(this string str, int startIndex, int length)
    {
        if (startIndex == length || length == 0)
            return string.Empty;
        if (startIndex + length > str.Length || startIndex < 0 || length < 0)
            throw new Exception("unvalid parameters");

        StringBuilder sb = new StringBuilder();
        for (int i = startIndex; i < startIndex + length; i++)
        {
            sb.Append(str[i]);
        }
        return sb.ToString();
    }

}