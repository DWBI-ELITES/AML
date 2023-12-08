import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-ctr',
  templateUrl: './ctr.component.html',
  styleUrls: ['./ctr.component.scss']
})
export class CtrComponent implements OnInit {
  reportDate: string;
  startDate: Date;
  endDate: Date;
  reportGenerated: boolean = false;
  generatedReportData: Blob;
  loading: boolean = false; // Add this line
  StartEndDatepopupDialog: boolean = false;
  success_message: string | null = null; // Initialize as null or with a default value
  failure_message: string | null = null; // Initialize as null or with a default value
  InvalidDatepopupDialog: boolean = false;
  NoRecordpopupDialog: boolean = false;
  ErrorGeneratingCTRpopupDialog: boolean = false;
  
  constructor(private http: HttpClient, private snackBar: MatSnackBar) { }

  ngOnInit() {
    const today = new Date();
    this.reportDate = today.toISOString().split('T')[0];
  }
  closeStartEndDatepopupDialog(){
    this.StartEndDatepopupDialog= false;
    this.InvalidDatepopupDialog= false;
    this.NoRecordpopupDialog= false;
    this.ErrorGeneratingCTRpopupDialog= false;
  }
  



  generateCTR() {
    const apiUrl = 'https://localhost:44356/api/Reports';

    if (!this.startDate || !this.endDate) {
      // this.snackBar.open('Please provide both start and end dates', 'Close', { duration: 3000 });
      this.failure_message ='Please provide both start and end dates';
      this.StartEndDatepopupDialog = true;
      return;
    }

    const startDateObj = new Date(this.startDate);
    const endDateObj = new Date(this.endDate);

    if (isNaN(startDateObj.getTime()) || isNaN(endDateObj.getTime())) {
      // this.snackBar.open('Invalid date format. Please use YYYY-MM-DD', 'Close', { duration: 3000 });
      this.failure_message ='Invalid date format. Please use YYYY-MM-DD';
      this.InvalidDatepopupDialog= true;
      return;
    }

    const startDateString = startDateObj.toISOString().split('T')[0];
    const endDateString = endDateObj.toISOString().split('T')[0];

    this.loading = true; // Show the progress spinner

    
    this.http.get<string>(`${apiUrl}/GetTransactions?startDate=${startDateString}&endDate=${endDateString}`).subscribe(
      (response: string) => {
        if (response) {
          const parser = new DOMParser();
          const xml = parser.parseFromString(response, 'application/xml');
          const serializer = new XMLSerializer();
          const xmlString = serializer.serializeToString(xml);

          this.generatedReportData = new Blob([xmlString], { type: 'application/xml' });

          this.reportGenerated = true;

          this.loading = false;
        } else {
          this.failure_message = 'Error generating CTR report';
          this.ErrorGeneratingCTRpopupDialog = true;

          this.loading = false;
        }
      },
      (error) => {
        console.error('Error:', error);

        if (error.status === 404) {
          this.failure_message = 'No record found for the date range selected';
          this.NoRecordpopupDialog = true;
        } else {
          this.failure_message = 'Error generating CTR report';
          this.ErrorGeneratingCTRpopupDialog = true;
        }

        this.loading = false;
      }
    );
  }


  downloadReport() {
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(this.generatedReportData);
    link.download = 'CTR_Report.xml';
    link.click();
  }
}
