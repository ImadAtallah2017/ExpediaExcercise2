using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace ExpediaExcercise2.Models
{
    [DataContract]
    public class HotelDealsData
    {
        [DataMember]
        public OfferInfo offerInfo { get; set; }
        [DataMember]
        public UserInfo userInfo { get; set; }
        [DataMember]
        public Offers offers { get; set; }
    }

    public class OfferInfo
    {
        public string siteID { get; set; }
        public string language { get; set; }
        public string currency { get; set; }
        public string userSelectedCurrency { get; set; }
    }

    public class Persona
    {
        public string personaType { get; set; }
    }

    public class UserInfo
    {
        public Persona persona { get; set; }
        public string userId { get; set; }
    }

    public class OfferDateRange
    {
        public List<int> travelStartDate { get; set; }
        public List<int> travelEndDate { get; set; }
        public int lengthOfStay { get; set; }
    }

    public class Destination
    {
        public string regionID { get; set; }
        public string associatedMultiCityRegionId { get; set; }
        public string longName { get; set; }
        public string shortName { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string tla { get; set; }
        public string nonLocalizedCity { get; set; }
    }

    public class HotelInfo
    {
        public string hotelId { get; set; }
        public string hotelName { get; set; }
        public string localizedHotelName { get; set; }
        public string hotelDestination { get; set; }
        public string hotelDestinationRegionID { get; set; }
        public string hotelLongDestination { get; set; }
        public string hotelStreetAddress { get; set; }
        public string hotelCity { get; set; }
        public string hotelProvince { get; set; }
        public string hotelCountryCode { get; set; }
        public double hotelLatitude { get; set; }
        public double hotelLongitude { get; set; }
        public string hotelStarRating { get; set; }
        public double hotelGuestReviewRating { get; set; }
        public int hotelReviewTotal { get; set; }
        public string hotelImageUrl { get; set; }
        public bool vipAccess { get; set; }
        public bool isOfficialRating { get; set; }
    }

    public class HotelPricingInfo
    {
        public double averagePriceValue { get; set; }
        public double totalPriceValue { get; set; }
        public double crossOutPriceValue { get; set; }
        public double originalPricePerNight { get; set; }
        public string currency { get; set; }
        public double percentSavings { get; set; }
        public bool drr { get; set; }
    }

    public class HotelUrls
    {
        public string hotelInfositeUrl { get; set; }
        public string hotelSearchResultUrl { get; set; }
    }

    public class Hotel
    {
        public OfferDateRange offerDateRange { get; set; }
        public Destination destination { get; set; }
        public HotelInfo hotelInfo { get; set; }
        public HotelPricingInfo hotelPricingInfo { get; set; }
        public HotelUrls hotelUrls { get; set; }
    }

    public class Offers
    {
        public List<Hotel> Hotel { get; set; }
    }

    public struct SearchAttributes
    {
        public bool GetAllDeals { get; set; }
        public string Destination { get; set; }
        public string MinTripStartDate { get; set; }
        public string MaxTripStartDate { get; set; }
        public string MinStarRating { get; set; }
        public string MaxStarRating { get; set; }
        public string MinTotalRating { get; set; }
        public string MaxTotalRating { get; set; }
        public string MinGuestRating { get; set; }
        public string MaxGuestRating { get; set; }
        public int lengthOfStay { get; set; }

    }
}
