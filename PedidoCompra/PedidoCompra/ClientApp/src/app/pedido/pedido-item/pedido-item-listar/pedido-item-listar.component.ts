import { Component, OnInit, Input, Output } from '@angular/core';
import { PedidoItem } from '../../pedido-item.model';

@Component({
  selector: 'app-pedido-item-listar',
  templateUrl: './pedido-item-listar.component.html'
})
export class PedidoItemListarComponent implements OnInit {

  @Input() itens: PedidoItem[];
  
  constructor() { }

  ngOnInit() {
  }

  private deletar(index: number): void{
    this.itens.splice(index, 1);
  }
}
