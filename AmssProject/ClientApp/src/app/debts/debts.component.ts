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
    this.getDebts();
    console.log(this.toReceiveDebts);
  }

  getDebts() {
    const test = this.debtsService.getDebts().subscribe({
      next: (result) => {
        this.toReceiveDebts = result;
      },
      error: (error) => {
        console.error('There was an error!', error);
      },
    });

    return [];
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
