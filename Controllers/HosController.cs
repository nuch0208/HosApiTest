using hosxpapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HosApi.Controllers;

[Route("/api/[controller]/[action]")]
    public class HosController : Controller
    {
        private readonly ApplicationDbContext db;
        public HosController(ApplicationDbContext db)
        {
            this.db = db;
        }
        
        [HttpGet]
        public IActionResult getHNdb (string para)
        
        { 
            if(para.Length > 4)
            {
            return Json((from a in db.Patients
                         join b in db.Ovsts on a.Hn equals b.Hn

                         where a.Hn == para

                         select new
                         {
                             b.Hn,
                             a.Cid,
                             a.Pname,
                             a.Fname,
                             a.Lname
                             // c.Name,
                             // c.OldCode
                         }).Take(50));
            }

            DateOnly dateNow = DateOnly.FromDateTime(DateTime.Now);
            var query = 
            from a in db.Ovsts
            join b in db.Patients on  a.Hn equals b.Hn
            where a.Vstdate == dateNow && Convert.ToString( a.Oqueue ) == para
            select new
            {
                a.Oqueue,
                a.Hn, 
                b.Pname, 
                b.Fname, 
                b.Lname,
                a.Vstdate
            };
            
            return Json(query.First());
        }

        [HttpGet]
        public IActionResult getUser (string para)
        
        { 
        
            return Json((from a in db.Opdusers
                         where a.Loginname == para

                         select new
                         {
                             a.Loginname,
                             a.Passweb

                         }).First());
        }
    }