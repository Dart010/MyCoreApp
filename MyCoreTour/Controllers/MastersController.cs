using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCoreTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCoreTour.Controllers
{
    [Route("[controller]")]
    // [Route("/")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        static List<Master> masters = new List<Master>();

        public MastersController()
        {
            if (masters.Count == 0)
            {
                masters.Add(new Master() { Id = Guid.NewGuid(), Name = "Mara Jade" });
                masters.Add(new Master() { Id = Guid.NewGuid(), Name = "Nomi Sunrider" });
                masters.Add(new Master() { Id = Guid.NewGuid(), Name = "Shaak Ti" });
                masters.Add(new Master() { Id = Guid.NewGuid(), Name = "Plo Koon" });
                masters.Add(new Master() { Id = Guid.NewGuid(), Name = "Adi Gallia" });
                masters.Add(new Master() { Id = Guid.NewGuid(), Name = "Kelleran Beq" });
                masters.Add(new Master() { Id = Guid.NewGuid(), Name = "Agen Kolar" });
                masters.Add(new Master() { Id = Guid.NewGuid(), Name = "Coleman Kcaj" });
                masters.Add(new Master() { Id = Guid.NewGuid(), Name = "Depa Billaba" });
            }
        }

        [HttpGet]
        [Route("")]
        [ActionName("GetMaster")]
        public Master[] Get()
        {
            return masters.ToArray();
        }

        [HttpPost]
        [ActionName("PostMaster")]
        public void Post([FromBody] Master master)
        {
            master.Id = Guid.NewGuid();
            masters.Add(master);
        }

        [HttpDelete]
        // [ActionName("DeleteMaster")]
        public void Delete([FromQuery] Guid id)        
        {
            Master masterToDelete = masters.FirstOrDefault(x => x.Id == id);
            masters.Remove(masterToDelete);
        }

        [HttpGet]
        [ActionName("GetMasterId")]
        [Route("{Id}")]
        public ActionResult<Master> Get([FromRoute] Guid id)
        {
            Master master = masters.FirstOrDefault(x => x.Id == id);
            if (master == null)
                return NotFound();
            return master;
        }

        [HttpPost]
        [ActionName("UpdateMaster")]
        [Route("{Id}")]
        public ActionResult<Master> Update([FromBody] Master master)
        {
            Master masterToUpdate = masters.FirstOrDefault(x => x.Id == master.Id);
            if (masterToUpdate == null)
                return NotFound();
            masterToUpdate.Name = master.Name;
            return NoContent();
        }

        //[HttpGet]
        //[ActionName("SearchMaster")]
        //[Route("/")]
        //public ActionResult<Master[]> Get([FromBody] string name)
        //{
        //    string nameToSearch = name.ToLower().Trim();
        //    if(!string.IsNullOrEmpty(nameToSearch))
        //    {
        //        List<Master> mastersFound = masters.FindAll(x => x.Name.ToLower().Contains(nameToSearch));
        //        if (mastersFound == null)
        //            return NotFound();
        //        return mastersFound.ToArray();
        //    }
        //    return NoContent();
        //}
    }
}
