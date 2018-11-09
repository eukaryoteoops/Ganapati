import { Component, OnInit } from '@angular/core';
import { GameService } from '../service/gameservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  currentRecord: ICurrentRecord;
  lastRecord: IlastRecord;
  constructor(private gameService: GameService, private router: Router) {

  }

  ngOnInit() {
    this.currentRecord = { LastPlayerPoint: [], LastHostPoint: [], PlayerPoint: [], HostPoint: [], Winner: "" };
    this.lastRecord = { LastPlayerPoint: [], LastHostPoint: [] };
    this.gameService.lastRecord().subscribe(
      data => {
        if (data.Data == null) return;
        this.lastRecord = data.Data
      },
      error => { alert("Session expired."); this.router.navigate(['/sign']) });
  }

  play() {
    this.gameService.play().subscribe(data => {
      let result = data.Data;
      this.lastRecord.LastPlayerPoint = result.LastPlayerPoint;
      this.lastRecord.LastHostPoint = result.LastHostPoint;
      this.currentRecord = result
    }, error => { alert("Session expired."); this.router.navigate(['/sign']) });
  }

}

export interface IlastRecord {
  LastPlayerPoint?: number[];
  LastHostPoint?: number[];
}

export interface ICurrentRecord extends IlastRecord {
  PlayerPoint?: number[];
  HostPoint?: number[];
  Winner: string;
}