import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

@Injectable()
export class HttpBaseService {
    
    protected httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };


    constructor(protected http: HttpClient,
        @Inject('BASE_URL') protected baseUrl: string) {

    }

    protected delete<T>(uri: string) : Observable<T> {
        return this.http.delete<T>(uri);
    }
}