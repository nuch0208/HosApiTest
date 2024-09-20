using hosxpapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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
        public IActionResult getUser (string uname,string para)
        
        { 
           var x = MD5Hash(para);

            return Json((from a in db.Opdusers
                         where a.Loginname == uname && a.Passweb == x 

                         select new
                         {
                             a.Loginname,
                             a.Passweb,
                             a.Cid,
                            

                         }).FirstOrDefault());
        }

        public static string MD5Hash(string input)
        {
        StringBuilder hash = new StringBuilder();
        MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
        byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

        for (int i = 0; i < bytes.Length; i++)
        {
            hash.Append(bytes[i].ToString("x2"));
        }
        return hash.ToString();
        }

    }

