using System;
using System.Linq;
using System.Collections.Generic;
using ACBr.Net.Core;

namespace ACBr.Net.NFe
{
    public abstract class GenericNFeCollection<T> : GenericCollection<T> where T : class
    {
        #region Methods

        public T AddNew()
        {
            var item = Activator.CreateInstance<T>();
            list.Add(item);
            return item;
        }

        #endregion Methods
    }
}