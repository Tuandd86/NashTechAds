import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Router} from "@angular/router"
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-ad-editor',
  templateUrl: './ad-editor.component.html',
  styleUrls: ['./ad-editor.component.css']
})
export class AdEditorComponent implements OnInit {

  fileData = null;
  categories = [];
  ad : any = { price : 0 };

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.http.get<any>(environment.apiEndpoint +'/api/categories')
    .subscribe(result =>{
      this.categories = result;
      this.ad.categoryId = this.categories[0].id;
    })
  }

  onFileSelect(files) {
    this.fileData = files[0];
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('image', this.fileData);
    formData.append('categoryId', this.ad.categoryId);
    formData.append('title', this.ad.title);
    formData.append('price', this.ad.price);
    formData.append('description', this.ad.description);
    this.http.post(environment.apiEndpoint +'/api/ads', formData)
      .subscribe(res => {
        this.router.navigate(['/ads'])
      })
  }

}
