using System;

namespace System
{
#if !NET_4_5
	public class Progress<T> : IProgress<T>
	{
		public Progress()
		{
		}

		public void Report(T value)
		{
			throw new NotImplementedException();
		}
	}
#endif
}

