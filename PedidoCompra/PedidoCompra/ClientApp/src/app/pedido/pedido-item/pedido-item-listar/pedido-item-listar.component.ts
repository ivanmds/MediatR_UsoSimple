import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PedidoItem } from '../../models/pedido-item.model';
import { PedidoService } from '../../../services/pedido-service';
import { ResultadoCommand } from '../../../shared/resultado.model';

@Component({
  selector: 'app-pedido-item-listar',
  templateUrl: './pedido-item-listar.component.html'
})
export class PedidoItemListarComponent implements OnInit {

  @Input() itens: PedidoItem[];
  @Output() itemDeletado = new EventEmitter<ResultadoCommand>();

  constructor(private pedidoService: PedidoService) { }

  ngOnInit() {
  }

  private deletar(index: number): void {
    let item = this.itens[index];
    
    if (item.id == null) {
      this.itens.splice(index, 1);
    } else {
      this.pedidoService.deletarItem(item).subscribe(r => {

        let resultado = this.pedidoService.obterResultadoCommand(r);
        if(resultado.isValid) {
          this.itens.splice(index, 1);
        }

        this.itemDeletado.emit(resultado);
      });
    }
  }
}
