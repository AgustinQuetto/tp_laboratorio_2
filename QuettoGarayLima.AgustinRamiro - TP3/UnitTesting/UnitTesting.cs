using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Abstractas;
using Clases_Instanciables;
using Archivos;

namespace UnitTesting
{
    [TestClass]
    public class UnitTesting
    {
        #region(Excepcion)
        [TestMethod]
        public void EnviaExcepcion()
        {
            //Verifico que de la excepcion correcta, y, además, se valida que el DNI sea numérico (dos tests en uno)
            try
            {
                Alumno dniString = new Alumno(1, "Domingo", "Sarmiento", "2236243a", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            }
            catch (DniInvalidoException e)
            {
                Assert.IsTrue(true);
            }
            catch(Exception e)
            {
                Assert.Fail();
            }

        }
        #endregion

        #region(Archivo)
        [TestMethod]
        public void ArchivoExcepcion()
        {
            //Verifica excepcion
            try
            {
                Texto unTexto = new Texto();
                unTexto.Guardar("test//dir.txt", "text");
            }
            catch (ArchivosException e)
            {
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

        }
        #endregion

        #region(ValidarNulls)
        [TestMethod]
        public void ValidarNulls()
        {
            //Verifica con y sin parametros
            try
            {
                Alumno noQuiereNulls = new Alumno();
                Profesor elTampoco = new Profesor();
                Universidad nadieQuiere = new Universidad();
                Jornada bastaDeNulls = new Jornada(Universidad.EClases.Laboratorio,elTampoco);
                noQuiereNulls.ToString();
                elTampoco.ToString();
                nadieQuiere.ToString();
                bastaDeNulls.ToString();
            }
            catch (Exception e)
            {
                //Distinto de null, true
                Assert.IsNotInstanceOfType(e,typeof(NullReferenceException));
            }
        }
        #endregion
    }
}
