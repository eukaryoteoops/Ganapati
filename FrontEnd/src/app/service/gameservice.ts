import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environments/environment.prod";
import { Observable } from "rxjs";



@Injectable({
    providedIn: 'root'
})
export class GameService {
    baseApiUrl: string;
    token: string;

    constructor(private http: HttpClient) {
        this.baseApiUrl = environment.baseApiUrl;
        this.token = sessionStorage.getItem('token');
    }

    lastRecord(): Observable<any> {
        //header
        let httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': sessionStorage.getItem('token')
            })
        };
        return this.http.get(`${this.baseApiUrl}/game`, httpOptions);
    }

    play(): Observable<any> {
        //header
        let httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': sessionStorage.getItem('token')
            })
        };
        return this.http.get(`${this.baseApiUrl}/game/play`, httpOptions);
    }

}
