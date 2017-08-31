import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  name = "Hello world! dongliping";
  heroes=HEROES;
}

export class Hero{
  id:number;
  name:string;
}

const HEROES:Hero[] = [
  {id:1,name:"12"},
]