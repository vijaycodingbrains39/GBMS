using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gbms.Models;
using System.Data;
using System.Web.Script.Serialization;
using BAL;
using System.Web.UI;
using Newtonsoft.Json;

namespace gbms.Controllers
{
    public class SaleController : Controller
    {
        //DataSet ds = new DataSet();
        //DataTable dt = new DataTable();
        // BusssinessLogic objbal = new BusssinessLogic();
        public SaleController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getdata()
        {
            try
            {
                List<salesResp> lstsalesresp = new List<salesResp> {

            new salesResp {

                ID="ID",
                Name="Name"
            }
            };
                List<products> lstprojects = new List<products>
            {
                new products {
                MfgPartNum= "MfgPartNum",
                ID="id",
                Description="description"
            }
            };

                List<EnteredBy> lstenteredBy = new List<EnteredBy> {

                 new EnteredBy{

                      SystemName="SystemName",
                      Username="Username",

                 }

            };

                ViewData["Products"] = lstprojects;
                ViewData["salesresp"] = lstsalesresp;
                ViewData["lstenteredBy"] = lstenteredBy;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            TempData["actiontransferdata"] = TempData["mfgpartcall"] == null ? "" : TempData["mfgpartcall"];
            TempData["itemnumbercalltransferdata"] = TempData["itemnumbercall"] == null ? "" : TempData["itemnumbercall"];
            TempData["salesresptransferdata"] = TempData["salesrespcall"] == null ? "" : TempData["salesrespcall"];

            return View("Getdata");
        }

        [HttpGet]
        public JsonResult tabledata(string tblname)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            List<Groups> lstgrp = new List<Groups>();
            try
            {
                lstgrp = objbal.Bltbldata(tblname);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(lstgrp, JsonRequestBehavior.AllowGet);
        }    

        [HttpGet]
        public JsonResult tblcountry() {


            BusssinessLogic objbal = new BusssinessLogic();
            List<country> lstgrp = new List<country>();
            try
            {
                lstgrp = objbal.blcountry();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(lstgrp, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult tblstate()
        {


            BusssinessLogic objbal = new BusssinessLogic();
            List<State> lstgrp = new List<State>();
            try
            {
                lstgrp = objbal.blState();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(lstgrp, JsonRequestBehavior.AllowGet);
        }









        [HttpGet]
        public JsonResult tableDevisiondata(string tblname, string Column1, string Column2)
        {
            BusssinessLogic objbal = new BusssinessLogic();

            List<Divisions> lstgrp = new List<Divisions>();
            try
            {
                lstgrp = objbal.BltblDivisiondata(tblname, Column1, Column2);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(lstgrp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult tableTermdata(string tblname, string Column1, string Column2)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            List<PayTerm> lstgrp = new List<PayTerm>();
            try
            {
                lstgrp = objbal.Bltbltermdata(tblname, Column1, Column2);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(lstgrp, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult tableDepartmentdata(string tblname, string Column1, string Column2)
        {
            BusssinessLogic objbal = new BusssinessLogic();

            List<Department> lstgrp = new List<Department>();
            lstgrp = objbal.BltblDepartmentdata(tblname, Column1, Column2);
            return Json(lstgrp, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetdataByCompanyID(string CustomerID)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            List<customers> lstcustomers = new List<customers>();
            try
            {
                lstcustomers = objbal.BlGetdataByCompanyID(CustomerID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(lstcustomers, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult tableCurrencydata(string tblname, string Column1, string Column2)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            List<CurrencyTypes> lstgrp = new List<CurrencyTypes>();
            lstgrp = objbal.BltblCurrencydata(tblname, Column1, Column2);
            return Json(lstgrp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult tabletaxdata(string tblname, string Column1, string Column2)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            List<Taxes> lstgrp = new List<Taxes>();
            lstgrp = objbal.Bltbltaxdata(tblname, Column1, Column2);
            return Json(lstgrp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult datawithclause(string tblname, string clause)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            List<Groups> lstgrp = new List<Groups>();
            lstgrp = objbal.Bltbldatawithparam(tblname, clause);
            return Json(lstgrp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Carrierdata(string tblname)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            List<Groups> lstgrp = new List<Groups>();
            lstgrp = objbal.carrierdata(tblname);
            return Json(lstgrp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult HitDataToFilter(string OrderStatus = "", string WrhsID = "", string NewShipToID = "", string ShipName = "", string ShipPostalCode = "", string OrderDate = "", string SalesRepID = "", string PONumber = "", string AltPONumber = "", string CustomerID = "", string ID = "")
        {
            BusssinessLogic objbal = new BusssinessLogic();
            var jsonSerialiser = new JavaScriptSerializer();
            var json = "";
            try
            {
                List<SalesFilterFcls> lstsalesflr = new List<SalesFilterFcls>();
                SalesFilterFcls objsalesfltr = new SalesFilterFcls();
                objsalesfltr.AltPONumber = AltPONumber == "null" ? "" : AltPONumber;
                objsalesfltr.ShipName = ShipName == "null" ? "" : ShipName;
                objsalesfltr.SalesRepID = SalesRepID == "null" ? "" : SalesRepID;
                objsalesfltr.WrhsID = WrhsID == "null" ? "" : WrhsID;
                objsalesfltr.NewShipToID = NewShipToID == "null" ? "" : NewShipToID;
                objsalesfltr.ShipPostalCode = ShipPostalCode == "null" ? "" : ShipPostalCode;
                objsalesfltr.OrderDate = OrderDate == "null" ? "" : OrderDate;
                objsalesfltr.OrderStatus = OrderStatus == "null" ? "" : OrderStatus;
                objsalesfltr.ID = ID == "null" ? "" : ID;
                objsalesfltr.CustomerID = CustomerID == "null" ? "" : CustomerID;
                objsalesfltr.PONumber = PONumber == "null" ? "" : PONumber;
                lstsalesflr = objbal.Filtersalesdata(objsalesfltr);

                json = jsonSerialiser.Serialize(lstsalesflr);

            }
            catch (Exception Ex)
            {

            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Searchdata(string OrderID = "")
        {
            BusssinessLogic objbal = new BusssinessLogic();

            var json = "";
            var jsonSerialiser = new JavaScriptSerializer();

            try
            {
                List<SalesFilterFcls> lstsalesflr = new List<SalesFilterFcls>();
                lstsalesflr = objbal.SearchBYID(OrderID);
                json = jsonSerialiser.Serialize(lstsalesflr);
            }
            catch (Exception ex)
            {

            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult MfgpartNumber(string tblname, string colname)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            var json = "";
            var jsonSerialiser = new JavaScriptSerializer();

            try
            {
                List<ProductMFgpartdescription> lstmfgpartdis = new List<ProductMFgpartdescription>();
                lstmfgpartdis = objbal.Bltbldatawithparammfgpart(tblname, colname);
                json = jsonSerialiser.Serialize(lstmfgpartdis);
            }
            catch (Exception ex)
            {

            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }



        public ActionResult MfgpartNumbercall(string tblname, string colname)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            var json = "";
            var jsonSerialiser = new JavaScriptSerializer();
            List<ProductMFgpartdescription> lstmfgpartdis = new List<ProductMFgpartdescription>();

            try
            {

                lstmfgpartdis = objbal.Bltbldatawithparammfgpart(tblname, colname);

            }
            catch (Exception ex) { }
            return View(lstmfgpartdis);
        }


        public ActionResult FinancialData() { 

            BusssinessLogic objbal = new BusssinessLogic();
            List<Financial> lstfinancials = new List<Financial>();

            try {

                lstfinancials= objbal.Bltbldatawithparamfinancial();

            }
            catch (Exception ex) {
                throw ex;
            }

            return View(lstfinancials);
        }

        public ActionResult Itemnumber(string tblname, string id, string description)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            var json = "";
            var jsonSerialiser = new JavaScriptSerializer();
            List<ProductMFgpartdescription> lstmfgpartdis = new List<ProductMFgpartdescription>();
            try
            {

                lstmfgpartdis = objbal.Bltbldatawithparammfgpart(tblname, id, description);

            }
            catch (Exception ex) { }
            return View(lstmfgpartdis);
        }

        public ActionResult salesResp(string tblname, string salesrespid, string salesname)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            var json = "";
            var jsonSerialiser = new JavaScriptSerializer();
            List<salesResp> lstmfgpartdis = new List<salesResp>();

            try
            {
                lstmfgpartdis = objbal.Bltbldatawithparamsalesresp(tblname, salesrespid, salesname);
            }
            catch (Exception ex) { }
            return View(lstmfgpartdis);
        }

        public ActionResult EnteredBy(string tblname, string UserId, string Systemname)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            var json = "";
            var jsonSerialiser = new JavaScriptSerializer();

            List<EnteredBy> lstenteredBy = new List<EnteredBy>();

            try
            {

                lstenteredBy = objbal.BltbldatawithparamEnteredBy(tblname, UserId, Systemname);
            }
            catch (Exception ex) { }
            return View(lstenteredBy);
        }
        // sale/actioncall? modelItem = 1DISCCASE
        public ActionResult mfgpartcall(string modelItem)
        {

            try
            {
                TempData["mfgpartcall"] = modelItem;

            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Getdata");
        }
        public ActionResult itemnumbercall(string modelItem)
        {
            try
            {
                TempData["itemnumbercall"] = modelItem;

            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Getdata");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelItem"></param>
        /// <returns></returns>
        public ActionResult saleRespcall(string modelItem)
        {
            try
            {
               TempData["salesrespcall"] = modelItem;
            }
            catch (Exception ex) { }
            return RedirectToAction("Getdata");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Documnettype"></param>
        /// <param name="CustomerServiceRepID"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult opensaleorderCntrl(string Documnettype, string CustomerServiceRepID, string OrderID)
        {

            //string Documnettype=Request["Documnettype"];
            //string CustomerServiceRepID = Request["CustomerServiceRepID"];
            //string OrderID = Request["OrderID"];
            BusssinessLogic objbal = new BusssinessLogic();
            List<OrderAtTable> lstdata = new List<OrderAtTable>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {

                ds = objbal.BaldsgetdataSp(Documnettype, CustomerServiceRepID, OrderID);
            }
            catch (Exception Ex)
            { 
                throw Ex;
            }
            dt = ds.Tables[0];
            lstdata.Add(
            new OrderAtTable
            {
            Company = dt.Rows[0]["Company"].ToString(),
            ID = dt.Rows[0]["ID"].ToString(),
            OrderDate = dt.Rows[0]["orderdate"].ToString()
            }

           );
            //var list = (from DataRow dr in dt.Rows
            //                   select new OrderAtTable
            //                   {
            //                       ID = dr["ID"].ToString(),
            //                       Company = dr["Company"].ToString(),
            //                       OrderDate = dr["OrderDate"].ToString()
            //                    }).ToList();
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            ViewData["OrderPlacedData"] = ds;
            ViewBag.OrderID = OrderID;
            //ViewData["OrderID"] = OrderID;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Documnettype"></param>
        /// <param name="CustomerServiceRepID"></param>
        /// <returns></returns>
        public ActionResult PlaceOrder(string Documnettype, string CustomerServiceRepID)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            List<OrderAtTable> lstdata = new List<OrderAtTable>();
            try
            {
                ds = objbal.BaldsgetdataWithorderIDSp(Documnettype, CustomerServiceRepID);
                dt = ds.Tables[0];
                lstdata.Add(
                 new OrderAtTable
                 {
                     Company = dt.Rows[0]["Company"].ToString(),
                     ID = dt.Rows[0]["ID"].ToString(),
                     OrderDate = dt.Rows[0]["orderdate"].ToString()
                 }

                 );
                var list = (from DataRow dr in dt.Rows
                            select new OrderAtTable
                            {
                                ID = dr["ID"].ToString(),
                                Company = dr["Company"].ToString(),
                                OrderDate = dr["OrderDate"].ToString()
                            }).ToList();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            ViewData["OrderdataWithNewID"] = ds;  //ViewData["NewOrderID"]
            ViewBag.neworderId = ds.Tables[0].Rows[0]["OrderID"];// ds.Tables[0].Rows[0]["OrderID"];
            return View("opensaleorderCntrl");

        }

        public JsonResult Taxchangerate(string  taxID) {
            string json = "";
            BusssinessLogic objbal = new BusssinessLogic();
            List<Taxes> lsttax = new List<Taxes>();
            var jsonSerialiser = new JavaScriptSerializer();
            try {

                lsttax=objbal.Bltbltaxchangedata(taxID);

                json=jsonSerialiser.Serialize(lsttax);
   }
            catch (Exception ex) {

                throw ex;
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }



        public JsonResult currencyexchange(string CurrencyId) {

            string json = "";
            BusssinessLogic objbal = new BusssinessLogic();
            List<CurrencyTypes> lstcurrency = new List<CurrencyTypes>();
            var jsonSerialiser = new JavaScriptSerializer();
            try
            {
                 lstcurrency = objbal.blcurrency(CurrencyId);
                json = jsonSerialiser.Serialize(lstcurrency);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(json, JsonRequestBehavior.AllowGet);

        }


        //public JsonResult checkcutomer(string customer)
        //{

        //    string json = "";
        //    BusssinessLogic objbal = new BusssinessLogic();
        //    List<customers> lstcurrency = new List<customers>();
        //    var jsonSerialiser = new JavaScriptSerializer();
        //    try
        //    {
        //        lstcurrency = objbal.blcurrency(customer);
        //        json = jsonSerialiser.Serialize(lstcurrency);

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //    return Json(json, JsonRequestBehavior.AllowGet);

        //}






        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public ActionResult GetdataByOrderId(string OrderId)
        { 
            BusssinessLogic objbal = new BusssinessLogic();
            List<Orders> lstordercls = new List<Orders>();
            try
            {
        lstordercls = objbal.BalGetdataByOrderId(OrderId);
      }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(lstordercls);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public PartialViewResult Orderdataship(string orderID)
        {
            DataTable dt = new DataTable();
            BusssinessLogic objbal = new BusssinessLogic();
            List<Orders> lstord = new List<Orders>();
        try
            {

                dt = objbal.BalGetdataByOrderIddatatableship(orderID);
        if (dt.Rows.Count > 0)
        {
        foreach (DataRow dr in dt.Rows)
                    {
                        lstord.Add(
                        new Orders
                        {
                            NewShipToID = dr["NewShipToID"].ToString()==null?"": dr["NewShipToID"].ToString(),
                            ShipCompany = dr["ShipCompany"].ToString() == null ? "" : dr["ShipCompany"].ToString(),
                            ShipAddress = dr["ShipAddress"].ToString() == null ? "" : dr["ShipAddress"].ToString(),
                            ShipPostalCode = dr["ShipPostalCode"].ToString() == null ? "" : dr["ShipPostalCode"].ToString(),
                            ShipName = dr["ShipName"].ToString() == null ? "" : dr["ShipName"].ToString(),
                            ShipPhone = dr["ShipPhone"].ToString() == null ? "" : dr["ShipPhone"].ToString(),
                            ShipmentAccountNo = dr["ShipmentAccountNo"].ToString() == null ? "" : dr["ShipmentAccountNo"].ToString(),
                            FOB = dr["FOB"].ToString() == null ? "" : dr["FOB"].ToString(),
                            FOBDescription = dr["FOBDescription"].ToString() == null ? "" : dr["FOBDescription"].ToString(),
                            ThirdPartyShipID = dr["ThirdPartyShipID"].ToString() == null ? "" : dr["ThirdPartyShipID"].ToString(),
                            ShipCountry= dr["ShipCountry"].ToString() == null ? "" : dr["ShipCountry"].ToString(),
                            ShipCity= dr["ShipCity"].ToString() == null ? "" : dr["ShipCity"].ToString(),
                            ShipmentTerms= dr["ShipmentTerms"].ToString() == null ? "" : dr["ShipmentTerms"].ToString(),
                            ShipVia= dr["ShipVia"].ToString() == null ? "" : dr["ShipVia"].ToString(),
                            FOBPoint= dr["FOBPoint"].ToString() == null ? "" : dr["FOBPoint"].ToString(),
                            ShipEmail= dr["ShipEmail"].ToString()==null?"": dr["ShipEmail"].ToString(),
                            RMAExpirationDays = Convert.ToInt32(dr["RMAExpirationDays"].ToString())
                        }
                      );

                    }

        }
                else {

                    lstord.Add(
                     new Orders
                     {

                         NewShipToID ="",
                         ShipCompany ="",
                         ShipAddress = "",
                         ShipPostalCode ="",
                         ShipName ="",
                         ShipPhone = "",
                         ShipmentAccountNo = "",
                         FOB = "",
                         FOBDescription = "",
                         ThirdPartyShipID ="",
                         RMAExpirationDays = 0
                     }
                   );

                }

                }
            catch (Exception ex)
            {

                throw ex;
            }
        return PartialView(lstord);
        }

        public PartialViewResult Linestab() {

        return PartialView();
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult newsalesId()
        {

            DataTable dt = new DataTable();
            BusssinessLogic objbal = new BusssinessLogic();
            List<string> getid = new List<string>();
            string json = "";
            string jsondata = "";
    try
            {

                json = Session["NewOrderID"].ToString();
                getid.Add(json);
                jsondata = JsonConvert.SerializeObject(getid);

            }
            catch (Exception ex)
            {

            throw ex; 
            }

            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }

        public PartialViewResult CCSharp()
        {
               return PartialView();

        }

        
        public PartialViewResult Lines(string orderID) {

            DataTable dt = new DataTable();
            BusssinessLogic objbal = new BusssinessLogic();
            List<Lines> lstline = new List<Lines>();
            try
            {
            
             //BalGetdataByOrderIdLines      
             //ProductID Qty price extPrice    uom Description
                dt = objbal.BalGetdataByOrderIdLines(orderID);
                 if (dt.Rows.Count > 0)
                {
                 foreach (DataRow dr in dt.Rows)
                 {
                   lstline.Add(
                            new Lines
                                  {
                                      Description = dr["Description"].ToString(),
                                      ProductID = dr["ProductID"].ToString(),
                                      Qty = dr["Qty"].ToString(),
                                      Price = dr["Price"].ToString(),
                                      ExtPrice = dr["ExtPrice"].ToString(),
                                      UOM = dr["UOM"].ToString(),
                                      Discount= dr["Discount"].ToString(),
                                      WrhsID = dr["WrhsID"].ToString(),
                                      Line=dr["Line"].ToString()
                                  }

                            );

                    }
            }
            else {
            lstline.Add(
                        new Lines
                                 {

                                     Description = "",
                                     ProductID ="",
                                     Qty ="",
                                     Price = "",
                                     ExtPrice = "",
                                     UOM = "",
                                     Discount="",
                                     WrhsID="",
                                     Line=""
                                 }

            );

                }

            }
            catch (Exception ex) {

                throw ex;
            }

            return PartialView(lstline);

        }

        public PartialViewResult Financial() {

            DataTable dt = new DataTable();
            BusssinessLogic objbal = new BusssinessLogic();
            List<Financial> lstfinancial = new List<Financial>();
            try {
                dt = objbal.BalGetdataByOrderIddatatableFinancial();
                if (dt.Rows.Count > 0)
                {

    foreach (DataRow dr in dt.Rows)
                    {
                        lstfinancial.Add(
                         new Financial
                         {
                            GLAccountName = dr["GLAccountName"].ToString(),
                            GLAccountNumber = dr["GLAccountNumber"].ToString(),
                            GLAccountType = dr["GLAccountType"].ToString(),
                            GLReportLevel = dr["GLReportLevel"].ToString()
                         }

                       );
                    }
    }
                else {

                    lstfinancial.Add(
                         new Financial
                         {
                             GLAccountName = "",
                             GLAccountNumber = "",
                             GLAccountType = "",
                             GLReportLevel = ""
                         }
                       );

                 }
            }
            catch (Exception ex) {


            }

            return PartialView(lstfinancial);
        }

        public PartialViewResult Commission(string orderID)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            List<CommissionDetails> lstcommdtl = new List<CommissionDetails>();
            DataTable dt = new DataTable();
            try
            {
                dt = objbal.BalgetdataForcommission(orderID);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        lstcommdtl.Add(
                                            new CommissionDetails
                                            {
                                                CplanName = dr["CplanName"].ToString() == null ? "" : dr["CplanName"].ToString(),
                                                EstCommission = dr["EstCommission"].ToString() == null ? "" : dr["EstCommission"].ToString(),
                                                PayPercentAtApproval = dr["PayPercentAtApproval"].ToString() == null ? "" : dr["PayPercentAtApproval"].ToString(),
                                                PayPercentAtShipping = dr["PayPercentAtShipping"].ToString() == null ? "" : dr["PayPercentAtShipping"].ToString(),
                                                Rate = dr["Rate"].ToString() == null ? "" : dr["Rate"].ToString(),
                                                salesresponsible = dr["salesresponsible"].ToString() == null ? "" : dr["salesresponsible"].ToString(),
                                                Split = dr["Split"].ToString() == null ? "" : dr["Split"].ToString()
                                            }
                                            );

                    }


                }
                else
                {

                    lstcommdtl.Add(

                          new CommissionDetails
                          {
                               CplanName = "",
                              EstCommission = "",
                              PayPercentAtApproval = "",
                              PayPercentAtShipping = "",
                              Rate = "",
                              salesresponsible = "",
                              Split = ""


                          }

                        );

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
            return PartialView(lstcommdtl);
        }

        public JsonResult GetdataByOrderIdjson(string OrderId)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            List<Orders> lstordercls = new List<Orders>();

        DataTable dt = new DataTable();
        try
            { 
             
                dt = objbal.BalGetdataByOrderIddatatable(OrderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            var jsondata = JsonConvert.SerializeObject(dt);
            //  return View(lstordercls);
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
     
        public JsonResult savedata(string ID, string OrderDate, string PONumber, string AltPONumber, string ArrivalDate, string OrderTermsCode, string SalesTaxCodeID, string CurrencyID, string CurrencyExchangeRate, string ContactName, string ContactPhone, string ContactFax, string ContactEmail, string WrhsID, string DepartmentID, string BackOrder, string PartialOk, string DivisionID, string Priority, string CustomerID, string ShipAddress, string ShipCity, string ShipRegion, string ShipCountry, string ShipPostalCode, string OrderCompany, string OrderStatus, int salespreapproved , int Loaner, int IsAutoSalesOrderShipInvoicePreApproved)
        {
            BusssinessLogic objbal = new BusssinessLogic();
            DataSet ds = new DataSet();
            string jsondata = "";
            try
            {
                ds = objbal.Balsavedata(ID, OrderDate, PONumber, AltPONumber, ArrivalDate, OrderTermsCode, SalesTaxCodeID, CurrencyID, CurrencyExchangeRate, ContactName, ContactPhone, ContactFax, ContactEmail, WrhsID, DepartmentID, BackOrder, PartialOk, DivisionID, Priority, CustomerID, ShipAddress, ShipCity, ShipRegion, ShipCountry, ShipPostalCode, OrderCompany, OrderStatus, salespreapproved,Loaner,IsAutoSalesOrderShipInvoicePreApproved);
            }
            catch (Exception ex)
            { 

            }
            //var salesList = ds.Tables[0].AsEnumerable().Select(dataRow => new SalesOrders
            //{
            //    OrderDate = dataRow.Field<string>("OrderDate"),
            //    Company = dataRow.Field<string>("Company"),
            //    Id = dataRow.Field<string>("ID")   
            //}).ToList();
            jsondata = JsonConvert.SerializeObject(ds, Formatting.Indented);
            ViewData["NewOrderEntry"] = ds;
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

    public JsonResult ShipdataInsupd(string NewShipToID, string ShipCompany, string ShipAddress, string ShipPostalCode, string ShipName, string ShipPhone, string ShipmentAccountNo, string FOB, string FOBDescription, string ThirdPartyShipID, string RMAExpirationDays, string OrderStatus, string orderID ,string shipingmethod,string ShipCountry,string shipState,string shippingterm)
        { 
            BusssinessLogic objbal = new BusssinessLogic();
            DataSet ds = new DataSet();
            string jsondata = "";
            try
            {
                ds = objbal.ShipdataInsupd(NewShipToID, ShipCompany, ShipAddress, ShipPostalCode, ShipName, ShipPhone, ShipmentAccountNo, FOB, FOBDescription, ThirdPartyShipID, RMAExpirationDays, OrderStatus, orderID, shipingmethod, ShipCountry, shipState, shippingterm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            jsondata = JsonConvert.SerializeObject(ds, Formatting.Indented);
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }
    }

    //class SalesOrders
    //{
    //    public string OrderDate { get; set; }
    //    public string Company { get; set; }
    //    public string Id { get; set; }
    //}
}