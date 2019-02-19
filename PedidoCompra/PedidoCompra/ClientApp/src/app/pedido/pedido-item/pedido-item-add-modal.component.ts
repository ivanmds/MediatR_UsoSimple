import { Component, TemplateRef, OnInit, Output } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { EventEmitter } from '@angular/core';
import { PedidoItem } from '../pedido-item.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
 
@Component({
  selector: 'app-pedido-item-add-modal',
  templateUrl: './pedido-item-add-modal.html'
})
export class PedidoItemAddModalComponent implements OnInit {
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
  }
}