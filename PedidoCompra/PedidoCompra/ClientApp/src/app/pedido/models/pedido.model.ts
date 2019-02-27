import { PedidoItem } from "./pedido-item.model";

export class Pedido {
    public id: string;
    public criado: Date;
    public descricao: string;
    public status: number;
    public itens: PedidoItem[] = new Array();
}