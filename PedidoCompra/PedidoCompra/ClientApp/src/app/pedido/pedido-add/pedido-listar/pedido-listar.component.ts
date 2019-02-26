import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Pedido } from '../../pedido.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pedido-listar',
  templateUrl: './pedido-listar.component.html'
})
export class PedidoListarComponent implements OnInit {

  @Input() pedidos: Pedido[];
  @Output() deletarPedido = new EventEmitter<Pedido>();
  @Output() editarPedido = new EventEmitter<string>();

  constructor(private router: Router) { }

  ngOnInit() {
  }

  deletar(pedido: Pedido): void {
    this.deletarPedido.emit(pedido);
  }

  private editar(id: string) : void {
    this.editarPedido.emit(id);
    this.router.navigate(['pedidos', id]);
  }
}
