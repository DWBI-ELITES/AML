import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-typography',
  templateUrl: './typography.component.html',
  styleUrls: ['./typography.component.css']
})
export class TypographyComponent  {
  selectedFile: File | undefined;

  constructor(private http: HttpClient) {}

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];
  }

  onUpload(): void {
    if (this.selectedFile) {
      const formData = new FormData();
      formData.append('excel_file', this.selectedFile);

      this.http.post<any>('https://localhost:44356/api/values/upload-excel', formData).subscribe(
        (response: any) => {
          // Handle success and show success message
        },
        (error: any) => {
          console.error('Error uploading file:', error);
          // Handle error and show error message
        }
        
      );
    } else {
      // Show warning message: "Choose a LIMIT_DEFINITION.XSLX file."
    }
  }
}
