using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using cpu.m68000;

namespace mame
{
    public class State
    {
        public delegate void savestate_delegate(BinaryWriter sw);
        public delegate void loadstate_delegate(BinaryReader sr);
        public static savestate_delegate savestate_callback;
        public static loadstate_delegate loadstate_callback;
        public static void state_init()
        {
            switch (Machine.sBoard)
            {
                case "CPS-1":
                    savestate_callback = CPS.SaveStateBinaryC;
                    loadstate_callback = CPS.LoadStateBinaryC;
                    break;
                case "CPS-1(QSound)":
                    savestate_callback = CPS.SaveStateBinaryQ;
                    loadstate_callback = CPS.LoadStateBinaryQ;
                    break;
                case "CPS2":
                    savestate_callback = CPS.SaveStateBinaryC2;
                    loadstate_callback = CPS.LoadStateBinaryC2;
                    break;
                case "Neo Geo":
                    savestate_callback = Neogeo.SaveStateBinary;
                    loadstate_callback = Neogeo.LoadStateBinary;
                    break;
                case "Namco System 1":
                    savestate_callback = Namcos1.SaveStateBinary;
                    loadstate_callback = Namcos1.LoadStateBinary;
                    break;
                case "IGS011":
                    savestate_callback = IGS011.SaveStateBinary;
                    loadstate_callback = IGS011.LoadStateBinary;
                    break;
                case "PGM":
                    savestate_callback = PGM.SaveStateBinary;
                    loadstate_callback = PGM.LoadStateBinary;
                    break;
                case "M72":
                    savestate_callback = M72.SaveStateBinary;
                    loadstate_callback = M72.LoadStateBinary;
                    break;
                case "M92":
                    savestate_callback = M92.SaveStateBinary;
                    loadstate_callback = M92.LoadStateBinary;
                    break;
                case "Taito B":
                    savestate_callback = Taitob.SaveStateBinary;
                    loadstate_callback = Taitob.LoadStateBinary;
                    break;
                case "Konami 68000":
                    switch (Machine.sName)
                    {
                        case "cuebrick"://ym K052109 K051960
                            savestate_callback = Konami68000.SaveStateBinary_cuebrick;
                            loadstate_callback = Konami68000.LoadStateBinary_cuebrick;
                            break;
                        case "mia"://ym k007232 K052109 K051960
                            savestate_callback = Konami68000.SaveStateBinary_mia;
                            loadstate_callback = Konami68000.LoadStateBinary_mia;
                            break;
                        case "tmnt":
                        case "tmntu":
                        case "tmntua":
                        case "tmntub":
                        case "tmht":
                        case "tmhta":
                        case "tmhtb":
                        case "tmntj":
                        case "tmnta":
                        case "tmht2p":
                        case "tmht2pa":
                        case "tmnt2pj":
                        case "tmnt2po"://ym k007232 upd samples K052109 K051960
                            savestate_callback = Konami68000.SaveStateBinary_tmnt;
                            loadstate_callback = Konami68000.LoadStateBinary_tmnt;
                            break;
                        case "punkshot":
                        case "punkshot2":
                        case "punkshotj"://ym k053260 K052109 K051960
                            savestate_callback = Konami68000.SaveStateBinary_punkshot;
                            loadstate_callback = Konami68000.LoadStateBinary_punkshot;
                            break;                        
                        case "lgtnfght":
                        case "lgtnfghta":
                        case "lgtnfghtu":
                        case "trigon"://ym k053260 K052109 K053245
                            savestate_callback = Konami68000.SaveStateBinary_lgtnfght;
                            loadstate_callback = Konami68000.LoadStateBinary_lgtnfght;
                            break;
                        case "blswhstl":
                        case "blswhstla":
                        case "detatwin"://ym k053260 K052109 K053245 eeprom bytee
                            savestate_callback = Konami68000.SaveStateBinary_blswhstl;
                            loadstate_callback = Konami68000.LoadStateBinary_blswhstl;
                            break;
                        case "glfgreat":
                        case "glfgreatj"://k053260 K052109 K053245
                            savestate_callback = Konami68000.SaveStateBinary_glfgreat;
                            loadstate_callback = Konami68000.LoadStateBinary_glfgreat;
                            break;
                        case "tmnt2":
                        case "tmnt2a":
                        case "tmht22pe":
                        case "tmht24pe":
                        case "tmnt22pu":
                        case "qgakumon"://ym k053260 K052109 K053245 eeprom tmnt2_1c0800
                            savestate_callback = Konami68000.SaveStateBinary_tmnt2;
                            loadstate_callback = Konami68000.LoadStateBinary_tmnt2;
                            break;
                        case "ssriders":
                        case "ssriderseaa":
                        case "ssridersebd":
                        case "ssridersebc":
                        case "ssridersuda":
                        case "ssridersuac":
                        case "ssridersuab":
                        case "ssridersubc":
                        case "ssridersadd":
                        case "ssridersabd":
                        case "ssridersjad":
                        case "ssridersjac":
                        case "ssridersjbd"://ym k053260 K052109 K053245 eeprom
                            savestate_callback = Konami68000.SaveStateBinary_ssriders;
                            loadstate_callback = Konami68000.LoadStateBinary_ssriders;
                            break;                        
                        case "thndrx2":
                        case "thndrx2a":
                        case "thndrx2j"://ym k053260 K052109 K051960 eeprom
                            savestate_callback = Konami68000.SaveStateBinary_thndrx2;
                            loadstate_callback = Konami68000.LoadStateBinary_thndrx2;
                            break;
                        case "prmrsocr":
                        case "prmrsocrj"://k054539 K052109 K053245 eeprom
                            savestate_callback = Konami68000.SaveStateBinary_prmrsocr;
                            loadstate_callback = Konami68000.LoadStateBinary_prmrsocr;
                            break;
                    }
                    break;
                case "Capcom":
                    switch (Machine.sName)
                    {
                        case "sf":
                        case "sfua":
                        case "sfj":
                        case "sfjan":
                        case "sfan":
                        case "sfp":
                            savestate_callback = Capcom.SaveStateBinary_sf;
                            loadstate_callback = Capcom.LoadStateBinary_sf;
                            break;
                    }
                    break;
            }
        }
    }
}
