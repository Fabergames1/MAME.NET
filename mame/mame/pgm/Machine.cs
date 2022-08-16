﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mame
{
    public partial class PGM
    {
        public static int kb_game_id, kb_region;
        public static ushort kb_prot_hold, kb_prot_hilo, kb_prot_hilo_select;
        public static int kb_cmd, kb_reg, kb_ptr;
        public static byte kb_swap;
        public static ushort olds_bs, kb_cmd3;
        public static byte[][] kb_source_data;
        public static byte[][] drgw2_source_data = new byte[0x08][]//[0xec]
        {
	        new byte[]{ 0, }, // Region 0, not used
	        new byte[]{   // Region 1, $13A886
		        0x67, 0x51, 0xF3, 0x19, 0xA0, 0x11, 0xB1, 0x11, 0xB0, 0xEE, 0xE3, 0xF6, 0xBE, 0x81, 0x35, 0xE3,
		        0xFB, 0xE6, 0xEF, 0xDF, 0x61, 0x01, 0xFA, 0x22, 0x5D, 0x43, 0x01, 0xA5, 0x3B, 0x17, 0xD4, 0x74,
		        0xF0, 0xF4, 0xF3, 0x43, 0xB5, 0x19, 0x04, 0xD5, 0x84, 0xCE, 0x87, 0xFE, 0x35, 0x3E, 0xC4, 0x3C,
		        0xC7, 0x85, 0x2A, 0x33, 0x00, 0x86, 0xD0, 0x4D, 0x65, 0x4B, 0xF9, 0xE9, 0xC0, 0xBA, 0xAA, 0x77,
		        0x9E, 0x66, 0xF6, 0x0F, 0x4F, 0x3A, 0xB6, 0xF1, 0x64, 0x9A, 0xE9, 0x25, 0x1A, 0x5F, 0x22, 0xA3,
		        0xA2, 0xBF, 0x4B, 0x77, 0x3F, 0x34, 0xC9, 0x6E, 0xDB, 0x12, 0x5C, 0x33, 0xA5, 0x8B, 0x6C, 0xB1,
		        0x74, 0xC8, 0x40, 0x4E, 0x2F, 0xE7, 0x46, 0xAE, 0x99, 0xFC, 0xB0, 0x55, 0x54, 0xDF, 0xA7, 0xA1,
		        0x0F, 0x5E, 0x49, 0xCF, 0x56, 0x3C, 0x90, 0x2B, 0xAC, 0x65, 0x6E, 0xDB, 0x58, 0x3E, 0xC9, 0x00,
		        0xAE, 0x53, 0x4D, 0x92, 0xFA, 0x40, 0xB2, 0x6B, 0x65, 0x4B, 0x90, 0x8A, 0x0C, 0xE2, 0xA5, 0x9A,
		        0xD0, 0x20, 0x29, 0x55, 0xA4, 0x44, 0xAC, 0x51, 0x87, 0x54, 0x53, 0x34, 0x24, 0x4B, 0x81, 0x67,
		        0x34, 0x4C, 0x5F, 0x31, 0x4E, 0xF2, 0xF1, 0x19, 0x18, 0x1C, 0x34, 0x38, 0xE1, 0x81, 0x17, 0xCF,
		        0x24, 0xB9, 0x9A, 0xCB, 0x34, 0x51, 0x50, 0x59, 0x44, 0xB1, 0x0B, 0x50, 0x95, 0x6C, 0x48, 0x7E,
		        0x14, 0xA4, 0xC6, 0xD9, 0xD3, 0xA5, 0xD6, 0xD0, 0xC5, 0x97, 0xF0, 0x45, 0xD0, 0x98, 0x51, 0x91,
		        0x9F, 0xA3, 0x43, 0x51, 0x05, 0x90, 0xEE, 0xCA, 0x7E, 0x5F, 0x72, 0x53, 0xB1, 0xD3, 0xAF, 0x36,
		        0x08, 0x75, 0xB0, 0x9B, 0xE0, 0x0D, 0x43, 0x88, 0xAA, 0x27, 0x44, 0x11
	        },
	        new byte[]{ 0, }, // Region 2, not used
	        new byte[]{ 0, }, // Region 3, not used
	        new byte[]{ 0, }, // Region 4, not used
	        new byte[]{   // Region 5, $13ab42 (drgw2c)
		        0x7F, 0x41, 0xF3, 0x39, 0xA0, 0x11, 0xA1, 0x11, 0xB0, 0xA2, 0x4C, 0x23, 0x13, 0xE9, 0x25, 0x3D,
		        0x0F, 0x72, 0x3A, 0x9D, 0xB5, 0x96, 0xD1, 0xDA, 0x07, 0x29, 0x41, 0x9A, 0xAD, 0x70, 0xBA, 0x46,
		        0x63, 0x2B, 0x7F, 0x3D, 0xBE, 0x40, 0xAD, 0xD4, 0x4C, 0x73, 0x27, 0x58, 0xA7, 0x65, 0xDC, 0xD6,
		        0xFD, 0xDE, 0xB5, 0x6E, 0xD6, 0x6C, 0x75, 0x1A, 0x32, 0x45, 0xD5, 0xE3, 0x6A, 0x14, 0x6D, 0x80,
		        0x84, 0x15, 0xAF, 0xCC, 0x7B, 0x61, 0x51, 0x82, 0x40, 0x53, 0x7F, 0x38, 0xA0, 0xD6, 0x8F, 0x61,
		        0x79, 0x19, 0xE5, 0x99, 0x84, 0xD8, 0x78, 0x27, 0x3F, 0x16, 0x97, 0x78, 0x4F, 0x7B, 0x0C, 0xA6,
		        0x37, 0xDB, 0xC6, 0x0C, 0x24, 0xB4, 0xC7, 0x94, 0x9D, 0x92, 0xD2, 0x3B, 0xD5, 0x11, 0x6F, 0x0A,
		        0xDB, 0x76, 0x66, 0xE7, 0xCD, 0x18, 0x2B, 0x66, 0xD8, 0x41, 0x40, 0x58, 0xA2, 0x01, 0x1E, 0x6D,
		        0x44, 0x75, 0xE7, 0x19, 0x4F, 0xB2, 0xE8, 0xC4, 0x96, 0x77, 0x62, 0x02, 0xC9, 0xDC, 0x59, 0xF3,
		        0x43, 0x8D, 0xC8, 0xFE, 0x9E, 0x2A, 0xBA, 0x32, 0x3B, 0x62, 0xE3, 0x92, 0x6E, 0xC2, 0x08, 0x4D,
		        0x51, 0xCD, 0xF9, 0x3A, 0x3E, 0xC9, 0x50, 0x27, 0x21, 0x25, 0x97, 0xD7, 0x0E, 0xF8, 0x39, 0x38,
		        0xF5, 0x86, 0x94, 0x93, 0xBF, 0xEB, 0x18, 0xA8, 0xFC, 0x24, 0xF5, 0xF9, 0x99, 0x20, 0x3D, 0xCD,
		        0x2C, 0x94, 0x25, 0x79, 0x28, 0x77, 0x8F, 0x2F, 0x10, 0x69, 0x86, 0x30, 0x43, 0x01, 0xD7, 0x9A,
		        0x17, 0xE3, 0x47, 0x37, 0xBD, 0x62, 0x75, 0x42, 0x78, 0xF4, 0x2B, 0x57, 0x4C, 0x0A, 0xDB, 0x53,
		        0x4D, 0xA1, 0x0A, 0xD6, 0x3A, 0x16, 0x15, 0xAA, 0x2C, 0x6C, 0x39, 0x42
	        },
	        new byte[]{   // Region 6, $13ab42 (drgw2), $13ab2e (dw2v100x)
		        0x12, 0x09, 0xF3, 0x29, 0xA0, 0x11, 0xA0, 0x11, 0xB0, 0xD5, 0x66, 0xA1, 0x28, 0x4A, 0x21, 0xC0,
		        0xD3, 0x9B, 0x86, 0x80, 0x57, 0x6F, 0x41, 0xC2, 0xE4, 0x2F, 0x0B, 0x91, 0xBD, 0x3A, 0x7A, 0xBA,
		        0x00, 0xE5, 0x35, 0x02, 0x74, 0x7D, 0x8B, 0x21, 0x57, 0x10, 0x0F, 0xAE, 0x44, 0xBB, 0xE2, 0x37,
		        0x18, 0x7B, 0x52, 0x3D, 0x8C, 0x59, 0x9E, 0x20, 0x1F, 0x0A, 0xCC, 0x1C, 0x8E, 0x6A, 0xD7, 0x95,
		        0x2B, 0x34, 0xB0, 0x82, 0x6D, 0xFD, 0x25, 0x33, 0xAA, 0x3B, 0x2B, 0x70, 0x15, 0x87, 0x31, 0x5D,
		        0xBB, 0x29, 0x19, 0x95, 0xD5, 0x8E, 0x24, 0x28, 0x5E, 0xD0, 0x20, 0x83, 0x46, 0x4A, 0x21, 0x70,
		        0x5B, 0xCD, 0xAE, 0x7B, 0x61, 0xA1, 0xFA, 0xF4, 0x2B, 0x84, 0x15, 0x6E, 0x36, 0x5D, 0x1B, 0x24,
		        0x0F, 0x09, 0x3A, 0x61, 0x38, 0x0F, 0x18, 0x35, 0x11, 0x38, 0xB4, 0xBD, 0xEE, 0xF7, 0xEC, 0x0F,
		        0x1D, 0xB7, 0x48, 0x01, 0xAA, 0x09, 0x8F, 0x61, 0xB5, 0x0F, 0x1D, 0x26, 0x39, 0x2E, 0x8C, 0xD6,
		        0x26, 0x5C, 0x3D, 0x23, 0x63, 0xE9, 0x6B, 0x97, 0xB4, 0x9F, 0x7B, 0xB6, 0xBA, 0xA0, 0x7C, 0xC6,
		        0x25, 0xA1, 0x73, 0x36, 0x67, 0x7F, 0x74, 0x1E, 0x1D, 0xDA, 0x70, 0xBF, 0xA5, 0x63, 0x35, 0x39,
		        0x24, 0x8C, 0x9F, 0x85, 0x16, 0xD8, 0x50, 0x95, 0x71, 0xC0, 0xF6, 0x1E, 0x6D, 0x80, 0xED, 0x15,
		        0xEB, 0x63, 0xE9, 0x1B, 0xF6, 0x78, 0x31, 0xC6, 0x5C, 0xDD, 0x19, 0xBD, 0xDF, 0xA7, 0xEC, 0x50,
		        0x22, 0xAD, 0xBB, 0xF6, 0xEB, 0xD6, 0xA3, 0x20, 0xC9, 0xE6, 0x9F, 0xCB, 0xF2, 0x97, 0xB9, 0x54,
		        0x12, 0x66, 0xA6, 0xBE, 0x4A, 0x12, 0x43, 0xEC, 0x00, 0xEA, 0x49, 0x02
	        },
	        new byte[]{ 0, }  // Region 7, not used
        };
        public static byte[][] killbld_source_data = new byte[0x0c][]//[0xec]
        {
	        new byte[]{ // region 16, $178772
		        0x5e, 0x09, 0xb3, 0x39, 0x60, 0x71, 0x71, 0x53, 0x11, 0xe5, 0x26, 0x34, 0x4c, 0x8c, 0x90, 0xee,
		        0xed, 0xb5, 0x05, 0x95, 0x9e, 0x6b, 0xdd, 0x87, 0x0e, 0x7b, 0xed, 0x33, 0xaf, 0xc2, 0x62, 0x98,
		        0xec, 0xc8, 0x2c, 0x2b, 0x57, 0x3d, 0x00, 0xbd, 0x12, 0xac, 0xba, 0x64, 0x81, 0x99, 0x16, 0x29,
		        0xb4, 0x63, 0xa8, 0xd9, 0xc9, 0x5f, 0xfe, 0x21, 0xbb, 0xbf, 0x9b, 0xd1, 0x7b, 0x93, 0xc4, 0x82,
		        0xef, 0x2b, 0xe8, 0xa6, 0xdc, 0x68, 0x3a, 0xd9, 0xc9, 0x23, 0xc7, 0x7b, 0x98, 0x5b, 0xe1, 0xc7,
		        0xa3, 0xd4, 0x51, 0x0a, 0x86, 0x30, 0x20, 0x51, 0x6e, 0x04, 0x1c, 0xd4, 0xfb, 0xf5, 0x22, 0x8f,
		        0x16, 0x6f, 0xb9, 0x59, 0x30, 0xcf, 0xab, 0x32, 0x1d, 0x6c, 0x84, 0xab, 0x23, 0x90, 0x94, 0xb1,
		        0xe7, 0x4b, 0x6d, 0xc1, 0x84, 0xba, 0x32, 0x68, 0xa3, 0xf2, 0x47, 0x28, 0xe5, 0xcb, 0xbb, 0x47,
		        0x14, 0x2c, 0xad, 0x4d, 0xa1, 0xd7, 0x18, 0x53, 0xf7, 0x6f, 0x05, 0x81, 0x8f, 0xbb, 0x29, 0xdc,
		        0xbd, 0x17, 0x61, 0x92, 0x9b, 0x1d, 0x4e, 0x7a, 0x83, 0x14, 0x9f, 0x7b, 0x7a, 0x6a, 0xe1, 0x27,
		        0x62, 0x52, 0x7e, 0x82, 0x45, 0xda, 0xed, 0xf1, 0x0a, 0x3b, 0x6c, 0x02, 0x5b, 0x6e, 0x45, 0x4e,
		        0xf2, 0x65, 0x87, 0x1d, 0x80, 0xed, 0x6a, 0xc3, 0x77, 0xcb, 0xe8, 0x8d, 0x5a, 0xb8, 0xda, 0x89,
		        0x88, 0x4b, 0x27, 0xd5, 0x57, 0x29, 0x91, 0x86, 0x12, 0xbb, 0xd3, 0x8c, 0xc7, 0x49, 0x84, 0x9c,
		        0x96, 0x59, 0x30, 0x93, 0x92, 0xeb, 0x59, 0x2b, 0x93, 0x5b, 0x5f, 0xf9, 0x67, 0xac, 0x97, 0x8c,
		        0x04, 0xda, 0x1b, 0x65, 0xd7, 0xef, 0x44, 0xca, 0xc4, 0x87, 0x18, 0x2b
	        },
	        new byte[]{ // region 17, $178a36
		        0xd7, 0x49, 0xb3, 0x39, 0x60, 0x71, 0x70, 0x53, 0x11, 0x00, 0x27, 0xb2, 0x61, 0xd3, 0x8c, 0x8b,
		        0xb2, 0xde, 0x6a, 0x78, 0x40, 0x5d, 0x4d, 0x88, 0xeb, 0x81, 0xd0, 0x2a, 0xbf, 0x8c, 0x22, 0x0d,
		        0x89, 0x83, 0xc8, 0xef, 0x0d, 0x7a, 0xf6, 0xf0, 0x1d, 0x49, 0xa2, 0xd3, 0x1e, 0xef, 0x1c, 0xa2,
		        0xce, 0x00, 0x5e, 0xa8, 0x7f, 0x4c, 0x41, 0x27, 0xa8, 0x6b, 0x92, 0x0a, 0xb8, 0x03, 0x2f, 0x7e,
		        0xaf, 0x4a, 0xd0, 0x5c, 0xce, 0xeb, 0x0e, 0x8a, 0x4d, 0x0b, 0x73, 0xb3, 0xf3, 0x0c, 0x83, 0xaa,
		        0xe5, 0xe4, 0x84, 0x06, 0xd7, 0xcc, 0xcb, 0x52, 0x8d, 0xbe, 0xa4, 0xdf, 0xd9, 0xab, 0x50, 0x59,
		        0x53, 0x61, 0xa1, 0xc8, 0x6d, 0xbc, 0xde, 0xab, 0xaa, 0x5e, 0xc6, 0xf7, 0x83, 0xdc, 0x40, 0xcb,
		        0x1b, 0xdd, 0x28, 0x3b, 0xee, 0xb1, 0x1f, 0x37, 0xdb, 0xe9, 0xbb, 0x74, 0x4b, 0xc2, 0x8a, 0xe8,
		        0xec, 0x6e, 0x0e, 0x35, 0xe3, 0x2e, 0xbe, 0xef, 0xfd, 0x07, 0xbf, 0x8c, 0xfe, 0xf3, 0x5c, 0xbf,
		        0x87, 0xe5, 0xbc, 0xcf, 0x60, 0xdc, 0x18, 0xf8, 0xfc, 0x51, 0x50, 0x86, 0xc6, 0x48, 0x3d, 0xb9,
		        0x1d, 0x26, 0xf7, 0x7e, 0x87, 0x90, 0x12, 0xe8, 0x06, 0x0a, 0x45, 0xe9, 0xd9, 0xd8, 0x41, 0x68,
		        0x21, 0x52, 0x92, 0x0f, 0xd6, 0xda, 0xa2, 0x97, 0xeb, 0x68, 0xd0, 0xb1, 0x15, 0x19, 0x8b, 0xd0,
		        0x48, 0x1a, 0xeb, 0x90, 0x3f, 0x2a, 0x33, 0x1e, 0x5e, 0x30, 0x66, 0x01, 0x64, 0xef, 0x99, 0x52,
		        0xba, 0x23, 0xbd, 0x53, 0xc0, 0x60, 0x87, 0x09, 0xcb, 0x4d, 0xd3, 0x87, 0x0e, 0x3a, 0x5c, 0x8d,
		        0xc8, 0xb8, 0xb7, 0x34, 0x01, 0xeb, 0x72, 0x0d, 0xb1, 0x1f, 0x0f, 0xea
	        },
	        new byte[]{ // region 18, $17dac4
		        0x6a, 0x13, 0xb3, 0x09, 0x60, 0x79, 0x61, 0x53, 0x11, 0x33, 0x41, 0x31, 0x76, 0x34, 0x88, 0x0f,
		        0x77, 0x08, 0xb6, 0x74, 0xc8, 0x36, 0xbc, 0x70, 0xe2, 0x87, 0x9a, 0x21, 0xe8, 0x56, 0xe1, 0x9a,
		        0x26, 0x57, 0x7e, 0x9b, 0xdb, 0xb7, 0xd4, 0x3d, 0x0f, 0xfe, 0x8a, 0x2a, 0xba, 0x2d, 0x22, 0x03,
		        0xcf, 0x9c, 0xfa, 0x77, 0x35, 0x39, 0x6a, 0x14, 0xae, 0x30, 0x89, 0x42, 0xdc, 0x59, 0xb2, 0x93,
		        0x6f, 0x82, 0xd1, 0x12, 0xd9, 0x88, 0xfa, 0x3b, 0xb7, 0x0c, 0x1f, 0x05, 0x68, 0xa3, 0x0c, 0xa6,
		        0x0f, 0xf4, 0x9e, 0x1b, 0x29, 0x82, 0x77, 0x3a, 0xac, 0x92, 0x2d, 0x04, 0xd0, 0x61, 0x65, 0x0a,
		        0x77, 0x6c, 0x89, 0x38, 0xaa, 0xa9, 0xf8, 0x0c, 0x1f, 0x37, 0x09, 0x2b, 0xca, 0x29, 0x05, 0xe5,
		        0x4e, 0x57, 0xfb, 0xcd, 0x40, 0xa8, 0x0c, 0x06, 0x2d, 0xe0, 0x30, 0xd9, 0x97, 0xb9, 0x59, 0x8a,
		        0xde, 0xc9, 0x87, 0x1d, 0x3f, 0x84, 0x4c, 0x73, 0x04, 0x85, 0x61, 0xb0, 0x6e, 0x2c, 0x8f, 0xa2,
		        0x6a, 0xcd, 0x31, 0xf3, 0x25, 0x83, 0xe1, 0x5e, 0x5d, 0xa7, 0xe7, 0xaa, 0x13, 0x26, 0xb1, 0x33,
		        0xf0, 0x13, 0x58, 0x7a, 0xb0, 0x46, 0x1d, 0xdf, 0x02, 0xbf, 0x1e, 0xd1, 0x71, 0x43, 0x56, 0x82,
		        0x4f, 0x58, 0x9d, 0x01, 0x2d, 0xc7, 0xda, 0x6b, 0x47, 0x05, 0xd1, 0xd5, 0xe8, 0x92, 0x3c, 0x18,
		        0x21, 0xcf, 0xc9, 0x32, 0x0e, 0x12, 0xed, 0xb5, 0xaa, 0xa4, 0x12, 0x75, 0x01, 0x7d, 0xc7, 0x21,
		        0xde, 0xec, 0x32, 0x13, 0xee, 0xd4, 0x9c, 0xe6, 0x04, 0x3f, 0x48, 0xfb, 0xb4, 0xc7, 0x21, 0x8e,
		        0x8d, 0x7d, 0x54, 0x03, 0x11, 0xe7, 0xb9, 0x4f, 0x85, 0xb6, 0x1f, 0xaa
	        },
	        new byte[]{ // region 19, $178eee
		        0xe3, 0x53, 0xb3, 0x09, 0x60, 0x79, 0x60, 0x53, 0x11, 0x66, 0x5b, 0xc8, 0x8b, 0x94, 0x84, 0xab,
		        0x3c, 0x18, 0x03, 0x57, 0x6a, 0x0f, 0x45, 0x58, 0xc0, 0x74, 0x64, 0x18, 0xf8, 0x39, 0xa1, 0x0f,
		        0xc2, 0x2b, 0x1b, 0x60, 0xaa, 0x0e, 0xb2, 0x89, 0x01, 0x9b, 0x72, 0x80, 0x57, 0x83, 0x28, 0x63,
		        0xe9, 0x39, 0x97, 0x46, 0xea, 0x3f, 0x93, 0x01, 0x9b, 0xf4, 0x80, 0x93, 0x01, 0xaf, 0x1d, 0x8f,
		        0x16, 0xa1, 0xb9, 0xc7, 0xe4, 0x0c, 0xe7, 0xd2, 0x3b, 0xf3, 0xca, 0x3d, 0xc3, 0x54, 0xad, 0x89,
		        0x51, 0x1e, 0xd1, 0x17, 0x7a, 0x1f, 0x23, 0x22, 0xcb, 0x4d, 0xce, 0x0f, 0xae, 0x30, 0x93, 0xd3,
		        0x9b, 0x77, 0x71, 0xa7, 0xe7, 0x96, 0x2c, 0x85, 0xac, 0x29, 0x4b, 0x5e, 0x2b, 0x75, 0xb0, 0x00,
		        0x81, 0xe9, 0xb6, 0x47, 0xaa, 0x9f, 0xdf, 0xd4, 0x7e, 0xd7, 0xa4, 0x3f, 0xe3, 0xb0, 0x41, 0x2c,
		        0xb7, 0x0c, 0xe7, 0xeb, 0x9a, 0xda, 0xd9, 0x10, 0x23, 0x1d, 0x1c, 0xd4, 0xdd, 0x7d, 0xc2, 0x6c,
		        0x4d, 0x9c, 0xa5, 0x18, 0xd0, 0x43, 0xab, 0xdc, 0xbd, 0xe4, 0x7f, 0xb5, 0x5f, 0x04, 0x0d, 0xac,
		        0xab, 0xe6, 0xb8, 0x76, 0xf2, 0x15, 0x41, 0xef, 0x17, 0x8e, 0xf6, 0xb9, 0xef, 0x94, 0x52, 0x83,
		        0x96, 0x45, 0x8f, 0xf2, 0x9c, 0xb4, 0x13, 0x3f, 0xbb, 0xa1, 0xd2, 0xf9, 0xa3, 0xf2, 0x06, 0x78,
		        0xe0, 0x9e, 0xa7, 0xd3, 0xdc, 0x13, 0x8f, 0x4d, 0xf6, 0x19, 0xbd, 0x03, 0x9d, 0x24, 0xdc, 0xd6,
		        0xe9, 0xcf, 0xa6, 0xd2, 0x1d, 0x49, 0xca, 0xc4, 0x55, 0x18, 0xbc, 0x70, 0x5b, 0x55, 0xfe, 0x8f,
		        0x6b, 0x42, 0xf0, 0xd1, 0x21, 0xe3, 0xe7, 0x91, 0x59, 0x4e, 0x16, 0x83
	        },
	        new byte[]{ 0, }, // unused region 1a
	        new byte[]{ 0, }, // unused region 1b
	        new byte[]{ 0, }, // unused region 1c
	        new byte[]{ 0, }, // unused region 1d
	        new byte[]{ 0, }, // unused region 1e
	        new byte[]{ 0, }, // unused region 1f
	        new byte[]{ // region 20, $17a322
		        0xb3, 0x10, 0xf3, 0x0b, 0xe0, 0x71, 0x60, 0x53, 0x11, 0x9a, 0x12, 0x70, 0x1f, 0x1e, 0x81, 0xda,
		        0x9d, 0x1f, 0x4b, 0xd6, 0x71, 0x48, 0x83, 0xe1, 0x04, 0x6c, 0x1b, 0xf1, 0xcd, 0x09, 0xdf, 0x3e,
		        0x0b, 0xaa, 0x95, 0xc1, 0x07, 0xec, 0x0f, 0x54, 0xd0, 0x16, 0xb0, 0xdc, 0x86, 0x7b, 0x52, 0x38,
		        0x3c, 0x68, 0x2b, 0xed, 0xe2, 0xeb, 0xb3, 0xc6, 0x48, 0x24, 0x41, 0x36, 0x17, 0x25, 0x1f, 0xa5,
		        0x22, 0xc6, 0x5c, 0xa6, 0x19, 0xef, 0x17, 0x5c, 0x56, 0x4b, 0x4a, 0x2b, 0x75, 0xab, 0xe6, 0x22,
		        0xd5, 0xc0, 0xd3, 0x46, 0xcc, 0xe4, 0xd4, 0xc4, 0x8c, 0x9a, 0x8a, 0x75, 0x24, 0x73, 0xa4, 0x26,
		        0xca, 0x79, 0xaf, 0xb3, 0x94, 0x2a, 0x15, 0xbe, 0x40, 0x7b, 0x4d, 0xf6, 0xb4, 0xa4, 0x7b, 0xcf,
		        0xce, 0xa0, 0x1d, 0xcb, 0x2f, 0x60, 0x28, 0x63, 0x85, 0x98, 0xd3, 0xd2, 0x45, 0x3f, 0x02, 0x65,
		        0xd7, 0xf4, 0xbc, 0x2a, 0xe7, 0x50, 0xd1, 0x3f, 0x7f, 0xf6, 0x05, 0xb8, 0xe9, 0x39, 0x10, 0x6e,
		        0x68, 0xa8, 0x89, 0x60, 0x00, 0x68, 0xfd, 0x20, 0xc4, 0xdc, 0xef, 0x67, 0x75, 0xfb, 0xbe, 0xfe,
		        0x2b, 0x16, 0xa6, 0x5a, 0x77, 0x0d, 0x0c, 0xe2, 0x2d, 0xd1, 0xe4, 0x11, 0xc9, 0x4b, 0x81, 0x3a,
		        0x0c, 0x24, 0xaa, 0x77, 0x2b, 0x2f, 0x83, 0x23, 0xd1, 0xe9, 0xa7, 0x29, 0x0a, 0xf9, 0x26, 0x9d,
		        0x51, 0xc8, 0x6d, 0x71, 0x9d, 0xce, 0x46, 0x72, 0x26, 0x48, 0x3d, 0x64, 0xe5, 0x67, 0xbb, 0x1a,
		        0xb4, 0x6d, 0x21, 0x11, 0x79, 0x78, 0xc2, 0xd5, 0x11, 0x6a, 0xd2, 0xea, 0x03, 0x4d, 0x92, 0xaf,
		        0x18, 0xd5, 0x07, 0x79, 0xaa, 0xf9, 0x44, 0x93, 0x6f, 0x41, 0x22, 0x0d
	        },
	        new byte[]{ // region 21, $17b3b4
		        0x2d, 0x50, 0xf3, 0x0b, 0xe0, 0x71, 0x61, 0x53, 0x11, 0xb4, 0x2c, 0xee, 0x34, 0x7e, 0x7d, 0x5e,
		        0x62, 0x48, 0x97, 0xd2, 0xf9, 0x3a, 0xf2, 0xc9, 0xfa, 0x59, 0xe4, 0xe8, 0xf6, 0xd2, 0x9f, 0xb2,
		        0xa7, 0x7e, 0x32, 0x86, 0xbc, 0x43, 0xec, 0xa0, 0xc2, 0xcb, 0x98, 0x33, 0x23, 0xd1, 0x58, 0x98,
		        0x56, 0x05, 0xc7, 0xbc, 0x98, 0xd8, 0xdc, 0xb3, 0x35, 0xe8, 0x51, 0x6e, 0x3b, 0x7b, 0x89, 0xba,
		        0xe1, 0xe5, 0x44, 0x5c, 0x24, 0x73, 0x04, 0x0d, 0xd9, 0x33, 0xf5, 0x63, 0xe9, 0x5c, 0x88, 0x05,
		        0x18, 0xd0, 0x07, 0x5b, 0x1e, 0x81, 0x80, 0xac, 0x92, 0x6e, 0x13, 0x80, 0x1b, 0x29, 0xd2, 0xef,
		        0x08, 0x84, 0x97, 0x23, 0xd1, 0x17, 0x2f, 0x38, 0xb4, 0x6d, 0x8f, 0x2a, 0x15, 0xf0, 0x40, 0xe9,
		        0x02, 0x33, 0xd7, 0x5e, 0x99, 0x57, 0x15, 0x32, 0xbd, 0x8f, 0x48, 0x38, 0x91, 0x36, 0xe9, 0x07,
		        0xc9, 0x37, 0x1d, 0x12, 0x2a, 0xbf, 0x5f, 0xdb, 0x85, 0x75, 0xbf, 0xdc, 0x59, 0x8a, 0x43, 0x51,
		        0x4b, 0x77, 0xfd, 0x84, 0xc4, 0x28, 0xc7, 0x85, 0x25, 0x1a, 0x87, 0x8b, 0xc1, 0xd9, 0x1a, 0x78,
		        0xe5, 0x03, 0x20, 0x56, 0xa0, 0xc2, 0x17, 0xf2, 0x29, 0xa0, 0xbd, 0xf8, 0x61, 0x9c, 0x7d, 0x54,
		        0x3a, 0x11, 0xb5, 0x69, 0x9a, 0x1c, 0xbb, 0xf6, 0x2d, 0x86, 0xa8, 0x4d, 0xdd, 0x5a, 0xd6, 0xe4,
		        0x11, 0x7e, 0x4b, 0x13, 0x6c, 0xb6, 0x01, 0x0a, 0x72, 0xbc, 0xe8, 0xf1, 0x82, 0x0e, 0xd0, 0xcf,
		        0xbf, 0x50, 0x95, 0xb7, 0xa7, 0xec, 0xd7, 0xb3, 0x49, 0x5c, 0x47, 0x5f, 0xa9, 0xda, 0x70, 0xb0,
		        0xdc, 0x9a, 0xa3, 0x48, 0xd3, 0xf5, 0x72, 0xd5, 0x43, 0xd8, 0x19, 0xcc
	        }
        };
        public static void drgw_interrupt()
        {
            if (Cpuexec.iloops == 0)
            {
                Cpuint.cpunum_set_input_line(0, 6, LineState.HOLD_LINE);
            }
            else
            {
                Cpuint.cpunum_set_input_line(0, 4, LineState.HOLD_LINE);
            }
        }
        public static void device_init()
        {
            kb_prot_hold = 0;
            kb_prot_hilo = 0;
            kb_prot_hilo_select = 0;
            kb_cmd = 0;
            kb_reg = 0;
            kb_ptr = 0;
            kb_swap = 0;
            olds_bs = 0;
            kb_cmd3 = 0;
            switch (Machine.sName)
            {
                case "drgw2":
                    kb_source_data = drgw2_source_data;
                    int region = 0x06;
                    kb_region = region;
                    kb_game_id = region | (region << 8) | (region << 16) | (region << 24);
                    break;
                case "killbld":
                    kb_source_data = killbld_source_data;

                    break;
            }
        }
        public static void device_reset()
        {
            kb_prot_hold = 0;
            kb_prot_hilo = 0;
            kb_prot_hilo_select = 0;
            kb_cmd = 0;
            kb_reg = 0;
            kb_ptr = 0;
            kb_swap = 0;
            olds_bs = 0;
            kb_cmd3 = 0;
        }
        public static int BIT(int x, int n)
        {
            return (x >> n) & 1;
        }
        public static int BITSWAP8(int val, int B7, int B6, int B5, int B4, int B3, int B2, int B1, int B0)
        {
            return ((BIT(val, B7) << 7) |
                (BIT(val, B6) << 6) |
                (BIT(val, B5) << 5) |
                (BIT(val, B4) << 4) |
                (BIT(val, B3) << 3) |
                (BIT(val, B2) << 2) |
                (BIT(val, B1) << 1) |
                (BIT(val, B0) << 0));
        }
        public static ushort killbld_igs025_prot_r(int offset)
        {
            if (offset!=0)
            {
                switch (kb_cmd)
                {
                    case 0x00:
                        return (ushort)BITSWAP8((kb_swap + 1) & 0x7f, 0, 1, 2, 3, 4, 5, 6, 7);
                    case 0x01:
                        return (ushort)(kb_reg & 0x7f);
                    case 0x02:
                        return (ushort)(olds_bs | 0x80);
                    case 0x03:
                        return (ushort)kb_cmd3;
                    case 0x05:
                        {
                            switch (kb_ptr)
                            {
                                case 1:
                                    return (ushort)(0x3f00 | ((kb_game_id >> 0) & 0xff));
                                case 2:
                                    return (ushort)(0x3f00 | ((kb_game_id >> 8) & 0xff));
                                case 3:
                                    return (ushort)(0x3f00 | ((kb_game_id >> 16) & 0xff));
                                case 4:
                                    return (ushort)(0x3f00 | ((kb_game_id >> 24) & 0xff));
                                default:
                                    return (ushort)(0x3f00 | BITSWAP8(kb_prot_hold, 5, 2, 9, 7, 10, 13, 12, 15));
                            }
                        }
                    case 0x40:
                        killbld_protection_calculate_hilo();
                        return 0;
                }
            }
            return 0;
        }
        public static void drgw2_d80000_protection_w(int offset, ushort data)
        {
            if (offset == 0)
            {
                kb_cmd = data;
                return;
            }
            switch (kb_cmd)
            {
                case 0x20:
                case 0x21:
                case 0x22:
                case 0x23:
                case 0x24:
                case 0x25:
                case 0x26:
                case 0x27:
                    kb_ptr++;
                    killbld_protection_calculate_hold(kb_cmd & 0x0f, data & 0xff);
                    break;
            }
        }
        public static void killbld_protection_calculate_hold(int y, int z)
        {
            ushort old = kb_prot_hold;
            kb_prot_hold = (ushort)((old << 1) | (old >> 15));
            kb_prot_hold ^= (ushort)0x2bad;
            kb_prot_hold ^= (ushort)BIT(z, y);
            kb_prot_hold ^= (ushort)(BIT(old, 7) << 0);
            kb_prot_hold ^= (ushort)(BIT(~old, 13) << 4);
            kb_prot_hold ^= (ushort)(BIT(old, 3) << 11);
            kb_prot_hold ^= (ushort)((kb_prot_hilo & ~0x0408) << 1);
        }
        public static void killbld_protection_calculate_hilo()
        {
            byte source;
            kb_prot_hilo_select++;
            if (kb_prot_hilo_select > 0xeb)
            {
                kb_prot_hilo_select = 0;
            }
            source = kb_source_data[kb_region][kb_prot_hilo_select];
            if ((kb_prot_hilo_select & 1) != 0)
            {
                kb_prot_hilo = (ushort)((kb_prot_hilo & 0x00ff) | (source << 8));
            }
            else
            {
                kb_prot_hilo = (ushort)((kb_prot_hilo & 0xff00) | (source << 0));
            }
        }
    }
}