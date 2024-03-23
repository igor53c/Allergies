using NUnit.Framework;
using AllergiesCsharpImplementation;

[TestFixture]
public class AllergiesTests
{
    [Test]
    public void IsAllergicTo_WithScoreZero_ShouldReturnFalseForAnyAllergen()
    {
        var allergies = new AllergiesCsharpImplementation.Allergies(0);
        Assert.That(allergies.IsAllergicTo(Allergen.Eggs), Is.False, "Expected no allergy to Eggs, but was found.");
        Assert.That(allergies.IsAllergicTo(Allergen.Peanuts), Is.False, "Expected no allergy to Peanuts, but was found.");
    }

    [Test]
    public void IsAllergicTo_WithScoreOne_ShouldReturnTrueForEggs()
    {
        var allergies = new AllergiesCsharpImplementation.Allergies(1);
        Assert.That(allergies.IsAllergicTo(Allergen.Eggs), Is.True, "Expected an allergy to Eggs, but wasn't found.");
    }

    [Test]
    public void IsAllergicTo_WithScoreSeventeen_ShouldReturnTrueForTomatoes()
    {
        var allergies = new AllergiesCsharpImplementation.Allergies(17);
        Assert.That(allergies.IsAllergicTo(Allergen.Tomatoes), Is.True, "Expected an allergy to Tomatoes, but wasn't found.");
    }

    [Test]
    public void List_WithScoreZero_ShouldReturnEmptyArray()
    {
        var allergies = new AllergiesCsharpImplementation.Allergies(0);
        Assert.That(allergies.List(), Is.Empty, "Expected no allergies, but some were found.");
    }

    [Test]
    public void List_WithScoreOne_ShouldReturnEggs()
    {
        var allergies = new AllergiesCsharpImplementation.Allergies(1);
        Assert.That(allergies.List(), Is.EquivalentTo(new[] { Allergen.Eggs }), "Expected a list containing only Eggs.");
    }

    [Test]
    public void CreateAllergy_WithEmptyArray_ShouldReturnScoreZero()
    {
        var allergies = AllergiesCsharpImplementation.Allergies.CreateAllergy(new Allergen[] { });
        Assert.That(allergies.score, Is.EqualTo(0), "Expected score to be 0 for an empty allergen list.");
    }

    [Test]
    public void CreateAllergy_WithEggsArray_ShouldReturnScoreOne()
    {
        var allergies = AllergiesCsharpImplementation.Allergies.CreateAllergy(new[] { Allergen.Eggs });
        Assert.That(allergies.score, Is.EqualTo(1), "Expected score to be 1 for an allergen list containing only Eggs.");
    }
}
