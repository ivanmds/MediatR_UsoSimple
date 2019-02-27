import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PedidoComponent } from './pedido/pedido.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { PedidoItemModalComponent } from './pedido/pedido-item/pedido-item-modal.component';
import { PedidoItemListarComponent } from './pedido/pedido-item/pedido-item-listar/pedido-item-listar.component';
import { TelaCarregandoComponent } from './tela-carregando/tela-carregando.component';
import { TelaCarregandoService } from './services/tela-carregando.service';
import { TelaCarregandoInterceptor } from './interceptors/tela-carregando.interceptor';
import { PedidoListarComponent } from './pedido/pedido-listar/pedido-listar.component';
import { PedidoService } from './services/pedido-service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PedidoComponent,
    PedidoListarComponent,
    PedidoItemModalComponent,
    PedidoItemListarComponent,
    TelaCarregandoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'pedidos', component: PedidoComponent },
      { path: 'pedidos/:id', component: PedidoComponent }
    ])
  ],
  providers: [
    TelaCarregandoService,
    { provide: HTTP_INTERCEPTORS, useClass: TelaCarregandoInterceptor, multi: true },
    PedidoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
