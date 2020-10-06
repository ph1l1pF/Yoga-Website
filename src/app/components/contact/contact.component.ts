import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';


@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {

  @ViewChild('inputMailFrom', { static: true }) inputMailFrom: any;
  @ViewChild('inputName', { static: true }) inputName: any;
  @ViewChild('inputMailText', { static: true }) inputMailText: any;

  messageSentSuccess = false;
  messageSentFailure = false;

  constructor(private httpClient: HttpClient) { }

  btnSendDisabled(): boolean {
    const hasMail = this.inputMailFrom.nativeElement.value && this.inputMailFrom.nativeElement.value.toString().trim()
      && this.inputMailFrom.nativeElement.value.toString().indexOf('@') !== -1;
    const hasName = this.inputName.nativeElement.value && this.inputName.nativeElement.value.trim();
    const hasText = this.inputMailText.nativeElement.value && this.inputMailText.nativeElement.value.trim();
    return !hasMail || !hasName || !hasText;
  }

  sendMail() {
    const url = `http://${environment.backendServerAdress}:${environment.backendServerPort}/sendmail/
                ${this.inputMailFrom.nativeElement.value}/
                ${this.inputName.nativeElement.value}/
                ${this.inputMailText.nativeElement.value}`;

    this.httpClient.post(url, null)
      .pipe(
        catchError(() => this.handleError())
      )
      .subscribe((response: any) => {
        console.log(response)
        if (response.statusCode === 200) {
          this.messageSentSuccess = true;
        } else {
          this.messageSentFailure = true;
        }
      });


    this.inputMailFrom.nativeElement.value = '';
    this.inputMailText.nativeElement.value = '';
    this.inputName.nativeElement.value = '';
  }

  private handleError(): Observable<any> {
    this.messageSentFailure = true;
    return of({});
  }

}
