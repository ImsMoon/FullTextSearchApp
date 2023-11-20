import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { UserInfo } from '../models/user-info';
@Injectable({
  providedIn: 'root'
})
export class SerachService {
  baseUrl = "http://localhost:5186/api";
  private responseTIme = new BehaviorSubject<number>(0);
  currentResponseTime = this.responseTIme.asObservable();

  constructor(private http:HttpClient) { }

  searchInfo(searchText:string):Observable<UserInfo[]>{
    let startTime = 0;
    let endTime = 0;
    startTime = performance.now();
    return this.http.get<UserInfo[]>(
      `${
        this.baseUrl
      }/search/get/${searchText}`
    ).pipe(
      tap(()=>{
        endTime = performance.now();
        this.responseTIme.next(endTime - startTime);
      })
    );    
  }
}
