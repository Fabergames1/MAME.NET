using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace mame
{
    public partial class Capcom
    {
        public static bool bBg, bFg, bTx, bSprite;
        public static void GDIInit()
        {

        }
        public static Bitmap GetBg()
        {
            int i1, i2, iOffset, i3, i4;
            int rows, cols, width, height;
            int tilewidth, tileheight;
            int tile_index;
            tilewidth = 0x10;
            tileheight = tilewidth;
            rows = 0x10;
            cols = 0x800;
            width = tilewidth * cols;
            height = tileheight * rows;
            int iByte;
            int code, color;
            int group, flags, attributes = 0;
            int pen_data_offset, palette_base;
            int x0 = 0, y0 = 0, dx0 = 0, dy0 = 0;
            Color c1 = new Color();
            Bitmap bm1;
            bm1 = new Bitmap(width, height);
            BitmapData bmData;
            bmData = bm1.LockBits(new Rectangle(0, 0, bm1.Width, bm1.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* ptr = (byte*)(bmData.Scan0);
                byte* ptr2 = (byte*)0;
                for (i3 = 0; i3 < cols; i3++)
                {
                    for (i4 = 0; i4 < rows; i4++)
                    {
                        tile_index = i3 * rows + i4;
                        int base_offset = 2 * tile_index;
                        int attr = Capcom.gfx5rom[base_offset + 0x10000];
                        color = Capcom.gfx5rom[base_offset];
                        code = (Capcom.gfx5rom[base_offset + 0x10000 + 1] << 8) | Capcom.gfx5rom[base_offset + 1];
                        code = code % bg_tilemap.total_elements;
                        pen_data_offset = code * 0x100;
                        palette_base = color * 0x10;
                        group = 0;
                        flags = (attr & 0x03) ^ (attributes & 0x03);
                        pen_data_offset = code * 0x100;
                        if (flags == 0)
                        {
                            x0 = tilewidth * i3;
                            y0 = tileheight * i4;
                            dx0 = 1;
                            dy0 = 1;
                        }
                        else if (flags == 1)
                        {
                            x0 = tilewidth * i3 + tilewidth - 1;
                            y0 = tileheight * i4;
                            dx0 = -1;
                            dy0 = 1;
                        }
                        else if (flags == 2)
                        {
                            x0 = tilewidth * i3;
                            y0 = tileheight * i4 + tileheight - 1;
                            dx0 = 1;
                            dy0 = -1;
                        }
                        else if (flags == 3)
                        {
                            x0 = tilewidth * i3 + tilewidth - 1;
                            y0 = tileheight * i4 + tileheight - 1;
                            dx0 = -1;
                            dy0 = -1;
                        }
                        for (i1 = 0; i1 < tilewidth; i1++)
                        {
                            for (i2 = 0; i2 < tileheight; i2++)
                            {
                                iOffset = pen_data_offset + i2 * 0x10 + i1;
                                iByte = gfx1rom[iOffset];
                                if (iByte == 0)
                                {
                                    c1 = Color.Transparent;
                                }
                                else
                                {
                                    if (palette_base + iByte >= 0x400)
                                    {
                                        c1 = Color.Transparent;
                                    }
                                    else
                                    {
                                        c1 = Color.FromArgb((int)Palette.entry_color[palette_base + iByte]);
                                    }
                                }
                                ptr2 = ptr + ((y0 + dy0 * i2) * width + x0 + dx0 * i1) * 4;
                                *ptr2 = c1.B;
                                *(ptr2 + 1) = c1.G;
                                *(ptr2 + 2) = c1.R;
                                *(ptr2 + 3) = c1.A;
                            }
                        }
                    }
                }
            }
            bm1.UnlockBits(bmData);
            return bm1;
        }
        public static Bitmap GetFg()
        {
            int i1, i2, iOffset, i3, i4;
            int rows, cols, width, height;
            int tilewidth, tileheight;
            int tile_index;
            tilewidth = 0x10;
            tileheight = tilewidth;
            rows = 0x10;
            cols = 0x800;
            width = tilewidth * cols;
            height = tileheight * rows;
            int iByte;
            int code,color;
            int group, flags,attributes=0;
            int pen_data_offset, palette_base;
            int x0 = 0, y0 = 0, dx0 = 0, dy0 = 0;
            Color c1 = new Color();
            Bitmap bm1;
            bm1 = new Bitmap(width, height);
            BitmapData bmData;
            bmData = bm1.LockBits(new Rectangle(0, 0, bm1.Width, bm1.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* ptr = (byte*)(bmData.Scan0);
                byte* ptr2 = (byte*)0;
                for (i3 = 0; i3 < cols; i3++)
                {
                    for (i4 = 0; i4 < rows; i4++)
                    {
                        tile_index = i3 * rows + i4;
                        int base_offset = 0x20000 + 2 * tile_index;
                        int attr = Capcom.gfx5rom[base_offset + 0x10000];
                        color = Capcom.gfx5rom[base_offset];
                        code = (Capcom.gfx5rom[base_offset + 0x10000 + 1] << 8) | Capcom.gfx5rom[base_offset + 1];
                        code = code % fg_tilemap.total_elements;
                        pen_data_offset = code * 0x100;
                        palette_base = 0x100 + color * 0x10;
                        group = 0;
                        flags = (attr & 0x03) ^ (attributes & 0x03);
                        pen_data_offset = code * 0x100;
                        palette_base = 0x100+ 0x10 * color;
                        if (flags == 0)
                        {
                            x0 = tilewidth * i3;
                            y0 = tileheight * i4;
                            dx0 = 1;
                            dy0 = 1;
                        }
                        else if (flags == 1)
                        {
                            x0 = tilewidth * i3 + tilewidth - 1;
                            y0 = tileheight * i4;
                            dx0 = -1;
                            dy0 = 1;
                        }
                        else if (flags == 2)
                        {
                            x0 = tilewidth * i3;
                            y0 = tileheight * i4 + tileheight - 1;
                            dx0 = 1;
                            dy0 = -1;
                        }
                        else if (flags == 3)
                        {
                            x0 = tilewidth * i3 + tilewidth - 1;
                            y0 = tileheight * i4 + tileheight - 1;
                            dx0 = -1;
                            dy0 = -1;
                        }
                        for (i1 = 0; i1 < tilewidth; i1++)
                        {
                            for (i2 = 0; i2 < tileheight; i2++)
                            {
                                iOffset = pen_data_offset + i2 * 0x10 + i1;
                                iByte = gfx2rom[iOffset];
                                if (iByte == 15)
                                {
                                    c1 = Color.Transparent;
                                }
                                else
                                {
                                    c1 = Color.FromArgb((int)Palette.entry_color[palette_base + iByte]);
                                }
                                ptr2 = ptr + ((y0 + dy0 * i2) * width + x0 + dx0 * i1) * 4;
                                *ptr2 = c1.B;
                                *(ptr2 + 1) = c1.G;
                                *(ptr2 + 2) = c1.R;
                                *(ptr2 + 3) = c1.A;
                            }
                        }
                    }
                }
            }
            bm1.UnlockBits(bmData);
            return bm1;
        }
        public static Bitmap GetTx()
        {
            int i1, i2, iOffset, i3, i4;
            int rows, cols, width, height;
            int tilewidth, tileheight;
            int tile_index;
            tilewidth = 0x8;
            tileheight = tilewidth;
            rows = 0x20;
            cols = 0x40;
            width = tilewidth * cols;
            height = tileheight * rows;
            int iByte;
            int code, color;
            int group, flags, attributes = 0;
            int pen_data_offset, palette_base;
            int x0 = 0, y0 = 0, dx0 = 0, dy0 = 0;
            Color c1 = new Color();
            Bitmap bm1;
            bm1 = new Bitmap(width, height);
            BitmapData bmData;
            bmData = bm1.LockBits(new Rectangle(0, 0, bm1.Width, bm1.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* ptr = (byte*)(bmData.Scan0);
                byte* ptr2 = (byte*)0;
                for (i3 = 0; i3 < cols; i3++)
                {
                    for (i4 = 0; i4 < rows; i4++)
                    {
                        tile_index = i4 * cols + i3;
                        int base_offset = 0x20000 + 2 * tile_index;
                        code = Capcom.sf_videoram[tile_index];
                        color = code >> 12;
                        code = (code & 0x3ff) % tx_tilemap.total_elements;
                        pen_data_offset = code * 0x40;
                        palette_base = 0x300 + color * 4;
                        group = 0;
                        flags = (((code & 0xc00) >> 10) & 0x03) ^ (attributes & 0x03);
                        if (flags == 0)
                        {
                            x0 = tilewidth * i3;
                            y0 = tileheight * i4;
                            dx0 = 1;
                            dy0 = 1;
                        }
                        else if (flags == 1)
                        {
                            x0 = tilewidth * i3 + tilewidth - 1;
                            y0 = tileheight * i4;
                            dx0 = -1;
                            dy0 = 1;
                        }
                        else if (flags == 2)
                        {
                            x0 = tilewidth * i3;
                            y0 = tileheight * i4 + tileheight - 1;
                            dx0 = 1;
                            dy0 = -1;
                        }
                        else if (flags == 3)
                        {
                            x0 = tilewidth * i3 + tilewidth - 1;
                            y0 = tileheight * i4 + tileheight - 1;
                            dx0 = -1;
                            dy0 = -1;
                        }
                        for (i1 = 0; i1 < tilewidth; i1++)
                        {
                            for (i2 = 0; i2 < tileheight; i2++)
                            {
                                iOffset = pen_data_offset + i2 * 0x8 + i1;
                                iByte = gfx4rom[iOffset];
                                if (iByte == 3)
                                {
                                    c1 = Color.Transparent;
                                }
                                else
                                {
                                    c1 = Color.FromArgb((int)Palette.entry_color[palette_base + iByte]);
                                }
                                ptr2 = ptr + ((y0 + dy0 * i2) * width + x0 + dx0 * i1) * 4;
                                *ptr2 = c1.B;
                                *(ptr2 + 1) = c1.G;
                                *(ptr2 + 2) = c1.R;
                                *(ptr2 + 3) = c1.A;
                            }
                        }
                    }
                }
            }
            bm1.UnlockBits(bmData);
            return bm1;
        }
        public static Bitmap GetSprite()
        {
            Bitmap bm1;
            int offs;
            int i5, i6;
            int xdir, ydir, offx, offy;
            int iByte1,iByte2,iByte3,iByte4;
            Color c11 = new Color(),c12=new Color(),c13=new Color(),c14=new Color();
            bm1 = new Bitmap(512,256);
            for (offs = 0x1000 - 0x20; offs >= 0; offs -= 0x20)
            {
                int c = sf_objectram[offs];
                int attr = sf_objectram[offs + 1];
                int sy = sf_objectram[offs + 2];
                int sx = sf_objectram[offs + 3];
                int color = attr & 0x000f;
                int flipx = attr & 0x0100;
                int flipy = attr & 0x0200;
                if ((attr & 0x400) != 0)
                {
                    int c1, c2, c3, c4, t;
                    if (Generic.flip_screen_get() != 0)
                    {
                        sx = 480 - sx;
                        sy = 224 - sy;
                        flipx = (flipx == 0) ? 1 : 0;
                        flipy = (flipy == 0) ? 1 : 0;
                    }
                    c1 = c;
                    c2 = c + 1;
                    c3 = c + 16;
                    c4 = c + 17;
                    if (flipx != 0)
                    {
                        t = c1; c1 = c2; c2 = t;
                        t = c3; c3 = c4; c4 = t;
                    }
                    if (flipy != 0)
                    {
                        t = c1; c1 = c3; c3 = t;
                        t = c2; c2 = c4; c4 = t;
                    }
                    if (flipx != 0)
                    {
                        offx = 0x0f;
                        xdir = -1;
                    }
                    else
                    {
                        offx = 0;
                        xdir = 1;
                    }
                    if (flipy != 0)
                    {
                        offy = 0x0f;
                        ydir = -1;
                    }
                    else
                    {
                        offy = 0;
                        ydir = 1;
                    }
                    for (i5 = 0; i5 < 0x10; i5++)
                    {
                        for (i6 = 0; i6 < 0x10; i6++)
                        {
                            iByte1 = gfx3rom[(sf_invert(c1)) * 0x100 + i5 + i6 * 0x10];
                            iByte2 = gfx3rom[(sf_invert(c2)) * 0x100 + i5 + i6 * 0x10];
                            iByte3 = gfx3rom[(sf_invert(c3)) * 0x100 + i5 + i6 * 0x10];
                            iByte4 = gfx3rom[(sf_invert(c4)) * 0x100 + i5 + i6 * 0x10];
                            if (iByte1 != 0x0f)
                            {
                                c11 = Color.FromArgb((int)Palette.entry_color[0x200 + 0x10 * color + iByte1]);
                                bm1.SetPixel(sx + offx + xdir * i5, sy + offy + ydir * i6, c11);
                            }
                            if (iByte2 != 0x0f)
                            {
                                c12 = Color.FromArgb((int)Palette.entry_color[0x200 + 0x10 * color + iByte2]);
                                bm1.SetPixel(sx + 16 + offx + xdir * i5, sy + offy + ydir * i6, c12);
                            }
                            if (iByte3 != 0x0f)
                            {
                                bm1.SetPixel(sx + offx + xdir * i5, sy + 16 + offy + ydir * i6, c13);
                                c13 = Color.FromArgb((int)Palette.entry_color[0x200 + 0x10 * color + iByte3]);
                            }
                            if (iByte4 != 0x0f)
                            {
                                c14 = Color.FromArgb((int)Palette.entry_color[0x200 + 0x10 * color + iByte4]);
                                bm1.SetPixel(sx + 16 + offx + xdir * i5, sy + 16 + offy + ydir * i6, c14);
                            }
                        }
                    }
                    /*Drawgfx.common_drawgfx_sf(gfx3rom, sf_invert(c1), color, flipx, flipy, sx, sy, cliprect);
                    Drawgfx.common_drawgfx_sf(gfx3rom, sf_invert(c2), color, flipx, flipy, sx + 16, sy, cliprect);
                    Drawgfx.common_drawgfx_sf(gfx3rom, sf_invert(c3), color, flipx, flipy, sx, sy + 16, cliprect);
                    Drawgfx.common_drawgfx_sf(gfx3rom, sf_invert(c4), color, flipx, flipy, sx + 16, sy + 16, cliprect);*/
                }
                else
                {
                    if (Generic.flip_screen_get() != 0)
                    {
                        sx = 496 - sx;
                        sy = 240 - sy;
                        flipx = (flipx == 0) ? 1 : 0;
                        flipy = (flipy == 0) ? 1 : 0;
                    }
                    if (flipx != 0)
                    {
                        offx = 0x0f;
                        xdir = -1;
                    }
                    else
                    {
                        offx = 0;
                        xdir = 1;
                    }
                    if (flipy != 0)
                    {
                        offy = 0x0f;
                        ydir = -1;
                    }
                    else
                    {
                        offy = 0;
                        ydir = 1;
                    }
                    for (i5 = 0; i5 < 0x10; i5++)
                    {
                        for (i6 = 0; i6 < 0x10; i6++)
                        {
                            iByte1 = gfx3rom[(sf_invert(c)) * 0x100 + i5 + i6 * 0x10];
                            if (iByte1 != 0x0f)
                            {
                                c11 = Color.FromArgb((int)Palette.entry_color[0x200 + 0x10 * color + iByte1]);
                                bm1.SetPixel(sx + offx + xdir * i5, sy + offy + ydir * i6, c11);
                            }
                        }
                    }                    
                    //Drawgfx.common_drawgfx_sf(gfx3rom, sf_invert(c), color, flipx, flipy, sx, sy, cliprect);
                }
            }
            return bm1;
        }
        public static Bitmap GetAllGDI()
        {
            Bitmap bm1 = new Bitmap(0x200, 0x100), bm2;
            Graphics g = Graphics.FromImage(bm1);
            g.Clear(Color.Transparent);
            if (bBg)
            {
                bm2 = GetBg();
                g.DrawImage(bm2, -bg_scrollx,0);
                //g.DrawImage(bm2, 0,0);
            }
            if(bFg)
            {
                bm2=GetFg();
                g.DrawImage(bm2, -fg_scrollx, 0);
            }
            if(bTx)
            {
                bm2=GetTx();
                g.DrawImage(bm2, 0,0);
            }
            if(bSprite)
            {
                bm2=GetSprite();
                g.DrawImage(bm2, 0,0);
            }
            return bm1;
        }
    }
}
