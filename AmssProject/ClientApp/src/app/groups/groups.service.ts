import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CalatorieGrupDto } from 'src/models/trip-group';
@Injectable({
  providedIn: 'root',
})
export class GroupService {
  private groupBaseUrl: string = "https://localhost:7242/api/Grup"
  private tripBaseUrl: string = "https://localhost:7242/api/Calatorie"
  private expenseBaseUrl: string = "https://localhost:7242/api/Cheltuiala"
  private groups: any[] = [];
  constructor(private http: HttpClient) {}
  getGroups() {
    return this.http.get<any[]>(this.groupBaseUrl);
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
  
  getGrupTrip(tripId: number){
    return this.http.get<any[]>(this.tripBaseUrl + "/" + tripId);
  }
  
  getGrupTrips(){
    return this.http.get<CalatorieGrupDto[]>(this.tripBaseUrl+"/calatoriiGrup");
  }

  getGrupTripWithId(id: number){
    return this.http.get<CalatorieGrupDto[]>(this.tripBaseUrl+"/calatorieGrup/" + id);
  }


  addTrip(destinatie: string, grupId: number) {
    const newTrip = {
      destinatie,
      grupId
    };
    return this.http.post<any>(this.tripBaseUrl, newTrip);
  }

  getMembers(groupTitle: string) {
    const group = this.groups.find(g => g.nume === groupTitle);
    return group ? group.members : [];
  }

  getExpenses() {
    return this.http.get<any[]>(this.expenseBaseUrl);
  }

  addExpenses(groupTitle: string, expenseData: any) {
    const group = this.groups.find(g => g.nume === groupTitle);
    if (group) {
      group.expenses.push(expenseData);
    }
  }
}
