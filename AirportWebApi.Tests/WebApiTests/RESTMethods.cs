using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace AirportWebApi.Tests.WebApiTests
{
    public class RESTMethods
    {
        public void Get(string url, out HttpWebResponse response)
        {
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "application/json";

            response = httpWebRequest.GetResponse() as HttpWebResponse;
        }

        public void Post(string url, out HttpWebResponse response, object entity)
        {
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(entity));
                streamWriter.Close();
            }
            
            response = httpWebRequest.GetResponse() as HttpWebResponse;
        }

        public void Put(string url, out HttpWebResponse response, object entity)
        {
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
            httpWebRequest.Method = "PUT";
            httpWebRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(entity));
                streamWriter.Close();
            }

            response = httpWebRequest.GetResponse() as HttpWebResponse;
        }

        public void Delete(string url, out HttpWebResponse response)
        {
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
            httpWebRequest.Method = "DELETE";
            httpWebRequest.ContentType = "application/json";

            response = httpWebRequest.GetResponse() as HttpWebResponse;
        }

    }
}
