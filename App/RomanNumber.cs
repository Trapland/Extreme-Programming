using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class RomanNumber
    {
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
                return "N";

            bool isNegative = Value < 0;
            var number = isNegative ? -Value : Value;

            StringBuilder sb = new();
            if (isNegative)
            {
                sb.Append("-");
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

        public static RomanNumber Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Null or empty input");
            }
            input = input.Trim();

            if (input == "N") return new(); // Value = 0 -- default

            if (input == "IIX")
            {
                throw new ArgumentException("Null or empty input");
            }

            int prev = 0;
            int current = 0;
            int result = 0;
            int lastDigitIndex = input[0] == '-' ? 1 : 0;

            // тест на легальність - лівіше від цифри може бути лише одна
            // цифра, що є меншою за дану (див. TestRomanNumberParseIllegal())
            // if (input == "IIX" || input == "IIV")
            int maxDigit = 0;
            int lessDigitsCount = 0;
            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                int digitValue = DigitValue(input[i]);
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

            //int lastbig = 0;
            //int falseNumCounter = 0;

            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                current = input[i] switch
                {
                    'I' => 1,
                    'V' => 5,
                    'X' => 10,
                    'L' => 50,
                    'C' => 100,
                    'D' => 500,
                    'M' => 1000,
                    _ => throw new ArgumentException($"Invalid Roman digit: '{input[i]}'"),
                };
                //if(lastbig <= current)
                //{
                //    lastbig = current;
                //    falseNumCounter = 0;
                //}
                //else
                //{
                //    falseNumCounter++;
                //}
                //if (falseNumCounter == 2)
                //{
                //    throw new ArgumentException($"Invalid Roman digit: '{input}'");
                //}

                result += prev <= current ? current : -current;
                prev = current;
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
            private static int DigitValue(char digit)
            {
                return digit switch
                {
                    'I' => 1,
                    'V' => 5,
                    'X' => 10,
                    'L' => 50,
                    'C' => 100,
                    'D' => 500,
                    'M' => 1000,
                    _ => throw new ArgumentException($"Invalid Roman digit: '{digit}'")
                };
            }
        }
    }
}
