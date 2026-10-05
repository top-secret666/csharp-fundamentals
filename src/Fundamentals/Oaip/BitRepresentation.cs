namespace Fundamentals.Oaip;

public readonly record struct FloatParts(int Sign, int Exponent, int Mantissa);

public static class BitRepresentation
{
    public static string ToBinary(int value)
    {
        string binary = Convert.ToString(value, 2).PadLeft(32, '0');
        return binary;
    }

    public static int Negate(int value)
    {
        value =  ~value + 1;
        return value;
    }

    public static FloatParts Decompose(float value)
    {
        int bits = BitConverter.SingleToInt32Bits(value);
        int sign = (bits >> 31) & 1;
        int exponent = (bits >> 23) & 0XFF;
        int mantissa = bits & 0X7FFFFF;
        return new FloatParts(sign, exponent, mantissa);
    }
}
