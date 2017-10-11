// Solution4.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "WinDef.h" 


int _tmain(int argc, _TCHAR* argv[])
{
	return 0;
}

BYTE MirrorBits (BYTE b)
{
    BYTE mask [] = {0xAA, 0xCC, 0xF0};
    int i;
    for (i = 0; i < sizeof(mask)/sizeof(BYTE); i++)
    {
        b = ((b & mask[i]) >> (i+1)) | ((b & ~mask[i]) << (i+1));
    }
    return b;
}