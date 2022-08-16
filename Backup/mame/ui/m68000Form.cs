using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using cpu.m68000;
using mame;

namespace ui
{
    public partial class m68000Form : Form
    {
        private mainForm _myParentForm;
        private string[] sde6 = new string[1] { "," }, sde7 = new string[1] { ";" }, sde9 = new string[1] { "$" }, sde10 = new string[] { "+" };
        private TextBox[] tbDs, tbAs;
        private MyCheckBox[] cbDs, cbAs;
        private MyCheckBox cbPC,cbTotal;
        private List<MyCheckBox> lsCB;
        private bool bLogNew,bNew;
        public static int iStatus,iRAddress,iWAddress,iROp,iWOp,iValue;
        private int PPCTill, PPC,Addr;
        private ulong CyclesTill,TotalExecutedCycles;
        private List<int> lsAddr = new List<int>();
        private List<int> lsPPC = new List<int>();
        public enum M68000State
        {
            M68000_NONE = 0,
            M68000_RUN,
            M68000_STEP,
            M68000_STEP2,
            M68000_STEP3,
            M68000_STOP,
        }
        public static M68000State m68000State, m68000FState;
        public m68000Form(mainForm form)
        {
            this._myParentForm = form;
            int i;
            tbDs = new TextBox[8];
            tbAs = new TextBox[8];
            cbDs = new MyCheckBox[8];
            cbAs = new MyCheckBox[8];
            for (i = 0; i < 8; i++)
            {
                tbDs[i] = new TextBox();
                tbDs[i].Location = new Point(14, 24 + i * 24);
                tbDs[i].Size = new Size(70, 21);
                Controls.Add(tbDs[i]);
                cbDs[i] = new MyCheckBox();
                cbDs[i].Location = new Point(90, 26 + i * 24);
                cbDs[i].Size = new Size(15, 14);
                cbDs[i].TB = tbDs[i];
                cbDs[i].str = "D" + i.ToString() + "=";
                Controls.Add(cbDs[i]);
                tbAs[i] = new TextBox();
                tbAs[i].Location = new Point(111, 24 + i * 24);
                tbAs[i].Size = new Size(70, 21);
                Controls.Add(tbAs[i]);
                cbAs[i] = new MyCheckBox();
                cbAs[i].Location = new Point(187, 26 + i * 24);
                cbAs[i].Size = new Size(15, 14);
                cbAs[i].TB = tbAs[i];
                cbAs[i].str = "A" + i.ToString() + "=";
                Controls.Add(cbAs[i]);
            }            
            InitializeComponent();
            cbPC = new MyCheckBox();
            cbPC.Location = new Point(298, 328);
            cbPC.Size = new Size(15, 14);
            cbPC.TB = tbPC;
            cbPC.str = "PC=";
            Controls.Add(cbPC);
            cbTotal = new MyCheckBox();
            cbTotal.Location = new Point(348, 285);
            cbTotal.Size = new Size(15, 14);
            cbTotal.TB = tbCycles;
            cbTotal.str = "";
            Controls.Add(cbTotal);
            MyCheckBox.TBResult = tbResult;
            lsCB = new List<MyCheckBox>();
            for (i = 0; i < 8; i++)
            {
                lsCB.Add(cbDs[i]);
                lsCB.Add(cbAs[i]);
            }
            lsCB.Add(cbPC);
        }
        private void m68000Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            m68000FState = m68000State;
            m68000State = M68000State.M68000_STOP;
            GetData();
            m68000State = m68000FState;
        }
        public void GetData()
        {
            int i;
            string sDisassemble, sDisassemble2 = "";
            for (i = 0; i < 8; i++)
            {
                tbDs[i].Text = MC68000.m1.D[i].u32.ToString("X8");
                tbAs[i].Text = MC68000.m1.A[i].u32.ToString("X8");
            }
            tbPPC.Text = MC68000.m1.PPC.ToString("X6");
            tbOP.Text = MC68000.m1.op.ToString("X4");
            cbS.Checked = MC68000.m1.S;
            cbM.Checked = MC68000.m1.M;
            cbX.Checked = MC68000.m1.X;
            cbN.Checked = MC68000.m1.N;
            cbZ.Checked = MC68000.m1.Z;
            cbV.Checked = MC68000.m1.V;
            cbC.Checked = MC68000.m1.C;
            tbIML.Text = MC68000.m1.InterruptMaskLevel.ToString();
            tbUSP.Text = MC68000.m1.usp.ToString("X8");
            tbSSP.Text = MC68000.m1.ssp.ToString("X8");
            tbCycles.Text = MC68000.m1.TotalExecutedCycles.ToString("X16");
            tbPC.Text = MC68000.m1.PC.ToString("X6");
            sDisassemble = MC68000.m1.Disassemble(MC68000.m1.PPC).ToString();
            tbDisassemble.Text = sDisassemble;
            sDisassemble2 = sDisassemble;
            foreach (MyCheckBox cb in lsCB)
            {
                if (cb.Checked)
                {
                    sDisassemble2 += " " + cb.str + cb.TB.Text;
                }
            }
            if (cbTotal.Checked)
            {
                sDisassemble2 = MC68000.m1.TotalExecutedCycles.ToString("X") + " " + sDisassemble2;
            }
            tbResult.AppendText(sDisassemble2 + "\r\n");
        }
        private void btnStep_Click(object sender, EventArgs e)
        {
            if (m68000State == M68000State.M68000_RUN)
            {
                m68000State = M68000State.M68000_STOP;
                tsslStatus.Text = "m68000 stop";
            }
            else
            {
                m68000State = M68000State.M68000_STEP;
                tsslStatus.Text = "m68000 step";
            }
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            m68000State = M68000State.M68000_RUN;
            tsslStatus.Text = "m68000 run";
        }
        private void btnStep2_Click(object sender, EventArgs e)
        {
            try
            {
                PPCTill = int.Parse(tbPPCTill.Text, NumberStyles.HexNumber);
                m68000State = M68000State.M68000_STEP2;
                tsslStatus.Text = "m68000 step2";
            }
            catch
            {
                tsslStatus.Text = "error PPC";
            }
        }
        private void btnStep3_Click(object sender, EventArgs e)
        {
            try
            {
                CyclesTill = ulong.Parse(tbCyclesTill.Text, NumberStyles.HexNumber);
                m68000State = M68000State.M68000_STEP3;
                tsslStatus.Text = "m68000 step3";
            }
            catch
            {
                tsslStatus.Text = "error TotalExecutedCycles";
            }
        }
        private void btnStep4_Click(object sender, EventArgs e)
        {
            UI.single_step = true;
            m68000State = M68000State.M68000_RUN;
            tsslStatus.Text = "m68000 run";
        }
        public void m68000_start_debug()
        {
            /*if (MC68000.m1.Disassemble(MC68000.m1.PPC).Mnemonic == "undisassembled")
            {
                m68000State = M68000State.M68000_STOP;
            }*/
            if (bLogNew && lsPPC.IndexOf(MC68000.m1.PPC) < 0)
            {
                m68000FState = m68000State;
                m68000State = M68000State.M68000_STOP;
                lsPPC.Add(MC68000.m1.PPC);
                tbResult.AppendText(MC68000.m1.Disassemble(MC68000.m1.PPC).ToString() + "\r\n");
                m68000State = m68000FState;
                //tbResult.AppendText(MC68000.m1.PPC.ToString("x") + "\r\n");
            }
            if (iStatus==0&&Attotime.attotime_compare(mame.Timer.global_basetime,new Atime(5,0))==0)
            {
                //iStatus = 1;
                //MC68000.m1.op = 0x451e;                
                //m68000State = M68000State.M68000_STOP;
                //tsslStatus.Text = "m68000 stop";
                //MC68000.m1.op = 0xbfbc;
            }
            PPC = MC68000.m1.PPC;
            TotalExecutedCycles = MC68000.m1.TotalExecutedCycles;
            if (iStatus == 1)// && MC68000.m1.A[0].u32!=0x000142cc)
            {
                iStatus = 0;
            }
            if (m68000State == M68000State.M68000_STEP2)
            {
                if (MC68000.m1.PPC == PPCTill)
                {
                    m68000State =M68000State.M68000_STOP;
                }
            }
            if (m68000State == M68000State.M68000_STEP3)
            {
                if (MC68000.m1.TotalExecutedCycles >= CyclesTill)
                {
                    m68000State = M68000State.M68000_STOP;
                }
            }
            if (cbLog.Checked == true && (m68000State == M68000State.M68000_STEP2 || m68000State == M68000State.M68000_STEP3))
            {
                GetData();
            }
            if (m68000State == M68000State.M68000_STOP)
            {
                GetData();
                tsslStatus.Text = "m68000 stop";
            }
            while (m68000State == M68000State.M68000_STOP)
            {
                //Video.video_frame_update();
                //Application.DoEvents();
            }
        }
        public void m68000_stop_debug()
        {
            if (iStatus == 1)
            {
                GetData();
                m68000State = M68000State.M68000_STOP;
                tsslStatus.Text = "m68000 stop";
                iStatus = 2;
            }
            if (m68000State == M68000State.M68000_STEP)
            {
                m68000State = M68000State.M68000_STOP;
                tsslStatus.Text = "m68000 stop";
            }
            if (bNew)
            {
                Addr = Memory.mainram[0x900c] * 0x100000 + Memory.mainram[0x900d] * 0x10000 + Memory.mainram[0x900e] * 0x100 + Memory.mainram[0x900f];
                if (lsAddr.IndexOf(Addr) < 0)
                {
                    tbResult.AppendText(Addr.ToString("X8") + "\r\n");
                    lsAddr.Add(Addr);
                }
            }
            if (iStatus == 0)
            {
                //if(Neogeo.short0 == unchecked((short)0xfd00))
                //if(Memory.mainram[0xd0b] == 0x09)
                //if(MC68000.m1.A[0].u32 == 0x000142CC)
                //if(Memory.mainram[0xa37]==0x02)
                //if(Memory.mainram[0x2002]==0x16&&Memory.mainram[0x2003]==0x72)
                //if(MC68000.m1.A[6].u32==0x00102000)
                //if(Memory.mainram[0xc01]==0x05)
                //if(Memory.mainram[0xfd96]==0x02)
                //if(Neogeo.neogeo_videoram[0x825a]==0xb102)
                //if(Memory.mainram[0x7b2]==0xb1&&Memory.mainram[0x7b3]==0x02)
                //if(Memory.mainram[0x1053]==0xae)
                //if(Memory.mainram[0x51df]==0xae)
                //if(Memory.mainram[0x51d1]==0xae)
                //if(Neogeo.neogeo_videoram[0x1680]==0xcb06)
                //if(Memory.mainram[0xb79]==0x59)
                //if(Memory.mainram[0x1487]==0x04)
                //if(Neogeo.neogeo_videoram[0x845a]==0x0c80)
                //if(Memory.mainram[0x51dd]==0x29)
                //if(Memory.mainram[0x51cf] == 0x29)
                //if(iAddress==0x1051ec&&iOp==0x06&&Memory.mainram[0x51ed]==0x2A&&Memory.mainram[0x51ee]==0xE4&&Memory.mainram[0x51ef]==0x0A)
                //if(iAddress==0x142dc&&iOp>=1&&iOp<=6)
                //if(Memory.mainram[0x900e]==0x31&&Memory.mainram[0x900f]==0xa2)
                //if(MC68000.m1.op==0x43e9&&Memory.mainram[0x900e]==0x30&&Memory.mainram[0x900f]==0xf2)
                //if(iRAddress>=0x6d02c&&iRAddress<=0x6d02d)
                //if(iWAddress>=0xff8410&&iWAddress<=0xff8413)
                /*if(Memory.mainram[0xd1b]==0x05)
                {
                    iStatus = 1;
                    GetData();
                    m68000State = M68000State.M68000_STOP;
                    tsslStatus.Text = "m68000 stop";
                }*/
            }
        }
        private void btnGetNew_Click(object sender, EventArgs e)
        {
            if (btnGetNew.Text == "get new")
            {
                btnGetNew.Text = "stop";
                lsPPC = new List<int>();
                bLogNew = true;
            }
            else if (btnGetNew.Text == "stop")
            {
                btnGetNew.Text = "get new";
                bLogNew = false;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbResult.Clear();
        }
        private void btnGN2_Click(object sender, EventArgs e)
        {
            if (btnGN2.Text == "get")
            {
                lsAddr = new List<int>();
                bNew = true;
                btnGN2.Text = "stop";
            }
            else if (btnGN2.Text == "stop")
            {
                bNew = false;
                btnGN2.Text = "get";
            }
        }
    }
}
