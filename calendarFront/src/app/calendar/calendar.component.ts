import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { CalendarEvent } from 'angular-calendar';

@Component({
  selector: 'app-calendar',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})

export class CalendarComponent implements OnInit {

  view: string = 'month';

  viewDate: Date = new Date();

  events: CalendarEvent[] = [];

  constructor() { }

  ngOnInit() {
  }

}
