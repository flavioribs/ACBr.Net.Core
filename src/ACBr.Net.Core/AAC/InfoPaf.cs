// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="InfoPaf.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

/// <summary>
/// The AAC namespace.
/// </summary>
namespace ACBr.Net.Core.AAC
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("C5C65122-FB1C-427F-89AD-5E1D20CB0420")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

    /// <summary>
    /// Class InfoPaf. This class cannot be inherited.
    /// </summary>
	public sealed class InfoPaf
	{
		#region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoPaf"/> class.
        /// </summary>
		public InfoPaf()
		{
		}

		#endregion Constructor

		#region Properties

		#region Dados do Aplicativo

        /// <summary>
        /// Gets or sets the nome aplicativo.
        /// </summary>
        /// <value>The nome aplicativo.</value>
        public string NomeAplicativo { get; set; }

        /// <summary>
        /// Gets or sets the linguagem aplicativo.
        /// </summary>
        /// <value>The linguagem aplicativo.</value>
        public string LinguagemAplicativo { get; set; }

        /// <summary>
        /// Gets or sets the banco de dados aplicativo.
        /// </summary>
        /// <value>The banco de dados aplicativo.</value>
        public string BancoDeDadosAplicativo { get; set; }

        /// <summary>
        /// Gets or sets the sistema operacional aplicativo.
        /// </summary>
        /// <value>The sistema operacional aplicativo.</value>
        public string SistemaOperacionalAplicativo { get; set; }

        /// <summary>
        /// Gets or sets the versao aplicativo.
        /// </summary>
        /// <value>The versao aplicativo.</value>
        public string VersaoAplicativo { get; set; }

        /// <summary>
        /// Gets or sets the principal executable aplicativo.
        /// </summary>
        /// <value>The principal executable aplicativo.</value>
        public string PrincipalExeAplicativo { get; set; }

        /// <summary>
        /// Gets or sets the m d5 aplicativo.
        /// </summary>
        /// <value>The m d5 aplicativo.</value>
        public string MD5Aplicativo { get; set; }

		#endregion Dados do Aplicativo

		#region Dados de Funcionalidades

        /// <summary>
        /// Gets or sets the tipo funcionamento.
        /// </summary>
        /// <value>The tipo funcionamento.</value>
        public TipoFuncionamento TipoFuncionamento { get; set; }

        /// <summary>
        /// Gets or sets the tipo integracao.
        /// </summary>
        /// <value>The tipo integracao.</value>
        public TipoIntegracao TipoIntegracao { get; set; }

        /// <summary>
        /// Gets or sets the tipo desenvolvimento.
        /// </summary>
        /// <value>The tipo desenvolvimento.</value>
        public TipoDesenvolvimento TipoDesenvolvimento { get; set; }

		#endregion Dados de Funcionalidades

		#region Dados de Nao Concomitancia

        /// <summary>
        /// Gets or sets a value indicating whether [realiza pre venda].
        /// </summary>
        /// <value><c>true</c> if [realiza pre venda]; otherwise, <c>false</c>.</value>
        public bool RealizaPreVenda { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [realiza davecf].
        /// </summary>
        /// <value><c>true</c> if [realiza davecf]; otherwise, <c>false</c>.</value>
        public bool RealizaDAVECF { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [realiza dav nao fiscal].
        /// </summary>
        /// <value><c>true</c> if [realiza dav nao fiscal]; otherwise, <c>false</c>.</value>
        public bool RealizaDAVNaoFiscal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [realiza davos].
        /// </summary>
        /// <value><c>true</c> if [realiza davos]; otherwise, <c>false</c>.</value>
        public bool RealizaDAVOS { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [realiza lancamento mesa].
        /// </summary>
        /// <value><c>true</c> if [realiza lancamento mesa]; otherwise, <c>false</c>.</value>
        public bool RealizaLancamentoMesa { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [realiza dav conf anexo ii].
        /// </summary>
        /// <value><c>true</c> if [realiza dav conf anexo ii]; otherwise, <c>false</c>.</value>
        public bool RealizaDAVConfAnexoII { get; set; }

		#endregion Dados de Nao Concomitancia

		#region Dados de Aplicacoes Especiais

        /// <summary>
        /// Gets or sets a value indicating whether [indice tecnico producao].
        /// </summary>
        /// <value><c>true</c> if [indice tecnico producao]; otherwise, <c>false</c>.</value>
        public bool IndiceTecnicoProducao { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [bar similiar ecf restaurante].
        /// </summary>
        /// <value><c>true</c> if [bar similiar ecf restaurante]; otherwise, <c>false</c>.</value>
        public bool BarSimiliarECFRestaurante { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [bar similiar ecf comum].
        /// </summary>
        /// <value><c>true</c> if [bar similiar ecf comum]; otherwise, <c>false</c>.</value>
        public bool BarSimiliarECFComum { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [bar similiar balanca].
        /// </summary>
        /// <value><c>true</c> if [bar similiar balanca]; otherwise, <c>false</c>.</value>
        public bool BarSimiliarBalanca { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [usa impressora nao fiscal].
        /// </summary>
        /// <value><c>true</c> if [usa impressora nao fiscal]; otherwise, <c>false</c>.</value>
        public bool UsaImpressoraNaoFiscal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [dav discr formula].
        /// </summary>
        /// <value><c>true</c> if [dav discr formula]; otherwise, <c>false</c>.</value>
        public bool DAVDiscrFormula { get; set; }

		#endregion Dados de Aplicacoes Especiais

		#region Dados Criterios UF

        /// <summary>
        /// Gets or sets a value indicating whether [totaliza valores lista].
        /// </summary>
        /// <value><c>true</c> if [totaliza valores lista]; otherwise, <c>false</c>.</value>
        public bool TotalizaValoresLista { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [trans pre venda].
        /// </summary>
        /// <value><c>true</c> if [trans pre venda]; otherwise, <c>false</c>.</value>
        public bool TransPreVenda { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [trans dav].
        /// </summary>
        /// <value><c>true</c> if [trans dav]; otherwise, <c>false</c>.</value>
        public bool TransDAV { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [recompoe gt].
        /// </summary>
        /// <value><c>true</c> if [recompoe gt]; otherwise, <c>false</c>.</value>
        public bool RecompoeGT { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [recompoe number serie].
        /// </summary>
        /// <value><c>true</c> if [recompoe number serie]; otherwise, <c>false</c>.</value>
        public bool RecompoeNumSerie { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [emite ped].
        /// </summary>
        /// <value><c>true</c> if [emite ped]; otherwise, <c>false</c>.</value>
        public bool EmitePED { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [cupom mania].
        /// </summary>
        /// <value><c>true</c> if [cupom mania]; otherwise, <c>false</c>.</value>
        public bool CupomMania { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [minas legal].
        /// </summary>
        /// <value><c>true</c> if [minas legal]; otherwise, <c>false</c>.</value>
        public bool MinasLegal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [paraiba legal].
        /// </summary>
        /// <value><c>true</c> if [paraiba legal]; otherwise, <c>false</c>.</value>
        public bool ParaibaLegal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [nota legal df].
        /// </summary>
        /// <value><c>true</c> if [nota legal df]; otherwise, <c>false</c>.</value>
        public bool NotaLegalDF { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [troco em cartao].
        /// </summary>
        /// <value><c>true</c> if [troco em cartao]; otherwise, <c>false</c>.</value>
        public bool TrocoEmCartao { get; set; }

		#endregion Dados Criterios UF

		#region Posto Combustiveis

        /// <summary>
        /// Gets or sets a value indicating whether [acumula volume diario].
        /// </summary>
        /// <value><c>true</c> if [acumula volume diario]; otherwise, <c>false</c>.</value>
        public bool AcumulaVolumeDiario { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [armazena encerrante ini final].
        /// </summary>
        /// <value><c>true</c> if [armazena encerrante ini final]; otherwise, <c>false</c>.</value>
        public bool ArmazenaEncerranteIniFinal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [cadastro placa bomba].
        /// </summary>
        /// <value><c>true</c> if [cadastro placa bomba]; otherwise, <c>false</c>.</value>
        public bool CadastroPlacaBomba { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [emite contr encerr apos redzleix].
        /// </summary>
        /// <value><c>true</c> if [emite contr encerr apos redzleix]; otherwise, <c>false</c>.</value>
        public bool EmiteContrEncerrAposREDZLEIX { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [impede venda VLR zero].
        /// </summary>
        /// <value><c>true</c> if [impede venda VLR zero]; otherwise, <c>false</c>.</value>
        public bool ImpedeVendaVlrZero { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [integrado COM bombas].
        /// </summary>
        /// <value><c>true</c> if [integrado COM bombas]; otherwise, <c>false</c>.</value>
        public bool IntegradoComBombas { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [cria abast diverg encerrante].
        /// </summary>
        /// <value><c>true</c> if [cria abast diverg encerrante]; otherwise, <c>false</c>.</value>
        public bool CriaAbastDivergEncerrante { get; set; }

		#endregion Posto Combustiveis

		#region Transporte Passageiros

        /// <summary>
        /// Gets or sets a value indicating whether [transporte passageiro].
        /// </summary>
        /// <value><c>true</c> if [transporte passageiro]; otherwise, <c>false</c>.</value>
        public bool TransportePassageiro { get; set; }

		#endregion Transporte Passageiros

		#endregion Properties
	}
}