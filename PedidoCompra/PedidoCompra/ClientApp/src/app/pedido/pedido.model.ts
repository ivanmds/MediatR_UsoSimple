import { PedidoItem } from "./pedido-item.model";

export class Pedido {
    constructor(public id: string,
        public criado: Date,
        public descricao: string,
        public status: number,
        public Itens: PedidoItem[]){ }
}