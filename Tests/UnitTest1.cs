using App; // ������ ��������� (Dependencies - Project Reference) �� ������ App
namespace Tests
{
    [TestClass]
    public class UnitTestApp
    {
        [TestMethod]
        public void TestRomanNumberParse()
        {
            Assert.AreEqual(                   // RomanNumber.Parse("I").Value == 1
                1,                             // ��������, �� ��������� (�� �� ����, ���������� ������)
                 RomanNumber                   // ��������� �������� (��, �� ����������)
                 .Parse("I")                   //
                 .Value                        //
                 , "1 == I");                  // �����������, �� �'������� ��� ������ �����
            
            Assert.AreEqual(
                2,
                 RomanNumber
                 .Parse("II")
                 .Value
                 , "2 == II");
        }
    }
}
/* ������ ��������� ����� ��������� ���������� (Asserts).
 * � ��������� ��������� ��� ��������: ��, �� ���������, ��
 * ��, �� ����������.
 * ��������� ����� ���������� ������ (��'����� AreSame �� ��������� AreEqual),
 * ��� � ��������� ����(IsTrue, IsNotNull, ....)
 */