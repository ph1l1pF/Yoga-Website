import { Component, OnInit } from '@angular/core';
import { constants } from 'src/constants';

@Component({
  selector: 'app-impress',
  templateUrl: './impress.component.html',
  styleUrls: ['./impress.component.css']
})
export class ImpressComponent {
  public constants = constants;
}
