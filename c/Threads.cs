using System;
using System.Threading;

namespace compression
{
	public class Threads
	{
		int threadsCount;
		List<Thread> threads = new List<Thread>();
		public Threads(int count)
		{
			threadsCount = count;
		}

		public void addThreads(int begin, int end, int i)
		{
			Thread th = new Thread(() => Compression.compress(begin, end));
			threads.Add(th);
		}

		public void start()
		{
			foreach (Thread thread in threads)
			{
				thread.Start();
				thread.Join();
			}
		}


	}
}

