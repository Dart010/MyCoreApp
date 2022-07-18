import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Master } from '../masters/masters.component';

@Component({
  selector: 'app-master-search',
  templateUrl: './master-search.component.html',
  styleUrls: ['./master-search.component.css']
})
export class MasterSearchComponent {

  public masters: Master[];

  public master: Master = <Master>{};

  searchTerm!: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
              private route: ActivatedRoute, private location: Location) {
    // this.getMasters();
    // this.searchMaster();
  }

  //private getMasters() {
  //  this.http.get<Master[]>(this.baseUrl).subscribe(result => {
  //    this.masters = result;
  //  }, error => console.error(error));
  //}

  //public searchMaster(master: Master) {
  //  this.http.get<Master[]>(this.baseUrl + '/').subscribe(result => {
  //    //this.master = result;
  //  }, error => console.error(error));
  //}
}
