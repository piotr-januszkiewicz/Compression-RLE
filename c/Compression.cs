using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

    public class Compression
    {
        static String Pixels;
        static int bmpWidth, bmpHeight;
        static List<Thread> ListOfThreads = new List<Thread>();
        static Bitmap bitmapBeforeCompression;
        public Compression()
        {

        }

        public int[] convertToIntArray(Bitmap bmp)
    {
        int[] Tab = new int[bmp.Width * bmp.Height * 3];

        for(int i=0;i<bmp.Width;i++)
        {
            for(int j=0;j<bmp.Height;j++)
            {
                Tab[3 * j] = bmp.GetPixel(j, i).R;
                Tab[3 * j + 1] = bmp.GetPixel(j, i).G;
                Tab[3 * j + 2] = bmp.GetPixel(j, i).B;
            }
        }



        return Tab; 
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

        public String sizeOfString(Bitmap bmp)
        {
            String stringOfPixels = "";

            for (int i = 0; i < bmpWidth; i++)
            {
                for (int j = 0; j < bmpHeight; j++)
                {
                    Color c = bmp.GetPixel(j, i);

                    String bump = (c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ";");
                    stringOfPixels = stringOfPixels + bump;
                }
            }
            return stringOfPixels;
        }

        public static void compress(int begin, int end)
        {
        int counter = 1;

        for (int i = begin; i < end; i++)
        {
            for (int j = 1; j < bmpHeight; j++)
            {
                Color c1 = bitmapBeforeCompression.GetPixel(j, i);
                Color c = bitmapBeforeCompression.GetPixel(j - 1, i);

                if (c == c1)
                {
                    counter++;
                }
                if (c != c1 || j == bmpHeight - 1)
                {
                    String bump = (counter.ToString() + "," + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ";");
                    Pixels = Pixels + bump;
                    counter = 1;
                }
            }
        }

        }

        public String startCompression(Bitmap bmap, int threads)
        {
            bitmapBeforeCompression = bmap;
            bmpWidth = bmap.Size.Width;
            bmpHeight = bmap.Size.Height;
            Pixels = "";

        List<int> beginAndEnd = new List<int> ();

        if (bmpHeight % threads == 0)
        {
            int numberOfCompressedLines = bmpWidth / threads;
            int begin = 0, end = numberOfCompressedLines;
            for (int i = 0; i < threads; i++)
            {
                Thread th = new Thread(() => { compress( begin, end); });
                ListOfThreads.Add(th);
               
            }

            foreach(Thread th in ListOfThreads)
            {
                th.Start();
                th.Join();

                begin += numberOfCompressedLines;
                end += numberOfCompressedLines;
            }
            ListOfThreads.Clear();
        }
        else
        {
            int difference = bmpWidth % (threads-1);
            int tmp = bmpWidth - difference;

            int numberOfCompressedLines = tmp / (threads - 1);

            int begin = 0, end = numberOfCompressedLines;
            for (int i = 0; i < threads - 1; i++)
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
            }

            Thread th1 = new Thread(() => { compress(begin, begin + difference); });
            th1.Start();
            th1.Join();

            ListOfThreads.Clear();

        }
        return Pixels;
        }

    public Bitmap convertStringToBitmap(String str)
    {
        List<int> IntNumbers = new List<int>();
        Bitmap DecompressedBitmap = new Bitmap(bmpWidth, bmpHeight);
        string[] numbers = Regex.Split(str, @"\D+");
        int line = 0, column = 0;

        foreach(String element in numbers)
        {
            if (!string.IsNullOrEmpty(element))
            {
                IntNumbers.Add(int.Parse(element));
            }
        }

        for (int i = 0; i < IntNumbers.Count; i += 4)
        {
            int occurences, R, G, B;
            occurences = IntNumbers[i];
            R = IntNumbers[i + 1];
            G = IntNumbers[i + 2];
            B = IntNumbers[i + 3];

            String hexR = R.ToString("X2"), hexG = G.ToString("X2"), hexB = B.ToString("X2");
            Color pixel = Color.FromArgb(R, G, B);
            
            for(int j=0;j<occurences;j++)
            {
                DecompressedBitmap.SetPixel(column, line, pixel);
                column += 1;
                
                if(column == bmpWidth)
                {
                    line++;
                    column = 0;
                }

            }
        }
        return DecompressedBitmap;
    }
    }


