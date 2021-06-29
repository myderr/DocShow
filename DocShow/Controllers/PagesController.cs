using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DocShow.Controllers
{
    public class PagesController : Controller
    {
        [HttpPost]
        public IActionResult Add([FromBody] Page page)
        {
            DbScoped.Sugar.CodeFirst.InitTables(typeof(Page));
            var guid = Guid.NewGuid().ToString();
            page.Id = guid;
            page.SendTime = DateTime.Now;
            DbScoped.Sugar.Insertable(page).ExecuteCommand();
            var url = $"/Pages/Index/{guid}";
            return Ok(url);
        }

        [HttpGet]
        public IActionResult Index(string id)
        {
            var page = DbScoped.Sugar.Queryable<Page>().First(m => m.Id == id);
            return View(page);
        }
    }
}
