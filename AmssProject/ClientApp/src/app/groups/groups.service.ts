import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class GroupService {
  private groupBaseUrl: string = "https://localhost:7242/api/Grup"
  private tripBaseUrl: string = "https://localhost:7242/api/Calatorie"
  private groups: any[] = [];
  constructor(private http: HttpClient) {}
  getGroups() {
    return this.groups;
  }

  addGroup(nume: string, members: string[]) {
    const newGroup = {
      nume,
      capacitate: members.length
    };
    this.groups.push(newGroup);
    return this.http.post<any>(this.groupBaseUrl, newGroup);
    // newGroup.expenses = [];
  }
  addTrip(destinatie: string, grupId: number) {
    const newTrip = {
      destinatie,
      grupId
    };
    this.http.post<any>(this.tripBaseUrl, newTrip).subscribe({
      next: data => {
        console.log(data);
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }

  getMembers(groupTitle: string) {
    const group = this.groups.find(g => g.nume === groupTitle);
    return group ? group.members : [];
  }

  getExpenses(groupTitle: string) {
    const group = this.groups.find(g => g.nume === groupTitle);
    return group ? group.expenses : [];
  }

  addExpense(groupTitle: string, expenseData: any) {
    const group = this.groups.find(g => g.nume === groupTitle);
    if (group) {
      group.expenses.push(expenseData);
    }
  }
}
