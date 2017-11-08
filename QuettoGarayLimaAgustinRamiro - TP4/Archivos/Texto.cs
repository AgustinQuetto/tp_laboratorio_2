using System;
using System.Collections.Generic;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string archivo;

        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(this.archivo, true))
                    streamWriter.WriteLine(datos);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                using (StreamReader streamReader = new StreamReader(this.archivo))
                {
                    while (!streamReader.EndOfStream)
                        datos.Add(streamReader.ReadLine());
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
