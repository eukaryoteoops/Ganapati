import { Component, OnInit } from '@angular/core';
import { SignService } from '../service/signservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign',
  templateUrl: './sign.component.html',
  styleUrls: ['./sign.component.css']
})
export class SignComponent implements OnInit {
  obj: any = {};
  constructor(private signService: SignService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.signService.login(this.obj.username, this.obj.password).subscribe(data => this.handle(data));
  }

  register() {
    this.signService.register(this.obj.username, this.obj.password).subscribe(data => this.handle(data));
  }

  handle(data) {
    sessionStorage.setItem("key" , data.token);
    this.router.navigate(['/game']);
  }
}
