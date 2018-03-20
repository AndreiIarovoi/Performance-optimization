import * as _ from "lodash";
import { RespondentsFilter } from "./RespondentsFilter";
import { Component, Input } from "@angular/core";
import { Respondent } from "./Respondent";
import { RespondentsService } from "./RespondentsService";
import { Observable } from "rxjs/Observable";

@Component({
    selector: "respondents",
    templateUrl: "../Scripts/App/components/respondents/respondents.component.html"
})

export class RespondentsComponent {
    public respondents: Respondent[];
    public errorMessage: any;
    @Input() toggleTimer;

    public filter: RespondentsFilter;
    public pageNumber: number = 1;

    public pageSize: number = 10;
    public respondentsChartData: any;

    constructor(private respondentsService: RespondentsService) {
        this.respondentsService = respondentsService;
        this.filter = new RespondentsFilter();
    }

    getRespondents() {
        this.toggleTimer();
        this.respondentsService.getRespondents(this.filter).subscribe(
            respondents => this.displayRespondents(respondents),
            error => this.errorMessage = <any>error);
    }

    private displayRespondents(respondents: Respondent[]) {
        this.respondents = respondents;
        this.createChartData(respondents);
        this.toggleTimer();
    }

    private createChartData(respondents: Respondent[]): void {
        let chartData: any = _(respondents).groupBy(r => r.experienceLevel).map((value: Respondent[], key) =>
            ({
                "label": key, "value": _.meanBy(value, (r) => {
                    let satisfaction: number = r.careerSatisfaction === "NA" ? 0 : parseInt(r.careerSatisfaction, 10);
                    return satisfaction;
                })
            }))
            .orderBy("value")
            .value();
        this.respondentsChartData =[{ key: "Respondents", values: chartData }];
    }

}