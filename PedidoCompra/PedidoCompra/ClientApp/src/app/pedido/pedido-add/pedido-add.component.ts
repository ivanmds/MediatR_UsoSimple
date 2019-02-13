import { Component, OnInit, Inject } from '@angular/core';
import { Pedido } from '../pedido.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-pedido-add',
  templateUrl: './pedido-add.component.html'
})
export class PedidoAddComponent implements OnInit {

  public pedido: Pedido;
  public form: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      descricao: [null, [Validators.required]],
    });
  }

  onSubmit(): void {
    if (this.form.valid) {
      let body = JSON.stringify(this.form.value);
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };      //var headersOptions = new Headers({ 'Content-Type': 'application/json' });

      let uri = this.baseUrl + 'api/pedidos';

      this.http.post(uri, body, httpOptions).subscribe(result => {

      }, error => console.error(error));

    }
  }

}
