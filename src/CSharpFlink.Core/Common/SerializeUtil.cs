﻿using System;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace CSharpFlink.Core.Common
{
    #region 序列化
    public static class SerializeUtil
    {
        /// <summary>
        /// 序列化BIN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="t"></param>
        //public static void BinarySerialize<T>(string filePath, T t) where T : class
        //{
        //    using (FileStream fs = new FileStream(filePath, FileMode.Create))
        //    {
        //        BinaryFormatter binaryFormatter = new BinaryFormatter();
        //        binaryFormatter.Serialize(fs, t);
        //    }
        //}

        /// <summary>
        /// 反序列化BIN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        //public static T BinaryDeserialize<T>(string filePath)
        //{
        //    if (System.IO.File.Exists(filePath))
        //    {
        //        T t = default(T);
        //        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        //        {
        //            IFormatter formatter = new BinaryFormatter();
        //            t = (T)formatter.Deserialize(fs);
        //        }
        //        return t;
        //    }
        //    else
        //    {
        //        return default(T);
        //    }
        //}

        /// <summary>
        /// 序列化SOAP
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="t"></param>
        //public static void SoapSerialize<T>(string filePath, T t) where T : class
        //{
        //    using (FileStream fs = new FileStream(filePath, FileMode.Create))
        //    {
        //        SoapFormatter formatter = new SoapFormatter();
        //        formatter.Serialize(fs, t);
        //    }
        //}


        /// <summary>
        /// 反序列化SOAP
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        //public static T SoapDeserialize<T>(string filePath)
        //{
        //    if (System.IO.File.Exists(filePath))
        //    {
        //        T t = default(T);
        //        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        //        {
        //            IFormatter formatter = new SoapFormatter();
        //            t = (T)formatter.Deserialize(fs);
        //        }
        //        return t;
        //    }
        //    else
        //    {
        //        return default(T);
        //    }
        //}

        /// <summary>
        /// 序列化XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="t"></param>
        public static void XmlSerialize<T>(string filePath, T t)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                ser.Serialize(writer, t);
            }
        }

        public static void XmlSerialize(string filePath, object obj)
        {
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                ser.Serialize(writer, obj);
            }
        }

        /// <summary>
        /// 反序列化XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T XmlDeserailize<T>(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                StreamReader read = new StreamReader(filePath);
                T t = (T)ser.Deserialize(read);
                read.Close();
                read.Dispose();
                read = null;
                return t;
            }
            else
            {
                return default(T);
            }
        }

        public static object XmlDeserailize(string filePath, Type objType)
        {
            if (System.IO.File.Exists(filePath))
            {
                XmlSerializer ser = new XmlSerializer(objType);
                StreamReader read = new StreamReader(filePath);
                object obj = ser.Deserialize(read);
                read.Close();
                read.Dispose();
                read = null;
                return obj;
            }
            else
            {
                return null;
            }
        }

        public static string JsonSerialize(object obj)
        {
           return Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
           {
               TypeNameHandling = TypeNameHandling.Auto
           });
        }

        public static T JsonDeserialize<T>(string json)
        {
            return (T)Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }
    }
    #endregion
}

