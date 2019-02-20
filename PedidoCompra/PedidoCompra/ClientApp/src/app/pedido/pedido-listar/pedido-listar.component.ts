import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Pedido } from '../pedido.model';

@Component({
  selector: 'app-pedido-listar',
  templateUrl: './pedido-listar.component.html'
})
export class PedidoListarComponent implements OnInit {

  @Input() pedidos: Pedido[];
  @Output() deletarPedido = new EventEmitter<Pedido>();

  constructor() { }

  ngOnInit() {
  }

  deletar(pedido: Pedido): void {
    this.deletarPedido.emit(pedido);
  }

}
