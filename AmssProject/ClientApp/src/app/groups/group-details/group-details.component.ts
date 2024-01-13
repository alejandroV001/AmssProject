import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GroupService } from '../groups.service';

@Component({
  selector: 'app-group-details',
  templateUrl: './group-details.component.html',
  styleUrls: ['./group-details.component.css'],
})
export class GroupDetailsComponent implements OnInit {
  groupTitle: string = '';
  expenseForm: FormGroup;

  constructor(
    public route: ActivatedRoute,
    public groupService: GroupService,
    public fb: FormBuilder
  ) {
    this.expenseForm = this.fb.group({
      totalPayment: ['', Validators.required],
      currency: ['', Validators.required],
      category: ['', Validators.required],
      participants: [[]],
      description: [''],
    });
  }

  ngOnInit(): void {
    this.groupTitle = this.route.snapshot.paramMap.get('title') || '';
  }

  addExpense() {
    const expenseData = this.expenseForm.value;
    this.groupService.addExpense(this.groupTitle, expenseData);
    this.expenseForm.reset();
  }
}
