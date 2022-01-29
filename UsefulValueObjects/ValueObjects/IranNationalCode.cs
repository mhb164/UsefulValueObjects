using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IranNationalCode
{
    public IranNationalCode(long value) : this(value.ToString()) { }
    public IranNationalCode(string value)
    {
        if (value == null)
            throw new ArgumentNullException(NationalCodeIsNullMessage);
        CheckNationalCode(value);
        Value = value;
    }

    public string Value { get; private set; }
    public long AsNumber => long.Parse(Value);

    public const string NationalCodeIsNullMessage = "NationalCode cannot be null.";
    public const string NationalCodeIsEmptyMessage = "NationalCode cannot be empty.";
    public const string NationalCodeLengthErrorMessage = "NationalCode length must be 10.";
    public const string NationalCodeNotNumberMessage = "NationalCode must be number.";
    public const string NationalCodeAllDigitsEqualMessage = "NationalCode all digits cannot be equal.";
    public const string NationalCodeIsWrongMessage = "NationalCode is wrong.";
    public static void CheckNationalCode(string value)
    {
        value = value.Replace("-", "").Replace(" ", "").ToLatin();
        if (value.Length == 0)//It's empty...
            throw new ApplicationException(NationalCodeIsEmptyMessage);
        if (value.Length != 10)//Length error
            throw new ApplicationException(NationalCodeLengthErrorMessage);
        if (value.IsDigit() == false)//not a number
            throw new ApplicationException(NationalCodeNotNumberMessage);

        var AllDigitsEqual = true;
        for (int i = 1; i < value.Length; i++)
            AllDigitsEqual &= value[0] == value[i];
        if (AllDigitsEqual)//All Digits are Equal
            throw new ApplicationException(NationalCodeAllDigitsEqualMessage);

        try
        {
            var num0 = ((byte)value[0] - 48) * 10;
            var num2 = ((byte)value[1] - 48) * 09;
            var num3 = ((byte)value[2] - 48) * 08;
            var num4 = ((byte)value[3] - 48) * 07;
            var num5 = ((byte)value[4] - 48) * 06;
            var num6 = ((byte)value[5] - 48) * 05;
            var num7 = ((byte)value[6] - 48) * 04;
            var num8 = ((byte)value[7] - 48) * 03;
            var num9 = ((byte)value[8] - 48) * 02;
            var a = ((byte)value[9] - 48);
            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;

            if (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)))
            {
                //It's OK!
            }
            else
            {
                throw new ApplicationException(NationalCodeIsWrongMessage);
            }
        }
        catch { throw new ApplicationException(NationalCodeIsWrongMessage); }
    }

    public override bool Equals(object obj) => obj is IranNationalCode code && Value == code.Value;
    public override int GetHashCode() => AsNumber.GetHashCode();
    public override string ToString() => GetFormated();
    public string GetFormated(string seperator = "-") => $"{Value.Substring(0, 3)}{seperator}{Value.Substring(3, 6)}{seperator}{Value.Substring(9, 1)}";
}
