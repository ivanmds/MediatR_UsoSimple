import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PedidoAddComponent } from './pedido/pedido-add/pedido-add.component';
import { PedidoListarComponent } from './pedido/pedido-listar/pedido-listar.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { PedidoItemAddModalComponent } from './pedido/pedido-item/pedido-item-add-modal.component';
import { PedidoItemListarComponent } from './pedido/pedido-item/pedido-item-listar/pedido-item-listar.component';
import { TelaCarregandoComponent } from './tela-carregando/tela-carregando.component';
import { TelaCarregandoService } from './services/tela-carregando.service';
import { TelaCarregandoInterceptor } from './interceptors/tela-carregando.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PedidoAddComponent,
    PedidoListarComponent,
    PedidoItemAddModalComponent,
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
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'pedidos', component: PedidoAddComponent }
    ])
  ],
  providers: [
    TelaCarregandoService,
    { provide: HTTP_INTERCEPTORS, useClass: TelaCarregandoInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
