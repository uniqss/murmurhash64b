package main

import "fmt"

func thash64(str string, expect uint64) {
	ret := Murmurhash64b([]byte(str), 0)
	if expect == ret {
		fmt.Println("ok.")
	} else {
		fmt.Println("not ok.")
		fmt.Println("expect:", expect, " ret:", ret)
		fmt.Println("str:", str)
	}
}

func main() {
	thash64("hello world", 15872188016033428291)
	thash64("hello|world", 18154384023894766483)
	thash64("world hello", 3885965473734762678)
	thash64("123456789|1001", 3735326771242004321)
	thash64("123456789|1002", 1645870013858767195)
}
