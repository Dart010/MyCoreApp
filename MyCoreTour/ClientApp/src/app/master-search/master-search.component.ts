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

  //public masters: Master[] = [
  //  { id: "abb9019c-5292-4c01-9e47-89bfad1c3860", name: "Mara Jade" },
  //  { id: "b6e53d3d-6f51-441e-bb04-9f6d48eace37", name: "Nomi Sunrider" },
  //  { id: "26a30f19-5950-4dfb-9ea1-4ed789a6dd6d", name: "Shaak Ti" },
  //  { id: "a1a389f7-048f-46d4-a328-75b48e464ba9", name: "Plo Koon" },
  //  { id: "d23d3bbb-e4dd-4b06-aa62-169b3c7dae70", name: "Adi Gallia" },
  //  { id: "83578eb6-9250-4674-9574-0b32c3decd86", name: "Kelleran Beq" },
  //  { id: "926fff78-95c7-49b0-9370-92e083ffbbff", name: "Agen Kolar" },
  //  { id: "f63f2bc0-e729-4e93-a32f-2dd33decec24", name: "Coleman Kcaj" },
  //  { id: "b53dd7ec-a4f4-457b-be11-0d2ed8e9ad3c", name: "Depa Billaba" }];

  public masters: Master[];

  public master: Master = <Master>{};

  public searchTermMaster: string = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
              private route: ActivatedRoute, private location: Location) {
    // this.getMasters();
  }

  //private getMasters() {
  //  this.http.get<Master[]>(this.baseUrl).subscribe(result => {
  //    this.masters = result;
  //  }, error => console.error(error));
  //}

  public searchMasters() {
    this.http.get<Master[]>(this.baseUrl + 'api/masters1' + '?masterToSearch=' + this.searchTermMaster).subscribe(result => {
      this.masters = result;
    }, error => console.error(error));
  }
}
