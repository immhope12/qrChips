using QRCoder;
using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace tabletLocal
{
    public partial class qrInicio : Form
    {
        public qrInicio()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Propiedades visuales de la tablet
            this.Text = "Tablet Local - Registro de Asistencia";
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configuramos el Timer en camelCase para que actualice el QR cada 10 segundos
            timerQr.Interval = 25000;
            timerQr.Tick += TimerQr_Tick;
            timerQr.Start();

            // Generamos el primer QR al abrir la app
            GenerarQRTemporal();
        }

        private void TimerQr_Tick(object sender, EventArgs e)
        {
            // Cada 10 segundos se ejecuta esto y renueva el QR
            GenerarQRTemporal();
        }

        private void GenerarQRTemporal()
        {
            // Token dinámico basado en la fecha y hora actual del local
            string tokenSeguridad = $"LOCAL-PANCHO-{DateTime.Now:yyyyMMddHHmmss}";

            // Generamos el código QR con QRCoder
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(tokenSeguridad, QRCodeGenerator.ECCLevel.Q))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        // Convertimos a Bitmap y lo mostramos en el PictureBox renombrado como imgQr
                        using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                        {
                            if (imgQr != null)
                            {
                                imgQr.Image = new Bitmap(qrCodeImage);
                                imgQr.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                }
            }
        }
    }
}