using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public Food(string name) : this(name, 0, 0, 0, 0) { }
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            // TODO: check
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Сarbohydrates = carbohydrates / 100.0;

        }

        public string Name { get; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Сarbohydrates { get; }
        /// <summary>
        /// Каллории за 100 грамм продукта.
        /// </summary>
        public double Calories { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
