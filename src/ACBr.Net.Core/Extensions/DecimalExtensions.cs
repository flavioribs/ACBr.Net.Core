using System;
using System.Collections.Generic;

namespace ACBr.Net.Core
{
	public static class DecimalExtensions
	{
		#region Fields

		private static readonly String[,] qualificadores = new String[,] {
                {"Centavo", "Centavos"},
                {"Real", "Reais"},
                {"e", "de"},
				{"Mil", "Mil"},
                {"Milhão", "Milhões"},
                {"Bilhão", "Bilhões"},
                {"Trilhão", "Trilhões"},
                {"Quatrilhão", "Quatrilhões"},
                {"Quintilhão", "Quintilhões"},
                {"Sextilhão", "Sextilhões"},
                {"Setilhão", "Setilhões"},
                {"Octilhão","Octilhões"},
                {"Nonilhão","Nonilhões"},
                {"Decilhão","Decilhões"}
		};

		private static readonly String[,] numeros = new String[,] {
                {"Zero", "Um", "Dois", "Três", "Quatro",
                 "Cinco", "Seis", "Sete", "Oito", "Nove",
                 "Dez","Onze", "Doze", "Treze", "Quatorze",
                 "Quinze", "Dezesseis", "Dezessete", "Dezoito", "Dezenove"},
                {"Vinte", "Trinta", "Quarenta", "Cinqüenta", "Sessenta",
                 "Setenta", "Oitenta", "Noventa",null,null,null,null,null,null,null,null,null,null,null,null},
                {"Cem", "Cento", "Duzentos", "Trezentos", "Quatrocentos", "Quinhentos", "Seiscentos",
                 "Setecentos", "Oitocentos", "Novecentos",null,null,null,null,null,null,null,null,null,null}
                };

		#endregion Fields
		
		#region Methods

        public static int DecimalPlacesCount(this decimal value)
        {
            return BitConverter.GetBytes(decimal.GetBits(value)[3])[2];
        }

		public static string ToCurrency(this decimal amount)
		{
			return ((decimal?)amount).ToCurrency();
		}

		public static string ToCurrency(this decimal? amount)
		{
			return (amount ?? 0).ToString("c2");
		}

		public static decimal InvertSignal(this decimal amount)
		{
			return (decimal)((decimal?)amount).InvertSignal();
		}

		public static decimal? InvertSignal(this decimal? amount)
		{
			return (amount ?? 0) * (-1);
		}

		public static string ToExtension(this decimal amount, bool invertersinal = false)
		{
			return ((decimal?)amount).ToExtension(invertersinal);
		}

		public static string ToExtension(this decimal? amount, bool invertersinal = false)
        {
            var valor = (amount ?? 0);

            if (valor == 0)
                return numeros[0, 0];

            if (valor < 0 && invertersinal)
                valor = valor.InvertSignal();
            else if (valor < 0)
                return "Valor Negativo";
            else if (valor >= 1000000000000000)
                return "Valor não suportado pelo sistema.";

            #region Function EscrevaParte

            var EscrevaParte = new Func<decimal, string>((valor1) =>
            {
                if (valor1 <= 0)
                    return string.Empty;

                string montagem = string.Empty;
                if (valor1 > 0 & valor1 < 1)
                {
                    valor1 *= 100;
                }

                string strValor1 = valor1.ToString("000");
                int a = Convert.ToInt32(strValor1.Substring(0, 1));
                int b = Convert.ToInt32(strValor1.Substring(1, 1));
                int c = Convert.ToInt32(strValor1.Substring(2, 1));

                if (a == 1) montagem += (b + c == 0) ? numeros[2, 0] : numeros[2, 1];
                else if (a == 2) montagem += numeros[2, 2];
                else if (a == 3) montagem += numeros[2, 3];
                else if (a == 4) montagem += numeros[2, 4];
                else if (a == 5) montagem += numeros[2, 5];
                else if (a == 6) montagem += numeros[2, 6];
                else if (a == 7) montagem += numeros[2, 7];
                else if (a == 8) montagem += numeros[2, 8];
                else if (a == 9) montagem += numeros[2, 9];

                if (b == 1)
                {
                    if (c == 0) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[0, 10];
                    else if (c == 1) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[0, 11];
                    else if (c == 2) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[0, 12];
                    else if (c == 3) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[0, 13];
                    else if (c == 4) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[0, 14];
                    else if (c == 5) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[0, 15];
                    else if (c == 6) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[0, 16];
                    else if (c == 7) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[0, 17];
                    else if (c == 8) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[0, 18];
                    else if (c == 9) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[0, 19];
                }
                else if (b == 2) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[1, 0];
                else if (b == 3) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[1, 1];
                else if (b == 4) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[1, 2];
                else if (b == 5) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[1, 3];
                else if (b == 6) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[1, 4];
                else if (b == 7) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[1, 5];
                else if (b == 8) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[1, 6];
                else if (b == 9) montagem += ((a > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty) + numeros[1, 7];

                if (strValor1.Substring(1, 1) != "1" & c != 0 & montagem != string.Empty)
                    montagem += string.Format(" {0} ", qualificadores[2, 0]);

                if (strValor1.Substring(1, 1) != "1")
                    if (c == 1) montagem += numeros[0, 1];
                    else if (c == 2) montagem += numeros[0, 2];
                    else if (c == 3) montagem += numeros[0, 3];
                    else if (c == 4) montagem += numeros[0, 4];
                    else if (c == 5) montagem += numeros[0, 5];
                    else if (c == 6) montagem += numeros[0, 6];
                    else if (c == 7) montagem += numeros[0, 7];
                    else if (c == 8) montagem += numeros[0, 8];
                    else if (c == 9) montagem += numeros[0, 9];

                return montagem;
            });

            #endregion Function EscrevaParte

            string strValor = valor.ToString("000000000000000.00");
            string valor_por_extenso = string.Empty;

            for (int i = 0; i <= 15; i += 3)
            {
                valor_por_extenso += EscrevaParte(Convert.ToDecimal(strValor.Substring(i, 3)));
                if (i == 0 & valor_por_extenso != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                        valor_por_extenso += string.Format(" {0} {1}", qualificadores[6, 0], ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty));
                    else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                        valor_por_extenso += string.Format(" {0} {1}", qualificadores[6, 1], ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty));
                }
                else if (i == 3 & valor_por_extenso != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                        valor_por_extenso += string.Format(" {0} {1}", qualificadores[5, 0], ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty));
                    else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                        valor_por_extenso += string.Format(" {0} {1}", qualificadores[5, 1], ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty));
                }
                else if (i == 6 & valor_por_extenso != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                        valor_por_extenso += string.Format(" {0} {1}", qualificadores[4, 0], ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty));
                    else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                        valor_por_extenso += string.Format(" {0} {1}", qualificadores[4, 1], ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty));
                }
                else if (i == 9 & valor_por_extenso != string.Empty)
                    if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                        valor_por_extenso += string.Format(" {0} {1}", qualificadores[3, 0], ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? string.Format(" {0} ", qualificadores[2, 0]) : string.Empty));

                if (i == 12)
                {
                    if (valor_por_extenso.Length > 8)
                        if (valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == qualificadores[4, 1] |
                            valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == qualificadores[5, 1])
                            valor_por_extenso += string.Format(" {0}", qualificadores[2, 1]);
                        else
                            if (valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == qualificadores[4, 1] |
                                valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == qualificadores[5, 1] |
                                valor_por_extenso.Substring(valor_por_extenso.Length - 8, 7) == qualificadores[6, 1])
                                valor_por_extenso += string.Format(" {0}", qualificadores[2, 1]);
                            else
                                if (valor_por_extenso.Substring(valor_por_extenso.Length - 8, 8) == qualificadores[6, 1])
                                    valor_por_extenso += string.Format(" {0}", qualificadores[2, 1]);

                    if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                        valor_por_extenso += string.Format(" {0}", qualificadores[1, 0]);
                    else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                        valor_por_extenso += string.Format(" {0}", qualificadores[1, 1]);

                    if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valor_por_extenso != string.Empty)
                        valor_por_extenso += string.Format(" {0} ", qualificadores[2, 0]);
                }

                if (i == 15)
                    if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                        valor_por_extenso += string.Format(" {0}", qualificadores[0, 0]);
                    else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                        valor_por_extenso += string.Format(" {0}", qualificadores[0, 1]);
            }

            return valor_por_extenso;
        }

        public static string ToRemessaString(this decimal ammount, int zerofill = 13)
        {
            return Math.Round(ammount * 100).ToString().ZeroFill(zerofill);
        }

		#endregion Methods
	}
}
