// debts.service.ts
import { Injectable } from '@angular/core';
import { GroupService } from '../groups/groups.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class DebtsService {
  private debtBaseUrl: string = 'https://localhost:7242/api/Datorie';

  private toPayDebts: any[] = [
    { to: 'Andreea', amount: 20, status: 'Paid' },
    { to: 'Daniel', amount: 30, status: 'Unpaid' },
  ];

  private toReceiveDebts: any[] = [];

  constructor(private groupService: GroupService, private http: HttpClient) {
    // this.loadToReceiveDebts();
    // this.getDebts();
  }

  loadToReceiveDebts() {
    const groups = this.groupService.getGroups().subscribe({
      next: (result) => {
        // this.debts = result;
      },
      error: (error) => {
        console.error('There was an error!', error);
      },
    });

    // groups.forEach((group: any) => {
    //   const totalExpenses = group.cheltuieli?.reduce(
    //     (total: any, expense: any) => total + expense.totalPayment,
    //     0
    //   );

    //   group.expenses.forEach((expense: any) => {
    //     const sharePerMember =
    //       expense.totalPayment / expense.participants.length;

    //     expense.participants?.forEach((participant: any) => {
    //       const existingDebt = this.toReceiveDebts.find(
    //         (debt) => debt.from === participant
    //       );

    //       if (!existingDebt) {
    //         this.toReceiveDebts.push({
    //           from: participant,
    //           amount: sharePerMember,
    //           status: 'Unpaid',
    //         });
    //       } else {
    //         existingDebt.amount += sharePerMember;
    //       }
    //     });
    //   });
    // });

    console.log('To Receive:', this.toReceiveDebts);
  }

  getToPayDebts() {
    return this.toPayDebts;
  }

  getToReceiveDebts() {
    return this.toReceiveDebts;
  }

  updateToPayDebtStatus(index: number) {
    this.toPayDebts[index].status =
      this.toPayDebts[index].status === 'Paid' ? 'Unpaid' : 'Paid';
  }

  updateToReceiveDebtStatus(index: number) {
    this.toReceiveDebts[index].status =
      this.toReceiveDebts[index].status === 'Paid' ? 'Unpaid' : 'Paid';
  }

  getDebts() {
    return this.http.get<any>(this.debtBaseUrl);
  }
}
