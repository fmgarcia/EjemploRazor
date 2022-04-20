using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace EjemploRazor.Utilidades
{
    public class JsonUtils
    {
        /// <summary>
        /// Lee un fichero json de la ruta especificada y devuelve el contenido con formato dinamico
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruta"></param>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public static T LeerFichero<T>(string ruta, string nombreArchivo)
        {
            try
            {
                using (StreamReader sr = new StreamReader($@"{ruta}{nombreArchivo}"))
                {
                    var json = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<dynamic>(json);
                }
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// Dado una url me devuelve todo su contenido como un string
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ReadUrl(string url)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.CreateHttp(url);
                using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Dado una url y un token para poder acceder a ella me devuelve todo su contenido como un string
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string ReadUrl(string url, string token)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.CreateHttp(url);
                httpWebRequest.UserAgent = "PostmanRuntime/7.28.4";
                httpWebRequest.Headers.Add("X-Auth-Token", token);
                using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        /// <summary>
        /// Dada una url me devuelve una lista con los objetos que encuentre en ella
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static List<T> DevolverListaGenerica<T>(string url)
        {
            try
            {
                Console.WriteLine("Tratando la url: " + url);
                string cadena = ReadUrl(url);
                return JsonConvert.DeserializeObject<List<T>>(cadena);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default;
            }
        }

        /// <summary>
        /// Dada una url y un token me devuelve una lista con los objetos que encuentre en ella
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static List<T> DevolverListaGenericaToken<T>(string url, string token)
        {
            try
            {
                Console.WriteLine("Tratando la url: " + url);
                string cadena = ReadUrl(url, token);
                return JsonConvert.DeserializeObject<List<T>>(cadena);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default;
            }
        }

        /// <summary>
        /// Dada una url que únicamente tiene un objeto (empieza y acaba entre llaves {})
        /// lo devuelve.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T DevolverObjetoGenerico<T>(string url)
        {
            try
            {
                Console.WriteLine("Tratando la url: " + url);
                string cadena = ReadUrl(url);
                return JsonConvert.DeserializeObject<T>(cadena);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default;
            }
        }

        /// <summary>
        /// Dada una url que únicamente tiene un objeto (empieza y acaba entre llaves {}) y un token necesario para acceder a dicha url
        /// lo devuelve.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T DevolverObjetoGenericoToken<T>(string url, string token)
        {
            try
            {
                Console.WriteLine("Tratando la url: " + url);
                string cadena = ReadUrl(url, token);
                return JsonConvert.DeserializeObject<T>(cadena);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default;
            }
        }


    }
}
