import { Component, OnInit, Inject } from '@angular/core';
import { Pedido } from './models/pedido.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResultadoCommand } from '../shared/resultado.model';
import { PedidoItem } from './models/pedido-item.model';
import { ActivatedRoute } from '@angular/router';

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
    let body = JSON.stringify(pedido);
    this.http.put<any>(`${this.uri}/${pedido.id}`, body, this.httpOptions).subscribe(retorno => {

      this.carregarRetorno(retorno);
      if (this.resultado.isValid === true) {
        this.listarPedidos();
      }
    }, error => console.error(error));
  }

  salvarNovo(pedido: Pedido) {

    let body = JSON.stringify(pedido);
    this.http.post<any>(this.uri, body, this.httpOptions).subscribe(retorno => {

      this.carregarRetorno(retorno);

      if (this.resultado.isValid === true) {
        this.form.reset();
        this.listarPedidos();
        this.pedidoItens = new Array();
      }

    }, error => console.error(error));
  }

  listarPedidos(): void {
    this.http.get<Pedido[]>(this.uri).subscribe(retorno => {
      this.pedidos = retorno;
    });
  }

  editarPedido(pedidoId: string): void {
    this.http.get<Pedido>(`${this.uri}/${pedidoId}`).subscribe(retorno => {

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
      let uri = `${this.uri}/${this.pedidoIdEditando}/itens`;

      let body = JSON.stringify(item);
      this.http.post<any>(uri, body, this.httpOptions).subscribe(retorno => {

        this.carregarRetorno(retorno);
        if (this.resultado.isValid === true) {
          this.pedidoItens.push(item);
        }

      }, error => console.error(error));
    }
  }

  itemDeletado(resultado: ResultadoCommand) {
    this.resultado = resultado;
  }

  deletarPedido(pedido: Pedido): void {
    let uri = `${this.uri}/${pedido.id}`;
    this.http.delete(uri).subscribe(retorno => {
      this.carregarRetorno(retorno);
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