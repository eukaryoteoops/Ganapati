import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment.prod";
import { Observable, Observer } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class SignService {
    baseApiUrl: string;
    constructor(private http: HttpClient) {
        this.baseApiUrl = environment.baseApiUrl;
    }

    login(account: string, password: string): Observable<any> {
        return this.http.post(`${this.baseApiUrl}/auth/login`, { username: account, password: password });
    }

    register(account: string, password: string): Observable<any> {
        return this.http.post(`${this.baseApiUrl}/auth/register`, { username: account, password: password });
    }
}





