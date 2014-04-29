namespace ACBr.Net.Core.ECF
{
	public sealed class Aliquota
	{
		#region Properties

		public int Sequencia { get; internal set; }
		public string Indice { get; internal set; }
		public decimal ValorAliquota {	get; internal set;	}
		public string Tipo { get; internal set; }
		public decimal Total { get;	internal set; }

		#endregion Properties
	}
}