using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Text;
using System.Net.Mail;
using System.Net;

using System.Net.Mime;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.Runtime.InteropServices;

namespace GMS.Common
{
    public class HelperMethods
    {
        public static bool validatePhone(string phone)
        {
            Regex regex = new Regex(@"^1?\d{10}$");
            Match match = regex.Match(phone);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static bool validateEmail(string emailaddress)
        {
            string email = emailaddress;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }
        public static bool validateCnic(string cnic)
        {
            Regex regex = new Regex(@"[0-9]{13}");
            if (cnic.Length == 13){
                Match match = regex.Match(cnic);
            if (match.Success)
                return true;
            else
                return false;

            }else{
                return false;
            }
            
            
        }

        public static DataTable JsonStringToDataTable(string jsonString)
        {
            DataTable dt = new DataTable();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", "").Replace("\r\n", "").Replace(" ", ""), "},{");
            List<string> ColumnsName = new List<string>();
            foreach (string jSA in jsonStringArray)
            {
                string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                foreach (string ColumnsNameData in jsonStringData)
                {
                    try
                    {
                        int idx = ColumnsNameData.IndexOf(":");
                        string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                        if (!ColumnsName.Contains(ColumnsNameString))
                        {
                            ColumnsName.Add(ColumnsNameString);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                    }
                }
                break;
            }
            foreach (string AddColumnName in ColumnsName)
            {
                dt.Columns.Add(AddColumnName);
            }
            foreach (string jSA in jsonStringArray)
            {
                string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in RowData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
                        string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                        nr[RowColumns] = RowDataString;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                dt.Rows.Add(nr);
            }
            return dt;
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(action);
            
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
        private static XmlDocument CreateXMLEnvelope(string UserId, string MobileNo, string SMS)
        {
            var User_Id = "t@talSoft";
            var Password = "GH78-09#12K*LYE";
            var MsgId = UserId + " - " + MobileNo;
            var MsgHeader = "939320";
            XmlDocument soapEnvelopeDocument = new XmlDocument();
        
            soapEnvelopeDocument.LoadXml(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                        <soap:Body><SendSMS xmlns=""http://tempuri.org/""><UserId>" + User_Id + "</UserId>" +
                         "<Password>" + Password + "</Password>" +
                         "<MobileNo>" + MobileNo + "</MobileNo>" +
                         "<MsgId>" + MsgId + "</MsgId>" +
                         "<SMS>" + SMS + "</SMS>" +
                         "<MsgHeader>" + MsgHeader + "</MsgHeader>" +
                      "</SendSMS>" +
                      "</soap:Body>" +
                      "</soap:Envelope>");
            return soapEnvelopeDocument;
        }


        public static dynamic GetResponseFromPostURL(string apiUrl, Dictionary<string, string> query_params = null, Dictionary<string, string> form_parameters = null, string jsonString = null, string bearerToken = null, Dictionary<string, string> header_parameters = null, bool log = true)
        {
            Console.WriteLine(apiUrl);

            dynamic result = null;
            string paramString = "";
            dynamic content = null;
            try
            {
                HttpClient client = new HttpClient();
              
                if (query_params != null)
                    paramString = GenrateQueryURI(query_params);
              
                if (!string.IsNullOrWhiteSpace(paramString))
                    apiUrl += "?" + paramString;
                if (form_parameters != null)//Attach Form-Data in Request
                    content = new FormUrlEncodedContent(form_parameters);
                else if (jsonString != null)//Attach Json Body in Request
                    content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                if (bearerToken != null) //Attach Bearer Token in Request if required
                    client.DefaultRequestHeaders.Authorization =
                                new AuthenticationHeaderValue("Bearer", bearerToken);
                if (header_parameters != null)//Attach Addtional Header-Data in Request
                    foreach (var header in header_parameters.Keys)
                        client.DefaultRequestHeaders.Add(header, header_parameters[header]);

                string apiLog = "API POST :: RequestURL = " + apiUrl + " | content=" + (jsonString != null ? jsonString : "NULL");


                HttpResponseMessage response = null;

                System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                if (content != null)
                    response = client.PostAsync(apiUrl, content).Result;
                else
                    response = client.PostAsync(apiUrl, null).Result;

                var responseString = response.Content.ReadAsStringAsync().Result;
                if (log)
                {
                    
                }
               
                result = JsonConvert.DeserializeObject(responseString);

            }
            catch (Exception ex)
            {
                result = null;
                
                //throw;
            }
            return result;

        }

        public static string GenrateQueryURI(Dictionary<string, string> query_params)
        {

            string paramString = string.Join("&",
                 query_params.Select(kvp =>
                     string.Format("{0}={1}", kvp.Key, HttpUtility.UrlEncode(kvp.Value))));

            return paramString;
        }


    }
}
