using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ExpediaExcercise2.Models;

namespace ExpediaExcercise2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /* This overload of the ShowHotelDeals takes no paramters.
         * It is the one called when the page is rendered for the first time
         */
        public ActionResult ShowHotelDeals()
        {
            Models.HotelDealsData objHotelDealsData = null;

            ViewBag.Message = "Your show hotel deals page.";
            objHotelDealsData = HotelDeals.GetHotelDeals();
            return View(objHotelDealsData.offers.Hotel);
        }

        /* 2nd overload of the ShowHotelDeals takes a parameter of type : Microsoft.AspNetCore.Http.IFormCollection
         * It also serves as the handler for the Search button.
         */
        [HttpPost]
        public ActionResult ShowHotelDeals(IFormCollection frmCollection)
        {
            Models.HotelDealsData objHotelDealsData = null;
            var objSearchAtts = new Models.SearchAttributes();
            DateTime TripStartDate = DateTime.MinValue;
            DateTime TripEndtDate = DateTime.MinValue;

            objSearchAtts.Destination = frmCollection["DestinationName"];
            objSearchAtts.MinTripStartDate = frmCollection["StartDate"];
            objSearchAtts.MaxTripStartDate = frmCollection["EndDate"];
            objSearchAtts.MinStarRating = frmCollection["MinStarRate"];
            objSearchAtts.MaxStarRating = frmCollection["MaxStarRate"];
            objSearchAtts.MinGuestRating = frmCollection["MinGuestRate"];
            objSearchAtts.MaxGuestRating = frmCollection["MaxGuestRate"];
            objSearchAtts.MinTotalRating = frmCollection["MinTotalRate"];
            objSearchAtts.MaxTotalRating = frmCollection["MaxTotalRate"];

            //Persist search criteria to be rendered back to the search form.
            TempData["Destination"] = objSearchAtts.Destination;
            TempData["StartDate"] = objSearchAtts.MinTripStartDate;
            TempData["EndDate"] = objSearchAtts.MaxTripStartDate;
            TempData["MinStarRate"] = objSearchAtts.MinStarRating;
            TempData["MaxStarRate"] = objSearchAtts.MaxStarRating;
            TempData["MinGuestRate"] = objSearchAtts.MinGuestRating;
            TempData["MaxGuestRate"] = objSearchAtts.MaxGuestRating;
            TempData["MinTotalRate"] = objSearchAtts.MinTotalRating;
            TempData["MaxTotalRate"] = objSearchAtts.MaxTotalRating;

            if (objSearchAtts.MinTripStartDate != String.Empty)
                TripStartDate = DateTime.Parse(objSearchAtts.MinTripStartDate);
            if (objSearchAtts.MaxTripStartDate != String.Empty)
                TripEndtDate = DateTime.Parse(objSearchAtts.MaxTripStartDate);

            objSearchAtts.lengthOfStay = (int)(TripEndtDate.Subtract(TripStartDate).TotalDays);

            objHotelDealsData = HotelDeals.GetHotelDeals(objSearchAtts);



            if (objHotelDealsData == null)
                return View();
            else
                return View(objHotelDealsData.offers.Hotel);
        }
    }
}
