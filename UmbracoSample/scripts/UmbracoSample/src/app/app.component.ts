
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
 
@Component({
  selector: 'app-root',
  template: '<div [innerHTML]="template.message"></div>',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  template;
  
  constructor (http: HttpClient)
  {
      console.log("Here");
      http.get('http://localhost:2288/umbraco/surface/Angular/AppComponent').subscribe(data => {
this.template = data; console.log(data)
       });
  }
}



