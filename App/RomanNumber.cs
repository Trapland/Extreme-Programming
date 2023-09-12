using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class RomanNumber
    {
        private const char ZERO_DIGIT = 'N';
        private const char MINUS_SIGN = '-';
        private const char DIGIT_QUOTE = '\'';
        private const String INVALID_DIGIT_MESSAGE = "Invalid Roman digit(s):";
        private const String EMPTY_INPUT_MESSAGE = "Null or empty input";
        private const String DIGITS_SEPARATOR = ", ";

        public int Value { get; set; }

        public RomanNumber(int value = 0)
        {
            Value = value;
        }

        public override string ToString()
        {
            // відобразити значення Value у формі римського числа
            // головна ідея - послідовне зменшення початкового числа i
            // формування результату
            Dictionary<int, String> parts = new()
            {
                {1000, "M" },
                {900,  "CM" },
                {500,  "D" },
                {400,  "CD" },
                {100,  "C" },
                {90,  "XC" },
                {50,  "L" },
                {40,  "XL" },
                {10,  "X" },
                {9,  "IX" },
                {5,  "V" },
                {4,  "IV" },
                {1,  "I" },
            };
            if (Value == 0)
                return ZERO_DIGIT.ToString();

            bool isNegative = Value < 0;
            var number = isNegative ? -Value : Value;

            StringBuilder sb = new();
            if (isNegative)
            {
                sb.Append(MINUS_SIGN);
            }
            foreach (var part in parts)
            {
                while (number >= part.Key)
                {
                    sb.Append(part.Value);
                    number -= part.Key;
                }
            }
            return sb.ToString();

            /*string romanNumber = "";

            var number = Value;
            if(number < 0)
            {
                romanNumber += "-";
                number = -number;
            }
            foreach (var part in parts)
            {
                int num = number / part.Key;
                if (num >= 1)
                {
                    for (int i = 0; i < num; i++)
                    {
                        romanNumber += part.Value;
                    }
                }
                number -= num * part.Key;
            }
            return romanNumber;*/
        }

        public RomanNumber Add(RomanNumber number)
        {
            return new() { Value = Value + number.Value};
        }

        public static RomanNumber Parse(string input)
        {
            input = input?.Trim();

            if (input == ZERO_DIGIT.ToString()) return new(); // Value = 0 -- default

            CheckValidityOrThrow(input);
            CheckLegalityOrThrow(input);

            int prev = 0;
            int result = 0;
            int lastDigitIndex = input?[0] == MINUS_SIGN ? 1 : 0;
            int digitValue;

            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                digitValue = DigitValue(input[i]);
                result += prev <= digitValue ? digitValue : -digitValue;
                prev = digitValue;
            }
            

            return new() { Value = result * (1 - 2 * lastDigitIndex) };
            //}
            //int result = 0;
            //for (int i = input.Length - 1; i >= 0; i--)
            //{
            //    if (input[i] == 'X')
            //    {
            //        result += 10;
            //    }
            //    else if (input[i] == 'V')
            //    {
            //        result += 5;
            //    }
            //    else
            //    {
            //        if (i != input.Length - 1 && (input[i + 1] == 'V' || input[i + 1] == 'X'))
            //        {
            //            result--;
            //        }
            //        else
            //        {
            //            result++;
            //        }
            //    }
            //}
            //if(input == "I")
            //{
            //    return new()
            //    {
            //        Value = 1
            //    };
            //}
            //if (input == "II")
            //{
            //    return new()
            //    {
            //        Value = 2
            //    };
            //}
            //return new()
            //{
            //    Value = 1
            //};

            //return new()
            //{
            //    Value = result 
            //input.Length для тестів "I","II","III"
            //input switch варіант для тестів "I","II","III"
            //{
            //    "I" => 1,
            //    "II" => 2,
            //    "III" => 3,
            //}

            //input == "I" ? 1 : 2 для тестів "I","II"

            /*Правило "читання" римських чисел:
             * Якщо цифра передує
             * більшій цифрі, то вона віднімається (IV, IX) - "I" передує більшій цифрі
             * меншій або рівній - додається (VI, II, XI)
             * Решту правил ігноруємо - робимо максимально "дружній" інтерфейс
             * 
             * Алгоритм - "заходимо" з правої цифри, її завжди додаємо, запам'ятовуємо,
             * і далі порівнюємо з наступною цифрою
             */
            //};

        }

        private static void CheckValidityOrThrow(String input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(EMPTY_INPUT_MESSAGE);
            }

            if(input.StartsWith(MINUS_SIGN))
            {
                input = input[1..];
            }
            if(input.Contains(MINUS_SIGN))
            {
                throw new ArgumentException($"{INVALID_DIGIT_MESSAGE} {DIGIT_QUOTE}{MINUS_SIGN}{DIGIT_QUOTE}");
            }
            if (input.Contains(ZERO_DIGIT))
            {
                throw new ArgumentException($"{INVALID_DIGIT_MESSAGE} {DIGIT_QUOTE}{ZERO_DIGIT}{DIGIT_QUOTE}");
            }

            List<char> invalidChars = new();

            foreach (char c in input)
            {
                try { DigitValue(c); }
                catch { invalidChars.Add(c); }
            }
            if (invalidChars.Count > 0)
            {
                String chars = String.Join(DIGITS_SEPARATOR, invalidChars.Select(c => $"{DIGIT_QUOTE}{c}{DIGIT_QUOTE}"));
                throw new ArgumentException($"{INVALID_DIGIT_MESSAGE} {DIGIT_QUOTE}{chars}{DIGIT_QUOTE}");
            }

        }

        private static void CheckLegalityOrThrow(String input)
        {
            int lastDigitIndex = input[0] == MINUS_SIGN ? 1 : 0;
            int maxDigit = 0;
            int lessDigitsCount = 0;
            int digitValue;

            // тест на легальність - лівіше від цифри може бути лише одна
            // цифра, що є меншою за дану (див. TestRomanNumberParseIllegal())
            // if (input == "IIX" || input == "IIV")

            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                digitValue = DigitValue(input[i]);
                if (digitValue < maxDigit)
                {
                    lessDigitsCount += 1;
                    if (lessDigitsCount > 1)
                    {
                        throw new ArgumentException(input);
                    }
                }
                else
                {
                    maxDigit = digitValue;
                    lessDigitsCount = 0;
                }
            }

        }

        private static int DigitValue(char digit)
        {
            return digit switch
            {
                ZERO_DIGIT => 0,
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                 _ => throw new ArgumentException($"{INVALID_DIGIT_MESSAGE} {DIGIT_QUOTE}{digit}{DIGIT_QUOTE}")
                // із зміною вимог - залишити у повідомленні усі неправильні символи
            };
        }
    }
}
