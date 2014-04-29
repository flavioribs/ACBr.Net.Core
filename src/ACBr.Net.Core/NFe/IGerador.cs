using System;
using System.Collections.Generic;

namespace ACBr.Net.Core
{
    public interface IGerador
    {
        #region Propriedades

        List<string> ListaDeAlertas { get; }

        string FormatoAlerta { get; set; }

        #endregion Propriedades

        #region Methods

        string GetXml(object item);

        #endregion Methods
    }
}
