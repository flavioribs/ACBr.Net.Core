using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ACBr.Net.Core.AAC;
using ACBr.Net.Core.ECF;

namespace ACBr.Net.Core.Interface
{
	public interface IECF 
	{
		#region Methods

		#region Métodos Ativar/Desativar

        void Ativar();

		void Desativar();

		#endregion Métodos Ativar/Desativar

		#region Métodos ECF

        bool EmLinha(int timeOut = 1);
        void PulaLinhas(int numLinhas);
        void CortaPapel(bool corteParcial = false);
        void MudaHorarioVerao();
        void MudaArredondamento(bool arredonda);
		void PreparaTEF();
        void TestaPodeAbrirCupom();
        string EnviaComando(string cmd, int timeout = - 1);
        void CorrigeEstadoErro(bool reducaoZ = true);

		#endregion Métodos ECF

		#region Métodos Cheque

        void ImprimeCheque(string Banco, decimal Valor, string Favorecido, string Cidade, DateTime Data, string Observacao = "");
		void CancelaImpressaoCheque();
        string LeituraCMC7();

		#endregion Métodos Cheque

		#region Cupom Fiscal

        void IdentificaConsumidor(string cpfCnpj, string nome, string endereco);
        void IdentificaOperador(string nome);
        void AbreCupom(string cpfCnpj = "", string nome = "", string endereco = "", bool ModoPreVenda = false);
        void LegendaInmetroProximoItem();
        void VendeItem(string codigo, string descricao, string aliquotaICMS, decimal qtd, decimal valorUnitario, decimal descontoPorc = 0M, string unidade = "UN", string tipoDescontoAcrescimo = "%", string descontoAcrescimo = "D", int CodDepartamento = -1);
        void DescontoAcrescimoItemAnterior(decimal valorDesconto, string descontoAcrescimo, string tipodescontoAcrescimo = "%", int item = 0);
		void SubtotalizaCupom(decimal descontoAcrescimo = 0M, string mensagemRodape = "");
        void EfetuaPagamento(string codFormaPagto, decimal valor, string observacao = "", bool imprimeVinculado = false);
		void EstornaPagamento(string codFormaPagtoEstornar, string codFormaPagtoEfetivar, double valor, string observacao);
        void FechaCupom(string observacao = "");
        void CancelaCupom();
        void CancelaItemVendido(int numItem);
        void CancelaItemVendidoParcial(int numItem, decimal quantidade);
        void CancelaDescontoAcrescimoItem(int numItem);
        void CancelaDescontoAcrescimoSubTotal(string tipoAcrescimoDesconto);

		#endregion Cupom Fiscal

		#region Métodos DAV

        void DAV_Abrir(DateTime emissao, string decrdocumento, string numero, string situacao, string vendedor, string observacao, string cpfCnpj, string nome, string endereco, int indice = 0);
		void DAV_RegistrarItem(string codigo, string descricao, string unidade, double quantidade, double vlrunitario, double desconto, double acrescimo, bool cancelado);
        void DAV_Fechar(string observacao);
		void PafMF_RelDAVEmitidos(DAVs[] DAVs, string TituloRelatorio, int IndiceRelatorio);

		#endregion Métodos DAV

		#region PAF Relatorios

        void PafMF_RelMeiosPagamento(FormaPagamento[] formasPagamento, string TituloRelatorio, int indiceRelatorio);
        void PafMF_RelIdentificacaoPafECF(IdenticacaoPaf identificacaoPAF = null, int indiceRelatorio = 0);
        void PafMF_RelParametrosConfiguracao(InfoPaf infoPAF = null, int indiceRelatorio = 1);

		#endregion PAF Relatorios

		#region PAF

        void PafMF_GerarCAT52(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
        void PafMF_LX_Impressao();
		void ArquivoMFD_DLL(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo, FinalizaArqMFD Finaliza = FinalizaArqMFD.MFD, params TipoDocumento[] Documentos);
		void ArquivoMFD_DLL(int COOInicial, int COOFinal, string CaminhoArquivo, FinalizaArqMFD Finaliza = FinalizaArqMFD.MFD, TipoContador TipoContador = TipoContador.COO, params TipoDocumento[] Documentos);
        void DoAtualizarValorGT();
        void DoVerificaValorGT();

		#endregion PAF

		#region PAF LMFC

        void PafMF_LMFC_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
		void PafMF_LMFC_Cotepe1704(int CRZInicial, int CRZFinal, string CaminhoArquivo);
		void PafMF_LMFC_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
		void PafMF_LMFC_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo);
		void PafMF_LMFC_Impressao(DateTime DataInicial, DateTime DataFinal);
        void PafMF_LMFC_Impressao(int CRZInicial, int CRZFinal);

		#endregion PAF LMFC

		#region PAF LMFS

        void PafMF_LMFS_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
		void PafMF_LMFS_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo);
		void PafMF_LMFS_Impressao(DateTime DataInicial, DateTime DataFinal);
		void PafMF_LMFS_Impressao(int CRZInicial, int CRZFinal);

		#endregion PAF LMFS

		#region PAF Espelho MFD

        void PafMF_MFD_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
		void PafMF_MFD_Cotepe1704(int COOInicial, int COOFinal, string CaminhoArquivo);

		#endregion PAF Espelho MFD

		#region PAF Arq. MFD

        void PafMF_MFD_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
		void PafMF_MFD_Espelho(int COOInicial, int COOFinal, string CaminhoArquivo);

		#endregion PAF Arq. MFD

		#region Leitura Memoria Fiscal

        void LeituraMemoriaFiscal(int reducaoInicial, int reducaoFinal, bool simplificada = false);
		void LeituraMemoriaFiscal(DateTime dataInicial, DateTime dataFinal, bool simplificada = false);
		string LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, bool simplificada = false);
		string LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, bool simplificada = false);
		void LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, string nomeArquivo, bool simplificada = false);
		void LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, string nomeArquivo, bool simplificada = false);

		#endregion Leitura Memoria Fiscal

		#region Cupom Vinculado

        void AbreCupomVinculado(int coo, string codFormaPagto, decimal valor);
        void AbreCupomVinculado(string coo, string codFormaPagto, decimal valor);
        void AbreCupomVinculado(string coo, string codFormaPagto, string codComprovanteNaoFiscal, decimal valor);
		void LinhaCupomVinculado(string[] linhas);
		void LinhaCupomVinculado(string linha);
		void ReimpressaoVinculado();
		void SegundaViaVinculado();

		#endregion Cupom Vinculado

		#region Leitura X / Redução Z

        void LeituraX();
        void ReducaoZ([Optional]DateTime data);
        string DadosUltimaReducaoZ();
        string DadosReducaoZ();

		#endregion Leitura X / Redução Z

		#region Relatório Gerencial

        void AbreRelatorioGerencial(int indice = 0);
        void LinhaRelatorioGerencial(string[] linhas, int indiceBMP = 0);
		void LinhaRelatorioGerencial(string linha, int indiceBMP = 0);
        void ProgramaRelatoriosGerenciais(string descricao, string posicao = "");
        void CarregaRelatoriosGerenciais();
		void LerTotaisRelatoriosGerenciais();
        void RelatorioGerencial(string[] relatorio, int vias = 1, int indice = 0);
        void FechaRelatorio();

		#endregion Relatório Gerencial

		#region Alíquotas

        void CarregaAliquotas();
		void LerTotaisAliquota();
		void ProgramaAliquota(decimal aliquota, string tipo, string posicao = "");

		#endregion Alíquotas

		#region Formas de Pagto

        FormaPagamento AchaFPGDescricao(string descricao, bool buscaExata = true, bool ignoreCase = true);
		FormaPagamento AchaFPGIndice(string indice);
		void CarregaFormasPagamento();
		void LerTotaisFormaPagamento();
		void ProgramaFormaPagamento(string descricao, bool permiteVinculado, string posicao = "");

		#endregion Formas de Pagto

		#region Comprovantes Não Fiscal

        ComprovanteNaoFiscal AchaCNFDescricao(string descricao, bool buscaExata = true, bool ignoreCase = true);
		void CarregaComprovantesNaoFiscais();
		void LerTotaisComprovanteNaoFiscal();
		void ProgramaComprovanteNaoFiscal(string descricao, string tipo, string posicao = "");
        void AbreNaoFiscal(string cpfCnpj = "", string nome = "", string endereco = "");
        void RegistraItemNaoFiscal(string codCNF, decimal value, string obs = "");
		void SubtotalizaNaoFiscal(decimal descontoAcrescimo, string mensagemRodape = "");
        void EfetuaPagamentoNaoFiscal(string codFormaPagto, decimal valor, string observacao = "", bool imprimeVinculado = false);
        void FechaNaoFiscal(string observacao = "", int IndiceBMP = 0);
        void CancelaNaoFiscal();

		#endregion Comprovantes Não Fiscal

		#region Suprimento e Sangria

        void Suprimento(decimal valor, string obs, string DescricaoCNF = "SUPRIMENTO", string DescricaoFPG = "DINHEIRO", int indicebmp = 0);
		void Sangria(decimal valor, string obs, string DescricaoCNF = "SANGRIA", string DescricaoFPG = "DINHEIRO", int indicebmp = 0);

		#endregion Suprimento e Sangria

		#region Gaveta

        void AbreGaveta();

		#endregion Gaveta

		#region Programação

        void IdentificaPAF(string nomeVersao, string md5);

		#endregion Programação

		#endregion Methods
	}
}