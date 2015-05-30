using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ACBr.Net.Core.Extensions
{
    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">Erro ao criptografar a string</exception>
        /// <exception cref="Exception">Erro ao criptografar string</exception>
        public static string Encrypt(this string data, string key)
        {
            try
            {
                var des = new TripleDESCryptoServiceProvider()
                {
                    Mode = CipherMode.ECB,
                    Key = Encoding.ASCII.GetBytes(key),
                    Padding = PaddingMode.PKCS7
                };

                using (var desEncrypt = des.CreateEncryptor())
                {
                    var buffer = Encoding.ASCII.GetBytes(data);
                    return Convert.ToBase64String(desEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao criptografar a string", ex);
            }
        }

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">Erro ao descriptografar string</exception>
        /// <exception cref="Exception">Erro ao descriptografar string</exception>
        public static string Decrypt(this string data, string key)
        {
            try
            {
                var des = new TripleDESCryptoServiceProvider()
                {
                    Mode = CipherMode.ECB,
                    Key = Encoding.ASCII.GetBytes(key),
                    Padding = PaddingMode.PKCS7
                };

                using (var desEncrypt = des.CreateDecryptor())
                {
                    var buffer = Convert.FromBase64String(data.Replace(" ", "+"));
                    return Encoding.UTF8.GetString(desEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao descriptografar string", ex);
            }
        }

        /// <summary>
        /// To the m d5 hash.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">Erro ao gerar hash MD5</exception>
        /// <exception cref="Exception">Erro ao gerar hash MD5</exception>
        public static string ToMd5Hash(this string input)
        {
            try
            {
                // Primeiro passo, calcular o MD5 hash a partir da string
                var md5 = MD5.Create();
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hash = md5.ComputeHash(inputBytes);

                // Segundo passo, converter o array de bytes em uma string hexadecimal
                var sb = new StringBuilder();
                for (var i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar hash MD5", ex);
            }
        }

        /// <summary>
        /// To the sh a1 hash.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">Erro ao gerar SHA1 hash</exception>
        /// <exception cref="Exception">Erro ao gerar SHA1 hash</exception>
        public static string ToSha1Hash(this string input)
        {
            try
            {
                SHA1 sha = new SHA1CryptoServiceProvider();
                var data = Encoding.ASCII.GetBytes(input);
                var hash = sha.ComputeHash(data);

                var sb = new StringBuilder();
                for (var i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar SHA1 hash", ex);
            }
        }

        /// <summary>
        /// Strings the reverse.
        /// </summary>
        /// <param name="toReverse">To reverse.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">Erro ao reverter string</exception>
        /// <exception cref="Exception">Erro ao reverter string</exception>
        public static string StringReverse(this string toReverse)
        {
            try
            {
                Array arr = toReverse.ToCharArray();
                Array.Reverse(arr);// reverse the string
                var c = (char[])arr;
                var b = Encoding.Default.GetBytes(c);
                return Encoding.Default.GetString(b);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao reverter string", ex);
            }
        }

        /// <summary>
        /// Formatars the specified valor.
        /// </summary>
        /// <param name="valor">The valor.</param>
        /// <param name="mascara">The mascara.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">Erro ao formatar string</exception>
        /// <exception cref="Exception">Erro ao formatar string</exception>
        public static string Formatar(this string valor, string mascara)
        {
            try
            {
                var dado = new StringBuilder();

                // remove caracteres nao numericos
                foreach (var c in valor)
                {
                    if (char.IsNumber(c))
                        dado.Append(c);
                }

                var indMascara = mascara.Length;
                var indCampo = dado.Length;

                for (; indCampo > 0 && indMascara > 0; )
                {
                    if (mascara[--indMascara] == '#')
                        indCampo--;
                }

                var saida = new StringBuilder();
                for (; indMascara < mascara.Length; indMascara++)
                    saida.Append((mascara[indMascara] == '#') ? dado[indCampo++] : mascara[indMascara]);

                return saida.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao formatar string", ex);
            }
        }

        /// <summary>
        /// To the double.
        /// </summary>
        /// <param name="dados">The dados.</param>
        /// <param name="def">The definition.</param>
        /// <returns>System.Double.</returns>
        /// <exception cref="System.Exception">Erro ao converter string</exception>
        /// <exception cref="Exception">Erro ao converter string</exception>
        public static double ToDouble(this string dados, double def = -1)
        {
            try
            {
                double converted;
                if (!double.TryParse(dados, NumberStyles.Any,
                                             CultureInfo.CurrentCulture, 
                                             out converted))
                    converted = def;

                return converted;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao converter string", ex);
            }
        }

        /// <summary>
        /// To the decimal.
        /// </summary>
        /// <param name="dados">The dados.</param>
        /// <param name="def">The definition.</param>
        /// <returns>System.Decimal.</returns>
        /// <exception cref="System.Exception">Erro ao converter string</exception>
        /// <exception cref="Exception">Erro ao converter string</exception>
        public static decimal ToDecimal(this string dados, decimal def = -1)
        {
            try
            {
                decimal converted;
                if (!decimal.TryParse(dados, NumberStyles.Any,
                                             CultureInfo.CurrentCulture,
                                             out converted))
                    converted = def;

                return converted;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao converter string", ex);
            }
        }

        /// <summary>
        /// To the int32.
        /// </summary>
        /// <param name="dados">The dados.</param>
        /// <param name="def">The definition.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.Exception">Erro ao converter string</exception>
        /// <exception cref="Exception">Erro ao converter string</exception>
        public static int ToInt32(this string dados, int def = -1)
        {
            try
            {
                int converted;
                if (!int.TryParse(dados, NumberStyles.Any,
                                         CultureInfo.CurrentCulture, 
                                         out converted))
                    converted = def;

                return converted;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao converter string", ex);
            }
        }

        /// <summary>
        /// To the int64.
        /// </summary>
        /// <param name="dados">The dados.</param>
        /// <param name="def">The definition.</param>
        /// <returns>Int64.</returns>
        /// <exception cref="System.Exception">Erro ao converter string</exception>
        /// <exception cref="Exception">Erro ao converter string</exception>
        public static long ToInt64(this string dados, long def = -1)
        {
            try
            {
                long converted;
                if (!long.TryParse(dados, NumberStyles.Any,
                                         CultureInfo.CurrentCulture,
                                         out converted))
                    converted = def;

                return converted;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao converter string", ex);
            }
        }

        /// <summary>
        /// To the data.
        /// </summary>
        /// <param name="dados">The dados.</param>
        /// <returns>DateTime.</returns>
        /// <exception cref="System.Exception">Erro ao converter string</exception>
        /// <exception cref="Exception">Erro ao converter string</exception>
        public static DateTime ToData(this string dados)
        {
            try
            {
                DateTime converted;
                if (!DateTime.TryParse(dados, out converted))
                    converted = default(DateTime);

                return converted;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao converter string", ex);
            }
        }

        /// <summary>
        /// Retorna apenas os numeros da string.
        /// </summary>
        /// <param name="toNormalize">String para processar.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">Erro ao processar a string</exception>
        /// <exception cref="Exception">Erro ao processar a string</exception>
        public static string OnlyNumbers(this string toNormalize)
        {
            try
            {
                if (toNormalize == null)
                    return string.Empty;

                var toReturn = Regex.Replace(toNormalize, "[^0-9]", string.Empty);
                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar a string", ex);
            }
        }

        /// <summary>
        /// Determines whether the specified cep is cep.
        /// </summary>
        /// <param name="cep">The cep.</param>
        /// <returns><c>true</c> if the specified cep is cep; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.Exception">Erro ao validar CEP</exception>
        /// <exception cref="Exception">Erro ao validar CEP</exception>
        public static bool IsCep(this string cep)
        {
            try
            {
                cep = cep.OnlyNumbers();

                if (cep.Length == 8)
                    cep = string.Format("{0}-{1}", cep.Substring(0, 5), cep.Substring(5, 3));

                return Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}"));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar CEP", ex);
            }
        }

        /// <summary>
        /// Checar se a string È um [CPF ou CNPJ] v·lido.
        /// </summary>
        /// <param name="cpfcnpj">CPFCNPJ</param>
        /// <returns><c>true</c> se o [CPF ou CNPJ] È v·lido; sen„o, <c>false</c>.</returns>
        public static bool IsCPFOrCNPJ(this string cpfcnpj)
        {
            var value = cpfcnpj.OnlyNumbers();
            if (value.Length == 11)
                return value.IsCPF();
            else if (value.Length == 14)
                return value.IsCNPJ();
            else
                return false;
        }

        /// <summary>
        /// Checa se a string È um CPF v·lido.
        /// </summary>
        /// <param name="vrCPF">CPF</param>
        /// <returns><c>true</c> se o CPF for v·lido; sen„o, <c>false</c>.</returns>
        /// <exception cref="System.Exception">Erro ao validar CPF</exception>
        /// <exception cref="Exception">Erro ao validar CPF</exception>
        public static bool IsCPF(this string vrCPF)
        {
            try
            {
                var cpf = vrCPF.OnlyNumbers();
                if (cpf.Length != 11)
                    return false;
                    
                if (new string(cpf[0], cpf.Length) == cpf || 
                    cpf == "12345678909")
                    return false;

                var numeros = new int[11];
                for (var i = 0; i < 11; i++)
                    numeros[i] = int.Parse(cpf[i].ToString());

                var soma = 0;
                for (var i = 0; i < 9; i++)
                    soma += (10 - i) * numeros[i];

                var resultado = soma % 11;
                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[9] != 0)
                        return false;
                }
                else if (numeros[9] != 11 - resultado)
                    return false;

                soma = 0;
                for (var i = 0; i < 10; i++)
                    soma += (11 - i) * numeros[i];

                resultado = soma % 11;
                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[10] != 0)
                        return false;
                }
                else if (numeros[10] != 11 - resultado)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar CPF", ex);
            }
        }

        /// <summary>
        /// Checa se a string È um CNPJ v·lido.
        /// </summary>
        /// <param name="vrCNPJ">CNPJ.</param>
        /// <returns><c>true</c> se o CNPJ for v·lido; sen„o, <c>false</c>.</returns>
        /// <exception cref="System.Exception">Erro ao validar CNPJ</exception>
        /// <exception cref="Exception">Erro ao validar CNPJ</exception>
        public static bool IsCNPJ(this string vrCNPJ)
        {
            try
            {
                var cnpj = vrCNPJ.OnlyNumbers();
                if (cnpj.Length != 14)
                    return false;

                if (new string(cnpj[0], cnpj.Length) == cnpj) 
                    return false;

                var resultado = new int[2];
                int nrDig;
                const string ftmt = "6543298765432";
                var cnpjOk = new bool[2];
                var digitos = new int[14];
                var soma = new int[2];
                soma[0] = 0;
                soma[1] = 0;
                resultado[0] = 0;
                resultado[1] = 0;
                cnpjOk[0] = false;
                cnpjOk[1] = false;

                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(cnpj.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));
                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        cnpjOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else
                        cnpjOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                }

                return (cnpjOk[0] && cnpjOk[1]);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar CNPJ", ex);
            }
        }

        /// <summary>
        /// Determines whether the specified p inscr is ie.
        /// </summary>
        /// <param name="pInscr">The p inscr.</param>
        /// <param name="pUF">The p uf.</param>
        /// <returns><c>true</c> if the specified p inscr is ie; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.Exception">Erro ao IE</exception>
        /// <exception cref="Exception">Erro ao IE</exception>
        public static bool IsIe(this string pInscr, string pUF)
        {
            try
            {
                var retorno = false;
                var strBase = "";
                string strBase2;
                var strOrigem = "";
                string strDigito1;
                string strDigito2;
                int intPos;
                int intValor;
                var intSoma = 0;
                int intResto;
                int intNumero;
                var intPeso = 0;

                if ((pInscr.Trim().ToUpper() == "ISENTO"))
                    return true;

                for (intPos = 1; intPos <= pInscr.Trim().Length; intPos++)
                {
                    if ((("0123456789P".IndexOf(pInscr.Substring((intPos - 1), 1), 0, StringComparison.OrdinalIgnoreCase) + 1) > 0))
                        strOrigem = (strOrigem + pInscr.Substring((intPos - 1), 1));
                }

                switch (pUF.ToUpper())
                {
                    case "AC":
                        #region AC

                        strBase = (strOrigem.Trim() + "00000000000").Substring(0, 11);

                        if (strBase.Substring(0, 2) == "01")
                        {
                            intSoma = 0;
                            intPeso = 4;

                            for (intPos = 1; (intPos <= 11); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                if (intPeso == 1) intPeso = 9;

                                intSoma += intValor * intPeso;

                                intPeso--;
                            }

                            intResto = (intSoma % 11);
                            strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                            intSoma = 0;
                            strBase = (strOrigem.Trim() + "000000000000").Substring(0, 12);
                            intPeso = 5;

                            for (intPos = 1; (intPos <= 12); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                if (intPeso == 1) intPeso = 9;

                                intSoma += intValor * intPeso;
                                intPeso--;
                            }

                            intResto = (intSoma % 11);
                            strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                            strBase2 = (strBase.Substring(0, 12) + strDigito2);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }
                        #endregion
                        break;

                    case "AL":
                        #region AL

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                        if ((strBase.Substring(0, 2) == "24"))
                        {
                            //24000004-8
                            //98765432
                            intSoma = 0;
                            intPeso = 9;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                intSoma += intValor * intPeso;
                                intPeso--;
                            }

                            intSoma = (intSoma * 10);
                            intResto = (intSoma % 11);

                            strDigito1 = ((intResto == 10) ? "0" : Convert.ToString(intResto)).Substring((((intResto == 10) ? "0" : Convert.ToString(intResto)).Length - 1));

                            strBase2 = (strBase.Substring(0, 8) + strDigito1);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                        break;

                    case "AM":
                        #region AM
                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                        intSoma = 0;
                        intPeso = 9;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intSoma += intValor * intPeso;
                            intPeso--;
                        }

                        intResto = (intSoma % 11);

                        if (intSoma < 11)
                            strDigito1 = (11 - intSoma).ToString();
                        else
                            strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                        #endregion
                        break;

                    case "AP":
                        #region AP

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                        intPeso = 9;

                        if ((strBase.Substring(0, 2) == "03"))
                        {
                            strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                            intSoma = 0;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                intSoma += intValor * intPeso;
                                intPeso--;
                            }

                            intResto = (intSoma % 11);
                            intValor = (11 - intResto);

                            strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));

                            strBase2 = (strBase.Substring(0, 8) + strDigito1);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                        break;

                    case "BA":
                        #region BA

                        if (strOrigem.Length == 8)
                            strBase = (strOrigem.Trim() + "00000000").Substring(0, 8);
                        else if (strOrigem.Length == 9)
                            strBase = (strOrigem.Trim() + "00000000").Substring(0, 9);

                        if ((("0123458".IndexOf(strBase.Substring(0, 1), 0, StringComparison.OrdinalIgnoreCase) + 1) > 0) && strBase.Length == 8)
                        {
                            #region

                            intSoma = 0;

                            for (intPos = 1; (intPos <= 6); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                if (intPos == 1) intPeso = 7;

                                intSoma += intValor * intPeso;
                                intPeso--;
                            }


                            intResto = (intSoma % 10);
                            strDigito2 = ((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Length - 1));


                            strBase2 = strBase.Substring(0, 7) + strDigito2;

                            if (strBase2 == strOrigem)
                                retorno = true;

                            if (retorno)
                            {
                                intSoma = 0;
                                intPeso = 0;

                                for (intPos = 1; (intPos <= 7); intPos++)
                                {
                                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                    if (intPos == 7)
                                        intValor = int.Parse(strBase.Substring((intPos), 1));

                                    if (intPos == 1) intPeso = 8;

                                    intSoma += intValor * intPeso;
                                    intPeso--;
                                }


                                intResto = (intSoma % 10);
                                strDigito1 = ((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Length - 1));

                                strBase2 = (strBase.Substring(0, 6) + strDigito1 + strDigito2);

                                if ((strBase2 == strOrigem))
                                    retorno = true;
                            }

                            #endregion
                        }
                        else if ((("679".IndexOf(strBase.Substring(0, 1), 0, StringComparison.OrdinalIgnoreCase) + 1) > 0) && strBase.Length == 8)
                        {
                            #region

                            intSoma = 0;

                            for (intPos = 1; (intPos <= 6); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                if (intPos == 1) intPeso = 7;

                                intSoma += intValor * intPeso;
                                intPeso--;
                            }


                            intResto = (intSoma % 11);
                            strDigito2 = ((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Length - 1));


                            strBase2 = strBase.Substring(0, 7) + strDigito2;

                            if (strBase2 == strOrigem)
                                retorno = true;

                            if (retorno)
                            {
                                intSoma = 0;
                                intPeso = 0;

                                for (intPos = 1; (intPos <= 7); intPos++)
                                {
                                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                    if (intPos == 7)
                                        intValor = int.Parse(strBase.Substring((intPos), 1));

                                    if (intPos == 1) intPeso = 8;

                                    intSoma += intValor * intPeso;
                                    intPeso--;
                                }


                                intResto = (intSoma % 11);
                                strDigito1 = ((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                                strBase2 = (strBase.Substring(0, 6) + strDigito1 + strDigito2);

                                if ((strBase2 == strOrigem))
                                    retorno = true;
                            }

                            #endregion
                        }
                        else if ((("0123458".IndexOf(strBase.Substring(1, 1), 0, StringComparison.OrdinalIgnoreCase) + 1) > 0) && strBase.Length == 9)
                        {
                            #region
                            /* Segundo digito */
                            //1000003
                            //8765432
                            intSoma = 0;


                            for (intPos = 1; (intPos <= 7); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                if (intPos == 1) intPeso = 8;

                                intSoma += intValor * intPeso;
                                intPeso--;
                            }

                            intResto = (intSoma % 10);
                            strDigito2 = ((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Length - 1));

                            strBase2 = strBase.Substring(0, 8) + strDigito2;

                            if (strBase2 == strOrigem)
                                retorno = true;

                            if (retorno)
                            {
                                //1000003 6
                                //9876543 2
                                intSoma = 0;
                                intPeso = 0;

                                for (intPos = 1; (intPos <= 8); intPos++)
                                {
                                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                    if (intPos == 8)
                                        intValor = int.Parse(strBase.Substring((intPos), 1));

                                    if (intPos == 1) intPeso = 9;

                                    intSoma += intValor * intPeso;
                                    intPeso--;
                                }


                                intResto = (intSoma % 10);
                                strDigito1 = ((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                                strBase2 = (strBase.Substring(0, 7) + strDigito1 + strDigito2);

                                if ((strBase2 == strOrigem))
                                    retorno = true;
                            }

                            #endregion
                        }

                        #endregion
                        break;

                    case "CE":
                        #region CE

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        intValor = (11 - intResto);

                        if ((intValor > 9))
                            intValor = 0;

                        strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;

                        #endregion
                        break;

                    case "DF":
                        #region DF

                        strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);

                        if ((strBase.Substring(0, 3) == "073"))
                        {
                            intSoma = 0;
                            intPeso = 2;

                            for (intPos = 11; (intPos >= 1); intPos = (intPos + -1))
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * intPeso);
                                intSoma = (intSoma + intValor);
                                intPeso = (intPeso + 1);

                                if ((intPeso > 9))
                                    intPeso = 2;
                            }

                            intResto = (intSoma % 11);
                            strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                            strBase2 = (strBase.Substring(0, 11) + strDigito1);
                            intSoma = 0;
                            intPeso = 2;

                            for (intPos = 12; (intPos >= 1); intPos = (intPos + -1))
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * intPeso);
                                intSoma = (intSoma + intValor);
                                intPeso = (intPeso + 1);

                                if ((intPeso > 9))
                                    intPeso = 2;
                            }

                            intResto = (intSoma % 11);
                            strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                            strBase2 = (strBase.Substring(0, 12) + strDigito2);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                        break;

                    case "ES":
                        #region ES

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;

                        #endregion
                        break;

                    case "GO":
                        #region GO

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                        if ((("10,11,15".IndexOf(strBase.Substring(0, 2), 0, StringComparison.OrdinalIgnoreCase) + 1) > 0))
                        {
                            intSoma = 0;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * (10 - intPos));
                                intSoma = (intSoma + intValor);
                            }

                            intResto = (intSoma % 11);

                            if ((intResto == 0))
                                strDigito1 = "0";
                            else if ((intResto == 1))
                            {
                                intNumero = int.Parse(strBase.Substring(0, 8));
                                strDigito1 = (((intNumero >= 10103105) && (intNumero <= 10119997)) ? "1" : "0").Substring(((((intNumero >= 10103105) && (intNumero <= 10119997)) ? "1" : "0").Length - 1));
                            }
                            else
                                strDigito1 = Convert.ToString((11 - intResto)).Substring((Convert.ToString((11 - intResto)).Length - 1));

                            strBase2 = (strBase.Substring(0, 8) + strDigito1);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                        break;

                    case "MA":
                        #region MA

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                        if ((strBase.Substring(0, 2) == "12"))
                        {
                            intSoma = 0;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * (10 - intPos));
                                intSoma = (intSoma + intValor);
                            }

                            intResto = (intSoma % 11);
                            strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                            strBase2 = (strBase.Substring(0, 8) + strDigito1);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                        break;

                    case "MT":
                        #region MT

                        strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 10; intPos >= 1; intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 9))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 10) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;

                        #endregion
                        break;
                    case "MS":
                        #region MS

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                        if ((strBase.Substring(0, 2) == "28"))
                        {
                            intSoma = 0;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * (10 - intPos));
                                intSoma = (intSoma + intValor);
                            }

                            intResto = (intSoma % 11);
                            strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                            strBase2 = (strBase.Substring(0, 8) + strDigito1);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                        break;

                    case "MG":
                        #region MG

                        strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);
                        strBase2 = (strBase.Substring(0, 3) + ("0" + strBase.Substring(3, 8)));
                        intNumero = 2;

                        var strSoma = "";

                        for (intPos = 1; (intPos <= 12); intPos++)
                        {
                            intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                            intNumero = ((intNumero == 2) ? 1 : 2);
                            intValor = (intValor * intNumero);

                            intSoma = (intSoma + intValor);
                            strSoma += intValor.ToString();
                        }

                        intSoma = 0;

                        //Soma -se os algarismos, n„o o produto
                        for (var i = 0; i < strSoma.Length; i++)
                        {
                            intSoma += int.Parse(strSoma.Substring(i, 1));
                        }

                        intValor = int.Parse(strBase.Substring(8, 2));
                        strDigito1 = (intValor - intSoma).ToString();

                        strBase2 = (strBase.Substring(0, 11) + strDigito1);

                        if ((strBase2 == strOrigem.Substring(0, 12)))
                            retorno = true;

                        if (retorno)
                        {
                            intSoma = 0;
                            intPeso = 3;

                            for (intPos = 1; (intPos <= 12); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                if (intPeso < 2)
                                    intPeso = 11;

                                intSoma += (intValor * intPeso);
                                intPeso--;
                            }

                            intResto = (intSoma % 11);
                            intValor = 11 - intResto;
                            strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                            strBase2 = (strBase.Substring(0, 12) + strDigito2);

                            if (strBase2 == strOrigem)
                                retorno = true;
                        }

                        #endregion
                        break;

                    case "PA":
                        #region PA

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                        if ((strBase.Substring(0, 2) == "15"))
                        {
                            intSoma = 0;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * (10 - intPos));
                                intSoma = (intSoma + intValor);
                            }

                            intResto = (intSoma % 11);
                            strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                            strBase2 = (strBase.Substring(0, 8) + strDigito1);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                        break;

                    case "PB":
                        #region PB

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        intValor = (11 - intResto);

                        if ((intValor > 9))
                            intValor = 0;

                        strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;

                        #endregion
                        break;

                    case "PE":
                        #region PE

                        strBase = (strOrigem.Trim() + "00000000000000").Substring(0, 14);
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 7; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 9))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        intValor = (11 - intResto);

                        if ((intValor > 9))
                            intValor = (intValor - 10);

                        strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                        strBase2 = (strBase.Substring(0, 7) + strDigito1);

                        if ((strBase2 == strOrigem.Substring(0, 8)))
                            retorno = true;

                        if (retorno)
                        {
                            intSoma = 0;
                            intPeso = 2;

                            for (intPos = 8; (intPos >= 1); intPos = (intPos + -1))
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * intPeso);
                                intSoma = (intSoma + intValor);
                                intPeso = (intPeso + 1);

                                if ((intPeso > 9))
                                    intPeso = 2;
                            }

                            intResto = (intSoma % 11);
                            intValor = (11 - intResto);

                            if ((intValor > 9))
                                intValor = (intValor - 10);

                            strDigito2 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                            strBase2 = (strBase.Substring(0, 8) + strDigito2);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                        break;

                    case "PI":
                        #region PI

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;

                        #endregion
                        break;

                    case "PR":
                        #region PR

                        strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 8; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 7))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 9; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 7))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase2 + strDigito2);

                        if ((strBase2 == strOrigem))
                            retorno = true;

                        #endregion
                        break;

                    case "RJ":
                        #region RJ

                        strBase = (strOrigem.Trim() + "00000000").Substring(0, 8);
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 7; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 7))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 7) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;

                        #endregion
                        break;

                    case "RN": //Verficar com 10 digitos
                        #region RN

                        if (strOrigem.Length == 9)
                            strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                        else if (strOrigem.Length == 10)
                            strBase = (strOrigem.Trim() + "000000000").Substring(0, 10);

                        if ((strBase.Substring(0, 2) == "20") && strBase.Length == 9)
                        {
                            intSoma = 0;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * (10 - intPos));
                                intSoma = (intSoma + intValor);
                            }

                            intSoma = (intSoma * 10);
                            intResto = (intSoma % 11);
                            strDigito1 = ((intResto > 9) ? "0" : Convert.ToString(intResto)).Substring((((intResto > 9) ? "0" : Convert.ToString(intResto)).Length - 1));
                            strBase2 = (strBase.Substring(0, 8) + strDigito1);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }
                        else if (strBase.Length == 10)
                        {
                            intSoma = 0;

                            for (intPos = 1; (intPos <= 9); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * (11 - intPos));
                                intSoma = (intSoma + intValor);
                            }

                            intSoma = (intSoma * 10);
                            intResto = (intSoma % 11);
                            strDigito1 = ((intResto > 10) ? "0" : Convert.ToString(intResto)).Substring((((intResto > 10) ? "0" : Convert.ToString(intResto)).Length - 1));
                            strBase2 = (strBase.Substring(0, 9) + strDigito1);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion

                        break;

                    case "RO":
                        #region RO

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                        strBase2 = strBase.Substring(3, 5);
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 5); intPos++)
                        {
                            intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                            intValor = (intValor * (7 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        intValor = (11 - intResto);

                        if ((intValor > 9))
                            intValor = (intValor - 10);

                        strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;

                        #endregion RO
                        break;

                    case "RR":
                        #region RR

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                        if ((strBase.Substring(0, 2) == "24"))
                        {
                            intSoma = 0;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = intValor * intPos;
                                intSoma += intValor;
                            }

                            intResto = (intSoma % 9);
                            strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                            strBase2 = (strBase.Substring(0, 8) + strDigito1);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                        break;

                    case "RS":
                        #region RS

                        strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);
                        intNumero = int.Parse(strBase.Substring(0, 3));

                        if (((intNumero > 0) && (intNumero < 468)))
                        {
                            intSoma = 0;
                            intPeso = 2;

                            for (intPos = 9; (intPos >= 1); intPos = (intPos + -1))
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * intPeso);
                                intSoma = (intSoma + intValor);
                                intPeso = (intPeso + 1);

                                if ((intPeso > 9))
                                    intPeso = 2;
                            }

                            intResto = (intSoma % 11);
                            intValor = (11 - intResto);

                            if ((intValor > 9))
                                intValor = 0;

                            strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                            strBase2 = (strBase.Substring(0, 9) + strDigito1);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                        break;

                    case "SC":
                        #region SC

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                        #endregion
                        break;

                    case "SE":
                        #region SE

                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        intValor = (11 - intResto);

                        if ((intValor > 9))
                            intValor = 0;

                        strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;

                        #endregion
                        break;

                    case "SP":
                        #region SP

                        if ((strOrigem.Substring(0, 1) == "P"))
                        {
                            strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);
                            strBase2 = strBase.Substring(1, 8);
                            intSoma = 0;
                            intPeso = 1;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos), 1));
                                intValor = (intValor * intPeso);
                                intSoma = (intSoma + intValor);
                                intPeso = (intPeso + 1);

                                if ((intPeso == 2))
                                    intPeso = 3;

                                if ((intPeso == 9))
                                    intPeso = 10;
                            }

                            intResto = (intSoma % 11);
                            strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                            strBase2 = (strBase.Substring(0, 9) + (strDigito1 + strBase.Substring(10, 3)));
                        }
                        else
                        {
                            strBase = (strOrigem.Trim() + "000000000000").Substring(0, 12);
                            intSoma = 0;
                            intPeso = 1;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * intPeso);
                                intSoma = (intSoma + intValor);
                                intPeso = (intPeso + 1);

                                if ((intPeso == 2))
                                    intPeso = 3;

                                if ((intPeso == 9))
                                    intPeso = 10;
                            }

                            intResto = (intSoma % 11);
                            strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                            strBase2 = (strBase.Substring(0, 8) + (strDigito1 + strBase.Substring(9, 2)));
                            intSoma = 0;
                            intPeso = 2;

                            for (intPos = 11; (intPos >= 1); intPos = (intPos + -1))
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                                intValor = (intValor * intPeso);
                                intSoma = (intSoma + intValor);
                                intPeso = (intPeso + 1);

                                if ((intPeso > 10))
                                    intPeso = 2;
                            }

                            intResto = (intSoma % 11);
                            strDigito2 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                            strBase2 = (strBase2 + strDigito2);
                        }

                        if ((strBase2 == strOrigem))
                            retorno = true;

                        #endregion
                        break;

                    case "TO":
                        #region TO

                        strBase = (strOrigem.Trim() + "00000000000").Substring(0, 11);

                        if ((("01,02,03,99".IndexOf(strBase.Substring(2, 2), 0, StringComparison.OrdinalIgnoreCase) + 1) > 0))
                        {
                            strBase2 = (strBase.Substring(0, 2) + strBase.Substring(4, 6));
                            intSoma = 0;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                                intValor = (intValor * (10 - intPos));
                                intSoma = (intSoma + intValor);
                            }

                            intResto = (intSoma % 11);
                            strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                            strBase2 = (strBase.Substring(0, 10) + strDigito1);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                        break;

                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao IE", ex);
            }
        }

        /// <summary>
        /// Determines whether the specified pis is pis.
        /// </summary>
        /// <param name="pis">The pis.</param>
        /// <returns><c>true</c> if the specified pis is pis; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.Exception">Erro ao validar PIS</exception>
        /// <exception cref="Exception">Erro ao validar PIS</exception>
        public static bool IsPIS(this string pis)
        {
            try
            {
                var multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                var soma = 0;
                int resto;

                if (pis.Trim().Length == 0)
                    return false;

                pis = pis.Trim();
                pis = pis.Replace("-", string.Empty).Replace(".", string.Empty).PadLeft(11, '0');
                for (var i = 0; i < 10; i++)
                    soma += int.Parse(pis[i].ToString()) * multiplicador[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                return pis.EndsWith(resto.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar PIS", ex);
            }
        }

        /// <summary>
        /// Determines whether the specified email is email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns><c>true</c> if the specified email is email; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.Exception">Erro ao validar Email</exception>
        /// <exception cref="Exception">Erro ao validar Email</exception>
        public static bool IsEmail(this string email)
        {
            try
            {
                var emailRegex = @"^(([^<>()[\]\\.,;·‡„‚‰ÈËÍÎÌÏÓÔÛÚıÙˆ˙˘˚¸Á:\s@\""]+"
                                  + @"(\.[^<>()[\]\\.,;·‡„‚‰ÈËÍÎÌÏÓÔÛÚıÙˆ˙˘˚¸Á:\s@\""]+)*)|(\"".+\""))@"
                                  + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|"
                                  + @"(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";

                // Inst‚ncia da classe Regex, passando como
                // argumento sua Express„o Regular
                var rx = new Regex(emailRegex);

                // MÈtodo IsMatch da classe Regex que retorna
                // verdadeiro caso o e-mail passado estiver
                // dentro das regras da sua regex.
                return rx.IsMatch(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar Email", ex);
            }
        }

        /// <summary>
        /// Determines whether the specified site is site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns><c>true</c> if the specified site is site; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.Exception">Erro ao validar endereÁo web</exception>
        /// <exception cref="Exception">Erro ao validar endereÁo web</exception>
        public static bool IsSite(this string site)
        {
            try
            {
                //string siteRegex = @"/^http:\/\/www\.[a-z]+\.(com)|(edu)|(net)$/";
                const string siteRegex = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";

                var rx = new Regex(siteRegex);
                return rx.IsMatch(site);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar endereÁo web", ex);
            }
        }

        /// <summary>
        /// Verifica se a string È numerica.
        /// </summary>
        /// <param name="strNum">The string number.</param>
        /// <returns>Retorna true/false se a string È numerica</returns>
        /// <exception cref="System.Exception">Erro ao validar string</exception>
        /// <exception cref="Exception">Erro ao validar string</exception>
        public static bool IsNumeric(this string strNum)
        {
            try
            {
                var reNum = new Regex(@"^\d+$");
                return reNum.IsMatch(strNum);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar string", ex);
            }
        }

        /// <summary>
        /// Converte a string para UTF8.
        /// </summary>
        /// <param name="value">The text.</param>
        /// <returns>Uma string com a codificaÁ„o UTF8</returns>
        /// <exception cref="System.Exception">Erro ao codificar string</exception>
        /// <exception cref="Exception">Erro ao codificar string</exception>
        public static string ToUtf8(this string value)
		{
		    if (value == null)
		        return string.Empty;

            try
            {
                var bytes = Encoding.Default.GetBytes(value);
                return Encoding.UTF8.GetString(bytes);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao codificar string", ex);
            }
        }

        /// <summary>
        /// To the XML string.
        /// </summary>
        /// <param name="value">The text.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">Erro ao codificar string</exception>
	    public static string ToXmlString(this string value)
	    {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return string.Empty; 

                var bytes = Encoding.Default.GetBytes(value);
                var text = RemoveCe(Encoding.UTF8.GetString(bytes));

                var textOut = new StringBuilder();
                foreach (var current in text.Where(XmlConvert.IsXmlChar))
                {
                    textOut.Append(current);
                }
                
                return textOut.ToString(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao codificar string", ex);
            }
	    }

        /// <summary>
        /// Transforma um array de string em uma unica string.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>String com todos os dados do array de strings</returns>
        /// <exception cref="System.Exception">Erro ao converter array</exception>
        /// <exception cref="Exception">Erro ao converter array</exception>
        public static string AsString(this string[] array)
        {
            try
            {
				return string.Join(Environment.NewLine, array);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao converter array", ex);
            }
        }

        /// <summary>
        /// Alinha a string a direita/esquerda e preenche com caractere informado ate ficar do tamanho especificado.
        /// </summary>
        /// <param name="text">O texto</param>
        /// <param name="length">Tamanho final desejado</param>
        /// <param name="with">Caractere para preencher</param>
        /// <param name="esquerda">DireÁ„o do preenchimento</param>
        /// <returns>String do tamanho especificado e se menor complementada com o caractere informado a direita/esquerda</returns>
        public static string StringFill(this string text, int length, char with = ' ', bool esquerda = true)
        {
            if (text == null)
                text = string.Empty;

            if (text.Length > length)
            {
                text = text.Remove(length);
            }
            else
            {
                length -= text.Length;

                if (esquerda)
                    text = new string(with, length) + text;
                else
                    text += new string(with, length);
            }

            return text;
        }

        /// <summary>
        /// Alinha a string a direita e preenche a esquerda com o caracter informado atÈ ficar do tamanho especificado.
        /// Se tamanho menor que a string atual retorna uma string do tamanho especificado.
        /// </summary>
        /// <param name="text">O texto.</param>
        /// <param name="length">Tamanho final desejado</param>
        /// <param name="with">Caractere para preencher</param>
        /// <returns>String do tamanho especificado e se menor complementada com o caractere informado a esquerda</returns>
        public static string FillRight(this string text, int length, char with = ' ')
        {
            if (text == null)
                text = string.Empty;

            return text.StringFill(length, with);
        }

        /// <summary>
        /// Alinha a string a esquerda e preenche a direita com o caracter informado atÈ ficar do tamanho especificado.
        /// Se tamanho menor que a string atual retorna uma string do tamanho especificado.
        /// </summary>
        /// <param name="text">O texto.</param>
        /// <param name="length">Tamanho final desejado</param>
        /// <param name="with">Caractere para preencher</param>
        /// <returns>String do tamanho especificado e se menor complementada com o caractere informado a direita</returns>
        public static string FillLeft(this string text, int length, char with = ' ')
        {
            if (text == null)
                text = string.Empty;

            return text.StringFill(length, with, false);
        }

        /// <summary>
        /// Preenche uma string com zero a direita/esquerda ate ficar do tamanho especificado.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="length">Tamanho final desejado</param>
        /// <returns>String do tamanho especificado e se menor complementada com zero a direita/esquerda</returns>
        public static string ZeroFill(this string text, int length)
        {
            if (text == null)
                text = string.Empty;

            return text.StringFill(length, '0');
        }

        /// <summary>
        /// Normalize e substitui os caracteres especiais de uma string.
        /// </summary>
        /// <param name="value">The text.</param>
        /// <returns>String sem carateres especiais e normalizada</returns>
        public static string RemoveCe(this string value)
		{
		    if (value == null)
		        return string.Empty;

            var stFormD = new string(value.Normalize(NormalizationForm.FormD)
                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray());

            var retorno = new string((stFormD.Normalize(NormalizationForm.FormC))
                .Where(c => char.IsLetter(c) || char.IsSeparator(c) || char.IsNumber(c) || c.Equals('|')).ToArray());

            return retorno.SubstituiCe();
        }

        /// <summary>
        /// Substitue os caracteres especiais de uma string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>String sem carateres especiais</returns>
        public static string SubstituiCe(this string text)
        {
            try
            {
                if (text == null)
                    return string.Empty;

                var retorno = string.Empty;
                const string caracterComAcento = "·‡„‚‰ÈËÍÎÌÏÓÔÛÚıÙˆ˙˘˚¸Á¡¿√¬ƒ…» ÀÕÃŒœ”“’÷‘⁄Ÿ€‹«";
                const string caracterSemAcento = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUC";

                if (!string.IsNullOrEmpty(text))
                {
                    for (var i = 0; i < text.Length; i++)
                    {
                        if (caracterComAcento.IndexOf(Convert.ToChar(text.Substring(i, 1))) >= 0)
                        {
                            var car = caracterComAcento.IndexOf(Convert.ToChar(text.Substring(i, 1)));
                            retorno += caracterSemAcento.Substring(car, 1);
                        }
                        else
                        {
                            retorno += text.Substring(i, 1);
                        }
                    }

                    string[] cEspeciais = { "#39", "---", "--", "-", "'", "#", Environment.NewLine, 
                                            "\n", "\r", ",", ".", "?", "&", ":", "/", "!", ";", "∫",
                                            "™", "%", "ë", "í", "(", ")", "\\", "î", "ì", "+", "É", "á" };

                    for (var q = 0; q < cEspeciais.Length; q++)
                    {
                        retorno = retorno.Replace(cEspeciais[q], string.Empty);
                    }

                    for (var x = (cEspeciais.Length - 1); x > -1; x--)
                    {
                        retorno = retorno.Replace(cEspeciais[x], string.Empty);
                    }

                    retorno = retorno.Trim();
                }

                return retorno;
            }
            catch (Exception ex)
            {
                var tmpEx = new Exception("Erro ao formatar string.", ex);
                throw tmpEx;
            }
        }

        /// <summary>
        /// Formata o CPF ou CNPJ no formato: 000.000.000-00, 00.000.000/0001-00 respectivamente.
        /// </summary>
        /// <param name="value">The text.</param>
        /// <returns>CPF/CNPJ Formatado</returns>
        public static string FormataCPFCNPJ(this string value)
		{
		    value = value.OnlyNumbers();
		    switch (value.Trim().Length)
		    {
		        case 11:
		            return FormataCPF(value);
		        case 14:
		            return FormataCNPJ(value);

		        default:
		            return value;
		    }
		}

        /// <summary>
        /// Formata o n˙mero do CPF 92074286520 para 920.742.865-20
        /// </summary>
        /// <param name="cpf">Sequencia numÈrica de 11 dÌgitos. Exemplo: 00000000000</param>
        /// <returns>CPF formatado</returns>
        public static string FormataCPF(this string cpf)
        {
            try
            {
                cpf = cpf.OnlyNumbers();
                cpf = cpf.ZeroFill(11);
                return string.Format("{0}.{1}.{2}-{3}", cpf.Substring(0, 3), cpf.Substring(3, 3), cpf.Substring(6, 3), cpf.Substring(9, 2));
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Formata o CNPJ. Exemplo 00.316.449/0001-63
        /// </summary>
        /// <param name="cnpj">Sequencia numÈrica de 14 dÌgitos. Exemplo: 00000000000000</param>
        /// <returns>CNPJ formatado</returns>
        public static string FormataCNPJ(this string cnpj)
        {
            try
            {
                cnpj = cnpj.OnlyNumbers();
                cnpj = cnpj.ZeroFill(14);
                return string.Format("{0}.{1}.{2}/{3}-{4}", cnpj.Substring(0, 2), cnpj.Substring(2, 3), cnpj.Substring(5, 3), cnpj.Substring(8, 4), cnpj.Substring(12, 2));
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Formato o CEP em 00.000-000
        /// </summary>
        /// <param name="cep">Sequencia numÈrica de 8 dÌgitos. Exemplo: 00000000</param>
        /// <returns>CEP formatado</returns>
        public static string FormataCEP(this string cep)
        {
            try
            {
                cep = cep.OnlyNumbers();
                return string.Format("{0}.{1}-{2}", cep.Substring(0, 2), cep.Substring(2, 3), cep.Substring(5, 3));
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Formata agÍncia e conta
        /// </summary>
        /// <param name="agencia">CÛdigo da agÍncia</param>
        /// <param name="digitoAgencia">DÌgito verificador da agÍncia. Pode ser vazio.</param>
        /// <param name="conta">CÛdigo da conta</param>
        /// <param name="digitoConta">dÌgito verificador da conta. Pode ser vazio.</param>
        /// <returns>AgÍncia e conta formatadas</returns>
        public static string FormataAgenciaConta(this string agencia, string digitoAgencia, string conta, string digitoConta)
        {
            try
            {
                var agenciaConta = agencia;
                if (digitoAgencia != string.Empty)
                    agenciaConta += "-" + digitoAgencia;

                agenciaConta += "/" + conta;
                if (digitoConta != string.Empty)
                    agenciaConta += "-" + digitoConta;

                return agenciaConta;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get substring of specified number of characters on the right.
        /// </summary>
        /// <param name="value">The text.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string Right(this string value, int length)
        {
            if (length > value.Length)
                length = value.Length;

            return value.Substring(value.Length - length);
        }

        /// <summary>
        /// Froms the julian date.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        /// <returns>DateTime.</returns>
		public static DateTime FromJulianDate(this string julianDate)
		{
			if(julianDate.Length < 1 || julianDate.Length > 5)
				return default(DateTime);

			var ano = 2000 + int.Parse(julianDate.Substring(0, 2));
			var dias = int.Parse(julianDate.Substring(2));
			return new DateTime(ano, 1, 1).AddDays(dias);
		}

        /// <summary>
        /// Safes the replace.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="wordToFind">The word to find.</param>
        /// <param name="replacement">The replacement.</param>
        /// <param name="ignorecase">if set to <c>true</c> [ignorecase].</param>
        /// <returns>System.String.</returns>
        public static string SafeReplace(this string original, string wordToFind, string replacement, bool ignorecase = false)
        {
            var pattern = string.Format(@"\b{0}\b", wordToFind);
            var opt = ignorecase ? RegexOptions.IgnoreCase : RegexOptions.None;
            return Regex.Replace(original, pattern, replacement, opt);
        }

        /// <summary>
        /// To the title case.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        public static string ToTitleCase(this string text)
	    {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
	    }

        /// <summary>
        /// Determines whether the specified value is empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified value is empty; otherwise, <c>false</c>.</returns>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Befores the specified end.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="end">The end.</param>
        /// <returns>System.String.</returns>
        public static string Before(this string value, int end)
        {
            return (end == 0 ? string.Empty : value.Between(0, end - 1));
        }

        /// <summary>
        /// Afters the specified start.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="start">The start.</param>
        /// <returns>System.String.</returns>
        public static string After(this string value, int start)
        {
            return value.Between(start + 1, int.MaxValue);
        }

        /// <summary>
        /// Betweens the specified start.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>System.String.</returns>
        public static string Between(this string value, int start, int end)
        {
            if (value == null)
                return string.Empty;

            var len = value.Length;
            if (start < 0) start += len;
            if (end < 0) end += len;
            if (len == 0 || start > len - 1 || end < start)
                return string.Empty;

            if (start < 0) start = 0;
            if (end >= len) end = len - 1;
            return value.Substring(start, end - start + 1);
        }

        /// <summary>
        /// Substitutes the specified arguments.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>System.String.</returns>
        public static string Substitute(this string format, params object[] args)
        {
            var value = string.Empty;
            if (string.IsNullOrEmpty(format)) return value;
            if (args.Length == 0) return format;
            try
            {
                return string.Format(format, args);
            }
            catch (FormatException)
            {
                return format;
            }
            catch
            {
                return "***";
            }
        }
    }
}