using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

public class Compression
{
    
    private int bmpWidth, bmpHeight;
    private int threads;
    private List<Thread> ListOfThreads;
    private Bitmap bitmapBeforeCompression;
    private List<int> Repetitions;
    private List<byte> ByteList;
    private byte[] ByteArray;
    
    public Compression()
    {

    }

    public Bitmap Preparation(string filename)
    {
        Bitmap bitmap;
        using (Stream bmpStream = System.IO.File.Open(filename, System.IO.FileMode.Open))
        {
            Image image = Image.FromStream(bmpStream);
            bitmap = new Bitmap(image);
        }

        return bitmap;
    }

    public void startCompression(Bitmap bmap, int Threads)
    {
        this.bitmapBeforeCompression = bmap;
        this.ByteList = new List<byte> { };
        this.Repetitions = new List<int> { };
        this.ListOfThreads = new List<Thread>();
        this.threads = Threads;
        int begin = 0;

        if (bmpHeight % threads == 0)
        {
            int numberOfCompressedLines = bmpWidth / threads;
            int end = numberOfCompressedLines;

            for (int i = 0; i < threads; i++)
            {
                Thread th = new Thread(() => { compress(begin, end); });
                ListOfThreads.Add(th);
            }

            foreach (Thread th in ListOfThreads)
            {
                th.Start();
                th.Join();

                begin += numberOfCompressedLines;
                end += numberOfCompressedLines;
                Console.WriteLine(end);
                while (th.IsAlive)
                {
                    Thread.Sleep(0);
                }
            }
        }
        else
        {
            int difference = bmpWidth % threads;
            int tmp = bmpWidth - difference;
            int numberOfCompressedLines = tmp / (threads - 1);
            int end = numberOfCompressedLines;

            for (int i = 0; i < threads; i++)
            {
                Thread th = new Thread(() => { compress(begin, end); });
                ListOfThreads.Add(th);
            }

            foreach (Thread th in ListOfThreads)
            {
                th.Start();
                th.Join();

                begin += numberOfCompressedLines;
                end += numberOfCompressedLines;

                while (th.IsAlive)
                {
                    Thread.Sleep(0);
                }
            }

            Thread th1 = new Thread(() => { compress(begin, begin + difference); });

            th1.Start();
            th1.Join();
            
            while (th1.IsAlive)
            {
                Thread.Sleep(0);
            }
        }
    }

    public void compress(int begin, int end)
    {
        int counter = 1;

        for (int i = begin; i < end; i++)
        {
            for (int j = 1; j < bmpHeight; j++)
            {
                Color c1 = this.bitmapBeforeCompression.GetPixel(j, i);
                Color c = this.bitmapBeforeCompression.GetPixel(j - 1, i);

                if (c == c1)
                {
                    counter++;
                }
                if (c != c1 || j == this.bmpHeight - 1)
                {
                    Repetitions.Add(counter);
                    ByteList.Add(c.R);
                    ByteList.Add(c.G);
                    ByteList.Add(c.B);

                    counter = 1;
                }
            }
        }
    }

    public void startCompressionAssembler(Bitmap bmap, int[] tab, int Threads)
    {
        bitmapBeforeCompression = bmap;
        ByteList = new List<byte> { };
        this.Repetitions = new List<int> { };
        this.ListOfThreads = new List<Thread>();
        this.threads = Threads;
        int begin = 0;

        if (bmpHeight % threads == 0)
        {
            int numberOfCompressedLines = bmpWidth / threads;
            int end = numberOfCompressedLines;

            for (int i = 0; i < threads; i++)
            {
                Thread th = new Thread(() => { compress1(tab, begin, end, bmpWidth, bmpHeight); });
                ListOfThreads.Add(th);
            }

            foreach (Thread th in ListOfThreads)
            {
                th.Start();
                th.Join();

                begin += numberOfCompressedLines;
                end += numberOfCompressedLines;
                while (th.IsAlive)
                {
                    Thread.Sleep(0);
                }
            }
        } else
        {
            
            int difference = bmpWidth % threads;
            int tmp = bmpWidth - difference;
            int numberOfCompressedLines = tmp / (threads - 1);
            int end = numberOfCompressedLines;
            
            for (int i = 0; i < threads; i++)
            {
                Thread th = new Thread(() => { compress1(tab, begin, end, bmpWidth, bmpHeight); });
                ListOfThreads.Add(th);
            }

            foreach (Thread th in ListOfThreads)
            {
                th.Start();
                th.Join();

                begin += numberOfCompressedLines;
                end += numberOfCompressedLines;

                while (th.IsAlive)
                {
                    Thread.Sleep(0);
                }
            }

            Thread th1 = new Thread(() => { compress1(tab, begin, begin + difference, bmpWidth, bmpHeight); });
            
            th1.Start();
            th1.Join();
           
            while (th1.IsAlive)
            {
                Thread.Sleep(0);
            }
        }
    }

    public void compress1(int[] tab, int begin, int end, int bmpWidth, int bmpHeight)
    {
        int counter = 1;
        byte[] compressed = new byte[0];
        int it = 0;
        int repIt = 0;
        int loopit = 3 * bmpWidth;

        for (int i = begin; i < end; i++)
        {
            for (int j = 0; j < loopit - 3; j += 3)
            {
                int c1R, c1G, c1B, c2R, c2G, c2B;
                c1R = tab[i * loopit + j];
                c1G = tab[i * loopit + j + 1];
                c1B = tab[i * loopit + j + 2];
                c2R = tab[i * loopit + j + 3];
                c2G = tab[i * loopit + j + 4];
                c2B = tab[i * loopit + j + 5];

                if (c1R == c2R && c1G == c2G && c1B == c2B)
                {
                    counter++;
                }
                if (c1R != c2R || c1G != c2G || c1B != c2B || j == loopit - 6)
                {
                    Repetitions.Add(counter);
                    Array.Resize<byte>(ref compressed, it + 3);
                    compressed[it] = (byte)c1R;
                    compressed[it + 1] = (byte)c1G;
                    compressed[it + 2] = (byte)c1B;

                    it += 3;
                    counter = 1;
                    
                }
            }
        }

        for (int i = 0; i < compressed.Length; i++)
        {
            ByteList.Add(compressed[i]);
        }
    }

    unsafe public int* compress2(int* tab, int begin, int end, int bmpWidth, int bmpHeight)
    {
        int counter = 1;
        int* compressed = new int*;
        int it = 0;
        int loopit = 3 * bmpWidth;

        for (int i = begin; i < end; i++)
        {
            for (int j = 0; j < loopit - 3; j += 3)
            {
                int c1R, c1G, c1B, c2R, c2G, c2B;
                c1R = tab[i * loopit + j];
                c1G = tab[i * loopit + j + 1];
                c1B = tab[i * loopit + j + 2];
                c2R = tab[i * loopit + j + 3];
                c2G = tab[i * loopit + j + 4];
                c2B = tab[i * loopit + j + 5];

                if (c1R == c2R && c1G == c2G && c1B == c2B)
                {
                    counter++;
                }
                if (c1R != c2R || c1G != c2G || c1B != c2B || j == loopit - 6)
                {

                    compressed[it] = counter;
                    compressed[it + 1] = c1R;
                    compressed[it + 2] = c1G;
                    compressed[it + 3] = c1B;

                    it += 4;
                    counter = 1;

                }
            }
        }

        return compressed;
    }


    public Bitmap convertArrayToBitmap()
    {
        Bitmap DecompressedBitmap = new Bitmap(bmpWidth, bmpHeight);
        int line = 0, column = 0;
        int repIt = 0;

        for (int i=0;i<ByteList.Count;i+=3)
        {
            int occurences, R, G, B;
            occurences = Repetitions[repIt];
            R = ByteList[i];
            G = ByteList[i + 1];
            B = ByteList[i + 2];
            String hexR = R.ToString("X2"), hexG = G.ToString("X2"), hexB = B.ToString("X2");
           
            Color pixel = Color.FromArgb(R, G, B);
            repIt++;
            for (int j = 0; j < occurences; j++)
            {
                DecompressedBitmap.SetPixel(column, line, pixel);
                column++;

                if (column == bmpWidth)
                {
                    line++;
                    column = 0;
                }
            }
        }

        return DecompressedBitmap;
    }

    public Bitmap convertArrayToBitmapFromAsm()
    {
        Bitmap DecompressedBitmap = new Bitmap(bmpWidth, bmpHeight);
        int line = 0, column = 0;
        int repIt = 0;

        for (int i = 0; i < ByteList.Count; i += 3)
        {
            int occurences, R, G, B;
            occurences = Repetitions[repIt];
            R = ByteList[i];
            G = ByteList[i + 1];
            B = ByteList[i + 2];
            String hexR = R.ToString("X2"), hexG = G.ToString("X2"), hexB = B.ToString("X2");

            Color pixel = Color.FromArgb(R, G, B);
            repIt++;
            for (int j = 0; j < occurences; j++)
            {
                DecompressedBitmap.SetPixel(column, line, pixel);
                column++;

                if (column == bmpWidth)
                {
                    line++;
                    column = 0;
                }
            }
        }

        return DecompressedBitmap;
    }

    public int[] convertToIntArray(Bitmap bmp)
    {
        int[] Tab = new int[bmp.Width * bmp.Height * 3];

        int itWidth = 0, itHeight = 0;
        for(int i=0;i<bmpHeight*bmpWidth;i++)
        {
            if (itWidth == bmpWidth)
            {
                itWidth = 0;
                itHeight++;
            }
            Color c = bmp.GetPixel(itWidth, itHeight);
            Tab[3 * i] = c.R;
            Tab[3 * i + 1] = c.G;
            Tab[3 * i + 2] = c.B;
            itWidth++;
        }

        return Tab;
    }

    public byte[] sizeOfByteArray(Bitmap bmp)
    {
        this.bmpHeight = bmp.Height;
        this.bmpWidth = bmp.Width;
        this.ByteArray = new byte[bmpHeight * bmpWidth * 3];

        for (int i = 0; i < bmp.Width; i++)
        {
            for (int j = 0; j < bmp.Height; j++)
            {
                ByteArray[3 * j] = bmp.GetPixel(j, i).R;
                ByteArray[3 * j + 1] = bmp.GetPixel(j, i).G;
                ByteArray[3 * j + 2] = bmp.GetPixel(j, i).B;
            }
        }
        return ByteArray;
    }

    public int sizeOfCompressedFile()
    {
        return ByteList.Count + Repetitions.Count; ;
    }
}


