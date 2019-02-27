import { Injectable } from "@angular/core";
import { HttpBaseService } from "./http-base.service";
import { PedidoItem } from "../pedido/models/pedido-item.model";
import { ResultadoCommand } from "../shared/resultado.model";
import { Observable } from "rxjs/Observable";

@Injectable()
export class PedidoService extends HttpBaseService {

    private urlBase = `${this.baseUrl}/api/pedidos`;

    public deletarItem<T>(item: PedidoItem): Observable<T> {
        let uri = `${this.urlBase}/${item.pedidoId}/itens/${item.id}`;
        return this.delete(uri);
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