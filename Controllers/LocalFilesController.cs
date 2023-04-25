using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;

namespace RESTfulAPI_practice.Controllers
{
    [Route("file")]
    [ApiController]
    public class LocalFilesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string orderBy="fileName",string direction="Descending", string filterByName="")
        {
            //初始化路徑
            string Path = Libs.Initiate.CheckUrl();
            
            //初始化List<CLASS>
            List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList(Path);

            //FilterByName處理搜尋
            CurrentFormList = Libs.Initiate.FilterByName(CurrentFormList, filterByName);

            //OrderBy處理排序
            CurrentFormList = Libs.Initiate.OrderBy(CurrentFormList, orderBy,direction);


            Models.Class CurrentFormClass = new Models.Class(CurrentFormList);
            return Ok(CurrentFormClass);
        }

        [HttpGet("GetFile")]
        public IActionResult GetFile()
        {
            //public DbSet<Models.student> students;
            string Path = Libs.Initiate.CheckUrl();
            //return File("image_2.png", "image/png");
            IFileProvider provider = new PhysicalFileProvider(Path);
            IFileInfo fileInfo = provider.GetFileInfo("image_2.png");
            return File(fileInfo.CreateReadStream(), "image/png");
        }

        [HttpGet("list")]
        public IActionResult GetWithOrder
            (string orderBy = "filename", string direction = "descending", string filterByName = "")
        {
            string Path = Libs.Initiate.CheckUrl();

            List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList(Path);
            CurrentFormList = Libs.Initiate.FilterByName(CurrentFormList, filterByName);
            CurrentFormList = Libs.Initiate.OrderBy(CurrentFormList, orderBy,direction);
            return Ok(CurrentFormList);
        }

        [HttpGet("{Path1}/{Path2}")]

        public IActionResult Get(string Path1, string Path2,
            string orderBy = "fileName", string direction = "Descending", string filterByName = "")
        {
            string Path = Libs.Initiate.CheckUrl(Path1,Path2);
            bool isFile = Libs.Initiate.CheckFile(Path);

            if (isFile) return Ok("this is a file");

            else
            {
                List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList(Path);
                CurrentFormList = Libs.Initiate.FilterByName(CurrentFormList, filterByName);
                CurrentFormList = Libs.Initiate.OrderBy(CurrentFormList, orderBy, direction);
                Models.Class CurrentFormClass = new Models.Class(CurrentFormList);
                return Ok(CurrentFormClass);
            }
        }

        [HttpGet("list/{Path1}/{Path2}")]
        public IActionResult GetWithOrder(string Path1, string Path2,
            string orderBy = "fileName", string direction = "Descending", string filterByName = "")
        {
            string Path = Libs.Initiate.CheckUrl(Path1,Path2);
            bool isFile = Libs.Initiate.CheckFile(Path);

            if (isFile) return Ok("this is a file");

            else
            {
                List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList(Path);
                CurrentFormList = Libs.Initiate.FilterByName(CurrentFormList, filterByName);
                CurrentFormList = Libs.Initiate.OrderBy(CurrentFormList, orderBy, direction);
                return Ok(CurrentFormList);
            }
        }

        [HttpGet("{Path1}")]
        public IActionResult Get(string Path1, 
            string orderBy = "fileName", string direction = "Descending", string filterByName = "")
        {
            string Path = Libs.Initiate.CheckUrl(Path1);
            bool isFile = Libs.Initiate.CheckFile(Path);

            if (isFile) return Ok("this is a file");

            else
            {
                List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList(Path);
                CurrentFormList = Libs.Initiate.FilterByName(CurrentFormList, filterByName);
                CurrentFormList = Libs.Initiate.OrderBy(CurrentFormList, orderBy, direction);
                Models.Class CurrentFormClass = new Models.Class(CurrentFormList);
                return Ok(CurrentFormClass);
            }
        }

        [HttpGet("list/{Path1}")]
        public IActionResult GetWithOrder(string Path1,
            string orderBy = "fileName", string direction = "Descending", string filterByName = "")
        {
            string Path = Libs.Initiate.CheckUrl(Path1);
            bool isFile = Libs.Initiate.CheckFile(Path);

            if (isFile) return Ok("this is a file");

            else
            {
                List<Models.Form> CurrentFormList = Libs.Initiate.InitiateList(Path);
                CurrentFormList = Libs.Initiate.FilterByName(CurrentFormList, filterByName);
                CurrentFormList = Libs.Initiate.OrderBy(CurrentFormList, orderBy, direction);
                return Ok(CurrentFormList);
            }
        }

        [HttpPost]
        
        public IActionResult Post()
        {
            return Ok("post");
        }

        [HttpGet("info")]
        public IActionResult Get()
        {
            return Ok("For INFO");
        }
    }
}
