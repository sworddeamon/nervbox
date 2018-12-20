﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NervboxDeamon.Controllers.Base;
using NervboxDeamon.Services;

namespace NervboxDeamon.Controllers
{
  [AllowAnonymous]
  [Route("api/[controller]")]
  [ApiController]
  public class SoundController : NervboxBaseController<SoundController>
  {
    //injected
    private IHostingEnvironment Environment { get; }
    private ISoundService SoundService { get; }
    private IHttpContextAccessor Accessor { get; }

    public SoundController(ISoundService soundService, IHostingEnvironment environment, IHttpContextAccessor accessor)
    {
      this.SoundService = soundService;
      this.Environment = environment;
      this.Accessor = accessor;
    }

    [HttpGet]
    public IActionResult GetAllValidSounds()
    {
      return Ok(this.DbContext.Sounds.Where(s => s.Allowed == true && s.Valid == true).ToList());
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("{soundId}/play")]
    public IActionResult PlaySound(string soundId)
    {      

      try
      {
        this.SoundService.PlaySound(soundId, Accessor.HttpContext.Connection.RemoteIpAddress.ToString());

        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(500, new
        {
          Error = ex.Message,
          Stacktrace = ex.StackTrace
        });
      }
    }

  }
}