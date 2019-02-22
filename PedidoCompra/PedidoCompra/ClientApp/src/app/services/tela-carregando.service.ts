import { Injectable } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Injectable()
export class TelaCarregandoService {
    private _carregando: boolean = false;
    carregandoStatus: Subject<boolean> = new Subject();

    get carregando(): boolean {
        return this._carregando;
    }

    set carregando(valor: boolean) {
        this._carregando = valor;
        this.carregandoStatus.next(valor);
    }

    public iniciar(): void {
        this.carregando = true;
    }

    public parar(): void {
        this.carregando = false;
    }
}