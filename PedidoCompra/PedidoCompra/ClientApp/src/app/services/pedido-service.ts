import { Injectable } from "@angular/core";
import { HttpBaseService } from "./http-base.service";
import { PedidoItem } from "../pedido/models/pedido-item.model";
import { ResultadoCommand } from "../shared/resultado.model";
import { Observable } from "rxjs/Observable";
import { Pedido } from "../pedido/models/pedido.model";

@Injectable()
export class PedidoService extends HttpBaseService {

    private urlBasePedidos = `${this.baseUrl}/api/pedidos`;

    public novo<T>(pedido: Pedido): Observable<T> {
        return this.post<T>(this.urlBasePedidos, pedido);
    }

    public listar() : Observable<Pedido[]> {
        return this.get<Pedido[]>(this.urlBasePedidos);
    }

    public obter(id: string): Observable<Pedido> {
        let uri = `${this.urlBasePedidos}/${id}`;
        return this.get<Pedido>(uri);
    }

    public atualizar<T>(pedido: Pedido): Observable<T> {
        let uri = `${this.urlBasePedidos}/${pedido.id}`;
        return this.http.put<T>(uri, pedido);
    }

    public deletar<T>(pedido: Pedido): Observable<T> {
        let uri = `${this.urlBasePedidos}/${pedido.id}`;
        return this.delete<T>(uri);
    }

    

    public novoItem<T>(pedidoId: string, item: PedidoItem): Observable<T> {
        let uri = `${this.urlBasePedidos}/${pedidoId}/itens`;
        return this.post<T>(uri, item);
    }

    public deletarItem<T>(item: PedidoItem): Observable<T> {
        let uri = `${this.urlBasePedidos}/${item.pedidoId}/itens/${item.id}`;
        return this.delete<T>(uri);
    }

    public obterResultadoCommand(result: any): ResultadoCommand {
        let resultado = new ResultadoCommand();

        result.errors.forEach(erro => {
            resultado.errors.push(erro.errorMessage);
        });
        
        resultado.isValid = result.isValid;
        return resultado;
    }
}