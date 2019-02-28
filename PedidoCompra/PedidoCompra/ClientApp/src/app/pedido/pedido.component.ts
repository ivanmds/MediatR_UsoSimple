import { Component, OnInit, Inject } from '@angular/core';
import { Pedido } from './models/pedido.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResultadoCommand } from '../shared/resultado.model';
import { PedidoItem } from './models/pedido-item.model';
import { ActivatedRoute } from '@angular/router';
import { PedidoService } from '../services/pedido-service';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html'
})
export class PedidoComponent implements OnInit {

  private pedidos: Pedido[];
  private resultado: ResultadoCommand = new ResultadoCommand();
  private form: FormGroup;
  private pedidoItens: PedidoItem[] = new Array();
  private pedidoIdEditando: string = "";

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private pedidoService: PedidoService) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      id: [null],
      criado: [null, [Validators.required]],
      descricao: [null, [Validators.required]],
      status: [null, [Validators.required]]
    });

    this.route.params.subscribe(p => {
      this.pedidoIdEditando = p['id'];
      if (this.pedidoIdEditando != null) {
        this.editarPedido(this.pedidoIdEditando);
      }
    });

    this.listarPedidos();
  }

  onSubmit(): void {
    if (this.form.valid) {
      let pedido = this.form.value;
      pedido.itens = this.pedidoItens;

      if (pedido.id === null) {
        this.salvarNovo(pedido);
      } else {
        this.salvarAtualizacao(pedido);
      }
    }
  }

  salvarAtualizacao(pedido: Pedido) {
    this.pedidoService.atualizar(pedido).subscribe(r => {
      this.mostrarResultado(this.pedidoService.obterResultadoCommand(r));

      if (this.resultado.isValid === true) {
        this.listarPedidos();
      }
    });
  }

  salvarNovo(pedido: Pedido) {
    delete pedido.id;
    this.pedidoService.novo(pedido).subscribe(r => {
      this.mostrarResultado(this.pedidoService.obterResultadoCommand(r));
      if (this.resultado.isValid === true) {
        this.form.reset();
        this.listarPedidos();
        this.pedidoItens = new Array();
      }
    });
  }

  listarPedidos(): void {
    this.pedidoService.listar().subscribe(retorno => {
      this.pedidos = retorno;
    });
  }

  editarPedido(pedidoId: string): void {
    this.pedidoService.obter(pedidoId).subscribe(retorno => {

      this.form.setValue({
        id: retorno.id,
        descricao: retorno.descricao,
        criado: new Date(retorno.criado).toISOString().split('T')[0],
        status: retorno.status
      });

      this.pedidoItens = retorno.itens;
    });
  }

  novoItemDoPedido(item: any): void {

    if (this.pedidoIdEditando == null) {
      this.pedidoItens.push(item);
    } else {
      this.pedidoService.novoItem(this.pedidoIdEditando, item).subscribe(r => {
        this.mostrarResultado(this.pedidoService.obterResultadoCommand(r));
        if (this.resultado.isValid === true) {
          this.pedidoItens.push(item);
        }
      });
    }
  }

  itemDeletado(resultado: ResultadoCommand) {
    this.mostrarResultado(resultado);
  }

 

  private mostrarResultado(resultado: ResultadoCommand): void {
    this.resultado = resultado;
    setTimeout(() => {
      this.resultado = new ResultadoCommand();
    }, 10000);
  }
}