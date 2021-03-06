import { Component, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { MessageState } from 'src/app/app.model';
import { constants } from 'src/constants';


@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {

  @ViewChild('inputMailFrom', { static: true }) inputMailFrom: any;
  @ViewChild('inputName', { static: true }) inputName: any;
  @ViewChild('inputMailText', { static: true }) inputMailText: any;

  public messageState: MessageState = 'idle';

  public constants = constants;

  constructor(private httpClient: HttpClient) { 
  }

  btnSendDisabled(): boolean {
    const hasMail = this.inputMailFrom.nativeElement.value && this.inputMailFrom.nativeElement.value.toString().trim()
      && this.inputMailFrom.nativeElement.value.toString().indexOf('@') !== -1;
    const hasName = this.inputName.nativeElement.value && this.inputName.nativeElement.value.trim();
    const hasText = this.inputMailText.nativeElement.value && this.inputMailText.nativeElement.value.trim();
    return !hasMail || !hasName || !hasText;
  }

  sendMail() {

    this.messageState = 'sending';

    let message: string = this.inputMailText.nativeElement.value.trim();
    message = message.replace(/(?:\r\n|\r|\n)/g, '\t');

    const url = `http://${environment.backendServerAdress}:${environment.backendServerPort}/mail/sendmail/
                ${this.inputMailFrom.nativeElement.value.trim()}/
                ${this.inputName.nativeElement.value.trim()}/
                ${message}`;

    this.httpClient.post(url, null, {responseType:'text'})
      .pipe(
        catchError(() => this.handleError())
      )
      .subscribe((response: {statusCode: number}) => {
        // TODO das Aulesen der respnse funktioniert zur Zeit nicht
        if (true) {
          this.messageState = 'sentSuccessfully';
          this.inputMailFrom.nativeElement.value = '';
          this.inputMailText.nativeElement.value = '';
          this.inputName.nativeElement.value = '';
        } else {
          this.messageState = 'sentFailure';
        }
      });
  }

  private handleError(): Observable<any> {
    this.messageState = 'sentFailure';
    return of({});
  }

}
