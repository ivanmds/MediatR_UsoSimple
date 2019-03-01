import { PedidoItem } from "./pedido-item.model";
import { Cartao } from "./cartao.model";

export class Pedido {
    public id: string;
    public criado: Date;
    public descricao: string;
    public status: number;
    public itens: PedidoItem[] = new Array();
    public cartao: Cartao = new Cartao();
}