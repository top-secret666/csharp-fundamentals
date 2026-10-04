namespace Fundamentals.Oaip;

public readonly record struct FloatParts(int Sign, int Exponent, int Mantissa);

public static class BitRepresentation
{
    public static string ToBinary(int value)
    {
        throw new NotImplementedException();
    }

    public static int Negate(int value)
    {
        throw new NotImplementedException();
    }

    public static FloatParts Decompose(float value)
    {
        throw new NotImplementedException();
    }
}
