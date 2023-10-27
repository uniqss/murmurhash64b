// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("c# is shit");


void test(string str, ulong expect)
{
    ulong ret = utility.MurmurHash64B.StringToHashValue(str);
    if (expect == ret)
    {
        Console.WriteLine("ok.");
    } else
    {
        Console.WriteLine();
        Console.WriteLine("not ok.");
        Console.WriteLine(expect);
        Console.WriteLine(ret);
        Console.WriteLine(str);
    }
}

void testii(long i1, int i2, ulong expect)
{
    ulong ret = utility.MurmurHash64B.HashII(i1, i2);
    if (expect == ret)
    {
        Console.WriteLine("ok.");
    } else
    {
        Console.WriteLine();
        Console.WriteLine("not ok.");
        Console.WriteLine(expect);
        Console.WriteLine(ret);
        Console.WriteLine(i1);
        Console.WriteLine(i2);
    }
}
void Main()
{
    test("hello world", 15872188016033428291ul);
    test("hello|world", 18154384023894766483ul);
    test("world hello", 3885965473734762678ul);
    test("123456789|1001", 3735326771242004321ul);
    test("123456789|1002", 1645870013858767195ul);
    test("你好世界", 3269873437238233672ul);
    test("1717720317549350912|1001", 9344049702176278212ul);
    testii(1717720317549350912, 1001, 3168977379835420589ul);
    Console.WriteLine("");
}

Main();
