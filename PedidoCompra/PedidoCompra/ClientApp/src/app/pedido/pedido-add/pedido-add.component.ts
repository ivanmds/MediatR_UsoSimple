import { Component, OnInit, Inject } from '@angular/core';
import { Pedido } from '../pedido.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResultadoCommand } from '../../shared/resultado.model';
import { PedidoItem } from '../pedido-item.model';

@Component({
  selector: 'app-pedido-add',
  templateUrl: './pedido-add.component.html'
})
export class PedidoAddComponent implements OnInit {

  private pedidos: Pedido[];
  private resultado: ResultadoCommand = new ResultadoCommand();
  private form: FormGroup;
  private itensNovos: PedidoItem[] = new Array();
  private uri: string =  this.baseUrl + 'api/pedidos';

  constructor(private formBuilder: FormBuilder,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      criado: [null, [Validators.required]],
      descricao: [null, [Validators.required]],
      status: [null, [Validators.required]]
    });
    this.listarPedidos();
  }

  onSubmit(): void {
    if (this.form.valid) {
      let pedido = this.form.value;
      pedido.itens = this.itensNovos;

      let body = JSON.stringify(pedido);
      console.log(body);
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };

      this.http.post<any>(this.uri, body, httpOptions).subscribe(retorno => {
       
        this.carregarRetorno(retorno);

        if (this.resultado.isValid === true) {
          this.form.reset();
          this.listarPedidos();
          this.itensNovos = new Array();
        }

      }, error => console.error(error));
    }
  }

  listarPedidos(): void {
    this.http.get<Pedido[]>(this.uri).subscribe(retorno => {
      this.pedidos = retorno;
    });
  }

  novoItemDoPedido(item: any): void {
    this.itensNovos.push(item);
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

  private carregarRetorno(result: any) :void{
    let errors = [];
    result.errors.forEach(erro => {
      errors.push(erro.errorMessage);
    });

    this.resultado.isValid = result.isValid;
    this.resultado.errors = errors;
    setTimeout(() => {
      this.resultado = new ResultadoCommand();
    }, 5000);
  }

}
