using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace ACBr.Net.Core
{
    public static class ACBrComponentExtensions
    {
        public static bool EventAssigned<T>(this T comp, string evento) where T : ACBrComponent
        {
            var handler = typeof(T).GetField(evento, BindingFlags.NonPublic | BindingFlags.Instance)
                                   .GetValue(comp) as Delegate;
            if (handler == null)
                return false;

            var subscribers = handler.GetInvocationList();
            if (subscribers.Length == 0)
                return false;
            else
                return true;
        }
    }
}
