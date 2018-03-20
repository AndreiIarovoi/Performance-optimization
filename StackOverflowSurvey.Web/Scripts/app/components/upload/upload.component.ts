import * as _ from "lodash";
import { Component, EventEmitter, Input } from "@angular/core";
import { UploadOutput, UploadInput, UploadFile, humanizeBytes } from "ngx-uploader";

@Component({
  selector: "file-upload",
  templateUrl: "../Scripts/App/components/upload/upload.component.html"
})
export class UploadComponent {

  @Input() toggleTimer;

  formData: FormData;
  files: UploadFile[];
  errors: string[];
  uploadInput: EventEmitter<UploadInput>;
  humanizeBytes: Function;
  dragOver: boolean;
  private uploadedFilesCounter: number = 0;

  constructor() {
    this.files = []; // local uploading files array
    this.uploadInput = new EventEmitter<UploadInput>(); // input events, we use this to emit data to ngx-uploader
    this.humanizeBytes = humanizeBytes;
    this.errors = [];
  }

  onUploadOutput(output: UploadOutput): void {
    console.log(output); // lets output to see what's going on in the console

    if (output.type === "allAddedToQueue") { // when all files added in queue
      // uncomment this if you want to auto upload files when added
      // const event: UploadInput = {
      //   type: 'uploadAll',
      //   url: '/upload',
      //   method: 'POST',
      //   data: { foo: 'bar' },
      //   concurrency: 0
      // };
      // this.uploadInput.emit(event);
    } else if (output.type === "addedToQueue") {
      this.files.push(output.file); // add file to array when added
    } else if (output.type === "uploading") {
      // update current data in files array for uploading file
      const index = this.files.findIndex(file => file.id === output.file.id);
      this.files[index] = output.file;
    } else if (output.type === "removed") {
      // remove file from array when removed
      this.files = this.files.filter((file: UploadFile) => file !== output.file);
    } else if (output.type === "dragOver") { // drag over event
      this.dragOver = true;
    } else if (output.type === "dragOut") { // drag out event
      this.dragOver = false;
    } else if (output.type === "drop") { // on drop event
      this.dragOver = false;
    } else if (output.type === "start") { // on drop event
    } else if (output.type === "done") { // on drop event
      this.uploadedFilesCounter++;
	  this.errors.push.apply(this.errors, _.filter(_.flatten(_.map(output.file.response, "errors")), (error: any) => {return error !== ""}));
      if (this.uploadedFilesCounter === this.files.length) {
        this.toggleTimer();
      }
    }
  }

  startUpload(): void {  // manually start uploading
    const event: UploadInput = {
      type: "uploadAll",
      url: "/api/respondents/upload",
      method: "POST",
      data: { foo: "bar" },
      concurrency: 1 // set sequential uploading of files with concurrency 1
    };
    this.uploadedFilesCounter = 0;
    this.toggleTimer();
    this.uploadInput.emit(event);
    this.errors = [];
  }

  cancelUpload(id: string): void {
    this.uploadInput.emit({ type: "cancel", id: id });
  }
}
