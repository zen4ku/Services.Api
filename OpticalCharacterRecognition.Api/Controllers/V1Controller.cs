﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OpticalCharacterRecognition.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class V1Controller : ControllerBase
    {
        public V1Controller()
        {
            ES = new Services.EmailService();
            RS = new Services.RecognitionService();
            SS = new Services.StorageService();
        }

        private Services.EmailService ES { get; }

        private Services.RecognitionService RS { get; }

        private Services.StorageService SS { get; }

        [EnableCors(Startup.CorsPolicy)]
        [HttpPost]
        public async Task<IActionResult> ReadBL(IFormFile file)
        {
            try
            {
                var result = await RS.ReadBL(file);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        [EnableCors(Startup.CorsPolicy)]
        [HttpPost]
        public async Task<IActionResult> ReadDO(IFormFile file)
        {
            try
            {
                var result = await RS.ReadDO(file);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        [EnableCors(Startup.CorsPolicy)]
        [HttpPost]
        public async Task<IActionResult> ReadAmount(IFormFile file)
        {
            try
            {
                var result = await RS.ReadAmount(file);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        [EnableCors(Startup.CorsPolicy)]
        [HttpPost]
        public async Task<IActionResult> ReadBLUrl(string url)
        {
            try
            {
                var result = await RS.ReadBL(url);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        [EnableCors(Startup.CorsPolicy)]
        [HttpPost]
        public async Task<IActionResult> ReadDOUrl(string url)
        {
            try
            {
                var result = await RS.ReadDO(url);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        [EnableCors(Startup.CorsPolicy)]
        [HttpPost]
        public async Task<IActionResult> ReadAmountUrl(string url)
        {
            try
            {
                var result = await RS.ReadAmount(url);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        [EnableCors(Startup.CorsPolicy)]
        [HttpPost]
        public IActionResult SendMail([FromBody] Models.EmailModel model)
        {
            try
            {
                ES.Send(model.To, model.Subject, model.Body);
                return Ok();
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [EnableCors(Startup.CorsPolicy)]
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            try
            {
                var result = SS.Upload(file);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [EnableCors(Startup.CorsPolicy)]
        [HttpGet]
        public IActionResult DownloadFile(string fileName)
        {
            try
            {
                var result = SS.Download(fileName);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }

    [ApiController]
    [Route("[controller]/[action]")]
    public class V2Controller : Controller
    {
        public V2Controller()
        {
            RS = new Services.RecognitionService();
        }

        private Services.RecognitionService RS { get; }
        
        [HttpPost]
        public async Task<IActionResult> Read(IFormFile request)
        {
            try
            {
                var result = await RS.Read(request);
                return Ok(result);
            }
            catch (System.Exception se)
            {
                throw se;
            }
        }
    }
}
