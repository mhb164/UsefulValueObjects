using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MobileNumber
{
    public MobileNumber(string value)
    {
        if (value == null)
            throw new ArgumentNullException(MobileNumberIsNullMessage);
        CheckMobileNumber(value);
        Value = value;
    }

    public string Value { get; private set; }
    public long AsNumber => long.Parse(Value.Replace("+", ""));

    public const string MobileNumberIsNullMessage = "MobileNumber cannot be null.";
    public const string MobileNumberIsEmptyMessage = "MobileNumber cannot be empty.";
    public const string MobileNumberNotNumberMessage = "MobileNumber must be number.";
    public const string MobileNumberNotStartWithPlusMessage = "MobileNumber must start with '+'.";
    public const string MobileNumberNotImplementedMessage = "MobileNumber not supported!";
    public const string MobileNumberIsWrongMessage = "NationalCode is wrong.";

    public static void CheckMobileNumber(string value)
    {
        value = value.Replace("-", "").Replace(" ", "").ToLatin();
        if (value.Length == 0)//It's empty...
            throw new ApplicationException(MobileNumberIsEmptyMessage);
        if (value.IsDigit('+') == false)//not a number
            throw new ApplicationException(MobileNumberNotNumberMessage);
        if (value.StartsWith("+") == false)
            throw new ApplicationException(MobileNumberNotStartWithPlusMessage);

        if (value.StartsWith("+989"))
        {
            if (value.Length != 13)
                throw new ApplicationException(MobileNumberIsWrongMessage);
            //It's OK!
        }
        else
        {
            throw new NotImplementedException(MobileNumberNotImplementedMessage);
        }
    }

    public override bool Equals(object obj) => obj is MobileNumber code && Value == code.Value;
    public override int GetHashCode() => AsNumber.GetHashCode();
    public override string ToString() => GetFormated();
    public string GetFormated(string seperator = "-")
    {
        if (Value.StartsWith("+989"))
            return $"{Value.Substring(0, 3)}{seperator}{Value.Substring(3, 3)}{seperator}{Value.Substring(6, 3)}{seperator}{Value.Substring(9, 4)}";
        else return Value;
    }
}
