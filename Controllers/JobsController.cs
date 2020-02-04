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
  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;
    public JobsController(JobsService js)
    {
      _js = js;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(_js.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<Job> Get(int id)
    {
      try
      {
        return Ok(_js.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try
      {
        return Ok(_js.Create(newJob));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_js.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}