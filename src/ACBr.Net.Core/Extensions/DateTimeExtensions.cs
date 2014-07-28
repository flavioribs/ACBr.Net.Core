using System;
using System.Linq;
using System.Management;
using System.Diagnostics;
using System.Collections.Generic;

namespace ACBr.Net.Core
{
    public static class DateTimeExtensions
    {
        public static int GetIdade(this DateTime dtNascimento)
        {
            int YearsAge = DateTime.Now.Year - dtNascimento.Year;

            if (DateTime.Now.Month < dtNascimento.Month ||
                (DateTime.Now.Month == dtNascimento.Month && DateTime.Now.Day < dtNascimento.Day))
            {
                YearsAge--;
            }

            return YearsAge;
        }

        public static string GetIdadeFull(this DateTime dtNascimento)
        {

            int idDias = 0, idMeses = 0, idAnos = 0;
            var dAtual = DateTime.Now;
            string ta = "", tm = "", td = "";
            
            if (dAtual < dtNascimento)
                return "Data de nascimento inválida ";

            if (dAtual.Day < dtNascimento.Day)
            {
                idDias = (DateTime.DaysInMonth(dAtual.Year, dAtual.Month - 1));

                idMeses = -1;
                if (idDias == 28 && dtNascimento.Day == 29)
                    idDias = 29;
            }

            if (dAtual.Month < dtNascimento.Month)
            {
                idMeses = idMeses + 12;
                idAnos = -1;
            }

            idDias = dAtual.Day - dtNascimento.Day + idDias;
            idMeses = dAtual.Month - dtNascimento.Month + idMeses;
            idAnos = dAtual.Year - dtNascimento.Year + idAnos;

            if (idAnos > 1)
                ta = idAnos + " anos ";
            else if (idAnos == 1)
                ta = idAnos + "ano";

            if (idMeses > 1)
                tm = idMeses + " meses ";
            else if (idMeses == 1)
                tm = idMeses + " mês ";

            if (idDias > 1)
                td = idDias + " dias ";
            else if (idDias == 1)
                td = idDias + " dia ";

            return ta + tm + td;

        }

        public static string CalcularFatorVencimento(this DateTime DataVencimento)
        {
            var dt = new DateTime(1997, 10, 07);
            return string.Format("{0:0000}", (DataVencimento - dt).TotalDays);
        }

		public static string ToJulianDate(this DateTime data)
		{
			return string.Format("{0:yy}{1:D3}", data, data.DayOfYear);
		}
    }
}
