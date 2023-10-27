// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("c# is shit");


void test(string str, ulong expect)
{
    ulong ret = utility.MurmurHash64B.MakeHashValue(Encoding.UTF8.GetBytes(str));
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
void Main()
{
    test("hello world", 15872188016033428291ul);
    test("hello|world", 18154384023894766483ul);
    test("world hello", 3885965473734762678ul);
    test("123456789|1001", 3735326771242004321ul);
    test("123456789|1002", 1645870013858767195ul);
    Console.WriteLine("");
}

Main();
