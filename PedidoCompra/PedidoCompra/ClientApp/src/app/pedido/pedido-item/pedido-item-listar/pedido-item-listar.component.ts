import { Component, OnInit, Input } from '@angular/core';
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

}
