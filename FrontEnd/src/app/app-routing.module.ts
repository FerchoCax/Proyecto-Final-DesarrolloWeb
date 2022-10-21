import { NgModule } from '@angular/core';
import { RouterModule, Routes, ActivatedRoute } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeLayoutComponent } from './layouts/home-layout/home-layout.component';
import { AuthGuard } from './helpers/auth.guard';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { SucursalesComponent } from './components/sucursales/sucursales.component';
import { ProductosComponent } from './components/productos/productos.component';
import { RolesComponent } from './components/roles/roles.component';
import { BodegasComponent } from './components/bodegas/bodegas.component';
import { LotesComponent } from './components/lotes/lotes.component';

const routes: Routes = [
  {
    path: '',
    component: HomeLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path:'Usuarios',
        canActivate:[AuthGuard],
        component:UsuariosComponent
      },
      {
        path: 'Sucursales',
        component:SucursalesComponent
      }, 
      {
        path:'productos',
        component:ProductosComponent
      },
      {
        path:'Roles',
        component:RolesComponent
      },
      {
        path:'Bodegas',
        component: BodegasComponent
      }, 
      {
        path:'Lotesitos',
        component: LotesComponent
      }
    ]
  
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
