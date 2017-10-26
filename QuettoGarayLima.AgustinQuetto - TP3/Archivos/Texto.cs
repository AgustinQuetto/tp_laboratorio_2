using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                Directory.CreateDirectory("archivos");
                StreamWriter texto = new StreamWriter("archivos/" + archivo, true);
                texto.Write(datos);
                texto.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

        }
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader texto = new StreamReader("archivos/" + archivo);
                datos = texto.ReadToEnd();
                texto.Close();
                return true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }

        }
    }
}
