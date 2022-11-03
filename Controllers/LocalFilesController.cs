using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulAPI_practice.Controllers
{
    [Route("file")]
    [ApiController]
    public class LocalFilesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string orderBy="fileName", string direction="descending", string filterByName="")
        {
            List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList();
            CurrentFormList = Libs.Initiate.OrderBy(CurrentFormList, orderBy,direction);
            Models.Class CurrentFormClass = new Models.Class(CurrentFormList);
            return Ok(CurrentFormClass);
        }

        [HttpGet("list")]
        public IActionResult GetWithOrder
            (string orderBy = "filename", string direction = "descending", string filterByName = "")
        {
            List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList();
            CurrentFormList = Libs.Initiate.OrderBy(CurrentFormList, orderBy,direction);
            return Ok(CurrentFormList);
        }

        [HttpGet("{Path1}/{Path2}")]

        public IActionResult Get(string Path1, string Path2,
            string orderBy = "fileName", string direction = "Descending", string filterByName = "")
        {
            List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList(Path1,Path2);
            Models.Class CurrentFormClass = new Models.Class(CurrentFormList);
            return Ok(CurrentFormClass);
        }

        [HttpGet("list/{Path1}/{Path2}")]
        public IActionResult GetWithOrder(string Path1, string Path2,
            string orderBy = "fileName", string direction = "Descending", string filterByName = "")
        {
            List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList(Path1,Path2);
            return Ok(CurrentFormList);
        }

        [HttpGet("{Path1}")]
        public IActionResult Get(string Path1, 
            string orderBy = "fileName", string direction = "Descending", string filterByName = "")
        {            
            List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList(Path1);
            Models.Class CurrentFormClass = new Models.Class(CurrentFormList);
            return Ok(CurrentFormClass);
        }

        [HttpGet("list/{Path1}")]
        public IActionResult GetWithOrder(string Path1,
            string orderBy = "fileName", string direction = "Descending", string filterByName = "")
        {
            List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList(Path1);
            return Ok(CurrentFormList);
        }

    }
}
