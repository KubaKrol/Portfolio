import { Component, OnInit } from '@angular/core';
import { ContactService } from '../_services/contact.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  model: any = {}
  emailSent : any;

  constructor(public contactService: ContactService) { }

  ngOnInit(): void {
    this.emailSent = false;
  }

  send(){
      this.contactService.send(this.model).subscribe(response => {
      console.log(response);
      this.emailSent = true;
    }, error =>
    {
      console.log(error);
    })
  }

}
