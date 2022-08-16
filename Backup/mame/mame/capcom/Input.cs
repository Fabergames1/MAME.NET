using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;

namespace mame
{
    public partial class Capcom
    {
        public static void loop_inputports_sfus()
        {
            if (Keyboard.IsPressed(Key.D5))
            {
                short0 &= ~0x0001;
            }
            else
            {
                short0 |= 0x0001;
            }
            if (Keyboard.IsPressed(Key.D6))
            {
                short0 &= ~0x0002;
            }
            else
            {
                short0 |= 0x0002;
            }
            if (Keyboard.IsPressed(Key.D1))
            {
                shorts &= ~0x0001;
            }
            else
            {
                shorts |= 0x0001;
            }
            if (Keyboard.IsPressed(Key.D2))
            {
                shorts &= ~0x0002;
            }
            else
            {
                shorts |= 0x0002;
            }
            if (Keyboard.IsPressed(Key.D))
            {
                short1 &= ~0x0001;
            }
            else
            {
                short1 |= 0x0001;
            }
            if (Keyboard.IsPressed(Key.A))
            {
                short1 &= ~0x0002;
            }
            else
            {
                short1 |= 0x0002;
            }
            if (Keyboard.IsPressed(Key.S))
            {
                short1 &= ~0x0004;
            }
            else
            {
                short1 |= 0x0004;
            }
            if (Keyboard.IsPressed(Key.W))
            {
                short1 &= ~0x0008;
            }
            else
            {
                short1 |= 0x0008;
            }
            if (Keyboard.IsPressed(Key.J))
            {
                short1 &= ~0x0010;
            }
            else
            {
                short1 |= 0x0010;
            }
            if (Keyboard.IsPressed(Key.K))
            {
                short1 &= ~0x0020;
            }
            else
            {
                short1 |= 0x0020;
            }
            if (Keyboard.IsPressed(Key.L))
            {
                short0 &= ~0x0200;
            }
            else
            {
                short0 |= 0x0200;
            }
            if (Keyboard.IsPressed(Key.U))
            {
                short1 &= ~0x0040;
            }
            else
            {
                short1 |= 0x0040;
            }
            if (Keyboard.IsPressed(Key.I))
            {
                short1 &= ~0x0080;
            }
            else
            {
                short1 |= 0x0080;
            }
            if (Keyboard.IsPressed(Key.O))
            {
                short0 &= ~0x0004;
            }
            else
            {
                short0 |= 0x0004;
            }
            if (Keyboard.IsPressed(Key.Right))
            {
                short1 &= ~0x0100;
            }
            else
            {
                short1 |= 0x0100;
            }
            if (Keyboard.IsPressed(Key.Left))
            {
                short1 &= ~0x0200;
            }
            else
            {
                short1 |= 0x0200;
            }
            if (Keyboard.IsPressed(Key.Down))
            {
                short1 &= ~0x0400;
            }
            else
            {
                short1 |= 0x0400;
            }
            if (Keyboard.IsPressed(Key.Up))
            {
                short1 &= ~0x0800;
            }
            else
            {
                short1 |= 0x0800;
            }
            if (Keyboard.IsPressed(Key.NumPad1))
            {
                short1 &= ~0x1000;
            }
            else
            {
                short1 |= 0x1000;
            }
            if (Keyboard.IsPressed(Key.NumPad2))
            {
                short1 &= ~0x2000;
            }
            else
            {
                short1 |= 0x2000;
            }
            if (Keyboard.IsPressed(Key.NumPad3))
            {
                short0 &= ~0x0400;
            }
            else
            {
                short0 |= 0x0400;
            }
            if (Keyboard.IsPressed(Key.NumPad4))
            {
                short1 &= ~0x4000;
            }
            else
            {
                short1 |= 0x4000;
            }
            if (Keyboard.IsPressed(Key.NumPad5))
            {
                short1 &= unchecked((short)~0x8000);
            }
            else
            {
                short1 |= unchecked((short)0x8000);
            }
            if (Keyboard.IsPressed(Key.NumPad6))
            {
                short0 &= ~0x0100;
            }
            else
            {
                short0 |= 0x0100;
            }
            if (Keyboard.IsPressed(Key.R))
            {
                shorts &= ~0x0004;
            }
            else
            {
                shorts |= 0x0004;
            }
            if (Keyboard.IsPressed(Key.T))
            {
                //sbyte0 &= ~0x40;
            }
            else
            {
                //sbyte0 |= 0x40;
            }
        }
        public static void loop_inputports_sfjp()
        {
            if (Keyboard.IsPressed(Key.D5))
            {
                shortc &= ~0x0001;
            }
            else
            {
                shortc |= 0x0001;
            }
            if (Keyboard.IsPressed(Key.D6))
            {
                shortc &= ~0x0002;
            }
            else
            {
                shortc |= 0x0002;
            }
            if (Keyboard.IsPressed(Key.D1))
            {
                shorts &= ~0x0001;
            }
            else
            {
                shorts |= 0x0001;
            }
            if (Keyboard.IsPressed(Key.D2))
            {
                shorts &= ~0x0002;
            }
            else
            {
                shorts |= 0x0002;
            }
            if (Keyboard.IsPressed(Key.D))
            {
                short1 &= ~0x0001;
            }
            else
            {
                short1 |= 0x0001;
            }
            if (Keyboard.IsPressed(Key.A))
            {
                short1 &= ~0x0002;
            }
            else
            {
                short1 |= 0x0002;
            }
            if (Keyboard.IsPressed(Key.S))
            {
                short1 &= ~0x0004;
            }
            else
            {
                short1 |= 0x0004;
            }
            if (Keyboard.IsPressed(Key.W))
            {
                short1 &= ~0x0008;
            }
            else
            {
                short1 |= 0x0008;
            }
            if (Keyboard.IsPressed(Key.J))
            {
                short1 &= ~0x0100;
            }
            else
            {
                short1 |= 0x0100;
            }
            if (Keyboard.IsPressed(Key.K))
            {
                short1 &= ~0x0200;
            }
            else
            {
                short1 |= 0x0200;
            }
            if (Keyboard.IsPressed(Key.L))
            {
                short1 &= ~0x0400;
            }
            else
            {
                short1 |= 0x0400;
            }
            if (Keyboard.IsPressed(Key.U))
            {
                short1 &= ~0x1000;
            }
            else
            {
                short1 |= 0x1000;
            }
            if (Keyboard.IsPressed(Key.I))
            {
                short1 &= ~0x2000;
            }
            else
            {
                short1 |= 0x2000;
            }
            if (Keyboard.IsPressed(Key.O))
            {
                short1 &= ~0x4000;
            }
            else
            {
                short1 |= 0x4000;
            }
            if (Keyboard.IsPressed(Key.Right))
            {
                short2 &= ~0x0001;
            }
            else
            {
                short2 |= 0x0001;
            }
            if (Keyboard.IsPressed(Key.Left))
            {
                short2 &= ~0x0002;
            }
            else
            {
                short2 |= 0x0002;
            }
            if (Keyboard.IsPressed(Key.Down))
            {
                short2 &= ~0x0004;
            }
            else
            {
                short2 |= 0x0004;
            }
            if (Keyboard.IsPressed(Key.Up))
            {
                short2 &= ~0x0008;
            }
            else
            {
                short2 |= 0x0008;
            }
            if (Keyboard.IsPressed(Key.NumPad1))
            {
                short2 &= ~0x0100;
            }
            else
            {
                short2 |= 0x0100;
            }
            if (Keyboard.IsPressed(Key.NumPad2))
            {
                short2 &= ~0x0200;
            }
            else
            {
                short2 |= 0x0200;
            }
            if (Keyboard.IsPressed(Key.NumPad3))
            {
                short2 &= ~0x0400;
            }
            else
            {
                short2 |= 0x0400;
            }
            if (Keyboard.IsPressed(Key.NumPad4))
            {
                short2 &= ~0x1000;
            }
            else
            {
                short2 |= 0x1000;
            }
            if (Keyboard.IsPressed(Key.NumPad5))
            {
                short2 &= ~0x2000;
            }
            else
            {
                short2 |= 0x2000;
            }
            if (Keyboard.IsPressed(Key.NumPad6))
            {
                short2 &= ~0x4000;
            }
            else
            {
                short2 |= 0x4000;
            }
            if (Keyboard.IsPressed(Key.R))
            {
                shorts &= ~0x0004;
            }
            else
            {
                shorts |= 0x0004;
            }
            if (Keyboard.IsPressed(Key.T))
            {
                //sbyte0 &= ~0x40;
            }
            else
            {
                //sbyte0 |= 0x40;
            }
        }
        public static void loop_inputports_sfan()
        {
            if (Keyboard.IsPressed(Key.D5))
            {
                shortc &= ~0x0001;
            }
            else
            {
                shortc |= 0x0001;
            }
            if (Keyboard.IsPressed(Key.D6))
            {
                shortc &= ~0x0002;
            }
            else
            {
                shortc |= 0x0002;
            }
            if (Keyboard.IsPressed(Key.D1))
            {
                shorts &= ~0x0001;
            }
            else
            {
                shorts |= 0x0001;
            }
            if (Keyboard.IsPressed(Key.D2))
            {
                shorts &= ~0x0002;
            }
            else
            {
                shorts |= 0x0002;
            }
            if (Keyboard.IsPressed(Key.D))
            {
                short0 &= ~0x0001;
            }
            else
            {
                short0 |= 0x0001;
            }
            if (Keyboard.IsPressed(Key.A))
            {
                short0 &= ~0x0002;
            }
            else
            {
                short0 |= 0x0002;
            }
            if (Keyboard.IsPressed(Key.S))
            {
                short0 &= ~0x0004;
            }
            else
            {
                short0 |= 0x0004;
            }
            if (Keyboard.IsPressed(Key.W))
            {
                short0 &= ~0x0008;
            }
            else
            {
                short0 |= 0x0008;
            }
            if (Keyboard.IsPressed(Key.J))
            {
                sbyte1 |= 0x01;
            }
            else
            {
                sbyte1 &= ~0x01;
            }
            if (Keyboard.IsPressed(Key.K))
            {
                sbyte1 |= 0x02;
            }
            else
            {
                sbyte1 &= ~0x02;                
            }
            if (Keyboard.IsPressed(Key.L))
            {
                sbyte1 |= 0x04;                
            }
            else
            {
                sbyte1 &= ~0x04;
            }
            if (Keyboard.IsPressed(Key.U))
            {
                sbyte2 |= 0x01;
            }
            else
            {
                sbyte2 &= ~0x01;                
            }
            if (Keyboard.IsPressed(Key.I))
            {                
                sbyte2 |= 0x02;
            }
            else
            {
                sbyte2 &= ~0x02;
            }
            if (Keyboard.IsPressed(Key.O))
            {
                sbyte2 |= 0x04;                
            }
            else
            {
                sbyte2 &= ~0x04;
            }
            if (Keyboard.IsPressed(Key.Right))
            {
                short0 &= ~0x0100;
            }
            else
            {
                short0 |= 0x0100;
            }
            if (Keyboard.IsPressed(Key.Left))
            {
                short0 &= ~0x0200;
            }
            else
            {
                short0 |= 0x0200;
            }
            if (Keyboard.IsPressed(Key.Down))
            {
                short0 &= ~0x0400;
            }
            else
            {
                short0 |= 0x0400;
            }
            if (Keyboard.IsPressed(Key.Up))
            {
                short0 &= ~0x0800;
            }
            else
            {
                short0 |= 0x0800;
            }
            if (Keyboard.IsPressed(Key.NumPad1))
            {                
                sbyte3 |= 0x01;
            }
            else
            {
                sbyte3 &= ~0x01;
            }
            if (Keyboard.IsPressed(Key.NumPad2))
            {                
                sbyte3 |= 0x02;
            }
            else
            {
                sbyte3 &= ~0x02;
            }
            if (Keyboard.IsPressed(Key.NumPad3))
            {                
                sbyte3 |= 0x04;
            }
            else
            {
                sbyte3 &= ~0x04;
            }
            if (Keyboard.IsPressed(Key.NumPad4))
            {
                sbyte4 |= 0x01;
            }
            else
            {
                sbyte4 &= ~0x01;
            }
            if (Keyboard.IsPressed(Key.NumPad5))
            {
                sbyte4 &= ~0x02;
            }
            else
            {
                sbyte4 |= 0x02;
            }
            if (Keyboard.IsPressed(Key.NumPad6))
            {
                sbyte4 |= 0x04;
            }
            else
            {
                sbyte4 &= ~0x04;                
            }
            if (Keyboard.IsPressed(Key.R))
            {
                shorts &= ~0x0004;
            }
            else
            {
                shorts |= 0x0004;
            }
            if (Keyboard.IsPressed(Key.T))
            {
                //sbyte0 &= ~0x40;
            }
            else
            {
                //sbyte0 |= 0x40;
            }
        }
        public static void record_port_sf()
        {
            if (short0 != short0_old || short1!=short1_old|| short2!=short2_old||shorts!=shorts_old||shortc!=shortc_old|| sbyte1 != sbyte1_old || sbyte2 != sbyte2_old || sbyte3 != sbyte3_old || sbyte4 != sbyte4_old)
            {
                short0_old = short0;
                short1_old = short1;
                short2_old = short2;
                shorts_old = shorts;
                shortc_old = shortc;
                sbyte1_old = sbyte1;
                sbyte2_old = sbyte2;
                sbyte3_old = sbyte3;
                sbyte4_old = sbyte4;
                Mame.bwRecord.Write(Video.screenstate.frame_number);
                Mame.bwRecord.Write(short0);
                Mame.bwRecord.Write(short1);
                Mame.bwRecord.Write(short2);
                Mame.bwRecord.Write(shorts);
                Mame.bwRecord.Write(shortc);
                Mame.bwRecord.Write(sbyte1);
                Mame.bwRecord.Write(sbyte2);
                Mame.bwRecord.Write(sbyte3);
                Mame.bwRecord.Write(sbyte4);
            }
        }
        public static void replay_port_sf()
        {
            if (Inptport.bReplayRead)
            {
                try
                {
                    Video.frame_number_obj = Mame.brRecord.ReadInt64();
                    short0_old = Mame.brRecord.ReadInt16();
                    short1_old = Mame.brRecord.ReadInt16();
                    short2_old = Mame.brRecord.ReadInt16();
                    shorts_old = Mame.brRecord.ReadInt16();
                    shortc_old = Mame.brRecord.ReadInt16();
                    sbyte1_old = Mame.brRecord.ReadSByte();
                    sbyte2_old = Mame.brRecord.ReadSByte();
                    sbyte3_old = Mame.brRecord.ReadSByte();
                    sbyte4_old = Mame.brRecord.ReadSByte();
                }
                catch
                {
                    Mame.playState = Mame.PlayState.PLAY_REPLAYEND;
                }
                Inptport.bReplayRead = false;
            }
            if (Video.screenstate.frame_number == Video.frame_number_obj)
            {
                short0 = short0_old;
                short1 = short1_old;
                short2 = short2_old;
                shorts = shorts_old;
                shortc = shortc_old;
                sbyte1 = sbyte1_old;
                sbyte2 = sbyte2_old;
                sbyte3 = sbyte3_old;
                sbyte4 = sbyte4_old;
                Inptport.bReplayRead = true;
            }
            else
            {
                Inptport.bReplayRead = false;
            }
        }
    }
}
