import { Component, OnInit } from '@angular/core';
import { CamasSocketService } from './camasSocket.service';

@Component({
  selector: 'app-dashboard-camas',
  templateUrl: './dashboard-camas.component.html',
  styleUrls: ['./dashboard-camas.component.scss']
})
export class DashboardCamasComponent implements OnInit {

  constructor(private socketCamas:CamasSocketService) 
  {
    // this.socketCamas.infoCamas.subscribe(res =>{
    //   console.log(res)
    // })
  }

  ngOnInit(): void {
    console.log(this.socketCamas);
    this.socketCamas.iniciar("1")
    this.socketCamas.infoCamas.subscribe(res =>{
      console.log(res);
      
    },error=>{
      console.log(error);
      
    })
  }

}
