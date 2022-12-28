import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ComponentName } from '../models/visit.model';

@Injectable({
  providedIn: 'root'
})
export class VisitService {

  constructor(private httpClient: HttpClient) { }

  public storeVisit(componentName: ComponentName): void {
    const url = `http://${environment.backendServerAdress}:${environment.backendServerPort}/usagedata/storevisit?componentName=${componentName}`;
     this.httpClient
      .post(url, null)
      .pipe(catchError(() => of(null)))
      .subscribe();
  }
  
}
