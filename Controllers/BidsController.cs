using System;
using System.Collections.Generic;
using System.Security.Claims;
using contractors.Models;
using contractors.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;



namespace contractors.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BidsController : ControllerBase
  {
    private readonly BidsService _bs;
    public BidsController(BidsService bs)
    {
      _bs = bs;
    }



    //by job id
    // [HttpGet("{id}")]
    // public ActionResult<Bid> GetBids(int id)
    // {
    //   try
    //   {
    //     return Ok(_bs.GetContractorBids(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpPost]
    public ActionResult<string> AddBidToJob([FromBody] Bid bid)
    {
      try
      {
        return Ok(_bs.AddContractor(bid.ContractorId, bid.JobId, bid.Price));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    // [HttpPut]
    // public ActionResult<string> RemoveBidFromJob([FromBody] Bid bid)
    // {
    //   try
    //   {
    //     return Ok(_bs.RemoveContractor(bid));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
  }
}