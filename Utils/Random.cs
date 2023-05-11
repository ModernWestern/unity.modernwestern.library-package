using System.Linq;

namespace ModernWestern
{
    public static class Random
    {
        /// <summary>
        /// Returns a random value from a list of values with assigned probabilities. The sum of all the probabilities must be 10.
        /// </summary>
        /// <typeparam name="T">The type of the values to select from.</typeparam>
        /// <param name="values">The list of values and their probabilities.</param>
        /// <returns>A random value from the list.</returns>
        /// <example>
        /// string bodyPart = RandomValue(("Heads", 8f), ("Tails", 2f));
        /// </example>
        public static T RandomValue<T>(params (T Value, float Probability)[] values)
        {
            var totalProbability = values.Sum(v => v.Probability);

            var randomValue = UnityEngine.Random.Range(0, totalProbability);

            var cumulativeProbability = 0f;

            foreach (var (value, probability) in values)
            {
                cumulativeProbability += probability;

                if (randomValue < cumulativeProbability)
                {
                    return value;
                }
            }

            return values.Last().Value;
        }

        /// <summary>
        /// Returns a random boolean value (true or false).
        /// </summary>
        /// <returns>A randomly selected boolean value.</returns>
        public static bool Boolean()
        {
            return UnityEngine.Random.Range(0, 2) == 0;
        }
    }
}