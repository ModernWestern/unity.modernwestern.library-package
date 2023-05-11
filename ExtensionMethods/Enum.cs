using System;
using UnityEngine;

namespace ModernWestern
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts an enum value to an integer.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="enumItem">The enum value to convert to an integer.</param>
        /// <returns>The integer representation of the enum value.</returns>
        /// <example>
        /// enum MyEnum { Value1 = 1, Value2 = 2, Value3 = 3 }
        /// MyEnum myEnumValue = MyEnum.Value2;
        /// int intValue = myEnumValue.ToInt();
        /// </example>
        public static int ToInt<T>(this T enumItem) where T : Enum
        {
            return Convert.ToInt32(enumItem);
        }

        /// <summary>
        /// Converts a string to an enum value of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the enum to convert to.</typeparam>
        /// <param name="str">The string to convert to an enum value.</param>
        /// <returns>The enum value corresponding to the input string, or the default value of the enum type if the input string is not a valid enum value.</returns>
        public static T ToEnum<T>(this string str)
        {
            try
            {
                var result = (T)Enum.Parse(typeof(T), str);

                return Enum.IsDefined(typeof(T), result) ? result : default;
            }
            catch
            {
#if UNITY_EDITOR

                Debug.Log($"{str} is not a member of the {typeof(T)} enumValue");
#endif
                return default;
            }
        }


        /// <summary>
        /// Cast the enum value to the specified type, and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the enum to match to.</typeparam>
        /// <param name="enumValue">The enum value to match.</param>
        /// <returns>The enum value cast to the specified type, or the default value of the specified type if the match is unsuccessful.</returns>
        public static T CastToEnumType<T>(this Enum enumValue)
        {
            if (enumValue.ToString().ToEnum<T>() is { } e)
            {
                return e;
            }
            else
            {
                return default;
            }
        }
    }
}