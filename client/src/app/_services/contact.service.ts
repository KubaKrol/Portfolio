import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Email } from '../_models/email';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  send(model: any)
  {
    return this.http.post(this.baseUrl + 'emailsender/sendmail', model);
  }
}
