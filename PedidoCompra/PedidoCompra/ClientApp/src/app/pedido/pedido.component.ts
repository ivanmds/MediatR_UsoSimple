import { Component, OnInit, Inject } from '@angular/core';
import { Pedido } from './models/pedido.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
  private uri: string = this.baseUrl + 'api/pedidos';
  private pedidoIdEditando: string = "";

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private route: ActivatedRoute,
    private pedidoService: PedidoService,
    @Inject('BASE_URL') private baseUrl: string) { }

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
      this.resultado = this.pedidoService.obterResultadoCommand(r);

      if (this.resultado.isValid === true) {
        this.listarPedidos();
      }
    });
  }

  salvarNovo(pedido: Pedido) {

    this.pedidoService.novo(pedido).subscribe(r => {
      this.resultado = this.pedidoService.obterResultadoCommand(r);
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
        this.resultado = this.pedidoService.obterResultadoCommand(r);
        if (this.resultado.isValid === true) {
          this.pedidoItens.push(item);
        }
      });
    }
  }

  itemDeletado(resultado: ResultadoCommand) {
    this.resultado = resultado;
  }

  deletarPedido(pedido: Pedido): void {
    this.pedidoService.deletar(pedido).subscribe(r => {
      this.resultado = this.pedidoService.obterResultadoCommand(r);
      if (this.resultado.isValid === true) {
        this.listarPedidos();
      }
    });
  }

  private carregarRetorno(result: any): void {
    let errors = [];
    result.errors.forEach(erro => {
      errors.push(erro.errorMessage);
    });

    this.resultado.isValid = result.isValid;
    this.resultado.errors = errors;
    setTimeout(() => {
      this.resultado = new ResultadoCommand();
    }, 10000);
  }
}