import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly MergeServiceAPIURL: string = 'https://localhost:44306/api/Merge'
  constructor(private http: HttpClient) { }

  //Card API
  getCard(): Observable<any[]> {
    return this.http.get<any>(this.MergeServiceAPIURL);
  }
}
