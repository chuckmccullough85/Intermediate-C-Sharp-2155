
namespace MoqLab
{
	public class GenericArrayList<E> 
	{
		private E[] items;
		int count;

		public GenericArrayList()
		{
			items = new E[15];
			count = 0;
		}

		public GenericArrayList<E> Add(E item)
		{
			if (count == items.Length)
			{
				Array.Resize(ref items, items.Length + ((int)items.Length / 2));
			}
			items[count++] = item;
			return this;
		}

		public void Remove(int idx)
		{
			if (idx >= 0 && idx >= count)
				throw new ArgumentOutOfRangeException("idx");
			for (int i = idx; i < count; i++)
			{
				if (i < count - 1)
					items[i] = items[i + 1];
			}
			count--;
		}
		public int Size { get { return count; } }

		public int IndexOf(E o)
		{
			return Array.IndexOf(items, o);
		}


		/// <summary>
		/// This is the class indexer.  Use it like an array.
		/// </summary>
		/// <param name="idx">The index of the item</param>
		/// <returns></returns>
		public E this[int idx]
		{
			get
			{
				if (idx >= 0 && idx < count)
					return items[idx];
				else
					throw new ArgumentOutOfRangeException("idx");
			}
			set
			{
				if (idx >= 0 && idx < count)
					items[idx] = value;
				else
					throw new ArgumentOutOfRangeException("idx");

			}
		}


	}
}
