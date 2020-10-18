import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PropostasComponent } from './propostas/propostas.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NavegacaoComponent } from './navegacao/navegacao.component';
import { TituloComponent } from './titulo/titulo.component';
import { LoginComponent } from './login/login.component';
import { ClienteCadastroComponent } from './cliente-cadastro/cliente-cadastro.component';
import { ReservasComponent } from './reservas/reservas.component';
import { PassagensComponent } from './passagens/passagens.component';
import { FiltroVoosComponent } from './filtro-voos/filtro-voos.component';
import { TabelaVoosComponent } from './tabela-voos/tabela-voos.component';

@NgModule({
  declarations: [													
    AppComponent,
      PropostasComponent,
      DashboardComponent,
      NavegacaoComponent,
      TituloComponent,
      LoginComponent,
      ClienteCadastroComponent,
      ReservasComponent,
      PassagensComponent,
      FiltroVoosComponent,
      TabelaVoosComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
