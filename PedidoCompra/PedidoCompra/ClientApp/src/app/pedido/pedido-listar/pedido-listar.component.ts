import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Pedido } from '../models/pedido.model';

@Component({
  selector: 'app-pedido-listar',
  templateUrl: './pedido-listar.component.html'
})
export class PedidoListarComponent implements OnInit {

  @Input() pedidos: Pedido[];
  @Output() deletarPedido = new EventEmitter<Pedido>();

  constructor(private router: Router) { }

  ngOnInit() {
  }

  deletar(pedido: Pedido): void {
    this.deletarPedido.emit(pedido);
  }

  private editar(id: string) : void {
    this.router.navigate(['pedidos', id]);
  }
}
