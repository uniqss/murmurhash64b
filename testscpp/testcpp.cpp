#include "../c++/murmurhash64b.hpp"

#include <string>
#include <iostream>
using std::string;
using std::cout;
using std::endl;

void test(const string& str, unsigned long long expect) {
    auto ret = utility::MurmurHash64B(str.c_str(), (int)str.size());
    if (expect == ret) {
        cout << "ok." << endl;
    } else {
        cout << "not ok." << endl;
        cout << "str:" << str << endl;
        cout << "expected: " << expect << " ret: " << ret << endl;
    }
}

int main() {
    test("hello world", 15872188016033428291ul);
    test("hello|world", 18154384023894766483ul);
    test("world hello", 3885965473734762678ul);
    test("123456789|1001", 3735326771242004321ul);
    test("123456789|1002", 1645870013858767195ul);
    return 0;
}
