using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Net;

namespace ExpediaExcercise2.Controllers
{
    /* for simpicty , I made this class as static */
    public static class HotelDeals
    {
        public static Models.HotelDealsData GetHotelDeals()
        {
            var objSearchAtts = new Models.SearchAttributes();
            objSearchAtts.GetAllDeals = true;
            return GetHotelDeals(objSearchAtts);

        }

        /* Make the query string based on the search criteria entered by the user . This query string will be added to the API call to filter */
        /* the results */
        private static string MakeQueryString(Models.SearchAttributes oSearchAtts)
        {
            string queryString = string.Empty;




            //add destination if a value is entered
            if (oSearchAtts.Destination.Length > 0)
                queryString = "&destinationName=" + oSearchAtts.Destination;

            // add minTripStartDate if a value is entered
            if (oSearchAtts.MinTripStartDate.Length > 0)
            {
                //..but first change date format to yyyy-mm-dd as this what the API expects
                oSearchAtts.MinTripStartDate = DateTime.Parse(oSearchAtts.MinTripStartDate).ToString("yyyy-MM-dd");
                queryString += "&minTripStartDate=" + oSearchAtts.MinTripStartDate;
            }

            // add minTripStartDate if a value is entered
            if (oSearchAtts.MaxTripStartDate.Length > 0)
            {
                //..but first change date format to yyyy-mm-dd as this what the API expects
                oSearchAtts.MaxTripStartDate = DateTime.Parse(oSearchAtts.MaxTripStartDate).ToString("yyyy-MM-dd");
                queryString += "&maxTripStartDate=" + oSearchAtts.MaxTripStartDate;
            }
            // add lengthOfStay if a value is entered
            if (oSearchAtts.lengthOfStay > 0)
                queryString += "&max.lengthOfStay=" + oSearchAtts.lengthOfStay.ToString();
            // add minStarRating if a value is entered
            if (oSearchAtts.MinStarRating.Length > 0)
                queryString += "&minStarRating=" + oSearchAtts.MinStarRating;
            // add maxStarRating if a value is entered
            if (oSearchAtts.MaxStarRating.Length > 0)
                queryString += "&maxStarRating=" + oSearchAtts.MaxStarRating;
            // add minTotalRate if a value is entered
            if (oSearchAtts.MinTotalRating.Length > 0)
                queryString += "&minTotalRate=" + oSearchAtts.MinTotalRating;
            // add maxTotalRate if a value is entered
            if (oSearchAtts.MaxTotalRating.Length > 0)
                queryString += "&maxTotalRate=" + oSearchAtts.MaxTotalRating;
            // add minGuestRating if a value is entered
            if (oSearchAtts.MinGuestRating.Length > 0)
                queryString += "&minGuestRating=" + oSearchAtts.MinGuestRating;
            // add maxGuestRating if a value is entered
            if (oSearchAtts.MaxGuestRating.Length > 0)
                queryString += "&maxGuestRating=" + oSearchAtts.MaxGuestRating;

            return queryString;
        }


        /* Takes an object that contains all the search fields that were added by the user. If the attributes */
        /* GetAllDeals if true, then no search criteria was provided. */
        public static Models.HotelDealsData GetHotelDeals(Models.SearchAttributes oSearchAtts)
        {
            Models.HotelDealsData objHotelDealsData = null;
            string url = "https://offersvc.expedia.com/offers/v2/getOffers?scenario=deal-finder&page=foo&uid=foo&productType=Hotel";

            try
            {
                if (!oSearchAtts.GetAllDeals)
                {
                    string queryString = MakeQueryString(oSearchAtts);
                    url += queryString;
                }
                var syncClient = new WebClient();
                var content = syncClient.DownloadString(url);

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Models.HotelDealsData));
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
                {
                    objHotelDealsData = (Models.HotelDealsData)serializer.ReadObject(ms);
                }

                if (objHotelDealsData.offers.Hotel.Count > 0)
                    foreach (var Hotel in objHotelDealsData.offers.Hotel)
                    {
                        //  this loop in case you need to do an processing on the returned returned data before send it back to  the controller.

                    }
                return objHotelDealsData;
            }
            catch
            {
                //Something went wrong
                //ToDO: Show an error message to the user.
                return null;
            }
        }
    }
}
