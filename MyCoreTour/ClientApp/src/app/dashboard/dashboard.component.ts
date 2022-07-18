import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Hero } from '../heroes/heroes.component';
import { Master } from '../masters/masters.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent { 

  title = "Tour of Heroes and Masters";

  public heroes: Hero[];
  public masters: Master[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    // this.getHeroes();
    // this.getMasters();
  }

  //private getHeroes() {
  //  this.http.get<Hero[]>(this.baseUrl).subscribe(result => {
  //    this.heroes = result.slice(1, 5);
  //  }, error => console.error(error));
  //}

  //private getMasters() {
  //  this.http.get<Master[]>(this.baseUrl).subscribe(result => {
  //    this.masters = result;
  //  }, error => console.error(error));
  //}

}
