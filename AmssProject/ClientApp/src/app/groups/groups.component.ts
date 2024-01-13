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
  title: string = '';
  members: string = '';
  
  constructor(private groupService: GroupService, private router: Router) {}

  addGroup() {
    const memberList = this.members.split(',').map(email => email.trim());
    this.groupService.addGroup(this.title, memberList);
    this.title = '';
    this.members = '';
  }

  getGroups() {
    return this.groupService.getGroups();
  }

  navigateToDetails(group: any) {
    this.router.navigate(['/group-details', group.title]);
  }
}
