import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Hero } from '../heroes/heroes.component';

@Component({
  selector: 'app-hero-search',
  templateUrl: './hero-search.component.html',
  styleUrls: ['./hero-search.component.css']
})
export class HeroSearchComponent {

  //public heroes: Hero[] = [
  //  { id: "270cb1fc-9a78-47d3-931f-18a8ff37d473", name: "Dr.Nice" },
  //  { id: "0c65a92c-9d2c-416a-9bf1-bebb8270f5e1", name: "Bombasto" },
  //  { id: "88cf2426-a0d2-47f8-b837-c9effc6a65ca", name: "Celeritas" },
  //  { id: "784f9c64-d695-42b3-9260-1f2e207d22df", name: "Magneta" },
  //  { id: "edaff5e3-7066-42ac-b218-d38ea38e8777", name: "RubberMan" },
  //  { id: "f384b2fc-bbd6-4c99-93a8-4e13e9662b1a", name: "Dynama" },
  //  { id: "d488f468-e632-40f0-ac1e-5704abb9eba8", name: "Dr. IQ" },
  //  { id: "80e9649f-12ea-42f4-8ad3-ab4bef6bf1d5", name: "Magma" },
  //  { id: "c20d7c7b-b0a5-464a-897d-518a03fdee5c", name: "Tornado" }
  //];

  public heroes: Hero[];

  public hero: Hero = <Hero>{};

  // searchTerm!: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
              private route: ActivatedRoute, private location: Location) {
    // this.getHeroes();
  }

  //private getHeroes() {
  //  this.http.get<Hero[]>(this.baseUrl).subscribe(result => {
  //    this.heroes = result;
  //  }, error => console.error(error));
  //}

  public searchHero(hero: Hero) {
    this.http.get<Hero[]>(this.baseUrl).subscribe(result => {
      this.heroes = result;
      // console.log(this.heroes);
    }, error => console.error(error));
  }

}
