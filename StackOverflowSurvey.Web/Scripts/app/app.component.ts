import { Component, OnInit } from '@angular/core';
import { SimpleTimer } from "ng2-simple-timer";

@Component({
    selector: 'my-app',
    templateUrl: '../Scripts/App/app.component.html'
})

export class AppComponent implements OnInit {
    timerStatus: string = "";
    public secCounter: number = 0;
    public minCounter: number = 0;

    private timerId: string = "";

    constructor(private timer: SimpleTimer) {
    }

    ngOnInit() {
        console.log("hello");
    }

    getTimer(): Function {
        return () => {
            return this.toggleTimer();
        };
    }
    toggleTimer(): void {
        const timerName: string = "1sec";
        if (this.timerId === "") {
            this.secCounter = 0;
            this.minCounter = 0;
            this.timer.newTimer(timerName, 1);
            this.timerId = this.timer.subscribe(timerName, () => this.timerTicked());
            this.timerStatus = "";
        } else {
            this.timer.unsubscribe(this.timerId);
            this.timerId = "";
            this.timer.delTimer(timerName);
            this.timerStatus = "finished";
        }
    }

    timerTicked(): void {
        this.incrementTimer();
    }

    incrementTimer(): void {
        this.secCounter++;
        if (this.secCounter === 60) {
            this.minCounter++;
            this.secCounter = 0;
        }
    }
}