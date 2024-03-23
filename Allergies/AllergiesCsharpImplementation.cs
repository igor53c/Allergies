using System;
using System.Collections.Generic;
using System.Linq;

namespace AllergiesCsharpImplementation
{
    public enum Allergen
    {
        Eggs = 1 << 0,
        Peanuts = 1 << 1,
        Shellfish = 1 << 2,
        Strawberries = 1 << 3,
        Tomatoes = 1 << 4,
        Chocolate = 1 << 5,
        Pollen = 1 << 6,
        Cats = 1 << 7
    }

    public class Allergies
    {
        public readonly int score;

        public static Allergies CreateAllergy(Allergen[] allergens)
        {
            // scenario 3
            int score = allergens.Aggregate(0, (current, allergen) => current | (int)allergen);
            return new Allergies(score);
        }

        public Allergies(int score) => this.score = score;

        public bool IsAllergicTo(Allergen allergen)
        {
            // scenario 1
            return (score & (int)allergen) == (int)allergen;
        }

        public Allergen[] List()
        {
            // scenario 2
            var allergiesList = new List<Allergen>();
            foreach (Allergen allergen in Enum.GetValues(typeof(Allergen)))
            {
                if (IsAllergicTo(allergen))
                {
                    allergiesList.Add(allergen);
                }
            }
            return allergiesList.ToArray();
        }
    }
}
