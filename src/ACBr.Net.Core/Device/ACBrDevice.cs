// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-24-2014
// ***********************************************************************
// <copyright file="ACBrDevice.cs" company="ACBr.Net">
// Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la
// sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela
// Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério)
// qualquer versão posterior.
//
// Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM
// NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU
// ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor
// do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)
//
// Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto
// com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,
// no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.
// Você também pode obter uma copia da licença em:
// http://www.opensource.org/licenses/lgpl-license.php
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using ACBr.Net.Core.Exceptions;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBr.Net.Core.Device
{

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("29A5B338-6E3C-47D3-AA31-91965AEF568C")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif    

    /// <summary>
    /// Class ACBrDevice. This class cannot be inherited.
    /// </summary>
    public sealed class ACBrDevice : IDisposable
    {
        #region Constantes

        /// <summary>
        /// The ac br device ativar porta exception
        /// </summary>
        const string ACBrDeviceAtivarPortaException    = "Porta não definida\\incorreta";
        /// <summary>
        /// The ac br device ativar exception
        /// </summary>
        const string ACBrDeviceAtivarException         = "Erro abrindo: ";
        /// <summary>
        /// The ac br device set baud exception
        /// </summary>
        const string ACBrDeviceSetBaudException        = "Valor deve estar na faixa de 50 a 4000000.\n\rNormalmente os equipamentos Seriais utilizam: 9600";
        /// <summary>
        /// The ac br device set data exception
        /// </summary>
        const string ACBrDeviceSetDataException        = "Valor deve estar na faixa de 5 a 8.\n\rNormalmente os equipamentos Seriais utilizam: 7 ou 8";
        /// <summary>
        /// The ac br device set porta exception
        /// </summary>
        const string ACBrDeviceSetPortaException       = "Não é possível mudar a Porta com o Dispositivo Ativo";
        /// <summary>
        /// The ac br device envia string thread exception
        /// </summary>
        const string ACBrDeviceEnviaStrThreadException = "Erro gravando em: ";       

        #endregion Constantes

        #region Field

        /// <summary>
        /// The COM port
        /// </summary>
        private SerialPort ComPort;
        /// <summary>
        /// The port
        /// </summary>
        private string Port;
        /// <summary>
        /// The timeout
        /// </summary>
        private int Timeout;
        /// <summary>
        /// The baud
        /// </summary>
        private int baud;
        /// <summary>
        /// The data
        /// </summary>
        private int Data;
        /// <summary>
        /// The hard
        /// </summary>
        private bool Hard;
        /// <summary>
        /// The soft
        /// </summary>
        private bool Soft;
        /// <summary>
        /// The interval
        /// </summary>
        private int Interval;
        /// <summary>
        /// The hand
        /// </summary>
        private Handshake Hand;
        /// <summary>
        /// The stop
        /// </summary>
        private StopBits Stop;
        /// <summary>
        /// The parity
        /// </summary>
        private Parity parity;

        #endregion Field

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ACBrDevice" /> class.
        /// </summary>
        public ACBrDevice()
		{
            Port = string.Empty;
            Ativo = false;
            Timeout = 3;
            parity = Parity.None;
            Hard = false;
            Soft = false;
            Data = 8;
            baud = 9600;
            ProcessMessages = true;
            SendBytesCount = 0;
            Interval = 0;
        }

		#endregion Constructor

		#region Properties

        /// <summary>
        /// Gets a value indicating whether this <see cref="ACBrDevice" /> is ativo.
        /// </summary>
        /// <value><c>true</c> if ativo; otherwise, <c>false</c>.</value>
        public bool Ativo { get; private set; }

        /// <summary>
        /// Gets or sets the porta.
        /// </summary>
        /// <value>The porta.</value>
        public string Porta
        {
            get { return Port; }
            set { SetPorta(value); }
        }

        /// <summary>
        /// Gets or sets the baud.
        /// </summary>
        /// <value>The baud.</value>
        public int Baud 
        {
            get { return baud; }
            set { SetBaund(value); }
        }

        /// <summary>
        /// Gets or sets the data bits.
        /// </summary>
        /// <value>The data bits.</value>
        public int DataBits
        {
            get { return Data; }
            set { SetData(value); }
        }

        /// <summary>
        /// Gets or sets the parity.
        /// </summary>
        /// <value>The parity.</value>
        public Parity Parity 
        { 
            get { return parity; }
            set { SetParity(value); }
        }

        /// <summary>
        /// Gets or sets the stop bits.
        /// </summary>
        /// <value>The stop bits.</value>
        public StopBits StopBits
        {
            get { return Stop; }
            set { SetStop(value); }
        }

        /// <summary>
        /// Gets or sets the hand shake.
        /// </summary>
        /// <value>The hand shake.</value>
        public Handshake HandShake
        {
            get { return Hand; }
            set { SetHandshake(value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [hard flow].
        /// </summary>
        /// <value><c>true</c> if [hard flow]; otherwise, <c>false</c>.</value>
        public bool HardFlow
        {
            get { return Hard; }
            set { SetHardflow(value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [soft flow].
        /// </summary>
        /// <value><c>true</c> if [soft flow]; otherwise, <c>false</c>.</value>
        public bool SoftFlow
        {
            get { return Soft; }
            set { SetSoftflow(value); }
        }

        /// <summary>
        /// Gets or sets the time out.
        /// </summary>
        /// <value>The time out.</value>
        public int TimeOut
        {
            get { return Timeout; }
            set { SetTimeout(value); }
        }

        /// <summary>
        /// Gets or sets the send bytes count.
        /// </summary>
        /// <value>The send bytes count.</value>
        public int SendBytesCount { get; set; }

        /// <summary>
        /// Gets or sets the send bytes interval.
        /// </summary>
        /// <value>The send bytes interval.</value>
        public int SendBytesInterval
        {
            get { return Interval; }
            set { SetBytesInterval(value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [process messages].
        /// </summary>
        /// <value><c>true</c> if [process messages]; otherwise, <c>false</c>.</value>
        public bool ProcessMessages { get; set; }

		#endregion Properties

        #region SetGetMethods

        /// <summary>
        /// Sets the porta.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ACBrException"></exception>
        private void SetPorta(string value)
        {
            if (Ativo)
                throw new ACBrException(ACBrDeviceSetPortaException);

            if (Port.Equals(value))
                return;

            Port = value;
        }

        /// <summary>
        /// Sets the handshake.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetHandshake(Handshake value)
        {
            switch (value)
            {
                case Handshake.RequestToSend:
                    Hard = true;
                    break;

                case Handshake.XOnXOff:
                    Soft = true;
                    break;
            }

            Hand = value;
        }

        /// <summary>
        /// Sets the hardflow.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void SetHardflow(bool value)
        {
            Hand = value ? Handshake.RequestToSend : Handshake.None;

            Hard = value;
        }

        /// <summary>
        /// Sets the softflow.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void SetSoftflow(bool value)
        {
            Hand = value ? Handshake.XOnXOff : Handshake.None;

            Soft = true;
        }

        /// <summary>
        /// Sets the baund.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ACBrException"></exception>
        private void SetBaund(int value)
        {
            if (Ativo)
                return;

            if (baud == value)
                return;

            if (value < 50 || value > 4000000)
                throw new ACBrException(ACBrDeviceSetBaudException);

            baud = value;
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ACBrException"></exception>
        private void SetData(int value)
        {
            if (Ativo)
                return;

            if (Data == value)
                return;

            if (value < 5 || value > 8)
                throw new ACBrException(ACBrDeviceSetDataException);

            Data = value;
        }

        /// <summary>
        /// Sets the timeout.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetTimeout(int value)
        {
            if (Timeout == value)
                return;

            if (value < 1)
                value = 1;

            Timeout = value;

            if (ComPort == null)
                return;

            ComPort.WriteTimeout = Timeout * 1000;
            ComPort.ReadTimeout = Timeout * 1000;
        }

        /// <summary>
        /// Sets the bytes interval.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetBytesInterval(int value)
        {
            if (Interval == value)
                return;

            if (Interval < 0)
                value = 0;

            Interval = value;
        }

        /// <summary>
        /// Sets the stop.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetStop(StopBits value)
        {
            if (Stop == value)
                return;

            Stop = value;

            if (ComPort != null)
                ComPort.StopBits = Stop;
        }

        /// <summary>
        /// Sets the parity.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetParity(Parity value)
        {
            if (parity == value)
                return;

            parity = value;

            if (ComPort != null)
                ComPort.Parity = parity;
        }

        #endregion SetGetMethods

        #region Methods

        /// <summary>
        /// Ativars this instance.
        /// </summary>
        /// <exception cref="ACBrException">Dispositivo já esta ativo
        /// or
        /// or</exception>
        public void Ativar()
        {
            try
            {
                if (Ativo)
                    throw new ACBrException("Dispositivo já esta ativo");

                if (Porta.ToLower().Substring(0, 3).Equals("COM"))
                    throw new ACBrException(ACBrDeviceAtivarPortaException);

                ConfigurarSerial();
                ComPort.Open();
                Ativo = true;
            }
            catch (Exception ex)
            {
                var msg = string.Format("{0}{1}", ACBrDeviceAtivarException, Port);
                throw new ACBrException(msg, ex);
            }
        }

        /// <summary>
        /// Desativars this instance.
        /// </summary>
        /// <exception cref="ACBrException">Dispositivo não está ativo
        /// or
        /// Erro ao desativar o dispositivo</exception>
        public void Desativar()
        {
            try
            {
                if (!Ativo)
                    throw new ACBrException("Dispositivo não está ativo");

                ComPort.Close();
                ComPort.Dispose();
                Ativo = false;
            }
            catch (Exception ex)
            {
                throw new ACBrException("Erro ao desativar o dispositivo", ex);
            }
        }

        /// <summary>
        /// Ems the linha.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool EmLinha(int timeout = 1)
        {
            if(!Ativo)
                return false;

            if (timeout < 1)
                timeout = 1;

            var retorno = false;
            var limite = DateTime.Now.AddSeconds(timeout);
            while (limite > DateTime.Now || retorno)
            {
                if(Hand == Handshake.RequestToSend)
                    retorno = ComPort.CtsHolding;

                if (Hand == Handshake.XOnXOff)
                    retorno = ComPort.CDHolding;

                if (retorno) 
                    continue;

                if (ProcessMessages)
                    Application.DoEvents();

                Thread.Sleep(10);
            }
            
            return retorno;
        }

        /// <summary>
        /// Envias the string.
        /// </summary>
        /// <param name="value">The value.</param>
        public void EnviaString(string value)
        {
            var i = 0;
            var max = value.Length;
            var nbytes = SendBytesCount;

            if (nbytes == 0)
                nbytes = max;

            while (i <= max)
            {
                ComPort.Write(value.Substring(i, nbytes));

                if(SendBytesInterval > 0)
                    Thread.Sleep(SendBytesInterval);

                i += nbytes;
            }
        }

        /// <summary>
        /// Configurars the serial.
        /// </summary>
        private void ConfigurarSerial()
        {            
            if(ComPort == null)
                ComPort = new SerialPort();
            
            if(ComPort.IsOpen)
                return;

            ComPort.PortName = Port;
            ComPort.ReadTimeout = Timeout * 1000;
            ComPort.WriteTimeout = Timeout * 1000;
            ComPort.BaudRate = baud;
            ComPort.DataBits = Data;
            ComPort.Parity = parity;
            ComPort.StopBits = Stop;
            ComPort.Handshake = Hand;
            ComPort.ErrorReceived += COMPort_ErrorReceived;
            ComPort.DataReceived += COMPort_DataReceived;
        }

        #endregion Methods

        #region Eventhandlers

        /// <summary>
        /// Handles the ErrorReceived event of the COMPort control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SerialErrorReceivedEventArgs" /> instance containing the event data.</param>
        private void COMPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            var sp = (SerialPort)sender;            
        }

        /// <summary>
        /// Handles the DataReceived event of the COMPort control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SerialDataReceivedEventArgs" /> instance containing the event data.</param>
        private void COMPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var sp = (SerialPort)sender;
            var indata = sp.ReadExisting();
        }

        #endregion Eventhandlers

        #region Dispose Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }

            if (ComPort == null) 
                return;

            if (Ativo)
                ComPort.Close();

            ComPort.Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion Dispose Methods
    }
}