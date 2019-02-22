import { Component, OnInit, OnDestroy } from '@angular/core';
import { TelaCarregandoService } from '../services/tela-carregando.service';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-tela-carregando',
  templateUrl: './tela-carregando.component.html',
  styleUrls: ['./tela-carregando.component.css']
})
export class TelaCarregandoComponent implements OnInit, OnDestroy {
 
  carregando: boolean = false;
  carregandoSubscription: Subscription;

  constructor(private telaCarregando: TelaCarregandoService) { }

  ngOnInit() {
     this.carregandoSubscription = this.telaCarregando.carregandoStatus.subscribe((valor) => {
       this.carregando = valor;
     });
  }

  ngOnDestroy(): void {
    this.telaCarregando.carregandoStatus.unsubscribe();
  }
}
