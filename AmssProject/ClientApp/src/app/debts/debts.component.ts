import { Component } from '@angular/core';
import { DebtsService } from './debts.service';

@Component({
  selector: 'app-debts',
  templateUrl: './debts.component.html',
  styleUrls: ['./debts.component.css'],
})
export class DebtsComponent {
  toPayDebts: any[] = [];
  toReceiveDebts: any[] = [];

  constructor(private debtsService: DebtsService) {
    this.loadDebts();
  }

  loadDebts() {
    this.toPayDebts = this.debtsService.getToPayDebts();
    this.toReceiveDebts = this.debtsService.getToReceiveDebts();
  }

  updateDebtStatus(debtCategory: string, index: number) {
    if (debtCategory === 'toPay') {
      this.debtsService.updateToPayDebtStatus(index);
    } else if (debtCategory === 'toReceive') {
      this.debtsService.updateToReceiveDebtStatus(index);
    }
    this.loadDebts();
  }
}
