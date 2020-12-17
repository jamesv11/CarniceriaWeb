import { Component, Input, OnInit } from '@angular/core';
import {NgbActiveModal, NgbModalConfig} from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-alert-modal',
  templateUrl: './alert-modal.component.html',
  styleUrls: ['./alert-modal.component.css']
})
export class AlertModalComponent implements OnInit {

  constructor(config: NgbModalConfig, public activeModal: NgbActiveModal) {
    config.backdrop = 'static';
    config.keyboard = false;
   }
  @Input() title;
  @Input() message;
  ngOnInit(): void {
  }

}
