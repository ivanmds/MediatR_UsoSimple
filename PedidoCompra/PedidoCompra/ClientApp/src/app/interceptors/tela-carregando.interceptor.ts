import { HttpInterceptor, HttpRequest, HttpEvent, HttpHandler } from "@angular/common/http";
import { TelaCarregandoService } from "../services/tela-carregando.service";
import { Observable } from "rxjs/Observable";
import { request } from "https";
import { finalize } from 'rxjs/operators';
import { Injectable } from "@angular/core";

@Injectable()
export class TelaCarregandoInterceptor implements HttpInterceptor {

    _requisicoesAtivas: number = 0;

    constructor(private _telaCarrengado: TelaCarregandoService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(this._requisicoesAtivas === 0) {
            this._telaCarrengado.iniciar();
        }

        this._requisicoesAtivas++;
        return next.handle(req).pipe(
            finalize(() => {
                this._requisicoesAtivas--;
                if(this._requisicoesAtivas === 0) {
                    this._telaCarrengado.parar();
                }
            })
        );
    }
}