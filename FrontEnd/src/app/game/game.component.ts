import { Component, OnInit } from '@angular/core';
import { GameService } from '../service/gameservice';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  obj: any;
  lastRecord: any;
  constructor(private gameService: GameService) {

  }

  ngOnInit() {
    this.gameService.lastRecord().subscribe();
  }

  play() {
    this.gameService.play().subscribe();
  }

}