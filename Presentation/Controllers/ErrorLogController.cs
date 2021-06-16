using Application.Interface;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorLogController : ControllerBase
    {
        protected IErrorLogRepo _IErrorLogRepo;
        protected ErrorLogResponse logResponse;
        private readonly IMapper _mapper;
        Logger logger  = NLogBuilder.ConfigureNLog("~/nlog.config").GetCurrentClassLogger();

        public ErrorLogController(IErrorLogRepo iErrorLogRepo, IMapper mapper)
        {
            _IErrorLogRepo = iErrorLogRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllErrorLog")]
        public async Task<ActionResult<GetAllErrorResponse>> GetAllErrorLog()
        {
            try
            {
                var result = await _IErrorLogRepo.GetAll();
                var detail = _mapper.Map<List<GetAllErrorResponse>>(result.ToList());
                if (detail.Count > 0)
                {
                    return Ok(detail);
                }
                else
                {
                    return BadRequest("Fail");
                }
            }
            catch(Exception c)
            {
                logger.Error("GetAllErrorLog:" + c.Message);
                return StatusCode(500, "Access Denied");
            }
           
        }

        [HttpGet]
        [Route("GetErrorLogbyId")]
        public async Task<ActionResult<GetAllErrorResponse>> GetErrorLogbyId(string Id)
        {
            try
            {
                var result = await _IErrorLogRepo.GetbyId(Id);
                var detail = _mapper.Map<GetAllErrorResponse>(result);
                if (detail.ErrorLogId != null)
                {
                    return Ok(detail);
                }
                else
                {
                    return BadRequest("Fail");
                }
            }
            catch(Exception c)
            {
                logger.Error("GetAllErrorLog:" + c.Message);
                return StatusCode(500, "Access Denied"); 
            }
        }

        [HttpPost]
        [Route("InsertErrorlog")]
        public async Task<ActionResult<ErrorLogResponse>> CreateErrorlog(ErrorLogRequest request)
        {
            logResponse = new ErrorLogResponse();
            try
            {
                logResponse = new ErrorLogResponse();
                ApplicationsErrorlog sa = new ApplicationsErrorlog();
                Random n = new Random();
                sa.ErrorLogId = DateTime.Now.ToString("yyyymmddss") + n.Next(99999);
                sa.StatusCode = request.StatusCode;
                sa.ErrorMessage = request.ErrorMessage;
                sa.Details = request.Details;
                sa.ApplicationName = request.ApplicationName;
                sa.CreatedDate = DateTime.Now;

                //var detail = _mapper.Map<ApplicationsErrorlog>(request);

                var result = await _IErrorLogRepo.Create(sa);

                if (result == true)
                {
                    logResponse.ResponseCode = "00";
                    logResponse.Message = "Successful";

                    return Ok(logResponse);
                }
                else
                {
                    logResponse.ResponseCode = "99";
                    logResponse.Message = "Fail";

                    return BadRequest(logResponse);
                }
            }
            catch(Exception c)
            {
                logResponse.ResponseCode = "500";
                logResponse.Message = "Access Denied";
                logger.Error("GetAllErrorLog:" + c.Message);
                return StatusCode(500, logResponse);
                //return Unauthorized(logResponse);
            }
        }
    }
}
