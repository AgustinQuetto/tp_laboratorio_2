using System;
using System.Net;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public event Descargador.EventProgress EventoProgreso;

        public event Descargador.EventFin EventoFin;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.WebClientDownloadProgressChanged);
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(this.WebClientDownloadCompleted);
                webClient.DownloadStringAsync(this.direccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.EventoProgreso(e.ProgressPercentage);
        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.html = e.Result;
            this.EventoFin(this.html);
        }

        public delegate void EventProgress(int progreso);

        public delegate void EventFin(string html);
    }
}
