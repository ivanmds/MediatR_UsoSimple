import { Component, OnInit, Input } from '@angular/core';
import { Pedido } from '../pedido.model';

@Component({
  selector: 'app-pedido-listar',
  templateUrl: './pedido-listar.component.html'
})
export class PedidoListarComponent implements OnInit {

  @Input() pedidos: Pedido[];

  constructor() { }

  ngOnInit() {
  }

}
