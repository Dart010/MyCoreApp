import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-masters',
  templateUrl: './masters.component.html',
  styleUrls: ['./masters.component.css']
})
export class MastersComponent {   

  public masters: Master[];

  public master: Master = <Master>{};

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.getMasters();
  }

  private getMasters() {
    this.http.get<Master[]>(this.baseUrl + 'api/masters1').subscribe(result => {
      this.masters = result;
    }, error => console.error(error));
  }

  public addMaster() {
    this.http.post<Master>(this.baseUrl + 'api/masters1', this.master).subscribe(result => {
      this.master = <Master>{};
      this.getMasters();
    }, error => console.error(error));
  }

  public deleteMaster(master: Master) {
    this.http.delete<Master>(this.baseUrl + 'api/masters1' + '?id=' + master.id).subscribe(result => {
      this.getMasters();
    }, error => console.error(error));
  }

  // implementare cu controller-ul HeroesController
  //private getMasters() {
  //  this.http.get<Master[]>(this.baseUrl + 'masters').subscribe(result => {
  //    this.masters = result;
  //  }, error => console.error(error));
  //}

  //public addMaster() {
  //  this.http.post<Master>(this.baseUrl + 'masters', this.master).subscribe(result => {
  //    this.master = <Master>{};
  //    this.getMasters();
  //  }, error => console.error(error));
  //}

  //public deleteMaster(master: Master) {
  //  this.http.delete<Master>(this.baseUrl + 'masters' + '?id=' + master.id).subscribe(result => {
  //    this.getMasters();
  //  }, error => console.error(error));
  //}
}

export interface Master {
  id: number;
  name: string;
}
