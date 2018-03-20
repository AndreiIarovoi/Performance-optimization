import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { BrowserModule } from "@angular/platform-browser";
import { NgUploaderModule } from "ngx-uploader";
import { SimpleTimer } from "ng2-simple-timer";
import { NgxPaginationModule } from "ngx-pagination";
import { NvD3Module, NvD3Component } from "ng2-nvd3";

import { AppComponent } from "./app.component";
import { RespondentsComponent } from "./components/respondents/respondents.component";
import { RespondentsService } from "./components/respondents/RespondentsService";
import { UploadComponent } from "./components/upload/upload.component";
import { ChartComponent } from "./components/chart/chart.component";

import "d3";
import "nvd3";

@NgModule({
    imports: [
        //angular builtin module
        BrowserModule,
        HttpModule,
        FormsModule,
        NgUploaderModule,
        NgxPaginationModule,
        NvD3Module
    ],
    declarations: [
        AppComponent,
        RespondentsComponent,
        UploadComponent,
        ChartComponent
    ],
    exports: [
	    RespondentsComponent
    ],
    providers: [
        RespondentsService,
        SimpleTimer
    ],
    bootstrap: [
        AppComponent
    ]
})

export class AppModule {
}

