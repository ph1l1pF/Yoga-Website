import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { MessageState } from 'src/app/app.model';
import { constants } from 'src/constants';
import { VisitService } from 'src/app/services/visit.service';

interface RequestBody {
  message: string;
  mailCustomer: string;
  nameCustomer: string;
}

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  @ViewChild('inputMailFrom', { static: true }) inputMailFrom: any;
  @ViewChild('inputName', { static: true }) inputName: any;
  @ViewChild('inputMailText', { static: true }) inputMailText: any;

  public messageState: MessageState = 'idle';

  public constants = constants;

  constructor(private httpClient: HttpClient,
              private visitService: VisitService) { }

  ngOnInit(): void {
    this.visitService.storeVisit('Contact');
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
    const body: RequestBody = {
      message: this.inputMailText.nativeElement.value,
      nameCustomer: this.inputName.nativeElement.value.trim(),
      mailCustomer: this.inputMailFrom.nativeElement.value.trim()
    }

    const url = `http://${environment.backendServerAdress}:${environment.backendServerPort}/mail/sendmail`;

    this.httpClient.post(url, body, {responseType: "text"})
      .pipe(
        catchError(() => this.handleError())
      )
      .subscribe((response: string) => {
        if (response === 'Mail successfully sent.') {
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
