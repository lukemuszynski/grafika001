﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Grafika002.Drawing
{
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }

        

    }

    public class DirectBitmapDouble : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Double[] BitsRed { get; private set; }
        public Double[] BitsGreen { get; private set; }
        public Double[] BitsBlue { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmapDouble(int width, int height)
        {
            Width = width;
            Height = height;
            BitsRed = new Double[width * height];
            BitsGreen = new Double[width * height];
            BitsBlue = new Double[width * height];
            BitsHandle = GCHandle.Alloc(BitsRed, GCHandleType.Pinned);
            BitsHandle = GCHandle.Alloc(BitsGreen, GCHandleType.Pinned);
            BitsHandle = GCHandle.Alloc(BitsBlue, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }



    }
}
