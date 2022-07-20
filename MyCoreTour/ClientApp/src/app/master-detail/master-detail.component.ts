import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Master } from '../masters/masters.component';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-master-detail',
  templateUrl: './master-detail.component.html',
  styleUrls: ['./master-detail.component.css']
})
export class MasterDetailComponent  {

  public masters: Master[];

  public master: Master = <Master>{};

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
              private route: ActivatedRoute, private location: Location) {
    this.getMaster();
  }

  private getMaster() {
    const id = this.route.snapshot.paramMap.get('id');
    this.http.get<Master>(this.baseUrl + 'api/masters1/' + id).subscribe(result => {
      this.master = result;
    }, error => console.error(error));
  }

  public updateHero(master: Master) {
    this.http.put<Master>(this.baseUrl + 'api/masters1/' + this.master.id, master).subscribe(result => {
      this.goBack();
    }, error => console.error(error));
  }

  goBack(): void {
    this.location.back();
  }

  // implementare cu controller-ul HeroesController
  //private getMaster() {
  //  const id = this.route.snapshot.paramMap.get('id');
  //  this.http.get<Master>(this.baseUrl + 'masters/' + id).subscribe(result => {
  //    this.master = result;
  //  }, error => console.error(error));
  //}

  //public updateHero(master: Master) {
  //  this.http.post<Master>(this.baseUrl + 'masters/' + this.master.id, master).subscribe(result => {
  //    this.goBack();
  //  }, error => console.error(error));
  //}
}
