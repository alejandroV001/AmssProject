import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GroupService } from '../groups.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-group-details',
  templateUrl: './group-details.component.html',
  styleUrls: ['./group-details.component.css'],
})
export class GroupDetailsComponent implements OnInit {
  groupId: string = '';
  expenseForm: FormGroup;
  groupBaseUrl: string = 'https://localhost:7242/api/Grup';
  groupDetails: any = { destinatie: '' };

  constructor(
    public route: ActivatedRoute,
    public fb: FormBuilder,
    public http: HttpClient,
    public groupService: GroupService
  ) {

    this.expenseForm = this.fb.group({
      suma: ['', Validators.required],
      currency: ['', Validators.required],
      category: ['', Validators.required],
      participants: [[]],
      description: [''],
    });    

    this.groupId = this.route.snapshot.paramMap.get('id') || '';
    this.getGrupTrip(parseInt(this.groupId));
    this.getExpensesOfTrip(parseInt(this.groupId));
  }

  ngOnInit(): void {
    this.groupId = this.route.snapshot.paramMap.get('id') || '';
    this.getGrupTrip(parseInt(this.groupId));
    this.getExpensesOfTrip(parseInt(this.groupId));
  }

  addExpense() {
    this.groupService
      .addExpense(
        parseInt(this.groupId),
        this.expenseForm.value.description,
        this.expenseForm.value.currency,
        this.expenseForm.value.suma,
      )
      .subscribe({
        next: (result) => {
          const expenseId = result.id;

          if (expenseId != null) {
            console.log(this.expenseForm)
            this.groupService
              .addDebt(
                false,
                expenseId,
                this.expenseForm.value.suma
              )
              .subscribe({
                next: (result) => {
                  console.log(result)
                },
              });
          }
        },
        error: (error) => {
          console.error('There was an error!', error);
        },
      });
      this.getExpensesOfTrip(parseInt(this.groupId));
    // this.expenseForm.reset();
  }

  getGrupTrip(id: number) {
    this.groupService.getGrupTripWithId(id).subscribe({
      next: (result: any) => {
        let members: any = [];
        for (let i = 0; i < result.grup.capacitate; i++)
          members.push('Member ' + i);
        this.groupDetails = { ...result, members };
        console.log('group deta', this.groupDetails);
      },
      error: (error) => {
        console.error('There was an error!', error);
      },
    });
  }

  getExpensesOfTrip(tripId: number) {
    this.groupService.getExpenses().subscribe({
      next: (result) => {
        this.groupDetails.cheltuieli = result.filter(
          (expense: any) => expense.calatorieId === tripId
        );
        console.log('DOAMNE CE', this.groupDetails.cheltuieli);
      },
      error: (error) => {
        console.error('There was an error!', error);
      },
    });
  }
}
