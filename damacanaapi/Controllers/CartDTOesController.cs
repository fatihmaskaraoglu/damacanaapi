using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using damacanaapi.Models;

namespace damacanaapi.Controllers
{
    public class CartDTOesController : ApiController
    {
        private damacanaapiContext db = new damacanaapiContext();

        // GET: api/CartDTOes
        public IQueryable<CartDTO> GetCartDTOes()
        {



            return db.CartDTOes;

        }


    }
}