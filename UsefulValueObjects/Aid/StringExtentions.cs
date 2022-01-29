using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StringExtentions
{
    public static bool IsDigit(this string input, params char[] excludes)
    {
        foreach (var item in input)
        {
            if (excludes.Contains(item)) continue;
            if (char.IsDigit(item)) continue;
            return false;
        }
        return true;
    }
    public static string ToPersian(this string input, bool isFloat = false)
    {
        string text2 = "";
        int length = input.Length;
        if (length == 0)
        {
            return input;
        }
        for (int i = 0; i < length; i++)
        {
            char c = input[i];
            if ('0' <= c && c <= '9')
            {
                c += 'ۀ';
            }
            if (isFloat && c == '.')
            {
                c = '/';
            }
            text2 += c;
        }
        return text2;
    }

    public static string ToLatin(this string num)
    {
        if (string.IsNullOrWhiteSpace(num)) return string.Empty;
        string text = "";
        int length = num.Length;
        if (length == 0)
        {
            return num;
        }
        for (int i = 0; i < length; i++)
        {
            char c = num[i];
            if ('۰' <= c && c <= '۹')
            {
                c -= 'ۀ';
            }
            text += c;
        }
        return text;
    }
}
