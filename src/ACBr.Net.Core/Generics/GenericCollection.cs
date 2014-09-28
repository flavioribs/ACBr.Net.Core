using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ACBr.Net.Core
{
	public abstract class GenericCollection<T> : IEnumerable<T> where T : class
	{
		#region Fields

		protected List<T> list;

		#endregion Fields

		#region Constructor

		protected internal GenericCollection()
		{
			list = new List<T>();
		}

		#endregion Constructor

		#region Properties

		public int Count
		{
			get
			{
				return list.Count;
			}
		}

		public T this[int idx]
		{
			get
			{
				if (idx >= Count || idx < 0)
					throw new IndexOutOfRangeException();

				return list[idx];
			}
			set
			{
				if (idx >= Count || idx < 0)
					throw new IndexOutOfRangeException();

				list[idx] = value;
			}
		}

		#endregion Properties

		#region Methods

		public virtual void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<T>

		public IEnumerator<T> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion IEnumerable<T>
	}
}
