using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace mame
{
    public class YM2610
    {
        public static Timer.emu_timer timer0, timer1;
        /* Timer overflow callback from timer.c */
        public static void timer_callback_0()
        {
            FM.ym2610_timer_over(0);
        }
        public static void timer_callback_1()
        {
            FM.ym2610_timer_over(1);
        }
        public static void timer_handler0(int count)
        {
            if (count == 0)
            {	/* Reset FM Timer */
                Timer.timer_enable(timer0, false);
            }
            else
            {	/* Start FM Timer */
                Atime period = Attotime.attotime_mul(new Atime(0, Attotime.ATTOSECONDS_PER_SECOND / 8000000), (uint)count);
                if (!Timer.timer_enable(timer0, true))
                {
                    Timer.timer_adjust_periodic(timer0, period, Attotime.ATTOTIME_NEVER);
                }
            }
        }
        public static void timer_handler1(int count)
        {
            if (count == 0)
            {	/* Reset FM Timer */
                Timer.timer_enable(timer1, false);
            }
            else
            {	/* Start FM Timer */
                Atime period = Attotime.attotime_mul(new Atime(0, Attotime.ATTOSECONDS_PER_SECOND / 8000000), (uint)count);
                if (!Timer.timer_enable(timer1, true))
                {
                    Timer.timer_adjust_periodic(timer1, period, Attotime.ATTOTIME_NEVER);
                }
            }
        }
        /* update request from fm.c */
        public static void ym2610_update_request()
        {
            Sound.ym2610stream.stream_update();
        }
        public static void ym2610_start()
        {
            AY8910.ay8910_start_ym();
            /* Timer Handler set */
            timer0 = Timer.timer_alloc_common(timer_callback_0, "timer_callback_0", false);
            timer1 = Timer.timer_alloc_common(timer_callback_1, "timer_callback_1", false);
            /**** initialize YM2610 ****/
            FM.ym2610_init();
        }
        public static void SaveStateBinary(BinaryWriter writer)
        {
            int i,j;
            writer.Write(FM.F2610.REGS, 0, 512);
            writer.Write(FM.F2610.addr_A1);
            writer.Write(FM.F2610.adpcmTL);
            writer.Write(FM.F2610.adpcmreg, 0, 0x30);
            writer.Write(FM.F2610.adpcm_arrivedEndAddress);
            writer.Write(FM.ST.freqbase);
            writer.Write(FM.ST.timer_prescaler);
            writer.Write(FM.ST.busy_expiry_time.seconds);
            writer.Write(FM.ST.busy_expiry_time.attoseconds);
            writer.Write(FM.ST.address);
            writer.Write(FM.ST.irq);
            writer.Write(FM.ST.irqmask);
            writer.Write(FM.ST.status);
            writer.Write(FM.ST.mode);
            writer.Write(FM.ST.prescaler_sel);
            writer.Write(FM.ST.fn_h);
            writer.Write(FM.ST.TA);
            writer.Write(FM.ST.TAC);
            writer.Write(FM.ST.TB);
            writer.Write(FM.ST.TBC);
            for (i = 0; i < 12; i++)
            {
                writer.Write(FM.OPN.pan[i]);
            }
            writer.Write(FM.OPN.eg_cnt);
            writer.Write(FM.OPN.eg_timer);
            writer.Write(FM.OPN.eg_timer_add);
            writer.Write(FM.OPN.eg_timer_overflow);
            writer.Write(FM.OPN.lfo_cnt);
            writer.Write(FM.OPN.lfo_inc);
            for (i = 0; i < 8; i++)
            {
                writer.Write(FM.OPN.lfo_freq[i]);
            }
            for (i = 0; i < 6; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    writer.Write(FM.SLOT[i, j].KSR);
                    writer.Write(FM.SLOT[i, j].ar);
                    writer.Write(FM.SLOT[i, j].d1r);
                    writer.Write(FM.SLOT[i, j].d2r);
                    writer.Write(FM.SLOT[i, j].rr);
                    writer.Write(FM.SLOT[i, j].ksr);
                    writer.Write(FM.SLOT[i, j].mul);
                    writer.Write(FM.SLOT[i, j].phase);
                    writer.Write(FM.SLOT[i, j].Incr);
                    writer.Write(FM.SLOT[i, j].state);
                    writer.Write(FM.SLOT[i, j].tl);
                    writer.Write(FM.SLOT[i, j].volume);
                    writer.Write(FM.SLOT[i, j].sl);
                    writer.Write(FM.SLOT[i, j].vol_out);
                    writer.Write(FM.SLOT[i, j].eg_sh_ar);
                    writer.Write(FM.SLOT[i, j].eg_sel_ar);
                    writer.Write(FM.SLOT[i, j].eg_sh_d1r);
                    writer.Write(FM.SLOT[i, j].eg_sel_d1r);
                    writer.Write(FM.SLOT[i, j].eg_sh_d2r);
                    writer.Write(FM.SLOT[i, j].eg_sel_d2r);
                    writer.Write(FM.SLOT[i, j].eg_sh_rr);
                    writer.Write(FM.SLOT[i, j].eg_sel_rr);
                    writer.Write(FM.SLOT[i, j].ssg);
                    writer.Write(FM.SLOT[i, j].ssgn);
                    writer.Write(FM.SLOT[i, j].key);
                    writer.Write(FM.SLOT[i, j].AMmask);
                }
            }
            for (i = 0; i < 6; i++)
            {
                writer.Write(FM.adpcm[i].flag);
                writer.Write(FM.adpcm[i].flagMask);
                writer.Write(FM.adpcm[i].now_data);
                writer.Write(FM.adpcm[i].now_addr);
                writer.Write(FM.adpcm[i].now_step);
                writer.Write(FM.adpcm[i].step);
                writer.Write(FM.adpcm[i].start);
                writer.Write(FM.adpcm[i].end);
                writer.Write(FM.adpcm[i].IL);
                writer.Write(FM.adpcm[i].adpcm_acc);
                writer.Write(FM.adpcm[i].adpcm_step);
                writer.Write(FM.adpcm[i].adpcm_out);
                writer.Write(FM.adpcm[i].vol_mul);
                writer.Write(FM.adpcm[i].vol_shift);
            }
            for (i = 0; i < 6; i++)
            {
                writer.Write(FM.CH[i].ALGO);
                writer.Write(FM.CH[i].FB);
                writer.Write(FM.CH[i].op1_out0);
                writer.Write(FM.CH[i].op1_out1);
                writer.Write(FM.CH[i].mem_value);
                writer.Write(FM.CH[i].pms);
                writer.Write(FM.CH[i].ams);
                writer.Write(FM.CH[i].fc);
                writer.Write(FM.CH[i].kcode);
                writer.Write(FM.CH[i].block_fnum);
            }
            for (i = 0; i < 3; i++)
            {
                writer.Write(FM.SL3.fc[i]);
            }
            writer.Write(FM.SL3.fn_h);
            writer.Write(FM.SL3.kcode, 0, 3);
            for (i = 0; i < 3; i++)
            {
                writer.Write(FM.SL3.block_fnum[i]);
            }
            writer.Write(YMDeltat.DELTAT.portstate);
            writer.Write(YMDeltat.DELTAT.now_addr);
            writer.Write(YMDeltat.DELTAT.now_step);
            writer.Write(YMDeltat.DELTAT.acc);
            writer.Write(YMDeltat.DELTAT.prev_acc);
            writer.Write(YMDeltat.DELTAT.adpcmd);
            writer.Write(YMDeltat.DELTAT.adpcml);
        }
        public static void LoadStateBinary(BinaryReader reader)
        {
            int i, j;
            FM.F2610.REGS = reader.ReadBytes(512);
            FM.F2610.addr_A1 = reader.ReadByte();
            FM.F2610.adpcmTL = reader.ReadByte();
            FM.F2610.adpcmreg = reader.ReadBytes(0x30);
            FM.F2610.adpcm_arrivedEndAddress = reader.ReadByte();
            FM.ST.freqbase = reader.ReadDouble();
            FM.ST.timer_prescaler = reader.ReadInt32();
            FM.ST.busy_expiry_time.seconds = reader.ReadInt32();
            FM.ST.busy_expiry_time.attoseconds = reader.ReadInt64();
            FM.ST.address = reader.ReadByte();
            FM.ST.irq = reader.ReadByte();
            FM.ST.irqmask = reader.ReadByte();
            FM.ST.status = reader.ReadByte();
            FM.ST.mode = reader.ReadByte();
            FM.ST.prescaler_sel = reader.ReadByte();
            FM.ST.fn_h = reader.ReadByte();
            FM.ST.TA = reader.ReadInt32();
            FM.ST.TAC = reader.ReadInt32();
            FM.ST.TB = reader.ReadByte();
            FM.ST.TBC = reader.ReadInt32();
            for (i = 0; i < 12; i++)
            {
                FM.OPN.pan[i] = reader.ReadUInt32();
            }
            FM.OPN.eg_cnt = reader.ReadUInt32();
            FM.OPN.eg_timer = reader.ReadUInt32();
            FM.OPN.eg_timer_add = reader.ReadUInt32();
            FM.OPN.eg_timer_overflow = reader.ReadUInt32();
            FM.OPN.lfo_cnt = reader.ReadInt32();
            FM.OPN.lfo_inc = reader.ReadInt32();
            for (i = 0; i < 8; i++)
            {
                FM.OPN.lfo_freq[i] = reader.ReadInt32();
            }
            for (i = 0; i < 6; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    FM.SLOT[i, j].KSR = reader.ReadByte();
                    FM.SLOT[i, j].ar = reader.ReadInt32();
                    FM.SLOT[i, j].d1r = reader.ReadInt32();
                    FM.SLOT[i, j].d2r = reader.ReadInt32();
                    FM.SLOT[i, j].rr = reader.ReadInt32();
                    FM.SLOT[i, j].ksr = reader.ReadByte();
                    FM.SLOT[i, j].mul = reader.ReadInt32();
                    FM.SLOT[i, j].phase = reader.ReadUInt32();
                    FM.SLOT[i, j].Incr = reader.ReadInt32();
                    FM.SLOT[i, j].state = reader.ReadByte();
                    FM.SLOT[i, j].tl = reader.ReadInt32();
                    FM.SLOT[i, j].volume = reader.ReadInt32();
                    FM.SLOT[i, j].sl = reader.ReadInt32();
                    FM.SLOT[i, j].vol_out = reader.ReadUInt32();
                    FM.SLOT[i, j].eg_sh_ar = reader.ReadByte();
                    FM.SLOT[i, j].eg_sel_ar = reader.ReadByte();
                    FM.SLOT[i, j].eg_sh_d1r = reader.ReadByte();
                    FM.SLOT[i, j].eg_sel_d1r = reader.ReadByte();
                    FM.SLOT[i, j].eg_sh_d2r = reader.ReadByte();
                    FM.SLOT[i, j].eg_sel_d2r = reader.ReadByte();
                    FM.SLOT[i, j].eg_sh_rr = reader.ReadByte();
                    FM.SLOT[i, j].eg_sel_rr = reader.ReadByte();
                    FM.SLOT[i, j].ssg = reader.ReadByte();
                    FM.SLOT[i, j].ssgn = reader.ReadByte();
                    FM.SLOT[i, j].key = reader.ReadUInt32();
                    FM.SLOT[i, j].AMmask = reader.ReadUInt32();
                }
            }
            for (i = 0; i < 6; i++)
            {
                FM.adpcm[i].flag = reader.ReadByte();
                FM.adpcm[i].flagMask = reader.ReadByte();
                FM.adpcm[i].now_data = reader.ReadByte();
                FM.adpcm[i].now_addr = reader.ReadUInt32();
                FM.adpcm[i].now_step = reader.ReadUInt32();
                FM.adpcm[i].step = reader.ReadUInt32();
                FM.adpcm[i].start = reader.ReadUInt32();
                FM.adpcm[i].end = reader.ReadUInt32();
                FM.adpcm[i].IL = reader.ReadByte();
                FM.adpcm[i].adpcm_acc = reader.ReadInt32();
                FM.adpcm[i].adpcm_step = reader.ReadInt32();
                FM.adpcm[i].adpcm_out = reader.ReadInt32();
                FM.adpcm[i].vol_mul = reader.ReadSByte();
                FM.adpcm[i].vol_shift = reader.ReadByte();
            }
            for (i = 0; i < 6; i++)
            {
                FM.CH[i].ALGO = reader.ReadByte();
                FM.CH[i].FB = reader.ReadByte();
                FM.CH[i].op1_out0 = reader.ReadInt32();
                FM.CH[i].op1_out1 = reader.ReadInt32();
                FM.CH[i].mem_value = reader.ReadInt32();
                FM.CH[i].pms = reader.ReadInt32();
                FM.CH[i].ams = reader.ReadByte();
                FM.CH[i].fc = reader.ReadUInt32();
                FM.CH[i].kcode = reader.ReadByte();
                FM.CH[i].block_fnum = reader.ReadUInt32();
            }
            for (i = 0; i < 3; i++)
            {
                FM.SL3.fc[i] = reader.ReadUInt32();
            }
            FM.SL3.fn_h = reader.ReadByte();
            FM.SL3.kcode = reader.ReadBytes(3);
            for (i = 0; i < 3; i++)
            {
                FM.SL3.block_fnum[i] = reader.ReadUInt32();
            }
            YMDeltat.DELTAT.portstate = reader.ReadByte();
            YMDeltat.DELTAT.now_addr = reader.ReadInt32();
            YMDeltat.DELTAT.now_step = reader.ReadInt32();
            YMDeltat.DELTAT.acc = reader.ReadInt32();
            YMDeltat.DELTAT.prev_acc = reader.ReadInt32();
            YMDeltat.DELTAT.adpcmd = reader.ReadInt32();
            YMDeltat.DELTAT.adpcml = reader.ReadInt32();
        }
    }
}
