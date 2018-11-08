import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
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
        this.token = sessionStorage.getItem('key');
    }

    lastRecord(): Observable<any> {
        //header
        return this.http.get(`${this.baseApiUrl}/game`);
    }

    play(): Observable<any> {
        //header
        return this.http.get(`${this.baseApiUrl}/game/play`);
    }

}
