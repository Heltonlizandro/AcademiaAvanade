import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClienteCadastroComponent } from './cliente-cadastro/cliente-cadastro.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FiltroVoosComponent } from './filtro-voos/filtro-voos.component';
import { LoginComponent } from './login/login.component';
import { PassagensComponent } from './passagens/passagens.component';
import { PropostasComponent } from './propostas/propostas.component';
import { ReservasComponent } from './reservas/reservas.component';
import { TabelaVoosComponent } from './tabela-voos/tabela-voos.component';
import { TituloComponent } from './titulo/titulo.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  { path: 'dashboard', component: DashboardComponent},
  { path: 'propostas', component: PropostasComponent},
  { path: 'login', component: LoginComponent},
  { path: 'reservas', component: ReservasComponent},
  { path: 'passagens', component: PassagensComponent},
  { path: 'cliente-cadastro', component: ClienteCadastroComponent},
  { path: 'filtro-voos', component: FiltroVoosComponent},
  { path: 'titulo', component: TituloComponent},
  { path: 'tabela-voos', component: TabelaVoosComponent}
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
