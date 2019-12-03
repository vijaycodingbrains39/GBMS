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

namespace gbms.SALE.Handler
{
    /// <summary>
    /// Summary description for ShipTocustomer
    /// </summary>
    public class ShipTocustomer : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //  GetlistByprocedure()
            List<ConvSerialization> lstjsondata = new List<ConvSerialization>();
            List<ShipToCustomer> listcustomers = new List<ShipToCustomer>();
            BusssinessLogic Objbal = new BusssinessLogic();
            string term = context.Request["term"] ?? "";

            context.Response.ContentType = "text/plain";
            string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
            JavaScriptSerializer jsserialized = new JavaScriptSerializer();

            var result = JsonConvert.DeserializeObject<ConvSerialization>(strJson);

            // customers objUsr = des<customers>(strJson);
            try
            {
                ShipToCustomer objship = new ShipToCustomer();
                objship.ID = result.term;
                listcustomers = Objbal.GetlistByprocedureshipTocustomer(objship);

            }
            catch (Exception ex)
            {
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

  
}