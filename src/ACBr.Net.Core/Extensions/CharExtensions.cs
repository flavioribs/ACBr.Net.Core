using System;
using System.Linq;
using System.Collections.Generic;

namespace ACBr.Net.Core
{
    public static class CharExtensions
    {
        public static int ToInt32(this char dados)
        {
            try
            {
                int converted = new int();
                if (!int.TryParse(dados.ToString(), out converted))
                    converted = -1;

                return converted;
            }
            catch (Exception ex)
            {
                throw new ACBrException("Erro ao converter string", ex);
            }
        }
    }
}
