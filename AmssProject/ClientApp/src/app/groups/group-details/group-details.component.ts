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
  groupService: GroupService;

  constructor(
    public route: ActivatedRoute,
    public fb: FormBuilder,
    public http: HttpClient
  ) {
    this.groupService = new GroupService(http);

    this.expenseForm = this.fb.group({
      totalPayment: ['', Validators.required],
      currency: ['', Validators.required],
      category: ['', Validators.required],
      participants: [[]],
      description: [''],
    });
  }

  ngOnInit(): void {
    this.groupId = this.route.snapshot.paramMap.get('id') || '';
    this.getGrupTrip(parseInt(this.groupId));
  }

  addExpense() {
    const expenseData = this.expenseForm.value;
    this.groupService.addExpenses(this.groupId, expenseData);
    this.expenseForm.reset();
  }

  getGrupTrip(id: number) {
    this.groupService.getGrupTripWithId(id).subscribe({
      next: (result) => {
        this.groupDetails = result;
        console.log('group deta', this.groupDetails);
      },
      error: (error) => {
        console.error('There was an error!', error);
      },
    });
  }
}
