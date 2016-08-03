using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurrencyData.BLL.Concrete;
using CurrencyData.Code.EFCurrencyData;


namespace CurrencyData.MvcApplicationUI.Controllers
{
    public class CurrencyController : Controller
    {
        //
        // GET: /Currency/
        //HANGİ ORM İLE ÇALIŞACAĞIMA BURDA KARAR VEREBİLİRİM. ENTITY FRAMEWORK KODLARININ OLDUĞU CurrencyDataDAL CLASS ını seçtim
        CurrencyManager _currencyManager = new CurrencyManager(new CurrencyDataDAL());
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 3 saniyede bir yenileniyor.Index.cs.html
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PartialViewResult RatesListPartial()
        {
            var currencyList = _currencyManager.GetLastExchangeRates();
            return PartialView("Partials/_RatesListPartial", currencyList);
        }
    }
}
