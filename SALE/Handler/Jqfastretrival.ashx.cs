using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft;
using BAL;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace gbms.Handler
{
    /// <summary>
    /// Summary description for Jqfastretrival
    /// </summary>
   
    public class Jqfastretrival : IHttpHandler
    {
        
        public void ProcessRequest(HttpContext context)
        {
            //  GetlistByprocedure()
            List<ConvSerialization> lstjsondata = new List<ConvSerialization>();
            List<customers> listcustomers = new List<customers>();
            BusssinessLogic Objbal = new BusssinessLogic();
            string term = context.Request["term"] ?? "";
            
            context.Response.ContentType = "text/plain";
            string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
            JavaScriptSerializer jsserialized = new JavaScriptSerializer();

            var result = JsonConvert.DeserializeObject<ConvSerialization>(strJson);
            
            // customers objUsr = des<customers>(strJson);
            try
            {
                customers objcust = new customers(); 
                objcust.ID = result.term;
                listcustomers= Objbal.GetlistByprocedure(objcust);
               
            }
            catch (Exception ex) {
         }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.Serialize(listcustomers);
            context.Response.Write(js.Serialize(listcustomers));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class ConvSerialization
    {
        public string term { get; set; }
    }
}