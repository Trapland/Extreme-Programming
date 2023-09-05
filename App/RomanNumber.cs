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

        public static RomanNumber Parse(string input)
        {
            input = input.ToUpper();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Null or empty input");
            }
            if (input == "N") return new(); // Value = 0 -- default

            int prev = 0;
            int current = 0;
            int result = 0;
            int lastDigitIndex = input[0] == '-' ? 1 : 0;
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
                };
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
        }
    }
}
