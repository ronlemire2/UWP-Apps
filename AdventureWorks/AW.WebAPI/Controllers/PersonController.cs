using AW.BL;
using AW.DAL.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AW.WebAPI.Controllers
{
    public class PersonController : ApiController
    {
        IBusinessLayer businessLayer;

        public PersonController() : this(new BusinessLayer()) {
        }

        public PersonController(IBusinessLayer businessLayer) {
            this.businessLayer = businessLayer;
        }

        public HttpResponseMessage GetAllPersons() {
            try {
                IList<PersonPOCO> personPOCOs = businessLayer.GetPersons().Take(200).ToList();
                return Request.CreateResponse<IList<PersonPOCO>>(HttpStatusCode.OK, personPOCOs);
            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, ex.Message);
            }
        }

        public HttpResponseMessage GetPerson(int id) {
            try {
                PersonPOCO personPOCO = businessLayer.GetPersonById(id);
                return Request.CreateResponse<PersonPOCO>(HttpStatusCode.OK, personPOCO);
            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        // For Edit and Delete
        public HttpResponseMessage PutPerson(PersonPOCO personPOCO) {
            if (ModelState.IsValid) {
                try {
                    int numRowsAffected = businessLayer.SavePersonGraph(personPOCO);
                    var response = Request.CreateResponse<int>(HttpStatusCode.OK, numRowsAffected);
                    return response;
                }
                catch (Exception ex) {
                    return Request.CreateErrorResponse(HttpStatusCode.NotModified, ex.Message);
                }
            }
            else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // For Add
        public HttpResponseMessage PostProduct(PersonPOCO personPOCO) {
            if (ModelState.IsValid) {
                try {
                    int numRowsAffected = businessLayer.SavePersonGraph(personPOCO);
                    var response = Request.CreateResponse<int>(HttpStatusCode.OK, numRowsAffected);
                    string uri = Url.Link("DefaultApi", new { BusinessEntityId = personPOCO.BusinessEntityID });
                    response.Headers.Location = new Uri(uri);
                    return response;
                }
                catch (Exception ex) {
                    return Request.CreateErrorResponse(HttpStatusCode.NotModified, ex.Message);
                }
            }
            else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}
