using DAL.Context;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiService.Controllers
{
    public class CityController : ApiController
    {
        AppDbContext db = new AppDbContext();

       

        public HttpResponseMessage Get(string cityname = "all")
        {
            IQueryable<City> query = db.Cities;
            cityname = cityname.ToLower();
            switch (cityname)
            {
                case "all":
                    break;
                case "adana":
                case "adıyaman":
                case "afyonkarahisar":
                    query = query.Where(x => x.CityName.ToLower() == cityname);
                    break;
                default:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"{cityname} is not a valid city name.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, query.ToList());
        }
        public HttpResponseMessage GetCity(int id) 
        {
            City city = db.Cities.Find(id);
            if (city==null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Şehir bulunamadı");


            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, city);
            }



        }
       

        public HttpResponseMessage CreateCity(City city)
        {
            if (city !=null)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, city);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Şehir bulunamadı");
            }
        }

    }

}
