import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CalatorieGrupDto } from 'src/models/trip-group';
import { LocalStorageService } from '../services/local-storage-service.service';
@Injectable({
  providedIn: 'root',
})
export class GroupService {
  private groupBaseUrl: string = 'https://localhost:7242/api/Grup';
  private tripBaseUrl: string = 'https://localhost:7242/api/Calatorie';
  private expenseBaseUrl: string = 'https://localhost:7242/api/Cheltuiala';
  private debtBaseUrl: string = 'https://localhost:7242/api/Datorie';
  private groups: any[] = [];
  constructor(private http: HttpClient,
              private localStorageService: LocalStorageService) {}
  getGroups() {
    return this.http.get<any[]>(this.groupBaseUrl);
  }

  addGroup(nume: string, members: string[]) {
    const newGroup = {
      nume,
      capacitate: members.length,
    };
    this.groups.push(newGroup);
    return this.http.post<any>(this.groupBaseUrl, newGroup);
    // newGroup.expenses = [];
  }

  getGrupTrip(tripId: number) {
    return this.http.get<any[]>(this.tripBaseUrl + '/' + tripId);
  }

  getGrupTrips() {
    return this.http.get<CalatorieGrupDto[]>(
      this.tripBaseUrl + '/calatoriiGrup'
    );
  }

  getGrupTripWithId(id: number) {
    return this.http.get<CalatorieGrupDto[]>(
      this.tripBaseUrl + '/calatorieGrup/' + id
    );
  }

  addDebt(stare: boolean, cheltuialaId: number, suma: number) {
    const newDebt = {
      stare,
      suma: suma,
      pentruUtilizatorId: this.localStorageService.getItem<{ id: string;}>('user')?.id,
      deLaUtilizatorId: this.localStorageService.getItem<{ id: string;}>('user')?.id,
      cheltuialaId,
    };
    console.log(newDebt)

    return this.http.post<any>(this.debtBaseUrl, newDebt);
  }

  getDebts() {
    return this.http.get<any>(this.debtBaseUrl);
  }

  addTrip(destinatie: string, grupId: number) {
    const newTrip = {
      destinatie,
      grupId,
    };
    return this.http.post<any>(this.tripBaseUrl, newTrip);
  }

  getMembers(groupTitle: string) {
    const group = this.groups.find((g) => g.nume === groupTitle);
    return group ? group.members : [];
  }

  getExpenses() {
    return this.http.get<any[]>(this.expenseBaseUrl);
  }

  addExpense(calatorieId: number, descriere: string, moneda: string, costTotal: number) {
    const newExpense = {
      tipCheltuialaId: 1,
      calatorieId,
      utilizatorId: this.localStorageService.getItem<{ id: string;}>('user')?.id,
      descriere,
      moneda,
      costTotal,
    };
    console.log(this.localStorageService.getItem<{ id: string;}>('user')?.id);
    return this.http.post<any>(this.expenseBaseUrl, newExpense);
  }
}
