// groups.component.ts
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GroupService } from './groups.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css'],
})
export class GroupsComponent implements OnInit {
  nume: string = '';
  destinatie: string = '';
  members: string = '';
  tripGroups: any[] = [];
  constructor(private groupService: GroupService, private router: Router) {}

  ngOnInit(): void {
    this.getGroups();
  }
  addGroup() {
    const memberList = this.members.split(',').map(email => email.trim());
    this.groupService.addGroup(this.nume, memberList).subscribe({
      next: (result) => {
        console.log(result);
  
        const groupId = result.id;
  
        if (groupId != null) {
          this.groupService.addTrip(this.destinatie, groupId).subscribe({
            next: (result) => {
              console.log(result);
              //i want to refresh the page
              this.getGroups();
            }
          });
        }
      },
      error: (error) => {
        console.error('There was an error!', error);
      }
    });
  }

  getGroups() {
   this.groupService.getGrupTrips().subscribe({
      next: (result) => {
        console.log(result);
        this.tripGroups = result;
      },
      error: (error) => {
        console.error('There was an error!', error);
      }
    });
   }

  

  navigateToDetails(group: any) {
    this.router.navigate(['/group-details', group.id]);
  }
}
