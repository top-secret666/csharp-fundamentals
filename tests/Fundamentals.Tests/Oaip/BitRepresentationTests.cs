using Fundamentals.Oaip;

namespace Fundamentals.Tests.Oaip;

public class BitRepresentationTests
{
    [Theory]
    [InlineData(0, "00000000000000000000000000000000")]
    [InlineData(5, "00000000000000000000000000000101")]
    [InlineData(-1, "11111111111111111111111111111111")]
    [InlineData(-5, "11111111111111111111111111111011")]
    [InlineData(int.MaxValue, "01111111111111111111111111111111")]
    [InlineData(int.MinValue, "10000000000000000000000000000000")]
    public void ToBinary_ReturnsAll32BitsInTwosComplement(int value, string expected)
    {
        Assert.Equal(expected, BitRepresentation.ToBinary(value));
    }

    [Theory]
    [InlineData(5, -5)]
    [InlineData(-5, 5)]
    [InlineData(0, 0)]
    public void Negate_FlipsSign(int value, int expected)
    {
        Assert.Equal(expected, BitRepresentation.Negate(value));
    }

    [Fact]
    public void Negate_MinValue_OverflowsBackToItself()
    {
        Assert.Equal(int.MinValue, BitRepresentation.Negate(int.MinValue));
    }

    [Fact]
    public void Decompose_One_HasBiasedExponentAndEmptyMantissa()
    {
        Assert.Equal(new FloatParts(0, 127, 0), BitRepresentation.Decompose(1.0f));
    }

    [Fact]
    public void Decompose_NegativeTwoAndHalf()
    {
        Assert.Equal(new FloatParts(1, 128, 0x200000), BitRepresentation.Decompose(-2.5f));
    }

    [Fact]
    public void Decompose_Zero_IsAllZeros()
    {
        Assert.Equal(new FloatParts(0, 0, 0), BitRepresentation.Decompose(0.0f));
    }

    [Fact]
    public void DoubleArithmetic_IsNotExact()
    {
        Assert.NotEqual(0.3, 0.1 + 0.2);
    }
}
