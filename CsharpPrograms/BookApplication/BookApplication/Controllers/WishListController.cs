using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishListController : ControllerBase
    {
        private readonly IWishList _wishList;

        public WishListController(IWishList wishList)
        {
            _wishList = wishList;
        }

        [HttpPost]
        [Route("AddWishList")]
        public async Task<IActionResult> AddWishList(Guid BookId)
        {
            string email = User.Identity.Name;
            if (!BookId.Equals("") && email != null)
            {

                var result = await _wishList.AddCartAsync(BookId, email);
                if (result > 0)
                    return Ok("Added to Cart");
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("GetWishLists")]
        public IActionResult GetWishLists()
        {
            string Message = null;
            try
            {
                string email = User.Identity.Name;
                if (email != null)
                {
                    var cartList = _wishList.GetAllCartBooks(email);
                    if (cartList.Count != 0)
                        return Ok(cartList);
                    return NotFound("Not found any cart books");
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
            }
            return BadRequest(Message);
        }

        [HttpGet, Route("UpdateSummary")]
        public async Task<IActionResult> OrdrerSummary(Guid BookID, Guid AddressID)
        {
            try
            {
                string email = User.Identity.Name;
                var result=await _wishList.OrdrerSummaryAsync(email, BookID, AddressID);
                if (result > 0)
                {
                    return this.Ok("Successfully Added");
                }
                return this.BadRequest("Failed");
            }
            catch (NullReferenceException ex)
            {
                return this.BadRequest("Failed");
            }
        }
    }
}