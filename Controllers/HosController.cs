using hosxpapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HosApi.Controllers;

[Route("/api/[controller]/[action]")]
    public class LabController : Controller
    {
        private readonly ApplicationDbContext db;
        public LabController(ApplicationDbContext db)
        {
            this.db = db;
        }

         [HttpGet]
        public IActionResult getdb (string paraHN)
        { 
            //  var query = Ovst  Patient
            // from a in db.Wards
            var query =
            from a in db.Patients
            join b in db.Ovsts on a.Hn equals b.Hn 
            // join c in db.Wards  on b.Oldcode equals c.OldCode 
            where a.Hn == paraHN 
            orderby a.Hn ascending
            select new
            {
                a.Hn,
                a.Cid,
                a.Pname,
                a.Fname,
                a.Lname,
                b.Doctor
                // c.Name,
                // c.OldCode
            };
            return Json(query.Take(50));
        }
        [HttpPost]
        public async Task<ActionResult<List<Ward>>> AddWard(Ward ward)
        {
            db.Wards.Add(ward);
            await db.SaveChangesAsync();
                
            return Ok(await db.Wards.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Ward>>> UpdateWard(Ward updateward)
        {
            var dbward = await db.Wards.FindAsync(updateward.Ward1);
            if (dbward is null)
                return NotFound("Ward not found");
            dbward.Name = updateward.Name;

            await db.SaveChangesAsync();
                
            return Ok(await db.Wards.ToListAsync());
        }

         [HttpDelete]
        public async Task<ActionResult<List<Ward>>> DeleteWard(int id)
        {
            var dbward = await db.Wards.FindAsync(id);
            if (dbward is null)
                return NotFound("Ward not found");
            
            db.Wards.Remove(dbward);
            await db.SaveChangesAsync();
                
            return Ok(await db.Wards.ToListAsync());
        }
    }