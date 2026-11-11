using System;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Windows.Forms;

namespace AppEmpleado
{
    public partial class formEmpleado : Form
    {
        // Apuntamos a tu API local
        private readonly string urlApi = "http://localhost:5004/api/asistencia/registrar";

        public formEmpleado()
        {
            
            ConfigurarVentanaMovil();
        }

        private void ConfigurarVentanaMovil()
        {
            // Propiedades de la ventana simulando un celular
            this.Text = "App Empleado - Celular";
            this.Size = new Size(350, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Creamos el botón de fichaje por código
            Button btnMarcar = new Button();
            btnMarcar.Text = "Escanear QR / Marcar Ingreso";
            btnMarcar.Size = new Size(260, 60);
            btnMarcar.Location = new Point(35, 200);
            btnMarcar.BackColor = Color.ForestGreen;
            btnMarcar.ForeColor = Color.White;
            btnMarcar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnMarcar.Click += BtnMarcar_Click;

            this.Controls.Add(btnMarcar);
        }

        private async void BtnMarcar_Click(object sender, EventArgs e)
        {
            // Simulamos que la cámara del celu leyó el texto dinámico actual del local
            // (En un sistema real acá usarías una librería de lectura de cámara como ZXing)
            string tokenEscaneado = "LOCAL-PANCHO-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            var datosFichada = new
            {
                id = 0,
                empleadoId = "Agustin-001",
                tipo = "Ingreso",
                qrToken = tokenEscaneado // <--- Mandamos el token escaneado del QR
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonPayload = JsonSerializer.Serialize(datosFichada);
                    HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(urlApi, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("¡Escaneo exitoso! Asistencia registrada con QR.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("QR inválido o expirado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar con la API: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
