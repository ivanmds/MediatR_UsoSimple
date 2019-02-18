import { Component, OnInit, Inject } from '@angular/core';
import { Pedido } from '../pedido.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResultadoCommand } from '../../shared/resultado.model';
import { strictEqual } from 'assert';

@Component({
  selector: 'app-pedido-add',
  templateUrl: './pedido-add.component.html'
})
export class PedidoAddComponent implements OnInit {

  public pedidos: Pedido[];
  public resultado: ResultadoCommand = new ResultadoCommand();
  public form: FormGroup;

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
      let body = JSON.stringify(this.form.value);
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };     

      let uri = this.baseUrl + 'api/pedidos';

      this.http.post<any>(uri, body, httpOptions).subscribe(result => {
        let errors = [] ;
        result.errors.forEach(erro => {
          errors.push(erro.errorMessage);
        });

        this.resultado.isValid = result.isValid;
        this.resultado.errors = errors;

        if(this.resultado.isValid === true)
        {
          this.form.reset();
          this.listarPedidos();
        }

      }, error => console.error(error));
    }
  }

  listarPedidos(): void {
    let uri = this.baseUrl + 'api/pedidos';
    this.http.get<Pedido[]>(uri).subscribe(retorno => {
      this.pedidos = retorno;
    });
  }
}
