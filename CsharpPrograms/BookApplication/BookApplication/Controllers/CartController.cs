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
    public class CartController : ControllerBase
    {
        private readonly ICart _cart;
        public CartController(ICart cart)
        {
            _cart = cart;
        }

        [HttpPost]
        public async Task<IActionResult> AddCart(Guid BookId) 
        {
            string email = User.Identity.Name;
            if (!BookId.Equals("")&&email!=null) 
            {

                var result=await _cart.AddCartAsync(BookId, email);
                if (result > 0)
                    return Ok("Added to Cart");
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetCartBooks() 
        {
            string Message = null;
            try 
            {
                string email = User.Identity.Name;
                if (email != null) 
                {
                    var cartList=_cart.GetAllCartBooks(email);
                    if (cartList.Count != 0)
                        return Ok(cartList);
                    return NotFound("Not found any cart books");
                }
            }
            catch(Exception ex) 
            {
                Message = ex.Message.ToString();
            }
            return BadRequest(Message);
        }
    }
}