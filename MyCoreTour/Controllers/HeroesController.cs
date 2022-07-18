//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCoreTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCoreTour.Controllers
{
    [Route("[controller]")]
    //[Route("/")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        public static List<Hero> heroes = new List<Hero>();

        public HeroesController()       // constructor
        {
            if (heroes.Count == 0)
            {
                heroes.Add(new Hero() { Id = Guid.NewGuid(), Name = "Dr.Nice" });
                heroes.Add(new Hero() { Id = Guid.NewGuid(), Name = "Bombasto" });
                heroes.Add(new Hero() { Id = Guid.NewGuid(), Name = "Celeritas" });
                heroes.Add(new Hero() { Id = Guid.NewGuid(), Name = "Magneta" });
                heroes.Add(new Hero() { Id = Guid.NewGuid(), Name = "RubberMan" });
                heroes.Add(new Hero() { Id = Guid.NewGuid(), Name = "Dynama" });
                heroes.Add(new Hero() { Id = Guid.NewGuid(), Name = "Dr. IQ" });
                heroes.Add(new Hero() { Id = Guid.NewGuid(), Name = "Magma" });
                heroes.Add(new Hero() { Id = Guid.NewGuid(), Name = "Tornado" });
            }
        }

        [HttpGet]
        [Route("")]
        [ActionName("GetHero")]
        public Hero[] Get()
        {
            return heroes.ToArray();
        }

        [HttpPost]
        [ActionName("PostHero")]
        public void Post([FromBody] Hero hero)         // adaugare hero (merge)
        {
            hero.Id = Guid.NewGuid();
            heroes.Add(hero);
        }

        [HttpDelete]
        // [ActionName("DeleteHero")]
        public void Delete([FromQuery] Guid id)         // stergere hero
        {
            Hero heroToDelete = heroes.FirstOrDefault(x => x.Id == id);
            heroes.Remove(heroToDelete);
        }

        [HttpGet]
        [ActionName("GetHeroId")]
        [Route("{Id}")]
        public ActionResult<Hero> Get([FromRoute] Guid id)
        {
            Hero hero = heroes.FirstOrDefault(x => x.Id == id);
            if (hero == null)
                return NotFound();
            return hero;
        }

        [HttpPost]
        [ActionName("UpdateHero")]
        [Route("{Id}")]
        public ActionResult<Hero> Update([FromBody] Hero hero)
        {
            Hero heroToUpdate = heroes.FirstOrDefault(x => x.Id == hero.Id);
            if (heroToUpdate == null)
                return NotFound();
            heroToUpdate.Name = hero.Name;
            return NoContent();
        }

        //[HttpGet]
        //[ActionName("SearchHero")]
        ////[Route("/")]
        //public ActionResult<Hero[]> Search([FromBody] Hero hero)
        //{
        //    string nameToSearch = hero.Name.ToLower().Trim();
        //    //var names = from h in heroes
        //    //            select h.Name;

        //    if (!string.IsNullOrEmpty(nameToSearch))
        //    {
        //        List<Hero> heroesFound = heroes.FindAll(h => h.Name.ToLower().Contains(nameToSearch));
        //        //System.Diagnostics.Debug.WriteLine("lista filtrata: " + heroesFound);

        //        //names = names.Where(x => x.ToLower().Contains(nameToSearch));
                
        //        if (heroesFound == null)
        //            return NotFound();
        //        return heroesFound.ToArray();
        //    }
        //    return NoContent();
        //}
    }
}
