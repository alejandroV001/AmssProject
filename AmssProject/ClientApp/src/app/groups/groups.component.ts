// groups.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { GroupService } from './groups.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css'],
})
export class GroupsComponent {
  nume: string = '';
  destinatie: string = '';
  members: string = '';
  
  constructor(private groupService: GroupService, private router: Router) {}

  addGroup() {
    const memberList = this.members.split(',').map(email => email.trim());
    this.groupService.addGroup(this.nume, memberList).subscribe({
      next: (result) => {
        console.log(result);
  
        const groupId = result.id;
  
        if (groupId != null) {
          this.groupService.addTrip(this.destinatie, groupId);
        }
      },
      error: (error) => {
        console.error('There was an error!', error);
      }
    });
  }

  getGroups() {
    return this.groupService.getGroups();
  }

  navigateToDetails(group: any) {
    this.router.navigate(['/group-details', group.nume]);
  }
}
