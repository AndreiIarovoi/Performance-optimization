import { RespondentsFilter } from './RespondentsFilter';
import { Respondent } from "./Respondent";

import { Injectable } from "@angular/core";
import { Http, Response, RequestOptions, URLSearchParams } from "@angular/http";

import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class RespondentsService {
    private respondentssUrl = "api/respondents";

    constructor(private http: Http) { }

    getRespondents(filter: RespondentsFilter): Observable<Respondent[]> {
        let params: URLSearchParams = new URLSearchParams();
        params.set("professional", filter.professional);
        params.set("country", filter.country);
        params.set("gender", filter.gender);
        params.set("developerType", filter.developerType);
        params.set("experienceLevel", filter.experienceLevel);
        params.set("versionControl", filter.versionControl);
        params.set("language", filter.language);
        params.set("companySize", filter.companySize);

        let requestOptions: RequestOptions = new RequestOptions();
        requestOptions.search = params;
        return this.http.get(this.respondentssUrl, requestOptions)
            .map(this.extractData)
            .catch(this.handleError);
    }
    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || "";
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ""} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}