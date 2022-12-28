import { BreakpointObserver, BreakpointState, MediaMatcher } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { VisitService } from 'src/app/services/visit.service';

@Component({
  selector: 'app-yoga-room',
  templateUrl: './yoga-room.component.html',
  styleUrls: ['./yoga-room.component.css']
})
export class YogaRoomComponent implements OnInit {

  public isMobileDevice: boolean;

  constructor(public breakpointObserver: BreakpointObserver,
              private visitService: VisitService) {}

  ngOnInit() {
    this.breakpointObserver
      .observe(['(max-width: 600px)'])
      .subscribe((state: BreakpointState) => {
        if (state.matches) {
          this.isMobileDevice = true;
        } else {
          this.isMobileDevice = false;
        }
      });
      this.visitService.storeVisit('Yoga-Room');
  }



}
