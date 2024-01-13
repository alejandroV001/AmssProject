import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GroupService {
  private groups: any[] = [];
  public expenseAdded = new EventEmitter<void>();

  getGroups() {
    return this.groups;
  }

  addGroup(title: string, members: string[]) {
    const newGroup = {
      title,
      members,
      expenses: [],
    };
    this.groups.push(newGroup);
  }

  getMembers(groupTitle: string) {
    const group = this.groups.find(g => g.title === groupTitle);
    return group ? group.members : [];
  }

  getExpenses(groupTitle: string) {
    const group = this.groups.find(g => g.title === groupTitle);
    return group ? group.expenses : [];
  }

  addExpense(groupTitle: string, expenseData: any) {
    const group = this.groups.find(g => g.title === groupTitle);
    if (group) {
      group.expenses.push(expenseData);
      this.expenseAdded.emit();
    }
  }
}
