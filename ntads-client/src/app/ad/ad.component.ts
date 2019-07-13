import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-ad',
  templateUrl: './ad.component.html',
  styleUrls: ['./ad.component.css']
})
export class AdComponent implements OnInit {

  ads : any = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get<any>(environment.apiEndpoint +'/api/ads')
    .subscribe(result =>{
      this.ads = result;
    })
  }

}
