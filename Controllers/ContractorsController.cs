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
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _cs;
    public ContractorsController(ContractorsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Contractor>> Get()
    {
      try
      {
        return Ok(_cs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
      try
      {
        return Ok(_cs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [Authorize]
    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor newContractor)
    {
      try
      {
        return Ok(_cs.Create(newContractor));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_cs.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}