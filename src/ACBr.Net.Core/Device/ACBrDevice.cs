// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="ACBrDevice.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

/// <summary>
/// The Core namespace.
/// </summary>
namespace ACBr.Net.Core
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
        const string ACBrDeviceSetBaudException        = "Valor deve estar na faixa de 50 a 4000000.\nNormalmente os equipamentos Seriais utilizam: 9600";
        /// <summary>
        /// The ac br device set data exception
        /// </summary>
        const string ACBrDeviceSetDataException        = "Valor deve estar na faixa de 5 a 8.\nNormalmente os equipamentos Seriais utilizam: 7 ou 8";
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
        private SerialPort COMPort;
        /// <summary>
        /// The port
        /// </summary>
        private string port;
        /// <summary>
        /// The timeout
        /// </summary>
        private int timeout;
        /// <summary>
        /// The baud
        /// </summary>
        private int baud;
        /// <summary>
        /// The data
        /// </summary>
        private int data;
        /// <summary>
        /// The hard
        /// </summary>
        private bool hard;
        /// <summary>
        /// The soft
        /// </summary>
        private bool soft;
        /// <summary>
        /// The interval
        /// </summary>
        private int interval;
        /// <summary>
        /// The hand
        /// </summary>
        private Handshake hand;
        /// <summary>
        /// The stop
        /// </summary>
        private StopBits stop;
        /// <summary>
        /// The parity
        /// </summary>
        private Parity parity;

        #endregion Field

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ACBrDevice"/> class.
        /// </summary>
        public ACBrDevice()
		{
            port = string.Empty;
            Ativo = false;
            timeout = 3;
            parity = Parity.None;
            hard = false;
            soft = false;
            data = 8;
            baud = 9600;
            ProcessMessages = true;
            SendBytesCount = 0;
            interval = 0;
        }

		#endregion Constructor

		#region Properties

        /// <summary>
        /// Gets a value indicating whether this <see cref="ACBrDevice"/> is ativo.
        /// </summary>
        /// <value><c>true</c> if ativo; otherwise, <c>false</c>.</value>
        public bool Ativo { get; private set; }

        /// <summary>
        /// Gets or sets the porta.
        /// </summary>
        /// <value>The porta.</value>
        public string Porta { get; set; }

        /// <summary>
        /// Gets or sets the baud.
        /// </summary>
        /// <value>The baud.</value>
        public int Baud 
        {
            get
            {
                return baud;
            }
            set
            {
                SetBaund(value);
            }
        }

        /// <summary>
        /// Gets or sets the data bits.
        /// </summary>
        /// <value>The data bits.</value>
        public int DataBits
        {
            get
            {
                return data;
            }
            set
            {
                SetData(value);
            }
        }

        /// <summary>
        /// Gets or sets the parity.
        /// </summary>
        /// <value>The parity.</value>
        public Parity Parity 
        { 
            get
            {
                return parity;
            }
            set
            {
                SetParity(value);
            }
        }

        /// <summary>
        /// Gets or sets the stop bits.
        /// </summary>
        /// <value>The stop bits.</value>
        public StopBits StopBits
        {
            get
            {
                return stop;
            }
            set
            {
                SetStop(value);
            }
        }

        /// <summary>
        /// Gets or sets the hand shake.
        /// </summary>
        /// <value>The hand shake.</value>
        public Handshake HandShake
        {
            get
            {
                return hand;
            }
            set
            {
                SetHandshake(value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [hard flow].
        /// </summary>
        /// <value><c>true</c> if [hard flow]; otherwise, <c>false</c>.</value>
        public bool HardFlow
        {
            get
            {
                return hard;
            }
            set
            {
                SetHardflow(value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [soft flow].
        /// </summary>
        /// <value><c>true</c> if [soft flow]; otherwise, <c>false</c>.</value>
        public bool SoftFlow
        {
            get
            {
                return soft;
            }
            set
            {
                SetSoftflow(value);
            }
        }

        /// <summary>
        /// Gets or sets the time out.
        /// </summary>
        /// <value>The time out.</value>
        public int TimeOut
        {
            get
            {
                return timeout;
            }
            set
            {
                SetTimeout(value);
            }
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
            get
            {
                return interval;
            }
            set
            {
                SetBytesInterval(value);
            }
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

            if (port.Equals(value))
                return;

            port = value;
        }

        /// <summary>
        /// Sets the handshake.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetHandshake(Handshake value)
        {
            if (value == Handshake.RequestToSend)
                hard = true;
            else if (value == Handshake.XOnXOff)
                soft = true;

            hand = value;
        }

        /// <summary>
        /// Sets the hardflow.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void SetHardflow(bool value)
        {
            if (value)
                hand = Handshake.RequestToSend;
            else
                hand = Handshake.None;

            hard = value;
        }

        /// <summary>
        /// Sets the softflow.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void SetSoftflow(bool value)
        {
            if (value)
                hand = Handshake.XOnXOff;
            else
                hand = Handshake.None;

            soft = true;
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

            if (data == value)
                return;

            if (value < 5 || value > 8)
                throw new ACBrException(ACBrDeviceSetDataException);

            data = value;
        }

        /// <summary>
        /// Sets the timeout.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetTimeout(int value)
        {
            if (timeout == value)
                return;

            if (value < 1)
                value = 1;

            timeout = value;

            if (COMPort != null)
            {
                COMPort.WriteTimeout = timeout * 1000;
                COMPort.ReadTimeout = timeout * 1000;
            }
        }

        /// <summary>
        /// Sets the bytes interval.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetBytesInterval(int value)
        {
            if (interval == value)
                return;

            if (interval < 0)
                value = 0;

            interval = value;
        }

        /// <summary>
        /// Sets the stop.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetStop(StopBits value)
        {
            if (stop == value)
                return;

            stop = value;

            if (COMPort != null)
                COMPort.StopBits = stop;
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

            if (COMPort != null)
                COMPort.Parity = parity;
        }

        #endregion SetGetMethods

        #region Methods

        /// <summary>
        /// Ativars this instance.
        /// </summary>
        /// <exception cref="ACBrException">
        /// Dispositivo já esta ativo
        /// or
        /// or
        /// </exception>
        public void Ativar()
        {
            try
            {
                if (Ativo)
                    throw new ACBrException("Dispositivo já esta ativo");

                if (Porta.ToLower().Substring(0, 3).Equals("COM"))
                    throw new ACBrException(ACBrDeviceAtivarPortaException);

                ConfigurarSerial();
                COMPort.Open();
                Ativo = true;
            }
            catch (Exception ex)
            {
                var msg = string.Format("{0}{1}", ACBrDeviceAtivarException, port);
                throw new ACBrException(msg, ex);
            }
        }

        /// <summary>
        /// Desativars this instance.
        /// </summary>
        /// <exception cref="ACBrException">
        /// Dispositivo não está ativo
        /// or
        /// Erro ao desativar o dispositivo
        /// </exception>
        public void Desativar()
        {
            try
            {
                if (!Ativo)
                    throw new ACBrException("Dispositivo não está ativo");

                COMPort.Close();
                COMPort.Dispose();
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

            bool retorno = false;
            var limite = DateTime.Now.AddSeconds(timeout);
            while (limite > DateTime.Now || retorno)
            {
                if(hand == Handshake.RequestToSend)
                    retorno = COMPort.CtsHolding;
                if (hand == Handshake.XOnXOff)
                    retorno = COMPort.CDHolding;

                if (!retorno)
                {
                    if (ProcessMessages)
                        Application.DoEvents();

                    Thread.Sleep(10);
                }
            }

            return retorno;
        }

        /// <summary>
        /// Envias the string.
        /// </summary>
        /// <param name="value">The value.</param>
        public void EnviaString(string value)
        {
            int i = 0;
            int max = value.Length;
            int nbytes = SendBytesCount;

            if (nbytes == 0)
                nbytes = max;

            while (i <= max)
            {
                COMPort.Write(value.Substring(i, nbytes));

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
            if(COMPort == null)
                COMPort = new SerialPort();
            
            if(COMPort.IsOpen)
                return;

            COMPort.PortName = port;
            COMPort.ReadTimeout = timeout * 1000;
            COMPort.WriteTimeout = timeout * 1000;
            COMPort.BaudRate = baud;
            COMPort.DataBits = data;
            COMPort.Parity = parity;
            COMPort.StopBits = stop;
            COMPort.Handshake = hand;
            COMPort.ErrorReceived += COMPort_ErrorReceived;
            COMPort.DataReceived += COMPort_DataReceived;
        }

        #endregion Methods

        #region Eventhandlers

        /// <summary>
        /// Handles the ErrorReceived event of the COMPort control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SerialErrorReceivedEventArgs"/> instance containing the event data.</param>
        void COMPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            var sp = (SerialPort)sender;            
        }

        /// <summary>
        /// Handles the DataReceived event of the COMPort control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SerialDataReceivedEventArgs"/> instance containing the event data.</param>
        void COMPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
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

            if (COMPort != null)
            {
                if (Ativo)
                    COMPort.Close();

                COMPort.Dispose();
            }
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