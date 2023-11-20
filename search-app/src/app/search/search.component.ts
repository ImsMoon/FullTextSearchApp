import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, map, of, startWith, switchMap, timeInterval } from 'rxjs';
import { SerachService } from './shared/services/serach.service';
import { UserInfo } from './shared/models/user-info';
import { userInfo } from 'os';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  myControl = new FormControl();
  filteredOptions!: Observable<UserInfo[]>;
  responeTime :number =0;
  apiInterval:number=0;

  constructor(private searchService:SerachService){}

  ngOnInit() {
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      switchMap(value => {
        return this._filter(value);
      }),
      timeInterval(),
      map(response =>{ 
        this.responeTime = response.interval;
        return response.value;
      })
    );
      this.getResponseTime();
  }

  getResponseTime(){
    this.responeTime = 0;
    this.searchService.currentResponseTime.subscribe(res=>{
      this.apiInterval = res;
    })
  }
  
  private _filter(value: string): Observable<UserInfo[]> {
    if (value) {
      return this.searchService.searchInfo(value);
    } else {
      this.responeTime = 0;
      return of([]);
    }
  }


}
