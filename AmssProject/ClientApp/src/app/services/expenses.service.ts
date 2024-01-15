import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ExpensesService {
  private cheltuialaBaseUrl: string = "https://localhost:7242/api/Cheltuiala"
  private datorieBaseUrl: string = "https://localhost:7242/api/Datorie"

  constructor() { }



  addExpense(groupTitle: string, expenseData: any) {
  }
}
