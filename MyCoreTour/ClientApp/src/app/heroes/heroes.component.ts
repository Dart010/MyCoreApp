import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})
export class HeroesComponent { 

  public heroes: Hero[];

  public hero: Hero = <Hero>{};

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.getHeroes();
  }

  private getHeroes() {
    this.http.get<Hero[]>(this.baseUrl + 'heroes').subscribe(result => {
      this.heroes = result;
    }, error => console.error(error));
  }

  public addHero() {
    this.http.post<Hero>(this.baseUrl + 'heroes', this.hero).subscribe(result => {
      this.hero = <Hero>{};
      this.getHeroes();
    }, error => console.error(error));
  }

  public deleteHero(hero: Hero) {
    this.http.delete<Hero>(this.baseUrl + 'heroes' + '?id=' + hero.id).subscribe(result => {
      this.getHeroes();
    }, error => console.error(error)); 
  }
}

export interface Hero {
  id: string;
  name: string;
} 
