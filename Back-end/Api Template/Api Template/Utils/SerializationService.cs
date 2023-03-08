using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace SL.Services
{
    /// <summary>
    /// Brinda el servicio de serialización (Json y binaria). 
    /// También facilita la exportación e importación de elementos serializados.
    /// </summary>
    public static class SerializationService
    {
        public static class Binary
        {
            private static BinaryFormatter formateadorBinario = new BinaryFormatter();
            //private static string serializationPath = AppData.Config.SerializationPath;

            private static Stream GetConexion(string pPath, FileMode pModo, FileAccess pAcceso)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(pPath));

                    if (!File.Exists(pPath)) File.WriteAllText(pPath, null);

                    return new FileStream(pPath, pModo, pAcceso);
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
            private static bool EsLaPropiedad(PropertyInfo pInfoPropiedad, string pPropiedad)
            {
                return pInfoPropiedad.Name == pPropiedad;
            }
            public static List<T> LoadPorValor<T>(string pPropiedad, object pValor, string path)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    List<T> resultado = new List<T>();
                    object objetoTest;

                    Stream flujo = GetConexion(path, FileMode.Open, FileAccess.Read);

                    while (flujo.Position < flujo.Length)
                    {
                        objetoTest = formateadorBinario.Deserialize(flujo);

                        //Compruebo que el nombre del objeto (CLASE) buscado coincida
                        if (typeof(T).FullName == objetoTest.GetType().FullName)
                        {
                            if (Comparar<T>((T)objetoTest, pPropiedad, pValor))
                            {
                                resultado.Add((T)objetoTest);
                            }
                        }
                    }

                    flujo.Close();
                    return resultado;
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
            public static T LoadFirst<T>(string path)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    object objeto = null;
                    object objetoTest;
                    Stream flujo = GetConexion(path, FileMode.Open, FileAccess.Read);

                    while (flujo.Position < flujo.Length)
                    {
                        objetoTest = formateadorBinario.Deserialize(flujo);

                        //Compruebo que el nombre del objeto (CLASE) buscado coincida (Requerimiento o Tarea, etc...)
                        if (typeof(T).FullName == objetoTest.GetType().FullName)
                        {
                            objeto = objetoTest;
                            break;
                        }
                    }
                    flujo.Close();
                    return (T)objeto;
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
            private static bool Comparar<T>(T obj, string pPropiedad, object pValor)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    bool resultado = false;
                    foreach (PropertyInfo propiedad in obj.GetType().GetProperties())
                    {
                        if (propiedad.Name == pPropiedad)
                        {
                            if (propiedad.GetValue(obj, null).ToString() == pValor.ToString())
                            {
                                resultado = true;
                                break;
                            }
                        }
                    }

                    return resultado;
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
            public static void Store(object obj, string path, bool append = false)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    if (!append && File.Exists(path)) Clear(path);

                    using (Stream flujo = GetConexion(path, FileMode.Append, FileAccess.Write))
                    {
                        formateadorBinario.Serialize(flujo, obj);
                        flujo.Close();
                    }
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
            public static T Retrieve<T>(string path)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    object returnVar = null;

                    if (File.Exists(path))
                    {
                        using (Stream flujo = GetConexion(path, FileMode.Open, FileAccess.Read))
                        {
                            if (flujo.Length > 0)
                            {
                                returnVar = formateadorBinario.Deserialize(flujo);
                                flujo.Close();
                            }
                        }
                    }

                    if (returnVar != null) return (T)returnVar;
                    else return default(T);
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
            public static void Clear(string path)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    File.WriteAllText(path, null);
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
        }
        public static class Json
        {
            public static string Serialize<T>(T obj, bool formatted_json = true)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    return JsonConvert.SerializeObject(obj, (formatted_json) ? Formatting.Indented : Formatting.None);
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
            public static T Deserialize<T>(string json)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
            public static void Store<T>(T obj, string path, bool append = false, bool formatted_json = true)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    if (!append && File.Exists(path)) Clear(path);

                    Directory.CreateDirectory(Path.GetDirectoryName(path));

                    File.WriteAllText(path, Serialize(obj, formatted_json));
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
            public static T Retrieve<T>(string path)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    object returnVar = null;

                    if (File.Exists(path))
                    {
                        using (StreamReader file = File.OpenText(path))
                        {
                            using (JsonTextReader reader = new JsonTextReader(file))
                            {
                                JObject j_obj = (JObject)JToken.ReadFrom(reader);
                                string json = j_obj.ToString();
                                returnVar = Deserialize<T>(json);
                            }
                        }
                    }

                    if (returnVar != null) return (T)returnVar;
                    else return default(T);
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
            public static void Clear(string path)
            {
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                try
                {
                    File.WriteAllText(path, null);
                }
                catch (Exception ex)
                {
                    //ex.Handle(typeof(SerializationService));
                    throw;
                }
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            }
        }
    }
}
