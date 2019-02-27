import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

@Injectable()
export class HttpBaseService {

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(protected http: HttpClient,
    @Inject('BASE_URL') protected baseUrl: string) {
  }

  protected get<T>(uri: string): Observable<T> {
    return this.http.get<T>(uri);
  }

  protected post<T>(uri: string, value: any): Observable<T> {
    let body = JSON.stringify(value);
    return this.http.post<T>(uri, body, this.httpOptions)
  }

  protected put<T>(uri: string, value: any): Observable<T> {
    let body = JSON.stringify(value);
    return this.http.put<T>(uri, body, this.httpOptions)
  }

  protected delete<T>(uri: string): Observable<T> {
    return this.http.delete<T>(uri);
  }
}