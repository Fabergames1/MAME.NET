using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using cpu.m68000;
using cpu.z80;

namespace mame
{
    public partial class Capcom
    {
        public static void SaveStateBinary_sf(BinaryWriter writer)
        {
            int i;
            writer.Write(dsw1);
            writer.Write(dsw2);
            writer.Write(basebanksnd1);
            for (i = 0; i < 0x1000; i++)
            {
                writer.Write(sf_objectram[i]);
            }
            for (i = 0; i < 0x800; i++)
            {
                writer.Write(sf_videoram[i]);
            }
            for (i = 0; i < 0x400; i++)
            {
                writer.Write(Generic.paletteram16[i]);
            }
            writer.Write(bg_scrollx);
            writer.Write(fg_scrollx);
            writer.Write(sf_active);
            for (i = 0; i < 0x400; i++)
            {
                writer.Write(Palette.entry_color[i]);
            }
            writer.Write(Memory.mainram, 0, 0x6000);
            MC68000.m1.SaveStateBinary(writer);
            writer.Write(Memory.audioram, 0, 0x800);
            Z80A.zz1[0].SaveStateBinary(writer);
            Z80A.zz1[1].SaveStateBinary(writer);
            Cpuint.SaveStateBinary(writer);
            writer.Write(Timer.global_basetime.seconds);
            writer.Write(Timer.global_basetime.attoseconds);
            writer.Write(Video.screenstate.frame_number);
            writer.Write(Sound.last_update_second);
            Cpuexec.SaveStateBinary(writer);
            Timer.SaveStateBinary(writer);
            YM2151.SaveStateBinary(writer);
            MSM5205.mm1[0].SaveStateBinary(writer);
            MSM5205.mm1[1].SaveStateBinary(writer);
            writer.Write(Sound.ym2151stream.output_sampindex);
            writer.Write(Sound.ym2151stream.output_base_sampindex);
            writer.Write(MSM5205.mm1[0].voice.stream.output_sampindex);
            writer.Write(MSM5205.mm1[0].voice.stream.output_base_sampindex);
            writer.Write(MSM5205.mm1[1].voice.stream.output_sampindex);
            writer.Write(MSM5205.mm1[1].voice.stream.output_base_sampindex);
            writer.Write(Sound.mixerstream.output_sampindex);
            writer.Write(Sound.mixerstream.output_base_sampindex);
        }
        public static void LoadStateBinary_sf(BinaryReader reader)
        {
            int i;
            dsw1 = reader.ReadUInt16();
            dsw2 = reader.ReadUInt16();
            basebanksnd1 = reader.ReadInt32();
            for (i = 0; i < 0x1000; i++)
            {
                sf_objectram[i] = reader.ReadUInt16();
            }
            for (i = 0; i < 0x800; i++)
            {
                sf_videoram[i] = reader.ReadUInt16();
            }
            for (i = 0; i < 0x400; i++)
            {
                Generic.paletteram16[i] = reader.ReadUInt16();
            }
            bg_scrollx = reader.ReadInt32();
            fg_scrollx = reader.ReadInt32();
            sf_active = reader.ReadInt32();
            for (i = 0; i < 0x400; i++)
            {
                Palette.entry_color[i] = reader.ReadUInt32();
            }
            Memory.mainram = reader.ReadBytes(0x6000);
            MC68000.m1.LoadStateBinary(reader);
            Memory.audioram = reader.ReadBytes(0x800);
            Z80A.zz1[0].LoadStateBinary(reader);
            Z80A.zz1[1].LoadStateBinary(reader);
            Cpuint.LoadStateBinary(reader);
            Timer.global_basetime.seconds = reader.ReadInt32();
            Timer.global_basetime.attoseconds = reader.ReadInt64();
            Video.screenstate.frame_number = reader.ReadInt64();
            Sound.last_update_second = reader.ReadInt32();
            Cpuexec.LoadStateBinary(reader);
            Timer.LoadStateBinary(reader);
            YM2151.LoadStateBinary(reader);
            MSM5205.mm1[0].LoadStateBinary(reader);
            MSM5205.mm1[1].LoadStateBinary(reader);
            Sound.ym2151stream.output_sampindex = reader.ReadInt32();
            Sound.ym2151stream.output_base_sampindex = reader.ReadInt32();
            MSM5205.mm1[0].voice.stream.output_sampindex = reader.ReadInt32();
            MSM5205.mm1[0].voice.stream.output_base_sampindex = reader.ReadInt32();
            MSM5205.mm1[1].voice.stream.output_sampindex = reader.ReadInt32();
            MSM5205.mm1[1].voice.stream.output_base_sampindex = reader.ReadInt32();
            Sound.mixerstream.output_sampindex = reader.ReadInt32();
            Sound.mixerstream.output_base_sampindex = reader.ReadInt32();
        }
    }
}
