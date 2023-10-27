package main

import "encoding/binary"

func Murmurhash64b(key []byte, seed uint32) uint64 {
	const (
		m           uint32 = 0x5bd1e995
		r           int    = 24
		defaultSeed uint32 = 0xee6b27eb
	)
	if seed == 0 {
		seed = defaultSeed
	}
	keyLen := len(key)
	h1 := seed ^ uint32(keyLen)
	h2 := uint32(0)

	offset := 0
	e := binary.LittleEndian

	for keyLen >= 8 {
		k1 := e.Uint32(key[offset : offset+4])
		k1 *= m
		k1 ^= k1 >> r
		k1 *= m
		h1 *= m
		h1 ^= k1

		offset += 4
		keyLen -= 4

		k2 := e.Uint32(key[offset : offset+4])
		k2 *= m
		k2 ^= k2 >> r
		k2 *= m
		h2 *= m
		h2 ^= k2

		offset += 4
		keyLen -= 4
	}

	if keyLen >= 4 {
		k1 := e.Uint32(key[offset : offset+4])
		k1 *= m
		k1 ^= k1 >> r
		k1 *= m
		h1 *= m
		h1 ^= k1

		offset += 4
		keyLen -= 4
	}

	switch keyLen {
	case 3:
		h2 ^= uint32(key[offset+2]) << 16
		fallthrough
	case 2:
		h2 ^= uint32(key[offset+1]) << 8
		fallthrough
	case 1:
		h2 ^= uint32(key[offset+0])
		h2 *= m
	}

	h1 ^= h2 >> 18
	h1 *= m
	h2 ^= h1 >> 22
	h2 *= m
	h1 ^= h2 >> 17
	h1 *= m
	h2 ^= h1 >> 19
	h2 *= m

	h := uint64(h1)

	h = (h << 32) | uint64(h2)

	return h
}
