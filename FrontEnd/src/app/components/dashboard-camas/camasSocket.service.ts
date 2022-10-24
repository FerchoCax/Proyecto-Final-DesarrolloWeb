import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import * as signalR from "@microsoft/signalr";
import { environment } from 'src/environments/environment';
import { Sucursale } from "src/app/services/api-backend";

@Injectable({
    providedIn: 'root'
  })
export class CamasSocketService {
    infoCamas = new Subject()
    camasSocket = null
    Sucursal:Sucursale;
    constructor(){}
    iniciar(idSucursal:string){
        
        let id=idSucursal;
        let apiUrl = environment.apiUrl
        console.log('ApiUrl: '+apiUrl);

        this.camasSocket = new signalR.HubConnectionBuilder().withUrl(apiUrl+'/hub/Camas')
        .withAutomaticReconnect()
        .build();
        this.camasSocket.on('Nueva', informacion =>{
            console.log(informacion);

            let objetoInfo = informacion

            this.infoCamas = objetoInfo
        })
        
        this.camasSocket.start().then(() => {
            this.camasSocket.invoke('UnirseAlGrupo', id);      
          })
          ;
    }
    detener() {
        if (this.camasSocket != null)
          this.camasSocket.stop();
        
        this.camasSocket = null;
      }
}