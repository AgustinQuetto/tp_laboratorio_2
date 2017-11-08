using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamWriter texto = new StreamWriter((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + archivo));
                serializer.Serialize(texto, datos);
                return true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }

        }
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamReader texto = new StreamReader((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + archivo));
                datos = (T)serializer.Deserialize(texto);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
