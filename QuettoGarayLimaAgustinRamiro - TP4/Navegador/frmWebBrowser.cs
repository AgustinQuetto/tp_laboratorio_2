using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;
using Archivos;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        private Texto archivos;

        public frmWebBrowser()
        {
            this.InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;
            this.txtUrl.SelectionLength = 0;
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = "Escriba aquí...";
            this.archivos = new Texto("historico.dat");
        }

        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam;
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (!this.txtUrl.Text.Equals("Escriba aquí..."))
                return;
            this.txtUrl.Text = "";
            this.txtUrl.ForeColor = Color.Black;
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.txtUrl.Text.Equals((string)null) && !this.txtUrl.Text.Equals(""))
                return;
            this.txtUrl.Text = "Escriba aquí...";
            this.txtUrl.ForeColor = Color.Gray;
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }

        private void ProgresoDescarga(int progreso)
        {
            if (this.statusStrip.InvokeRequired)
                this.Invoke((Delegate)new frmWebBrowser.ProgresoDescargaCallback(this.ProgresoDescarga), (object)progreso);
            else
                this.tspbProgreso.Value = progreso;
        }

        private void FinDescarga(string html)
        {
            if (this.rtxtHtmlCode.InvokeRequired)
                this.Invoke((Delegate)new frmWebBrowser.FinDescargaCallback(this.FinDescarga), (object)html);
            else
                this.rtxtHtmlCode.Text = html;
        }

        private void btnIr_Click_1(object sender, EventArgs e)
        {
            this.tspbProgreso.Value = 0;
            if (!this.txtUrl.Text.StartsWith("http://"))
                this.txtUrl.Text = "http://" + this.txtUrl.Text;
            Uri result;
            if (Uri.TryCreate(this.txtUrl.Text, UriKind.Absolute, out result))
            {
                Descargador descargador = new Descargador(result);
                descargador.EventoProgreso += new Descargador.EventProgress(this.ProgresoDescarga);
                descargador.EventoFin += new Descargador.EventFin(this.FinDescarga);
                new Thread(new ThreadStart(descargador.IniciarDescarga)).Start();
            }
            this.archivos.guardar(this.txtUrl.Text);
        }

        private void mostrarTodoElHistorialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int num = (int)new frmHistorial().ShowDialog();
        }

        private delegate void ProgresoDescargaCallback(int progreso);

        private delegate void FinDescargaCallback(string html);
    }
}
