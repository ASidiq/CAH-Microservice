import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly MergeServiceAPIURL: string = '/merge-service'
  constructor(private http: HttpClient) { }

  //Card API
  getCard(): Observable<any[]> {
    return this.http.get<any>(this.MergeServiceAPIURL);
  }
}
