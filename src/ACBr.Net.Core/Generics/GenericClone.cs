// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 01-06-2015
//
// Last Modified By : RFTD
// Last Modified On : 01-06-2015
// ***********************************************************************
// <copyright file="GenericClone.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Reflection;

namespace ACBr.Net.Core.Generics
{
    /// <summary>
    /// Classe GenericClone implementação generica da interface ICloneable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericClone<T> : ICloneable where T : class
    {
        /// <summary>
        /// Cria um novo objeto que é uma copia da instancia atual.
        /// </summary>
        /// <returns>T.</returns>
        public T Clone()
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            var local = Activator.CreateInstance(typeof(T)) as T;
            
            foreach (var info in from prop in properties
                where null != prop.GetSetMethod()
                select prop)
            {
                var value = info.GetValue(this, null);

                if (value is ICloneable)
                    info.SetValue(local, ((ICloneable)value).Clone(), null);
                else
                    info.SetValue(local, value, null);
            }

            return local;
        }

        /// <summary>
        /// Cria um novo objeto que é uma copia da instancia atual.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}