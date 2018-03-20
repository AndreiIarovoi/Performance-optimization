import { Component, EventEmitter, Input } from "@angular/core";
import { Observable } from "rxjs/Observable";

@Component({
    selector: "chart",
    templateUrl: "../Scripts/App/components/chart/chart.component.html"
})

export class ChartComponent {
    @Input() chartData: Observable<any> = Observable.from([]);
    public options: any;

    constructor() {

        this.options = {
            chart: {
                type: "discreteBarChart",
                height: 350,
                margin: {
                    top: 20,
                    right: 20,
                    bottom: 50,
                    left: 55
                },
                x: function (d) { return d.label; },
                y: function (d) { return d.value; },
                showValues: true,
                valueFormat: function (d) {
                    return d3.format(",.4f")(d);
                },
                duration: 500,
                xAxis: {
                    axisLabel: "Experience Level"
                },
                yAxis: {
                    axisLabel: "Career Satisfaction",
                    axisLabelDistance: -10
                }
            }
        };
    }
}
