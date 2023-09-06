using App; // додати залежність (Dependencies - Project Reference) від проєкту App
namespace Tests
{
    [TestClass]
    public class UnitTestApp
    {
        [TestMethod]
        public void TestToString()
        {
            Dictionary<int, String> testCases = new()
            {
                {0, "N" },
                {1, "I" },
                {2, "II" },
                {3, "III" },
                {4, "IV" },
                {5, "V" },
                {6, "VI" },
                {7, "VII" },
                {8, "VIII" },
                {9, "IX" },
                {10, "X" },
                {11, "XI" },
                {12, "XII" },
                {13, "XIII" },
                {14, "XIV" },
                {15, "XV" },
                {16, "XVI" },
                {17, "XVII" },
                {18, "XVIII" },
                {19, "XIX" },
                {20, "XX" },
                {21, "XXI" },
                {22, "XXII" },
                {23, "XXIII" },
                {29, "XXIX"},
                {30, "XXX" },
                {33, "XXXIII" },
                {39, "XXXIX"},
                {40, "XL" },
                {44, "XLIV" },
                {48, "XLVIII" },
                {50, "L" },
                {51, "LI" },
                {52, "LII" },
                {55, "LV" },
                {59, "LIX" },
                {62, "LXII" },
                {64, "LXIV" },
                {66, "LXVI" },
                {75, "LXXV" },
                {77, "LXXVII" },
                {81, "LXXXI" },
                {88, "LXXXVIII" },
                {90, "XC" },
                {92, "XCII" },
                {99, "XCIX" },
                {100, "C" },
                {105, "CV" },
                {107, "CVII" },
                {111, "CXI" },
                {115, "CXV" },
                {123, "CXXIII" },
                {222, "CCXXII" },
                {234, "CCXXXIV" },
                {246, "CCXLVI"},
                {321, "CCCXXI" },
                {333, "CCCXXXIII" },
                {345, "CCCXLV" },
                {378, "CCCLXXVIII"},
                {404, "CDIV" },
                {444, "CDXLIV" },
                {456, "CDLVI" },
                {500, "D" },
                {555, "DLV" },
                {567, "DLXVII" },
                {609, "DCIX" },
                {666, "DCLXVI" },
                {678, "DCLXXVIII" },
                {777, "DCCLXXVII" },
                {789, "DCCLXXXIX" },
                {888, "DCCCLXXXVIII" },
                {890, "DCCCXC" },
                {901, "CMI" },
                {999, "CMXCIX" },
                {1000, "M" },
                {1007, "MVII" },
                {1111, "MCXI" },
                {1199, "MCXCIX"},
                {1234, "MCCXXXIV" },
                {1317, "MCCCXVII" },
                {1350, "MCCCL"},
                {1432, "MCDXXXII" },
                {1500, "MD" },
                {1575, "MDLXXV" },
                {1632, "MDCXXXII" },
                {1667, "MDCLXVII" },
                {1734, "MDCCXXXIV" },
                {1872, "MDCCCLXXII" },
                {1969, "MCMLXIX" },
                {1985, "MCMLXXXV" },
                {2023, "MMXXIII" },
                {2048, "MMXLVIII" },
                {2107, "MMCVII" },
                {2184, "MMCLXXXIV" },
                {2222, "MMCCXXII" },
                {2247, "MMCCXLVII"},
                {2288, "MMCCLXXXVIII" },
                {2345, "MMCCCXLV" },
                {2392, "MMCCCXCII" },
                {2496, "MMCDXCVI" },
                {2499, "MMCDXCIX"},
                {2500, "MMD" },
                {2678, "MMDCLXXVIII" },
                {2700, "MMDCC"},
                {2781, "MMDCCLXXXI" },
                {2884, "MMDCCCLXXXIV" },
                {2958, "MMCMLVIII" },
                {2999, "MMCMXCIX"},
                {3000, "MMM" },
                {-1968, "-MCMLXVIII" },
                {-1272, "-MCCLXXII" },
                {-1456, "-MCDLVI" },
                {-1785, "-MDCCLXXXV" },
                {-2142, "-MMCXLII" },
                {-2266, "-MMCCLXVI" },
                {-2510, "-MMDX" },
                {-2727, "-MMDCCXXVII" },
                {-2814, "-MMDCCCXIV" },
                {-2987, "-MMCMLXXXVII" },
                { -23, "-XXIII" },
                { -169, "-CLXIX" },
                { -313, "-CCCXIII" },
                { -996, "-CMXCVI" },
                { -2998, "-MMCMXCVIII"},
                { -2947, "-MMCMXLVII" },
                { -2970, "-MMCMLXX" },
                { -2730, "-MMDCCXXX" },
                { -2756, "-MMDCCLVI" },
                { -2767, "-MMDCCLXVII" },
                { -2777, "-MMDCCLXXVII" },
                { -2799, "-MMDCCXCIX" },
                { -1603, "-MDCIII" },
                { -1674, "-MDCLXXIV" },
                { -1718, "-MDCCXVIII" },
                { -1742, "-MDCCXLII" },
                { -1747, "-MDCCXLVII" },
                { -1784, "-MDCCLXXXIV" },
                { -1796, "-MDCCXCVI" },
                { -1884, "-MDCCCLXXXIV" },
                { -1945, "-MCMXLV" },
                { -1951, "-MCMLI" },
                { -1972, "-MCMLXXII" },
                { -1980, "-MCMLXXX" },
                { -456, "-CDLVI" },
                { -500, "-D" },
                { -555, "-DLV" },
                { -567, "-DLXVII" },
                { -609, "-DCIX" },
                { -666, "-DCLXVI" },
                { -678, "-DCLXXVIII" },
                { -777, "-DCCLXXVII" },

            };
            foreach (var pair in testCases)
            {
                Assert.AreEqual(pair.Value, new RomanNumber(pair.Key).ToString(), $"{pair.Key}.ToString() == {pair.Value}");
            }
            Assert.AreEqual("N",
                new RomanNumber().ToString(),
                $"new RomanNumber() == 'N'");
        }

        private static Dictionary<String, int> parseTests = new()
        {
            {"I"          , 1 },
            {"II"         , 2 },
            {"III"        , 3 },
            {"IIII"       , 4 }, // Особливі твердження - з них ми визначаємо про
            {"IV"         , 4 }, // підтримку неоптимальних записів чисел
            {"V"          , 5 },
            {"VI"         , 6 },
            {"VII"        , 7 },
            {"VIII"       , 8 },
            {"IX"         , 9 },
            { "X"         , 10 },
            { "VV"        , 10 }, // ще одне наголошення неоптимальності
            { "IIIIIIIIII", 10 }, // ще одне наголошення неоптимальності
            { "VX"        , 5 }, // ще одне наголошення неоптимальності
            { "N"         , 0 }, // доповнюємо множину чисел нулем
            { "-L"        , -50 }, // вказуємо, що можливі від'ємні числа
            { "-XL"       , -40 },
            { "-IL"       , -49 }, // неоптимальностість
            { "C"         , 100 },
            { "D"         , 500 },
            { "M"         , 1000 },
            { "CCCC"      , 400 },
            { "XD"        , 490 },
            { "LM"        , 950 },
            { "CDX"       , 410 },
            { "DDD"       , 1500 },
            { "VM"        , 995 },
            { "MDCC"      , 1700 },
            { "DDDIV"     , 1504 },
            { "MMMM"      , 4000 },
            {"LX"         , 60 },
            {"LXII"       , 62 },
            {"CCL"        , 250 },
            {"-CCIII"     , -203 },
            {"-LIV"       , -54},
            {"MDII"       , 1502 },
            { "-D"        , -500 },
            { "-C"        , -100 },
            { "-M"        , -1000 },
            { "IM"        , 999 },
            { "-IM"       , -999 },
            { "IC"        , 99 },
            { "-IC"       , -99 },
            { "ID"        , 499 },
            { "-ID"       , -499 },
            { "-VM"       , -995 },
            { "VC"        , 95 },
            { "-VC"       , -95 },
            { "VD"        , 495 },
            { "-VD"       , -495 },
            { "XM"        , 990 },
            { "-XM"       , -990 },
            { "XC"        , 90 },
            { "-XC"       , -90 },
            { "-XD"       , -490 },
            { "MI"        , 1001 },
            { "-MI"       , -1001 },
            { "CI"        , 101 },
            { "-CI"       , -101 },
            { "DI"        , 501 },
            { "-DI"       , -501 },
            { "MV"        , 1005 },
            { "-MV"       , -1005 },
            { "CV"        , 105 },
            { "-CV"       , -105 },
            { "DV"        , 505 },
            { "-DV"       , -505 },
            { "MX"        , 1010 },
            { "-MX"       , -1010 },
            { "CX"        , 110 },
            { "-CX"       , -110 },
            { "DX"        , 510 },
            { "-DX"       , -510 },
            { "CMD"       , 1400 },
            { "CLI"       , 151},
            { "LID"       , 549},
            { "DID"       , 999},
            { "DMC"       , 600},
            {"MMXXIII"    , 2023},
            {"CDIV"       , 404},
            {"CDXXXXIV"       , 444},
            {"DXXXXV"       , 545},
            {"DVVV"       , 515},
            {"CVIIIII"       , 110},
            {"DVD"       , 995},
            {"DDDD"       , 2000},
            {"XXXXXX"       , 60},
            {"IXIXIXIX"       , 36},
            {"ILIL"       , 98},
            {"XLX"       , 50},
            {"LC"       , 50},
            {"CCCCC"       , 500},
            {"ICI"       , 100},
            {"XCX"       , 100},
            {"XDX"       , 500},
            {"XMX"       , 1000},
            {"XXVV"       , 30},
            {"LLLLL"       , 250},
            {"XXXXXXXIIIIIII"       , 77},
            {"DXXXX"       , 540},
            {"DIIIII"       , 505},
            {"DIIIII "       , 505},
            {" DIIIII "       , 505},
            {" DIIIII"       , 505},
            {"\nDIIIII\t"       , 505},
        };

        [TestMethod]
        public void TestRomanNumberParseValid()
        {
            Assert.AreEqual(                   // RomanNumber.Parse("I").Value == 1
                1,                             // Значення, що очікується (що має бути, правильний варіант)
                 RomanNumber                   // Актуальне значення (те, що вирахуване)
                 .Parse("I")                   //
                 .Value                        //
                 , "1 == I");                  // Повідомлення, що з'явиться при провалі тесту
            foreach (var pair in parseTests)
            {
                Assert.AreEqual(
                pair.Value,
                 RomanNumber
                 .Parse(pair.Key)
                 .Value
                 , $"{pair.Value} == {pair.Key}");
            }

        }
        [TestMethod]
        public void TestRomanNumberParseNonValid()
        {
            // Тестування з неправильними формами чисел
            Assert.ThrowsException<ArgumentException>(
            () => RomanNumber.Parse(null!), "null -> ArgumentException");
            Assert.ThrowsException<ArgumentException>(
            () => RomanNumber.Parse(""), "'' -> ArgumentException");
            // саме виключення, що виникло у лямбді, повертається як рез-т
            var ex = Assert.ThrowsException<ArgumentException>(
            () => RomanNumber.Parse("XBC"), "XBC -> ArgumentException");
            // вимагаємо, щоб відомості про неправильну цифру ('B') було
            // включено у повідомлення виключення
            Assert.IsTrue(ex.Message.Contains('B'), "ex.Message should Contain 'B'");
            Dictionary<String, Char> testCases = new()
            {
                { "Xx", 'x' },
                { "Xy", 'y' },
                { "AX", 'A' },
                { "X C", ' ' },
                { "X\tC", '\t' },
                { "X\nC", '\n' },
            };
            foreach (var pair in testCases)
            {
                Assert.IsTrue(
                    Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.Parse(pair.Key),
                    $"'{pair.Key}' -> ArgumentException")
                        .Message.Contains($"'{pair.Value}'"),
                    $"ex.Message should Contain '{pair.Value}'");
            }
            ex = Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse("ABC"), "'' -> ArgumentException");
            Assert.IsTrue(ex.Message.Contains('A') || ex.Message.Contains('B'), "'ABC' ex.Message should Contain either 'A' or 'B'");
            // * перевіримо, що повідомлення(виключення) не занадто коротке
            // мову чи інші слова не встановлюємо, але щоб не одна літера -
            // накладемо умову на довжину повідомлення (15 літер)
            Assert.IsFalse(ex.Message.Length < 15, "ex.Message.Length min 15");
        }

        [TestMethod]
        public void CrossRomanNumberTest()
        {
            int random = 0;
            for (int i = 0; i < 256; i++)
            {
                random = Random.Shared.Next(6001) - 3000;
                Assert.AreEqual(random,
                    RomanNumber
                 .Parse(new RomanNumber(random).ToString())
                 .Value,
                    $"{random}.ToString() == {random}");
            }
        }
    }
}

/* Тестування виключень(exceptions)
 * У системі тестування виключення - провали тесту.
 * Тому вирази, що мають завершуватись виключеннями, оточують
 * функціональними виразами (лямбдами). Це дозволяє перенести
 * появу виключення у середину тестового методу, де воно буде
 * оброблене належним чином.
 * Особливості:
 *  - перевіряється суворий збіг типів виключень, більш загальний
 *    тип не зараховується як проходження тесту
 *  - тест повертає викинуте виключення, це дозволяє накласти
 *  умови на повідомлення, причину, тощо
 *  
 *  Слухання які з комбінацій вважати правильними, які ні
 *  'X C', ' XC', 'XC ', 'XC\t', '\nXC', 'XC\n', 'X\nC',
 *    x       v     v       v       v       v       x
 */


/* Основу модульних тестів складають твердження (Asserts).
 * У твердженні фігурують два значення: те, що очікується, та
 * те, що одержується.
 * Більшість тестів перевіряють рівність (об'єктну AreSame чи контентну AreEqual),
 * або у скороченій формі(IsTrue, IsNotNull, ....)
 */