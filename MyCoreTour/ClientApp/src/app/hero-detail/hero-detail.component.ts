import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Hero } from '../heroes/heroes.component';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: ['./hero-detail.component.css']
})
export class HeroDetailComponent {

  public heroes: Hero[];

  public hero: Hero = <Hero>{};

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
              private route: ActivatedRoute, private location: Location) {
    this.getHero();
  }

  private getHero() {
    const id = this.route.snapshot.paramMap.get('id');
    this.http.get<Hero>(this.baseUrl + 'heroes/' + id).subscribe(result => {
        this.hero = result;
    }, error => console.error(error));
  }

  public updateHero(hero: Hero) {
    this.http.post<Hero>(this.baseUrl + 'heroes/' + this.hero.id, hero).subscribe(result => {
      this.goBack();  
    }, error => console.error(error));
  }

  goBack(): void {
    this.location.back();
  }
}
