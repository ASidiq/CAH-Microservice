import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service'

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  card: string;
  cardQuestion: string;
  questionPack: number;
  cardAnswer: string;
  answerPack: number
  constructor(private service: SharedService) { }

  ngOnInit(): void {
    this.cardDetails();
  }

  cardDetails() {
    this.service.getCard().subscribe(data => {
      this.card = data["cah"];
      this.cardQuestion = data["question"].text;
      this.questionPack = data["question"].pack;
      this.cardAnswer = data["answer"].text;
      this.answerPack = data["answer"].pack;
      console.log(
        this.card, "\n",
        this.cardQuestion, "\n",
        this.questionPack, "\n",
        this.cardAnswer, "\n",
        this.answerPack);
    })
  }

}
