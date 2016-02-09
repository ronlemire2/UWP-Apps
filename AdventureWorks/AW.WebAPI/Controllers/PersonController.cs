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

        // TODO Unity.WebAPI
        public PersonController(IBusinessLayer businessLayer) {
            this.businessLayer = businessLayer;
        }

        public IList<PersonPOCO> Get() {
            return businessLayer.GetAllPeople().Take(200).ToList();
        }
    }
}
