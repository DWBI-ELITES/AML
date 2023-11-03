import { Component, OnInit, } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as $ from 'jquery';



@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})


export class UserProfileComponent  implements OnInit {

  public identifiertypes: { item: string, description: string }[] = [];
  countries: { country: string, countryCode: string }[] = [];
  public contacttypes: { item: string, description: string }[] = [];
  public communicationtypes: { item: string, description: string }[] = [];
  public gendertypes: { item: string, description: string }[] = [];
  // public countries: { country: string, countryCode: string }[] = [];
  // countries: any[] = [];
  // identifiertypes: string[] = []; // Initialize the identifiertypes array
  titles: string[] = []; // Initialize the titles array
  updateModel: any = {}; // Initialize it with an empty object
  updateSignatoryModel: any = {}; // Initialize it with an empty object
  newPerson: any = {};
  newDirector: any = {};

  editedCustomerDetails: any = {};
  editpopupDialog: boolean = false; // To control the pop-up window visibility
  editsignatorypopupDialog: boolean = false;
  editdirectorpopupDialog: boolean = false;
  saveaddsignatorypopupDialog: boolean = false;
  addsignatorypopupDialog: boolean = false;
  saveaddpopupDialog: boolean = false;
  saveadddirectorpopupDialog: boolean = false;
  adddirectorpopupDialog: boolean = false;
  

  isDirectorInfoCollapsed: boolean = false;
  isSignatoryInfoCollapsed: boolean = false;
  isCustomerInfoCollapsed: boolean = false;
  isCorporateDetailsCollapsed: boolean = false;
  isPersonalDetailsCollapsed: boolean = false;
  isAddressPhoneCollapsed: boolean = false;
  isAccountInfoCollapsed: boolean = false;
  isOtherDetailsCollapsed: boolean = false;
  isAddressInfoCollapsed: boolean = false;
  isPersonInfoCollapsed: boolean = false;
  isEmployerInfoCollapsed: boolean = false;
  isForeignerInfoCollapsed: boolean = false;
  isHideInfoCollapsed: boolean = false;
  isPhoneInfoCollapsed: boolean = false;

  


  
  accountSearchValue: string;
  nameSearchValue: string;
  custIDSearchValue: string;
  searchResults: any[] = [];
  hasSearchCriteria: boolean = false;
  sortKey: string = '';
  sortDirection: string = 'asc';
  visible: boolean = false;
  selectedCustId: string = ''; // Track the selected row's cust_id
  customerDetails: any = null; // To store the fetched customer details
  popupDialog: boolean = false; // To control the pop-up window visibility
  selectedAccount: string = ''; // Track the selected row's account
  country: string = ''; // Track the selected row's account
  countrycode: string = ''; // Track the selected row's account
  countryCodeDirector: string = '';
  identifierNumber: string = ''; 
  identifierCode: string = ''; 
  identifierNumberDirector: string = ''; 
  identifierCodeDirector: string = ''; 
  accountDetails: any = null; // To store the fetched account details
  accountpopupDialog: boolean = false; // To control the pop-up window visibility
  savepopupDialog: boolean = false; // To control the pop-up window visibility
  savesignatorypopupDialog: boolean = false; // To control the pop-up window visibility
  signatoryResults: string = '';
  verifyResults: string = '';
  verifyDirectorResults: string = '';
  signatorypopupDialog: boolean = false; // To control the pop-up window visibility
  verifysignatorypopupDialog: boolean = false; // To control the pop-up window visibility
  continuesignatorypopupDialog: boolean = false; 
  verifydirectorpopupDialog: boolean = false; // To control the pop-up window visibility
  continuedirectorpopupDialog: boolean = false; 
  directorResults: string = '';
  directorpopupDialog: boolean = false; // To control the pop-up window visibility
  customerDetailsVerify: any = null; // To store the fetched customer details
  signatoryFullDetails: any = null; 
  signatoryFullpopupDialog: boolean = false; // Show the pop-up window
  selectedIdentifierNumber: string = ''; // Track the selected row's identifier_number
  directorFullDetails: any = null; 
  directorFullpopupDialog: boolean = false; // Show the pop-up window
  selecteddirectorIdentifierNumber: string = ''; // Track the selected row's identifier_number
  savedirectorpopupDialog: boolean = false; // To control the pop-up window visibility
  checksignatorypopupDialog: boolean = false; 
  checkdirectorpopupDialog: boolean = false; 

  addresstypes: { item: string, description: string }[];






   apiUrl = 'https://localhost:44356/api/AccountSearch'; // Replace with your API URL
  // apiUrl = '/api/AccountSearch';


  success_message: string | null = null; // Initialize as null or with a default value
  failure_message: string | null = null; // Initialize as null or with a default value



  showNoSearchCriteriaWarning: boolean = false; // Added this line

  constructor(private http: HttpClient, private formBuilder: FormBuilder, private snackBar: MatSnackBar) {
    // Initialize the form
    this.customerDetailsForm = this.formBuilder.group({
      customer_type: [''],
      cust_id: [''],
      // Initialize more form controls for other properties
    });

    this.signatoryFullDetailsForm = this.formBuilder.group({
      identifier_number: [''],
      // cust_id: [''],
      // Initialize more form controls for other properties
    });

    this.directorFullDetailsForm = this.formBuilder.group({
      identifier_number: [''],
      // cust_id: [''],
      // Initialize more form controls for other properties
    });
  }

  
  ngOnInit() {

    
    // throw new Error('Method not implemented.');
        // Fetch titles from the API
        this.http.get<string[]>('https://localhost:44356/api/AccountSearch/GetTitles')
        .subscribe(data => {
          this.titles = data;
        });


        // ...
        
        this.http.get<{ item: string, description: string }[]>('https://localhost:44356/api/AccountSearch/GetIdentifierTypes')
        .subscribe(data => {
            console.log(data); // Log the data to the console
            this.identifiertypes = data;
        
                // Assuming you want to update the identifier_description based on identifier_code
                const matchingIdentifier = this.identifiertypes.find(item => item.item === this.updateSignatoryModel.identifier_code);
        
                if (matchingIdentifier) {
                    this.updateSignatoryModel.identifier_description = matchingIdentifier.description;
                    
                }
            });


            this.http.get<{ item: string, description: string }[]>('https://localhost:44356/api/AccountSearch/GetContactTypes')
            .subscribe(data => {
                console.log(data); // Log the data to the console
                this.contacttypes = data;
            
                    // Assuming you want to update the identifier_description based on identifier_code
                    const matchingIdentifier = this.contacttypes.find(item => item.item === this.updateSignatoryModel.tph_contact_type || item.item === this.updateSignatoryModel.addressType );
            
                    if (matchingIdentifier) {
                        this.updateSignatoryModel.identifier_description = matchingIdentifier.description;
                        
                    }
                });



                this.http.get<{ item: string, description: string }[]>('https://localhost:44356/api/AccountSearch/GetGenderTypes')
                .subscribe(data => {
                    console.log(data); // Log the data to the console
                    this.gendertypes = data;
                
                        // Assuming you want to update the identifier_description based on identifier_code
                        const matchingIdentifier = this.gendertypes.find(item => item.item === this.updateSignatoryModel.sex);
                
                        if (matchingIdentifier) {
                            this.updateSignatoryModel.identifier_description = matchingIdentifier.description;
                            
                        }
                    });
    


                this.http.get<{ item: string, description: string }[]>('https://localhost:44356/api/AccountSearch/GetCommunicationTypes')
                .subscribe(data => {
                    console.log(data); // Log the data to the console
                    this.communicationtypes = data;
                
                        // Assuming you want to update the identifier_description based on identifier_code
                        const matchingIdentifier = this.communicationtypes.find(item => item.item === this.updateSignatoryModel.tph_communication_type);
                
                        if (matchingIdentifier) {
                            this.updateSignatoryModel.identifier_description = matchingIdentifier.description;
                            
                        }
                    });



            this.http.get<{ country: string, countryCode: string }[]>('https://localhost:44356/api/AccountSearch/GetCountries')
            .subscribe(data => {
              this.countries = data;
            });


          

            // Assuming you have a class property called contacttypes

// This is where you retrieve the contact types
// this.http.get<{ item: string, description: string }[]>('https://localhost:44356/api/AccountSearch/GetContactTypes')
//   .subscribe(data => {
//     console.log(data); // Log the data to the console
//     this.addresstypes = data;

//     // Assuming you want to update the identifier_description based on identifier_code
//     const matchingIdentifier = this.addresstypes.find(item => item.item === this.signatoryFullDetails.addressType);

//     if (matchingIdentifier) {
//       this.signatoryFullDetails.addressTypeDescription = matchingIdentifier.description;
//     }
//   });

            

            // this.http.get<any>('https://localhost:44356/api/AccountSearch/GetIdentifierTypes').subscribe(
            //   data => {
            //     // Assuming data is an array of objects with 'item' and 'description' properties
            //     const matchingItem = data.find(item => item.item === this.signatoryFullDetails.identifier_code);
            //     if (matchingItem) {
            //       this.signatoryFullDetails.identifier_other = matchingItem.description;
            //     }
            //   },
            //   error => {
            //     console.error('Error fetching identifier types:', error);
            //   }
            // );

        }
      
        onSelectCountry() {
          const matchingCountry = this.countries.find(country => country.countryCode === this.newPerson.country_code || country.countryCode === this.newDirector.country_code);
          if (matchingCountry) {
            this.newPerson.passport_issue_country = matchingCountry.country;
            this.newDirector.passport_issue_country = matchingCountry.country;
            this.country = matchingCountry.country; 
          }
           
  };

 
  // getDescriptionForAddressType(): string {
  //   const matchingIdentifier = this.contacttypes.find(item => item.item === this.signatoryFullDetails.addressType);
  
  //   if (matchingIdentifier) {
  //     return matchingIdentifier.description;
  //   }
  
  //   return 'Unknown'; // Return a default value if no match is found
  // }



  customerDetailsForm: FormGroup; // Add this property
  signatoryFullDetailsForm: FormGroup;
  directorFullDetailsForm: FormGroup;
  signatoryAddForm:FormGroup;


  
  performSearch() {
    // Check if at least one search criterion is entered
    if (this.accountSearchValue || this.nameSearchValue || this.custIDSearchValue) {
      this.showNoSearchCriteriaWarning = false; // Reset the warning flag
      this.hasSearchCriteria = true;
      this.searchResults = [];

      if (this.accountSearchValue) {
        this.search('account', this.accountSearchValue);
      } else if (this.nameSearchValue) {
        this.search('name', this.nameSearchValue);
      } else if (this.custIDSearchValue) {
        this.search('cust_id', this.custIDSearchValue);
      }
    } else {
      // No search criteria entered
      this.showNoSearchCriteriaWarning = true; // Show the warning message
      this.hasSearchCriteria = false;
      this.searchResults = [];
    }
  }

  private search(criteria: string, searchValue: string) {
    this.http.get<any[]>(`${this.apiUrl}?searchValue=${searchValue}&criteria=${criteria}`)
      .subscribe(data => {
        this.searchResults = data;
        // console.log(JSON.stringify(this.searchResults))
      });
      
  }

  clearInput(fieldName: string) {
    // Clear the input value based on the fieldName
    if (fieldName === 'accountSearchValue') {
      this.accountSearchValue = '';
    } else if (fieldName === 'nameSearchValue') {
      this.nameSearchValue = '';
    } else if (fieldName === 'custIDSearchValue') {
      this.custIDSearchValue = '';
    }
  }

  sort(key: string) {
  
    if (this.sortKey === key) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortKey = key;
      this.sortDirection = 'asc';
    }

    this.searchResults.sort((a, b) => {
      const aValue = a[this.sortKey];
      const bValue = b[this.sortKey];
      if (this.sortDirection === 'asc') {
        return aValue.localeCompare(bValue);
      } else {
        return bValue.localeCompare(aValue);
      }
    });
  }


  getSortIcon(key: string): string {
    if (this.sortKey === key) {
      return this.sortDirection === 'asc' ? 'fa-caret-up' : 'fa-caret-down';
    } else {
      return '';
    }
  }


  // selectRow(searchResults: any) {
  //   this.selectedCustId = searchResults.cust_id;
  //   this.selectedAccount = searchResults.account;
  //   this.newPerson.cust_id = searchResults.cust_id;
  //   this.newPerson.address_id = searchResults.cust_id;
  //   this.newPerson.phone_id = searchResults.cust_id;
  // }

 
  selectedRow: any = null; // Initialize selectedRow as null

selectRow(result: any) {
  if (this.selectedRow === result) {
    this.selectedRow = null; // Deselect the row if it's already selected
    this.selectedCustId = null;
    this.selectedAccount = null;
    this.newPerson.cust_id = null;
    this.newPerson.address_id = null;
    this.newPerson.phone_id = null;
  } else {
    this.selectedRow = result; // Select the new row
    this.selectedCustId = result.cust_id;
    this.selectedAccount = result.account;
    this.newPerson.cust_id = result.cust_id;
    this.newPerson.address_id = result.cust_id;
    this.newPerson.phone_id = result.cust_id;
    this.newDirector.cust_id = result.cust_id;
    this.newDirector.address_id = result.cust_id;
    this.newDirector.phone_id = result.cust_id;
  }
}


  selectSignatoryRow(signatoryResults: any) {
    this.selectedIdentifierNumber = signatoryResults.identifier_number;


  }

  selectDirectorRow(directorResults: any) {
    this.selecteddirectorIdentifierNumber = directorResults.identifier_number;


  }



  



  openView() {
    if (this.selectedCustId) {
      this.http.get<any>(`${this.apiUrl}/GetCustomerDetails?custId=${this.selectedCustId}`)
        .subscribe(data => {
          this.customerDetails = data;
          this.popupDialog = true; // Show the pop-up window
        }, error => {
          console.error("Error fetching customer details:", error);
        });
    }
  }


  openAccount() {
    if (this.selectedAccount) {
      this.http.get<any>(`${this.apiUrl}/GetAccountDetails?aCCOUNT=${this.selectedAccount}`)
        .subscribe(data => {
          this.accountDetails = data;
          this.accountpopupDialog = true; // Show the pop-up window
        }, error => {
          console.error("Error fetching account details:", error);
        });
    }
  }

  

  openSignatory() {
    if (this.selectedAccount) {
      this.http.get<any>(`${this.apiUrl}/GetSignatoryDetails?aCCOUNT=${this.selectedAccount}`)
        .subscribe(data => {
          this.signatoryResults = data;
          console.log( this.signatoryResults);
          this.signatorypopupDialog = true; // Show the pop-up window
        }, 
        () => { // This is the else block
          
          this.signatorypopupDialog = true; // Show the pop-up window
        }
        );
    }
  }




  

  openViewSignatory() {
    if (this.selectedIdentifierNumber) {
      this.http.get<any>(`${this.apiUrl}/GetSignatoryFullDetails?identifierNumber=${this.selectedIdentifierNumber}`)
        .subscribe(data => {
          this.signatorypopupDialog = false; // Show the pop-up window
          this.directorpopupDialog = false; // Show the pop-up window
          this.signatoryFullDetails = data;
          this.signatoryFullDetails.identifier_issue_date = new Date(this.signatoryFullDetails.identifier_issue_date).toISOString().split('T')[0];
          this.signatoryFullDetails.identifier_expire_date = new Date(this.signatoryFullDetails.identifier_expire_date).toISOString().split('T')[0];
          this.signatoryFullDetails.birthdate = new Date(this.signatoryFullDetails.birthdate).toISOString().split('T')[0];
          this.signatoryFullDetails.foreigner_date_arrival = new Date(this.signatoryFullDetails.identifier_issue_date).toISOString().split('T')[0];
          console.log(this.signatoryFullDetails)
          this.signatoryFullpopupDialog = true; // Show the pop-up window

        }, error => {
          console.error("Error fetching customer details:", error);
        });
    }
  }


  closeViewSignatoryDialog(){
    this.signatorypopupDialog = true; // Show the pop-up window
    this.directorpopupDialog = true; // Show the pop-up window
    this.selectedIdentifierNumber = '';
    this.signatoryFullpopupDialog = false; // Show the pop-up window

  }



  openViewDirector() {
    if (this.selecteddirectorIdentifierNumber) {
      this.http.get<any>(`${this.apiUrl}/GetSignatoryFullDetails?identifierNumber=${this.selecteddirectorIdentifierNumber}`)
        .subscribe(data => {
          this.signatorypopupDialog = false; // Show the pop-up window
          this.directorpopupDialog = false; // Show the pop-up window
          this.directorFullDetails = data;
          this.directorFullDetails.identifier_issue_date = new Date(this.directorFullDetails.identifier_issue_date).toISOString().split('T')[0];
          this.directorFullDetails.identifier_expire_date = new Date(this.directorFullDetails.identifier_expire_date).toISOString().split('T')[0];
          this.directorFullDetails.birthdate = new Date(this.directorFullDetails.birthdate).toISOString().split('T')[0];
          this.directorFullDetails.foreigner_date_arrival = new Date(this.directorFullDetails.identifier_issue_date).toISOString().split('T')[0];

          this.directorFullpopupDialog = true; // Show the pop-up window

        }, error => {
          console.error("Error fetching customer details:", error);
        });
    }
  }

  closeViewDirectorDialog(){
    this.signatorypopupDialog = true; // Show the pop-up window
    this.directorpopupDialog = true; // Show the pop-up window
    this.selecteddirectorIdentifierNumber = '';
    this.directorFullpopupDialog = false; // Show the pop-up window

  }


  
  openDirector() {
    if (this.selectedCustId) {
      this.http.get<any>(`${this.apiUrl}/GetCustomerDetails?custId=${this.selectedCustId}`)
        .subscribe(customerData => {
          this.customerDetailsVerify = customerData;
          
          // Check if customer_type is 'CC' before proceeding
          if (this.customerDetailsVerify.customer_type === 'CC') {
            this.http.get<any>(`${this.apiUrl}/GetDirectorDetails?custId=${this.selectedCustId}`)
              .subscribe(directorData => {
                this.directorResults = directorData;
                console.log(this.directorResults);
                this.directorpopupDialog = true; // Show the pop-up window
              }, 
              () => { // This is the else block for fetching directorData
                this.directorpopupDialog = true; // Show the pop-up window
              });
          } else {
            this.directorResults = null; // Clear directorResults
            this.directorpopupDialog = false; // Hide the pop-up window
          }
        }, 
        () => { // This is the else block for customerData
          this.directorpopupDialog = true; // Show the pop-up window
        });
    }
  }
  
  
  
  openEdit() {
    if (this.selectedCustId) {
      this.http.get<any>(`${this.apiUrl}/GetCustomerDetails?custId=${this.selectedCustId}`)
        .subscribe(
          (data) => {
            this.customerDetails = data;
            this.editpopupDialog = true; // Show the pop-up window
            
          // Convert date properties to JavaScript Date objects
          data.update_date = new Date(data.update_date); // Adjust the property name as needed
          data.incorporation_date = new Date(data.incorporation_date); // Adjust the property name as needed
          data.business_closed_date = new Date(data.business_closed_date); // Adjust the property name as needed


          // Adjust for time zone offset
          const offset = data.update_date.getTimezoneOffset();
          data.update_date.setMinutes(data.update_date.getMinutes() - offset);

          const offset2 = data.incorporation_date.getTimezoneOffset();
          data.incorporation_date.setMinutes(data.incorporation_date.getMinutes() - offset2);

          const offset3 = data.business_closed_date.getTimezoneOffset();
          data.business_closed_date.setMinutes(data.business_closed_date.getMinutes() - offset3);

          // Format the date property for the HTML input field
          this.updateModel = { ...data, update_date: data.update_date.toISOString().substring(0, 10),
                                        incorporation_date: data.incorporation_date.toISOString().substring(0, 10),
                                        business_closed_date: data.business_closed_date.toISOString().substring(0, 10) };
          this.customerDetailsForm.patchValue(this.updateModel);
          },
          (error) => {
            console.error('Error fetching customer details:', error);
          }
        );
    }
  }


// ...

updateCustomerDetails(updateModel: any): void {
  console.log('updateModel:', updateModel);
  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  this.http.put(`${this.apiUrl}/UpdateCustomerDetails?custId=${this.selectedCustId}`, JSON.stringify(this.updateModel), { headers })
    .subscribe(
      (response) => {
        console.log(JSON.stringify(response));

        // Set success message and show popup dialog
        this.success_message = 'Customer details updated successfully';
        this.savepopupDialog = true;
        console.log('savepopupDialog:', this.savepopupDialog);

        this.editpopupDialog = false;
        this.customerDetails = null;
        this.selectedCustId = '';
        this.customerDetailsForm.reset();
      },
      (error) => {
        console.log(JSON.stringify(error));

        // Set failure message and show popup dialog
        this.failure_message = 'An error occurred while updating customer details';
        this.savepopupDialog = true;
        console.log('savepopupDialog:', this.savepopupDialog);

        this.editpopupDialog = false;
        this.customerDetails = null;
        this.selectedCustId = '';
        this.customerDetailsForm.reset();
      }
    );
}

closeDialog() {
  this.popupDialog = false; // Close the popup dialog
  this.editpopupDialog = false;
  this.customerDetails = null;
  this.selectedCustId = '';
  this.customerDetailsForm.reset();
  this.savepopupDialog = false; // Close the popup dialog
  this.signatorypopupDialog = false;
  this.directorpopupDialog = false;
  this.signatoryResults = '';
  this.directorResults = '';
  this.customerDetailsVerify = '';


    //   this.popupDialog = false; // Close the pop-up window
  //   this.editpopupDialog = false; // Close the pop-up window
    this.accountpopupDialog = false; // Close the pop-up window
  //   this.customerDetails = null; // Clear customer details
    this.accountDetails = null; // Clear account details
  //   this.selectedCustId = ''; // Reset the selectedCustId
    this.selectedAccount = ''; // Reset the selectedAccount
    this.isOtherDetailsCollapsed= false;
}


  

  openSignatoryandDirector(){

    this.signatorypopupDialog = true;
    this.directorpopupDialog = true;
    this.openDirector()
    this.openSignatory()
  }



  saveChanges() {
    if (this.selectedCustId && this.customerDetailsForm.valid) {
      // const updateModel = this.customerDetailsForm.value;
      const updateModel = { ...this.updateModel }; // Create a copy of the object to avoid modifying the original

      // Convert date properties to ISO string format before updating
      updateModel.update_date = new Date(this.updateModel.update_date).toISOString();
      updateModel.incorporation_date = new Date(this.updateModel.incorporation_date).toISOString();
      updateModel.business_closed_date = new Date(this.updateModel.business_closed_date).toISOString();

      this.updateCustomerDetails(this.updateModel);
    }
  }





  openSignatoryEdit() {
    if (this.selectedIdentifierNumber) {
      this.http.get<any>(`${this.apiUrl}/GetSignatoryFullDetails?identifierNumber=${this.selectedIdentifierNumber}`)
        .subscribe(
          (data) => {
            this.signatoryFullDetails = data;
            this.editsignatorypopupDialog = true; // Show the pop-up window
            


		  data.identifier_issue_date = new Date(data.identifier_issue_date); // Adjust the property name as needed
          data.identifier_expire_date = new Date(data.identifier_expire_date); // Adjust the property name as needed
          data.birthdate = new Date(data.birthdate); // Adjust the property name as needed
		  data.foreigner_date_arrival = new Date(data.foreigner_date_arrival); // Adjust the property name as needed



          // Adjust for time zone offset
          const offset = data.identifier_issue_date.getTimezoneOffset();
          data.identifier_issue_date.setMinutes(data.identifier_issue_date.getMinutes() - offset);

          const offset2 = data.identifier_expire_date.getTimezoneOffset();
          data.identifier_expire_date.setMinutes(data.identifier_expire_date.getMinutes() - offset2);

          const offset3 = data.birthdate.getTimezoneOffset();
          data.birthdate.setMinutes(data.birthdate.getMinutes() - offset3);
		    
		  const offset4 = data.foreigner_date_arrival.getTimezoneOffset();
          data.foreigner_date_arrival.setMinutes(data.foreigner_date_arrival.getMinutes() - offset4);




          // Format the date property for the HTML input field
          this.updateSignatoryModel = { ...data ,
          identifier_issue_date: data.identifier_issue_date.toISOString().substring(0, 10),
          identifier_expire_date: data.identifier_expire_date.toISOString().substring(0, 10),
          birthdate: data.birthdate.toISOString().substring(0, 10) ,
          foreigner_date_arrival: data.foreigner_date_arrival.toISOString().substring(0, 10) };
          this.signatoryFullDetailsForm.patchValue(this.updateSignatoryModel);
          },
          (error) => {
            console.error('Error fetching signatory details:', error);
          }
        );
    }
  }

 

updateSignatoryDetails(updateSignatoryModel: any): void {
  console.log('updateSignatoryModel:', updateSignatoryModel);
  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  this.http.put(`${this.apiUrl}/UpdateSignatoryDetails?identifierNumber=${this.selectedIdentifierNumber}`, JSON.stringify(this.updateSignatoryModel), { headers })
    .subscribe(
      (response) => {
        console.log(JSON.stringify(response));

        // Set success message and show popup dialog
        this.success_message = 'Signatory details updated successfully';
        this.savesignatorypopupDialog = true;
        console.log('savepopupDialog:', this.savepopupDialog);

        this.editsignatorypopupDialog = false;
        this.signatoryFullDetails = null;
        this.selectedIdentifierNumber = '';
        this.signatoryFullDetailsForm.reset();
      },
      (error) => {
        console.log(JSON.stringify(error));

        // Set failure message and show popup dialog
        this.failure_message = 'An error occurred while updating signatory details';
        this.savesignatorypopupDialog = true;
        console.log('savepopupDialog:', this.savepopupDialog);

        this.editsignatorypopupDialog = false;
        this.signatoryFullDetails = null;
        this.selectedIdentifierNumber = '';
        this.signatoryFullDetailsForm.reset();
      }
    );
}


  saveSignatoryChanges() {
    if (this.selectedIdentifierNumber && this.signatoryFullDetailsForm.valid) {
      // const updateSignatoryModel = this.signatoryFullDetailsForm.value;
      const updateSignatoryModel = { ...this.updateSignatoryModel }; // Create a copy of the object to avoid modifying the original

 
     updateSignatoryModel.identifier_issue_date = new Date(this.updateSignatoryModel.identifier_issue_date).toISOString();
     updateSignatoryModel.identifier_expire_date = new Date(this.updateSignatoryModel.identifier_expire_date).toISOString();
     updateSignatoryModel.birthdate = new Date(this.updateSignatoryModel.birthdate).toISOString();
         updateSignatoryModel.foreigner_date_arrival = new Date(this.updateSignatoryModel.foreigner_date_arrival).toISOString();

      this.updateSignatoryDetails(this.updateSignatoryModel);
    }
  }



  closesignatoryEditDialog() {
    // this.popupDialog = false; // Close the popup dialog
    this.editsignatorypopupDialog = false;
    // this.customerDetails = null;
    // this.signatoryFullDetails = null;
    // this.selectedCustId = '';
    this.selectedIdentifierNumber = '';
    // this.customerDetailsForm.reset();
    this.signatoryFullDetailsForm.reset();
    this.savesignatorypopupDialog = false; // Close the popup dialog
    // this.signatorypopupDialog = false;
    // this.directorpopupDialog = false;
    // this.signatoryResults = '';
    // this.directorResults = '';
    // this.customerDetailsVerify = '';
  
  
      //   this.popupDialog = false; // Close the pop-up window
    //   this.editpopupDialog = false; // Close the pop-up window
      // this.accountpopupDialog = false; // Close the pop-up window
    //   this.customerDetails = null; // Clear customer details
      // this.accountDetails = null; // Clear account details
    //   this.selectedCustId = ''; // Reset the selectedCustId
      // this.selectedAccount = ''; // Reset the selectedAccount
      // this.isOtherDetailsCollapsed= false;
  }



 

// Function to open the input dialog
// Function to open the input dialog
openSignatoryDialog() {
  this.checksignatorypopupDialog = true;
}

continueVerifySignatory() {
  this.identifierNumber = this.newPerson.identifier_number;
  this.identifierCode = this.newPerson.identifier_code;
  this.newPerson.personid = `${this.newPerson.identifier_code}-${this.newPerson.identifier_number}`;

  this.verifySignatory(this.country, this.identifierNumber, this.identifierCode);
}

verifySignatory(country: string, identifierNumber: string, identifierCode: string) {
  this.http.get<any>(`${this.apiUrl}/ReplaceCharacters?country=${country}&identifierNumber=${identifierNumber}&identifierCode=${identifierCode}`)
    .subscribe(
      data => {
        if (data && data !== "No data found.") {
          console.log(data);
          this.verifyResults = data;

          const keyValuePairs = this.verifyResults.split(', ');
          let issuerName;
          
          for (const pair of keyValuePairs) {
            const [key, value] = pair.split(': ');
            if (key === 'Issuer Name') {
              issuerName = value;
              break;
            }
          }
          
          console.log(issuerName); // This will print the value of "Issue Name"
          this.newPerson.identifier_issuer = issuerName;

          this.continuesignatorypopupDialog = true;
          this.fetchSignatoryDetails();
        } else {
          console.error("No data found.");
          this.failure_message = "This is not a Valid Identifier!"
          this.verifysignatorypopupDialog = true;
        }
      },
      error => {
        console.error(error);
        this.failure_message = "An Error Occurred!"
        this.verifysignatorypopupDialog = true;
      }
    );
}


fetchSignatoryDetails() {
  this.http.get<any>(`${this.apiUrl}/GetSignatoryFullDetails?identifierNumber=${this.identifierNumber}`)
  .subscribe(
      data => {
        if (data) {
          console.log(data);

          // Update newPerson with the fetched data
          // console.log(this.identifierNumberDirector);
          this.newPerson = data;
          this.newPerson.identifier_issue_date = new Date(this.newPerson.identifier_issue_date).toISOString().split('T')[0];
          this.newPerson.identifier_expire_date = new Date(this.newPerson.identifier_expire_date).toISOString().split('T')[0];
          this.newPerson.birthdate = new Date(this.newPerson.birthdate).toISOString().split('T')[0];
          this.newPerson.foreigner_date_arrival = new Date(this.newPerson.identifier_issue_date).toISOString().split('T')[0];

          console.log(this.newPerson);
          this.continuesignatorypopupDialog = true;
        } else {
          // If no data is found, proceed with inserting
          this.continuesignatorypopupDialog = true;
        }
      },
      // error => {
      //   console.error(error);
      //   this.failure_message = "An Error Occurred!";
      //   this.verifysignatorypopupDialog = true;
      // }
    );
}


addSignatory(newPerson: any): void {
  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  this.http.post(`${this.apiUrl}/InsertAmlPerson?aCCOUNT=${this.selectedAccount}&identifierNumber=${this.identifierNumber}`, JSON.stringify(newPerson), { headers })
    .subscribe(
      (response) => {
        console.log(JSON.stringify(response));

        this.success_message = 'Signatory details added successfully';
      },
      (error) => {
        console.log(JSON.stringify(error));

        this.failure_message = 'An error occurred while adding signatory details';
      }
    );
}

saveaddSignatoryChanges() {
  const newPerson = { ...this.newPerson };

  if (!this.isFormDataValid(newPerson)) {
    return;
  }

  this.saveaddsignatorypopupDialog = true;
  this.addSignatory(newPerson);
}

isFormDataValid(newPerson: any) {
  if (!newPerson.identifier_issue_date) {
     this.failure_message = 'ISSUE DATE is required !';
     this.addsignatorypopupDialog = true;
     return false;
   }

   if (!newPerson.identifier_expire_date) {
    this.failure_message = 'EXPIRY DATE is required !';
    this.addsignatorypopupDialog = true;
    return false;
  }


  if (!newPerson.tph_contact_type) {
    this.failure_message = 'CONTACT TYPE is required !';
    this.addsignatorypopupDialog = true;
    return false;
  }
 

  if (!newPerson.tph_communication_type) {
    this.failure_message = 'COMMUNICATION TYPE is required !';
    this.addsignatorypopupDialog = true;
    return false;
  }


   // if (!newPerson.first_name) {
   //   this.failure_message = 'First Name is required.';
   //   this.addsignatorypopupDialog = true;
   //   return false;
   // }
 
   // Add more validations for other fields as needed...
 
   return true; // Form data is valid
 }

resetFormFields() {
  this.newPerson.identifier_code = null;
  this.newPerson.country_code = null;
  this.newPerson.identifier_number = null;


  //this.newPerson.identifier_number = null;
  this.newPerson.personid = null;
  //this.newPerson.cust_id = null;
  //this.newPerson.identifier_code = null;
  this.newPerson.identifier_issuer = null;
  this.newPerson.occupation = null;
  this.newPerson.identifier_issue_date = null;
  this.newPerson.identifier_expire_date = null;
  this.newPerson.passport_issue_country = null;
  this.newPerson.identifier_state = null;
  this.newPerson.title = null;
  this.newPerson.first_name = null;
  this.newPerson.middle_name = null;
  this.newPerson.last_name = null;
  this.newPerson.sex = null;
  this.newPerson.birthdate = null;
  this.newPerson.birth_place = null;
  this.newPerson.mothers_name = null;
  this.newPerson.tax_number = null;
  this.newPerson.source_of_weqlth = null;
  this.newPerson.residence = null;
  this.newPerson.town = null;
  this.newPerson.address1 = null;
  this.newPerson.addressType = null;
  this.newPerson.p_add_address1 = null;
  this.newPerson.p_add_address2 = null;
  this.newPerson.city = null;
  this.newPerson.state = null;
  this.newPerson.zip = null;
  this.newPerson.country_code = null;
  this.newPerson.tph_contact_type = null;
  this.newPerson.tph_country_prefix = null;
  this.newPerson.tph_number = null;
  this.newPerson.tph_extension = null;
  this.newPerson.employer_name = null;
  this.newPerson.foreigner_date_arrival = null;
  this.newPerson.foreigner_nationality = null;
  this.newPerson.foreigner_passport_number = null;
  this.newPerson.foreigner_permit_number = null;
  this.newPerson.foreigner_visa_number = null;
  this.newPerson.foreigner_permit_valid_from = null;
  this.newPerson.foreigner_permit_valid_to = null;
  this.newPerson.tph_communication_type = null;
}

closechecksignatorypopupDialog() {
  this.resetFormFields();
  this.checksignatorypopupDialog = false;
}

closeaddsignatorypopupDialog() {
  this.addsignatorypopupDialog = false;
}

closeverifysignatorypopupDialog() {
  this.verifysignatorypopupDialog = false;
}

closesignatoryAddDialog() {
  this.resetFormFields();
  this.continuesignatorypopupDialog = false;

  
}

closesignatoryAddMessageDialog() {
  this.resetFormFields();
  this.saveaddsignatorypopupDialog = false;
  this.addsignatorypopupDialog = false;
  this.checksignatorypopupDialog = false;
  this.continuesignatorypopupDialog = false;

}





openDirectorDialog() {
  this.checkdirectorpopupDialog = true;
}



continueVerifyDirector() {
  this.identifierNumberDirector = this.newDirector.identifier_number;
  this.identifierCodeDirector = this.newDirector.identifier_code;
  //this.countryCodeDirector = this.newDirector.country_code;
  this.newDirector.personid = `${this.newDirector.identifier_code}-${this.newDirector.identifier_number}`;
console.log(this.identifierNumberDirector,this.identifierCodeDirector,this.countryCodeDirector)
  this.verifyDirector(this.country, this.identifierNumberDirector, this.identifierCodeDirector);
}


verifyDirector(country: string, identifierNumberDirector: string, identifierCodeDirector: string) {
  this.http.get<any>(`${this.apiUrl}/ReplaceCharacters?country=${country}&identifierNumber=${identifierNumberDirector}&identifierCode=${identifierCodeDirector}`)
    .subscribe(
      data => {
        if (data && data !== "No data found.") {
          console.log(data);
          this.verifyDirectorResults = data;

          const keyValuePairs = this.verifyDirectorResults.split(', ');
          let issuerName;
          
          for (const pair of keyValuePairs) {
            const [key, value] = pair.split(': ');
            if (key === 'Issuer Name') {
              issuerName = value;
              break;
            }
          }
          
          console.log(issuerName); // This will print the value of "Issue Name"
          this.newDirector.identifier_issuer = issuerName;

          this.continuedirectorpopupDialog = true;
          this.fetchDirectorDetails();
        } else {
          console.error("No data found.");
          this.failure_message = "This is not a Valid Identifier!"
          this.verifydirectorpopupDialog = true;
        }
      },
      error => {
        console.error(error);
        this.failure_message = "An Error Occurred!"
        this.verifydirectorpopupDialog = true;
      }
    );
}




fetchDirectorDetails() {
  this.http.get<any>(`${this.apiUrl}/GetSignatoryFullDetails?identifierNumber=${this.identifierNumberDirector}`)
  .subscribe(
      data => {
        if (data) {
          console.log(data);

          // Update newDirector with the fetched data
          console.log(this.selecteddirectorIdentifierNumber);
          this.newDirector = data;
          this.newDirector.identifier_issue_date = new Date(this.newDirector.identifier_issue_date).toISOString().split('T')[0];
          this.newDirector.identifier_expire_date = new Date(this.newDirector.identifier_expire_date).toISOString().split('T')[0];
          this.newDirector.birthdate = new Date(this.newDirector.birthdate).toISOString().split('T')[0];
          this.newDirector.foreigner_date_arrival = new Date(this.newDirector.identifier_issue_date).toISOString().split('T')[0];

          console.log(this.newDirector);
          this.continuedirectorpopupDialog = true;
        } else {
          // If no data is found, proceed with inserting
          this.continuedirectorpopupDialog = true;
        }
      },
      // error => {
      //   console.error(error);
      //   this.failure_message = "An Error Occurred!";
      //   this.verifydirectorpopupDialog = true;
      // }
    );
}



addDirector(newDirector: any): void {
  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  this.http.post(`${this.apiUrl}/InsertAmlPersonDirector?customerID=${this.selectedCustId}&identifierNumber=${this.identifierNumber}`, JSON.stringify(newDirector), { headers })
    .subscribe(
      (response) => {
        console.log(JSON.stringify(response));

        this.success_message = 'Director details added successfully';
      },
      (error) => {
        console.log(JSON.stringify(error));

        this.failure_message = 'An error occurred while adding director details';
      }
    );
}


saveaddDirectorChanges() {
  const newDirector = { ...this.newDirector };

  if (!this.isDirectorFormDataValid(newDirector)) {
    return;
  }

  this.saveadddirectorpopupDialog = true;
  this.addDirector(newDirector);
}



isDirectorFormDataValid(newDirector: any) {
  if (!newDirector.identifier_issue_date) {
     this.failure_message = 'ISSUE DATE is required !';
     this.adddirectorpopupDialog = true;
     return false;
   }

   if (!newDirector.identifier_expire_date) {
    this.failure_message = 'EXPIRY DATE is required !';
    this.adddirectorpopupDialog = true;
    return false;
  }


  if (!newDirector.tph_contact_type) {
    this.failure_message = 'CONTACT TYPE is required !';
    this.adddirectorpopupDialog = true;
    return false;
  }
 

  if (!newDirector.tph_communication_type) {
    this.failure_message = 'COMMUNICATION TYPE is required !';
    this.adddirectorpopupDialog = true;
    return false;
  }


   // if (!newDirector.first_name) {
   //   this.failure_message = 'First Name is required.';
   //   this.adddirectorpopupDialog = true;
   //   return false;
   // }
 
   // Add more validations for other fields as needed...
 
   return true; // Form data is valid
 }
 
 
 resetDirectorFormFields() {
  this.newDirector.identifier_code = null;
  this.newDirector.country_code = null;
  this.newDirector.identifier_number = null;


  //this.newDirector.identifier_number = null;
  this.newDirector.personid = null;
  //this.newDirector.cust_id = null;
  //this.newDirector.identifier_code = null;
  this.newDirector.identifier_issuer = null;
  this.newDirector.occupation = null;
  this.newDirector.identifier_issue_date = null;
  this.newDirector.identifier_expire_date = null;
  this.newDirector.passport_issue_country = null;
  this.newDirector.identifier_state = null;
  this.newDirector.title = null;
  this.newDirector.first_name = null;
  this.newDirector.middle_name = null;
  this.newDirector.last_name = null;
  this.newDirector.sex = null;
  this.newDirector.birthdate = null;
  this.newDirector.birth_place = null;
  this.newDirector.mothers_name = null;
  this.newDirector.tax_number = null;
  this.newDirector.source_of_weqlth = null;
  this.newDirector.residence = null;
  this.newDirector.town = null;
  this.newDirector.address1 = null;
  this.newDirector.addressType = null;
  this.newDirector.p_add_address1 = null;
  this.newDirector.p_add_address2 = null;
  this.newDirector.city = null;
  this.newDirector.state = null;
  this.newDirector.zip = null;
  this.newDirector.country_code = null;
  this.newDirector.tph_contact_type = null;
  this.newDirector.tph_country_prefix = null;
  this.newDirector.tph_number = null;
  this.newDirector.tph_extension = null;
  this.newDirector.employer_name = null;
  this.newDirector.foreigner_date_arrival = null;
  this.newDirector.foreigner_nationality = null;
  this.newDirector.foreigner_passport_number = null;
  this.newDirector.foreigner_permit_number = null;
  this.newDirector.foreigner_visa_number = null;
  this.newDirector.foreigner_permit_valid_from = null;
  this.newDirector.foreigner_permit_valid_to = null;
  this.newDirector.tph_communication_type = null;
}



closecheckdirectorpopupDialog() {
  this.resetFormFields();
  this.checkdirectorpopupDialog = false;
}

closeadddirectorpopupDialog() {
  this.adddirectorpopupDialog = false;
}

closeverifydirectorpopupDialog() {
  this.verifydirectorpopupDialog = false;
}

closedirectorAddDialog() {
  this.resetDirectorFormFields();
  this.continuedirectorpopupDialog = false;

  
}

closedirectorAddMessageDialog() {
  this.resetDirectorFormFields();
  this.saveadddirectorpopupDialog = false;
  this.adddirectorpopupDialog = false;
  this.checkdirectorpopupDialog = false;
  this.continuedirectorpopupDialog = false;

}




//   addSignatory() {
//     const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  
//     this.http.post(`${this.apiUrl}/InsertAmlPerson`, JSON.stringify(this.newPerson), { headers })
//       .subscribe(
//         (response) => {
//           console.log(JSON.stringify(response));
  
//           // Set success message and show popup dialog
//           this.addsignatorypopupDialog = true;
//           this.success_message = 'Signatory added successfully';
//           this.saveaddsignatorypopupDialog = true;
//           console.log('saveaddsignatorypopupDialog:', this.saveaddsignatorypopupDialog);

//           // Reset the form and signatory model
//           this.newPerson = {};
//           this.signatoryAddForm.reset();


//    // Set success message and show popup dialog


//         },
//         (error) => {
//           console.log(JSON.stringify(error));
  
//           // Set failure message and show popup dialog
//           this.addsignatorypopupDialog = true;
//           this.failure_message = 'An error occurred while adding signatory';
//           this.saveaddsignatorypopupDialog = true;
//           console.log('saveaddsignatorypopupDialog:', this.saveaddsignatorypopupDialog);


//         }
//       );
//   }
  
//   // ...
  
//   // ...
// closesignatoryAddDialog() {
//   this.addsignatorypopupDialog = false; // Close the popup dialog
//   this.newPerson = {}; // Reset the signatory model
//   this.signatoryAddForm.reset(); // Reset the form
// }
// // ...


// saveSignatoryAdd() {
//   if (this.signatoryAddForm.valid) {
//     const newPerson = { ...this.newPerson }; // Create a copy of the object to avoid modifying the original

//     newPerson.identifier_issue_date = new Date(this.newPerson.identifier_issue_date).toISOString();
//     newPerson.identifier_expire_date = new Date(this.newPerson.identifier_expire_date).toISOString();
//     newPerson.birthdate = new Date(this.newPerson.birthdate).toISOString();
//     newPerson.foreigner_date_arrival = new Date(this.newPerson.foreigner_date_arrival).toISOString();

//     // Add code to send the data to the server or perform any other necessary actions

//     // After successful submission, you can display a success message and close the dialog
//     this.success_message = 'Signatory details added successfully';
//     this.saveaddsignatorypopupDialog = true;
//   }
// }




  openDirectorEdit() {
    if (this.selecteddirectorIdentifierNumber) {
      this.http.get<any>(`${this.apiUrl}/GetSignatoryFullDetails?identifierNumber=${this.selecteddirectorIdentifierNumber}`)
        .subscribe(
          (data) => {
            this.directorFullDetails = data;
            this.editdirectorpopupDialog = true; // Show the pop-up window
    

            data.identifier_issue_date = new Date(data.identifier_issue_date); // Adjust the property name as needed
            data.identifier_expire_date = new Date(data.identifier_expire_date); // Adjust the property name as needed
            data.birthdate = new Date(data.birthdate); // Adjust the property name as needed
        data.foreigner_date_arrival = new Date(data.foreigner_date_arrival); // Adjust the property name as needed
  
  
  
            // Adjust for time zone offset
            const offset = data.identifier_issue_date.getTimezoneOffset();
            data.identifier_issue_date.setMinutes(data.identifier_issue_date.getMinutes() - offset);
  
            const offset2 = data.identifier_expire_date.getTimezoneOffset();
            data.identifier_expire_date.setMinutes(data.identifier_expire_date.getMinutes() - offset2);
  
            const offset3 = data.birthdate.getTimezoneOffset();
            data.birthdate.setMinutes(data.birthdate.getMinutes() - offset3);
          
        const offset4 = data.foreigner_date_arrival.getTimezoneOffset();
            data.foreigner_date_arrival.setMinutes(data.foreigner_date_arrival.getMinutes() - offset4);

          // Format the date property for the HTML input field
          this.updateSignatoryModel = { ...data 	,
            identifier_issue_date: data.identifier_issue_date.toISOString().substring(0, 10),
            identifier_expire_date: data.identifier_expire_date.toISOString().substring(0, 10),
            birthdate: data.birthdate.toISOString().substring(0, 10) ,
            foreigner_date_arrival: data.foreigner_date_arrival.toISOString().substring(0, 10) };
        
          this.directorFullDetailsForm.patchValue(this.updateSignatoryModel);
          },
          (error) => {
            console.error('Error fetching director details:', error);
          }
        );
    }
  }


// ...

updateDirectorDetails(updateSignatoryModel: any): void {
  console.log('updateSignatoryModel:', updateSignatoryModel);
  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  this.http.put(`${this.apiUrl}/UpdateSignatoryDetails?identifierNumber=${this.selecteddirectorIdentifierNumber}`, JSON.stringify(this.updateSignatoryModel), { headers })
    .subscribe(
      (response) => {
        console.log(JSON.stringify(response));

        // Set success message and show popup dialog
        this.success_message = 'Director details updated successfully';
        this.savedirectorpopupDialog = true;
        console.log('savepopupDialog:', this.savepopupDialog);

        this.editdirectorpopupDialog = false;
        this.directorFullDetails = null;
        this.selecteddirectorIdentifierNumber = '';
        this.directorFullDetailsForm.reset();
      },
      (error) => {
        console.log(JSON.stringify(error));

        // Set failure message and show popup dialog
        this.failure_message = 'An error occurred while updating director details';
        this.savedirectorpopupDialog = true;
        console.log('savepopupDialog:', this.savepopupDialog);

        this.editdirectorpopupDialog = false;
        this.directorFullDetails = null;
        this.selecteddirectorIdentifierNumber = '';
        this.directorFullDetailsForm.reset();
      }
    );
}


  saveDirectorChanges() {
    if (this.selecteddirectorIdentifierNumber && this.directorFullDetailsForm.valid) {
      // const updateSignatoryModel = this.signatoryFullDetailsForm.value;
      const updateSignatoryModel = { ...this.updateSignatoryModel }; // Create a copy of the object to avoid modifying the original

      updateSignatoryModel.identifier_issue_date = new Date(this.updateSignatoryModel.identifier_issue_date).toISOString();
      updateSignatoryModel.identifier_expire_date = new Date(this.updateSignatoryModel.identifier_expire_date).toISOString();
      updateSignatoryModel.birthdate = new Date(this.updateSignatoryModel.birthdate).toISOString();
	        updateSignatoryModel.foreigner_date_arrival = new Date(this.updateSignatoryModel.foreigner_date_arrival).toISOString();

      this.updateDirectorDetails(this.updateSignatoryModel);
    }
  }



  closedirectorEditDialog() {
    // this.popupDialog = false; // Close the popup dialog
    this.editdirectorpopupDialog = false;
    // this.customerDetails = null;
    // this.signatoryFullDetails = null;
    // this.selectedCustId = '';
    this.selecteddirectorIdentifierNumber = '';
    // this.customerDetailsForm.reset();
    this.directorFullDetailsForm.reset();
    this.savedirectorpopupDialog = false; // Close the popup dialog
    // this.signatorypopupDialog = false;
    // this.directorpopupDialog = false;
    // this.signatoryResults = '';
    // this.directorResults = '';
    // this.customerDetailsVerify = '';
  
  
      //   this.popupDialog = false; // Close the pop-up window
    //   this.editpopupDialog = false; // Close the pop-up window
      // this.accountpopupDialog = false; // Close the pop-up window
    //   this.customerDetails = null; // Clear customer details
      // this.accountDetails = null; // Clear account details
    //   this.selectedCustId = ''; // Reset the selectedCustId
      // this.selectedAccount = ''; // Reset the selectedAccount
      // this.isOtherDetailsCollapsed= false;
  }








}
