import { Component, TemplateRef, OnInit, Output } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { EventEmitter } from '@angular/core';
import { PedidoItem } from '../models/pedido-item.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
 
@Component({
  selector: 'app-pedido-item-modal',
  templateUrl: './pedido-item-modal.html'
})
export class PedidoItemModalComponent implements OnInit {
  modalRef: BsModalRef;

  @Output() novoItem = new EventEmitter<PedidoItem>();
  formItem: FormGroup;

  constructor(private formBuilder: FormBuilder, private modalService: BsModalService) {}

  ngOnInit() {
    this.formItem = this.formBuilder.group({
      descricao: [null, [Validators.required]],
      quantidade: [null, [Validators.required]],
      valorUnitario: [null, [Validators.required]]
    });
  }

 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  private adicionar(): void{
    let item = this.formItem.value;
    this.formItem.reset();
    this.novoItem.emit(item);
    this.modalRef.hide();
  }
}