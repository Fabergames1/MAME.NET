﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cpu.z80;

namespace mame
{
    public partial class Capcom
    {
        public static sbyte sbyte1, sbyte2, sbyte3, sbyte4;
        public static sbyte sbyte1_old, sbyte2_old, sbyte3_old, sbyte4_old;
        public static short short0, short1,short2,shorts,shortc;
        public static short short0_old, short1_old,short2_old,shorts_old,shortc_old;
        public static sbyte MReadOpByte_sfus(int address)
        {
            address &= 0xffffff;
            sbyte result = 0;
            if (address <= 0x04ffff)
            {
                if (address < Memory.mainrom.Length)
                {
                    result = (sbyte)(Memory.mainrom[address]);
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }
        public static sbyte MReadByte_sf(int address)
        {
            address &= 0xffffff;
            sbyte result = 0;
            if (address <= 0x04ffff)
            {
                if (address < Memory.mainrom.Length)
                {
                    result = (sbyte)(Memory.mainrom[address]);
                }
                else
                {
                    result = 0;
                }
            }
            else if (address >= 0x800000 && address <= 0x800fff)
            {
                int offset = (address - 0x800000) / 2;
                if (address % 2 == 0)
                {
                    result = (sbyte)(sf_videoram[offset] >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)sf_videoram[offset];
                }
            }
            else if (address >= 0xc00000 && address <= 0xc00001)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(shortc >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)shortc;
                }
            }
            else if (address >= 0xc00002 && address <= 0xc00003)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(short0 >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)short0;
                }
            }
            else if (address >= 0xc00004 && address <= 0xc00005)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(button1_r() >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)button1_r();
                }
            }
            else if (address >= 0xc00006 && address <= 0xc00007)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(button2_r() >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)button2_r();
                }
            }
            else if (address >= 0xc00008 && address <= 0xc00009)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dsw1 >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dsw1;
                }
            }
            else if (address >= 0xc0000a && address <= 0xc0000b)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dsw2 >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dsw2;
                }
            }
            else if (address >= 0xc0000c && address <= 0xc0000d)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(shorts >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)shorts;
                }
            }
            else if (address >= 0xc0000e && address <= 0xc0000f)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dummy_r() >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dummy_r();
                }
            }
            else if (address >= 0xff8000 && address <= 0xffdfff)
            {
                int offset = address - 0xff8000;
                result = (sbyte)Memory.mainram[offset];
            }
            else if (address >= 0xffe000 && address <= 0xffffff)
            {
                int offset = (address - 0xffe000) / 2;
                if (address % 2 == 0)
                {
                    result = (sbyte)(sf_objectram[offset] >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)sf_objectram[offset];
                }
            }
            return result;
        }
        public static sbyte MReadByte_sfus(int address)
        {
            address &= 0xffffff;
            sbyte result = 0;
            if (address <= 0x04ffff)
            {
                if (address < Memory.mainrom.Length)
                {
                    result = (sbyte)(Memory.mainrom[address]);
                }
                else
                {
                    result = 0;
                }
            }
            else if (address >= 0x800000 && address <= 0x800fff)
            {
                int offset = (address - 0x800000) / 2;
                if (address % 2 == 0)
                {
                    result = (sbyte)(sf_videoram[offset] >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)sf_videoram[offset];
                }
            }
            else if (address >= 0xc00000 && address <= 0xc00001)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(short0 >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)short0;
                }
            }
            else if (address >= 0xc00002 && address <= 0xc00003)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(short1 >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)short1;
                }
            }
            else if (address >= 0xc00004 && address <= 0xc00005)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dummy_r() >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dummy_r();
                }
            }
            else if (address >= 0xc00006 && address <= 0xc00007)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dummy_r() >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dummy_r();
                }
            }
            else if (address >= 0xc00008 && address <= 0xc00009)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dsw1 >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dsw1;
                }
            }
            else if (address >= 0xc0000a && address <= 0xc0000b)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dsw2 >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dsw2;
                }
            }
            else if (address >= 0xc0000c && address <= 0xc0000d)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(shorts >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)shorts;
                }
            }
            else if (address >= 0xc0000e && address <= 0xc0000f)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dummy_r() >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dummy_r();
                }
            }
            else if (address >= 0xff8000 && address <= 0xffdfff)
            {
                int offset = address - 0xff8000;
                result = (sbyte)Memory.mainram[offset];
            }
            else if (address >= 0xffe000 && address <= 0xffffff)
            {
                int offset = (address - 0xffe000) / 2;
                if (address % 2 == 0)
                {
                    result = (sbyte)(sf_objectram[offset] >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)sf_objectram[offset];
                }
            }
            return result;
        }
        public static sbyte MReadByte_sfjp(int address)
        {
            address &= 0xffffff;
            sbyte result = 0;
            if (address <= 0x04ffff)
            {
                if (address < Memory.mainrom.Length)
                {
                    result = (sbyte)(Memory.mainrom[address]);
                }
                else
                {
                    result = 0;
                }
            }
            else if (address >= 0x800000 && address <= 0x800fff)
            {
                int offset = (address - 0x800000) / 2;
                if (address % 2 == 0)
                {
                    result = (sbyte)(sf_videoram[offset] >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)sf_videoram[offset];
                }
            }
            else if (address >= 0xc00000 && address <= 0xc00001)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(shortc >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)shortc;
                }
            }
            else if (address >= 0xc00002 && address <= 0xc00003)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(short1 >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)short1;
                }
            }
            else if (address >= 0xc00004 && address <= 0xc00005)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(short2 >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)short2;
                }
            }
            else if (address >= 0xc00006 && address <= 0xc00007)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dummy_r() >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dummy_r();
                }
            }
            else if (address >= 0xc00008 && address <= 0xc00009)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dsw1 >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dsw1;
                }
            }
            else if (address >= 0xc0000a && address <= 0xc0000b)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dsw2 >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dsw2;
                }
            }
            else if (address >= 0xc0000c && address <= 0xc0000d)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(shorts >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)shorts;
                }
            }
            else if (address >= 0xc0000e && address <= 0xc0000f)
            {
                if (address % 2 == 0)
                {
                    result = (sbyte)(dummy_r() >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)dummy_r();
                }
            }
            else if (address >= 0xff8000 && address <= 0xffdfff)
            {
                int offset = address - 0xff8000;
                result = (sbyte)Memory.mainram[offset];
            }
            else if (address >= 0xffe000 && address <= 0xffffff)
            {
                int offset = (address - 0xffe000) / 2;
                if (address % 2 == 0)
                {
                    result = (sbyte)(sf_objectram[offset] >> 8);
                }
                else if (address % 2 == 1)
                {
                    result = (sbyte)sf_objectram[offset];
                }
            }
            return result;
        }
        public static short MReadOpWord_sfus(int address)
        {
            address &= 0xffffff;
            short result = 0;
            if (address <= 0x04ffff)
            {
                if (address + 1 < Memory.mainrom.Length)
                {
                    result = (short)(Memory.mainrom[address] * 0x100 + Memory.mainrom[address + 1]);
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }
        public static short MReadWord_sf(int address)
        {
            address &= 0xffffff;
            short result = 0;
            if (address <= 0x04ffff)
            {
                if (address + 1 < Memory.mainrom.Length)
                {
                    result = (short)(Memory.mainrom[address] * 0x100 + Memory.mainrom[address + 1]);
                }
                else
                {
                    result = 0;
                }
            }
            else if (address >= 0x800000 && address + 1 <= 0x800fff)
            {
                int offset = (address - 0x800000) / 2;
                result = (short)sf_videoram[offset];
            }
            else if (address >= 0xc00000 && address + 1 <= 0xc00001)
            {
                result = shortc;
            }
            else if (address >= 0xc00002 && address + 1 <= 0xc00003)
            {
                result = short0;
            }
            else if (address >= 0xc00004 && address + 1 <= 0xc00005)
            {
                result = (short)button1_r();
            }
            else if (address >= 0xc00006 && address + 1 <= 0xc00007)
            {
                result = (short)button2_r();
            }
            else if (address >= 0xc00008 && address + 1 <= 0xc00009)
            {
                result = (short)dsw1;
            }
            else if (address >= 0xc0000a && address + 1 <= 0xc0000b)
            {
                result = (short)dsw2;
            }
            else if (address >= 0xc0000c && address + 1 <= 0xc0000d)
            {
                result = shorts;
            }
            else if (address >= 0xc0000e && address + 1 <= 0xc0000f)
            {
                result = (short)dummy_r();
            }
            else if (address >= 0xff8000 && address + 1 <= 0xffdfff)
            {
                int offset = address - 0xff8000;
                result = (short)(Memory.mainram[offset] * 0x100 + Memory.mainram[offset + 1]);
            }
            else if (address >= 0xffe000 && address + 1 <= 0xffffff)
            {
                int offset = (address - 0xffe000) / 2;
                result = (short)sf_objectram[offset];
            }
            return result;
        }
        public static short MReadWord_sfus(int address)
        {
            address &= 0xffffff;
            short result = 0;
            if (address <= 0x04ffff)
            {
                if (address + 1 < Memory.mainrom.Length)
                {
                    result = (short)(Memory.mainrom[address] * 0x100 + Memory.mainrom[address + 1]);
                }
                else
                {
                    result = 0;
                }
            }
            else if (address >= 0x800000 && address + 1 <= 0x800fff)
            {
                int offset = (address - 0x800000) / 2;
                result = (short)sf_videoram[offset];
            }
            else if (address >= 0xc00000 && address + 1 <= 0xc00001)
            {
                result = short0;
            }
            else if (address >= 0xc00002 && address + 1 <= 0xc00003)
            {
                result = short1;
            }
            else if (address >= 0xc00004 && address + 1 <= 0xc00005)
            {
                result = (short)dummy_r();
            }
            else if (address >= 0xc00006 && address + 1 <= 0xc00007)
            {
                result = (short)dummy_r();
            }
            else if (address >= 0xc00008 && address + 1 <= 0xc00009)
            {
                result = (short)dsw1;
            }
            else if (address >= 0xc0000a && address + 1 <= 0xc0000b)
            {
                result = (short)dsw2;
            }
            else if (address >= 0xc0000c && address + 1 <= 0xc0000d)
            {
                result = shorts;
            }
            else if (address >= 0xc0000e && address + 1 <= 0xc0000f)
            {
                result = (short)dummy_r();
            }
            else if (address >= 0xff8000 && address + 1 <= 0xffdfff)
            {
                int offset = address - 0xff8000;
                result = (short)(Memory.mainram[offset]*0x100+Memory.mainram[offset+1]);
            }
            else if (address >= 0xffe000 && address + 1 <= 0xffffff)
            {
                int offset = (address - 0xffe000)/2;
                result = (short)sf_objectram[offset];
            }
            return result;
        }
        public static short MReadWord_sfjp(int address)
        {
            address &= 0xffffff;
            short result = 0;
            if (address <= 0x04ffff)
            {
                if (address + 1 < Memory.mainrom.Length)
                {
                    result = (short)(Memory.mainrom[address] * 0x100 + Memory.mainrom[address + 1]);
                }
                else
                {
                    result = 0;
                }
            }
            else if (address >= 0x800000 && address + 1 <= 0x800fff)
            {
                int offset = (address - 0x800000) / 2;
                result = (short)sf_videoram[offset];
            }
            else if (address >= 0xc00000 && address + 1 <= 0xc00001)
            {
                result = shortc;
            }
            else if (address >= 0xc00002 && address + 1 <= 0xc00003)
            {
                result = short1;
            }
            else if (address >= 0xc00004 && address + 1 <= 0xc00005)
            {
                result = short2;
            }
            else if (address >= 0xc00006 && address + 1 <= 0xc00007)
            {
                result = (short)dummy_r();
            }
            else if (address >= 0xc00008 && address + 1 <= 0xc00009)
            {
                result = (short)dsw1;
            }
            else if (address >= 0xc0000a && address + 1 <= 0xc0000b)
            {
                result = (short)dsw2;
            }
            else if (address >= 0xc0000c && address + 1 <= 0xc0000d)
            {
                result = shorts;
            }
            else if (address >= 0xc0000e && address + 1 <= 0xc0000f)
            {
                result = (short)dummy_r();
            }
            else if (address >= 0xff8000 && address + 1 <= 0xffdfff)
            {
                int offset = address - 0xff8000;
                result = (short)(Memory.mainram[offset] * 0x100 + Memory.mainram[offset + 1]);
            }
            else if (address >= 0xffe000 && address + 1 <= 0xffffff)
            {
                int offset = (address - 0xffe000) / 2;
                result = (short)sf_objectram[offset];
            }
            return result;
        }
        public static int MReadOpLong_sfus(int address)
        {
            address &= 0xffffff;
            int result = 0;
            if (address <= 0x04ffff)
            {
                if (address + 3 < Memory.mainrom.Length)
                {
                    result = (int)(Memory.mainrom[address] * 0x1000000 + Memory.mainrom[address + 1] * 0x10000 + Memory.mainrom[address + 2] * 0x100 + Memory.mainrom[address + 3]);
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }
        public static int MReadLong_sfus(int address)
        {
            address &= 0xffffff;
            int result = 0;
            if (address <= 0x04ffff)
            {
                if (address + 3 < Memory.mainrom.Length)
                {
                    result = (int)(Memory.mainrom[address] * 0x1000000 + Memory.mainrom[address + 1] * 0x10000 + Memory.mainrom[address + 2] * 0x100 + Memory.mainrom[address + 3]);
                }
                else
                {
                    result = 0;
                }
            }
            else if (address >= 0x800000 && address + 3 <= 0x800fff)
            {
                int offset = (address - 0x800000) / 2;
                result = (int)(sf_videoram[offset]*0x10000+sf_videoram[offset+1]);
            }
            else if (address >= 0xff8000 && address + 3 <= 0xffdfff)
            {
                int offset = address - 0xff8000;
                result = (int)(Memory.mainram[offset] * 0x1000000 + Memory.mainram[offset + 1] * 0x10000 + Memory.mainram[offset + 2] * 0x100 + Memory.mainram[offset + 3]);
            }
            else if (address >= 0xffe000 && address + 3 <= 0xffffff)
            {
                int offset = (address - 0xffe000) / 2;
                result = (int)(sf_objectram[offset] * 0x10000 + sf_objectram[offset + 1]);
            }
            return result;
        }
        public static void MWriteByte_sf(int address, sbyte value)
        {
            address &= 0xffffff;
            if (address >= 0x000000 && address <= 0x04ffff)
            {
                if (address < Memory.mainrom.Length)
                {
                    Memory.mainrom[address] = (byte)value;
                }
            }
            else if (address >= 0x800000 && address <= 0x800fff)
            {
                int offset = (address - 0x800000) / 2;
                if (address % 2 == 0)
                {
                    sf_videoram_w1(offset, (byte)value);
                }
                else if (address % 2 == 1)
                {
                    sf_videoram_w2(offset, (byte)value);
                }
            }
            else if (address >= 0xb00000 && address <= 0xb007ff)
            {
                int offset = (address - 0xb00000) / 2;
                if (address % 2 == 0)
                {
                    Generic.paletteram16_xxxxRRRRGGGGBBBB_word_w1(offset, (byte)value);
                }
                else if (address % 2 == 1)
                {
                    Generic.paletteram16_xxxxRRRRGGGGBBBB_word_w2(offset, (byte)value);
                }
            }
            else if (address >= 0xc00010 && address <= 0xc00011)
            {
                if (address % 2 == 0)
                {

                }
                else if (address % 2 == 1)
                {
                    sf_coin_w2();
                }
            }
            else if (address >= 0xc00014 && address <= 0xc00015)
            {
                if (address % 2 == 0)
                {
                    sf_fg_scroll_w1((byte)value);
                }
                else if (address % 2 == 1)
                {
                    sf_fg_scroll_w2((byte)value);
                }
            }
            else if (address >= 0xc00018 && address <= 0xc00019)
            {
                if (address % 2 == 0)
                {
                    sf_bg_scroll_w1((byte)value);
                }
                else if (address % 2 == 1)
                {
                    sf_bg_scroll_w2((byte)value);
                }
            }
            else if (address >= 0xc0001a && address <= 0xc0001b)
            {
                if (address % 2 == 0)
                {
                    
                }
                else if (address % 2 == 1)
                {
                    sf_gfxctrl_w2((byte)value);
                }
            }
            else if (address >= 0xc0001c && address <= 0xc0001d)
            {
                if (address % 2 == 0)
                {
                    
                }
                else if (address % 2 == 1)
                {
                    soundcmd_w2((byte)value);
                }
            }
            else if (address >= 0xc0001e && address <= 0xc0001f)
            {
                if (address % 2 == 0)
                {
                    protection_w1((byte)value);
                }
                else if (address % 2 == 1)
                {
                    protection_w2((byte)value);
                }
            }
            else if (address >= 0xff8000 && address <= 0xffdfff)
            {
                int offset = address - 0xff8000;
                Memory.mainram[offset] = (byte)value;
            }
            else if (address >= 0xffe000 && address <= 0xffffff)
            {
                int offset = (address - 0xffe000) / 2;
                if (address % 2 == 0)
                {
                    sf_objectram[offset] = (ushort)((value << 8) | (sf_objectram[offset] & 0xff));
                }
                else if (address % 2 == 1)
                {
                    sf_objectram[offset] = (ushort)((sf_objectram[offset] & 0xff00) | (byte)value);
                }
            }
        }
        public static void MWriteWord_sf(int address, short value)
        {
            address &= 0xffffff;
            if (address >= 0x000000 && address + 1 <= 0x04ffff)
            {
                if (address + 1 < Memory.mainrom.Length)
                {
                    Memory.mainrom[address] = (byte)(value >> 8);
                    Memory.mainrom[address + 1] = (byte)value;
                }
            }
            else if (address >= 0x800000 && address + 1 <= 0x800fff)
            {
                int offset = (address - 0x800000) / 2;
                sf_videoram_w(offset, (ushort)value);
            }
            else if (address >= 0xb00000 && address + 1 <= 0xb007ff)
            {
                int offset = (address - 0xb00000) / 2;
                Generic.paletteram16_xxxxRRRRGGGGBBBB_word_w(offset, (ushort)value);
            }
            else if (address >= 0xc00010 && address + 1 <= 0xc00011)
            {
                sf_coin_w();
            }
            else if (address >= 0xc00014 && address + 1 <= 0xc00015)
            {
                sf_fg_scroll_w((ushort)value);
            }
            else if (address >= 0xc00018 && address + 1 <= 0xc00019)
            {
                sf_bg_scroll_w((ushort)value);
            }
            else if (address >= 0xc0001a && address + 1 <= 0xc0001b)
            {
                sf_gfxctrl_w((ushort)value);
            }
            else if (address >= 0xc0001c && address + 1 <= 0xc0001d)
            {
                soundcmd_w((ushort)value);
            }
            else if (address >= 0xc0001e && address + 1 <= 0xc0001f)
            {
                protection_w((ushort)value);
            }
            else if (address >= 0xff8000 && address + 1 <= 0xffdfff)
            {
                int offset = address - 0xff8000;
                Memory.mainram[offset] = (byte)(value>>8);
                Memory.mainram[offset + 1] = (byte)value;
            }
            else if (address >= 0xffe000 && address + 1 <= 0xffffff)
            {
                int offset = (address - 0xffe000) / 2;
                sf_objectram[offset] = (ushort)value;
            }
        }
        public static void MWriteLong_sf(int address, int value)
        {
            address &= 0xffffff;
            if (address >= 0x000000 && address + 3 <= 0x04ffff)
            {
                if (address + 3 < Memory.mainrom.Length)
                {
                    Memory.mainrom[address] = (byte)(value >> 24);
                    Memory.mainrom[address + 1] = (byte)(value >> 16);
                    Memory.mainrom[address + 2] = (byte)(value >> 8);
                    Memory.mainrom[address + 3] = (byte)value;
                }
            }
            else if (address >= 0x800000 && address + 3 <= 0x800fff)
            {
                int offset = (address - 0x800000) / 2;
                sf_videoram_w(offset, (ushort)(value>>16));
                sf_videoram_w(offset + 1, (ushort)value);
            }
            else if (address >= 0xb00000 && address + 3 <= 0xb007ff)
            {
                int offset = (address - 0xb00000) / 2;
                Generic.paletteram16_xxxxRRRRGGGGBBBB_word_w(offset, (ushort)(value >> 16));
                Generic.paletteram16_xxxxRRRRGGGGBBBB_word_w(offset + 1, (ushort)value);
            }
            else if (address >= 0xff8000 && address + 3 <= 0xffdfff)
            {
                int offset = address - 0xff8000;
                Memory.mainram[offset] = (byte)(value >> 24);
                Memory.mainram[offset + 1] = (byte)(value >> 16);
                Memory.mainram[offset + 2] = (byte)(value >> 8);
                Memory.mainram[offset + 3] = (byte)value;
            }
            else if (address >= 0xffe000 && address + 3 <= 0xffffff)
            {
                int offset = (address - 0xffe000) / 2;
                sf_objectram[offset] = (ushort)(value >> 16);
                sf_objectram[offset + 1] = (ushort)value;
            }
        }
        public static byte Z0ReadOp_sf(ushort address)
        {
            byte result = 0;
            if (address <= 0x7fff)
            {
                result = Memory.audiorom[address];
            }
            else if (address >= 0xc000 && address <= 0xc7ff)
            {
                int offset = address - 0xc000;
                result = Memory.audioram[offset];
            }
            else
            {
                result = 0;
            }
            return result;
        }
        public static byte Z0ReadMemory_sf(ushort address)
        {
            byte result = 0;
            if (address <= 0x7fff)
            {
                result = Memory.audiorom[address];
            }
            else if (address >= 0xc000 && address <= 0xc7ff)
            {
                int offset = address - 0xc000;
                result = Memory.audioram[offset];
            }
            else if (address == 0xc800)
            {
                result = (byte)Sound.soundlatch_r();
            }
            else if (address == 0xe001)
            {
                result = YM2151.ym2151_status_port_0_r();
            }
            else
            {
                result = 0;
            }
            return result;
        }
        public static void Z0WriteMemory_sf(ushort address, byte value)
        {
            if (address >= 0x0000 && address <= 0x7fff)
            {
                Memory.audiorom[address] = value;
            }
            else if (address >= 0xc000 && address <= 0xc7ff)
            {
                int offset = address - 0xc000;
                Memory.audioram[offset] = value;
            }
            else if (address == 0xe000)
            {
                YM2151.ym2151_register_port_0_w(value);
            }
            else if (address == 0xe001)
            {
                YM2151.ym2151_data_port_0_w(value);
            }
        }
        public static byte Z0ReadHardware(ushort address)
        {
            return 0;
        }
        public static void Z0WriteHardware(ushort address, byte value)
        {

        }
        public static int Z0IRQCallback()
        {
            return Cpuint.cpu_irq_callback(Z80A.zz1[0].cpunum, 0);
        }
        public static byte Z1ReadOp_sf(ushort address)
        {
            byte result = 0;
            if (address <= 0x7fff)
            {
                result = audiorom2[address];
            }
            else if (address >= 0x8000 && address <= 0xffff)
            {
                int offset = address - 0x8000;
                result = audiorom2[basebanksnd1 + offset];
            }
            return result;
        }
        public static byte Z1ReadMemory_sf(ushort address)
        {
            byte result = 0;
            if (address <= 0x7fff)
            {
                result = audiorom2[address];
            }
            else if (address >= 0x8000 && address <= 0xffff)
            {
                int offset = address - 0x8000;
                result = audiorom2[basebanksnd1 + offset];
            }
            return result;
        }
        public static void Z1WriteMemory_sf(ushort address, byte value)
        {
            if (address >= 0x0000 && address <= 0xffff)
            {

            }
        }
        public static byte Z1ReadHardware(ushort address)
        {
            byte result = 0;
            address &= 0xff;
            if (address == 0x01)
            {
                result = (byte)Sound.soundlatch_r();
            }
            return result;
        }
        public static void Z1WriteHardware(ushort address, byte value)
        {
            address &= 0xff;
            if (address >= 0x00 && address <= 0x01)
            {
                msm5205_w(address, value);
            }
            else if (address == 0x02)
            {
                basebanksnd1 = 0x8000 * (value + 1);
            }
        }
        public static int Z1IRQCallback()
        {
            return Cpuint.cpu_irq_callback(Z80A.zz1[1].cpunum, 0);
        }
    }
}
