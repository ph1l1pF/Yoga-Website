import { Component, OnInit } from '@angular/core';
import { VisitService } from 'src/app/services/visit.service';
import { constants } from 'src/constants';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  constructor(private visitService: VisitService) { }

  ngOnInit(): void {
    this.visitService.storeVisit('Courses');
  }

}
