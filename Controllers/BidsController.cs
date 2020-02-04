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


  }
}