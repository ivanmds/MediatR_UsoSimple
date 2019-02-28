import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Pedido } from '../models/pedido.model';
import { PedidoService } from '../../services/pedido-service';
import { ResultadoCommand } from '../../shared/resultado.model';

@Component({
  selector: 'app-pedido-listar',
  templateUrl: './pedido-listar.component.html'
})
export class PedidoListarComponent implements OnInit {

  pedidos: Pedido[];
  private resultado: ResultadoCommand = new ResultadoCommand();

  constructor(private router: Router,
    private pedidoService: PedidoService) { }

  ngOnInit() {
    this.listarPedidos();
  }

  private listarPedidos() : void{
    this.pedidoService.listar().subscribe(lista => {
      this.pedidos = lista;
    });
  }

  deletar(pedido: Pedido): void {
    this.pedidoService.deletar(pedido).subscribe(r => {
      this.resultado = this.pedidoService.obterResultadoCommand(r);
      if (this.resultado.isValid === true) {
        this.listarPedidos();
      }
    });
  }

  private editar(id: string) : void {
    this.router.navigate(['pedidos', 'editar', id]);
  }
}
