package main

import "fmt"

func thash64(str string, expect uint64) {
	ret := Murmurhash64bStr(str)
	if expect == ret {
		fmt.Println("ok.")
	} else {
		fmt.Println("not ok.")
		fmt.Println("expect:", expect, " ret:", ret)
		fmt.Println("str:", str)
	}
}

func thashii(v1 int64, v2 int32, expect uint64) {
	ret := Murmurhash64bLD(v1, v2)
	if expect == ret {
		fmt.Println("ok.")
	} else {
		fmt.Println("not ok.")
		fmt.Println("expect:", expect, " ret:", ret)
		fmt.Println("v1:", v1, " v2:", v2)
	}
}

func main() {
	thash64("hello world", 15872188016033428291)
	thash64("hello|world", 18154384023894766483)
	thash64("world hello", 3885965473734762678)
	thash64("123456789|1001", 3735326771242004321)
	thash64("123456789|1002", 1645870013858767195)
	thash64("你好世界", 3269873437238233672)
	thash64("1717720317549350912|1001", 9344049702176278212)
	thashii(1717720317549350912, 1001, 3168977379835420589)
}
