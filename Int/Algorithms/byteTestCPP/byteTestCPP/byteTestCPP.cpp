// byteTestCPP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

unsigned char MirrorBits (unsigned char b);


int _tmain(int argc, _TCHAR* argv[])
{
	unsigned char input = 0x08;
	unsigned char x = input;
	x = ((x & 0xAA) >> 1) | ((x & 0x55) << 1);
    x = ((x & 0xCC) >> 2) | ((x & 0x33) << 2);
    x = ((x & 0xF0) >> 4) | ((x & 0x0F) << 4);

	unsigned char mirrorbyte = MirrorBits(input);
	return 0;
}

unsigned char MirrorBits (unsigned char b)
{
    unsigned char mask [] = {0xAA, 0xCC,0xF0};
    int i;
	int y = 1;
    for (i = 0; i < sizeof(mask)/sizeof(unsigned char); i++)
    {
		b = ((b & mask[i]) >> y) | ((b & ~mask[i]) << y);
		y = y << 1;
    }
    return b;
}

