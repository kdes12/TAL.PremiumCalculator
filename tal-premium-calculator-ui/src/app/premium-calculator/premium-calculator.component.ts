import { Component } from '@angular/core';
import { OccupationResponse, OccupationService, PremiumService } from 'src/api';

@Component({
  selector: 'app-premium-calculator',
  templateUrl: './premium-calculator.component.html',
  styleUrls: ['./premium-calculator.component.css']
})
export class PremiumCalculatorComponent {
  constructor(
    private occupationService: OccupationService, 
    private premiumService: PremiumService) {}

    // input values    
    name = "";
    dateOfBirth = new Date(new Date().getFullYear(), 0, 1);
    sumInsured = 0;
    occupationId = "";

    // output values
    deathPremium = 0;
    tpdMonthlyPremium = 0;

    // validation values
    // true by default, so alerts are not shown by default
    nameValid = true;
    dateOfBirthValid = true;
    sumInsuredValid = true;
    occupationIdValid = true;
    // false by default, to invalid premium is not shown
    premiumValid = false;
    
    maximumAgeLoaded = false;
    occupationsLoaded = false;

    // get maximum age
    maximumAge = 0;
    _ = this.premiumService.apiPremiumGetMaximumAgeGet().subscribe(
    {
      next: (maximumAge) => {
        // set occupations
        this.maximumAge = maximumAge;
        this.maximumAgeLoaded = true;
      }
    });

    // get occupations
    occupations = [] as OccupationResponse[];
    __ = this.occupationService.apiOccupationGetOccupationsGet().subscribe(
      {
        next: (occupationsResponse) => {
          // set occupations
          this.occupations = occupationsResponse;
          // set current occupation id to first item in list
          this.occupationId = occupationsResponse[0].id ?? ""
          this.occupationsLoaded = true;
        }
      }
    );

    onOccupationChange(event : Event) {
      // set occupation id
      this.occupationId = (event.target as HTMLSelectElement).value;
      // calculate premium
      this.calculatePremium();
    }

    calculatePremium() {
      // validate input first
      if (this.validateInput())
      {
        console.log("valid");
        // call premium service
        this.premiumService.apiPremiumCalculatePremiumGet(this.occupationId, this.sumInsured, this.dateOfBirth.toString()).subscribe(
          {
              next: (premiumResponse) => {
                // set death premium/tpd monthly premium
                this.deathPremium = premiumResponse.deathPremium ?? 0;
                this.tpdMonthlyPremium = premiumResponse.tpdPremiumMonthly ?? 0
                this.premiumValid = true;
              },
              error: (error) => {
                this.deathPremium = 0;
                this.tpdMonthlyPremium = 0;
                this.premiumValid = false;
                console.log(error);
              },
              complete: () => {} 
          });
      }
    }

    validateInput() : boolean
    {
      console.log(this.name);
      console.log(this.dateOfBirth);
      console.log(this.sumInsured);
      console.log(this.occupationId);

      // name cannot be null, undefined, empty or whitespace
      if (this.name != null && this.name.trim() !== '') {
        this.nameValid = true;
      }
      else
      {
        this.nameValid = false;
      }

      // date of birth must be set, and calculated age must be greater than or equal to max age
      if (this.dateOfBirth != null && this.calculateAge(this.dateOfBirth) <= this.maximumAge)
      {
        this.dateOfBirthValid = true;
      }
      else
      {
        this.dateOfBirthValid = false;
      }

      // sum insured must be set, and greater than 0
      if (this.sumInsured != null && this.sumInsured > 0)
      {
        this.sumInsuredValid = true;
      }
      else
      {
        this.sumInsuredValid = false;
      }

      // occupationId cannot be null, undefined, empty or whitespace
      if (this.occupationId != null && this.occupationId.trim() !== ''){
        this.occupationIdValid = true;
      }
      else
      {
        this.occupationIdValid = false;
      }

      // everything must be valid to return true
      return this.nameValid && this.dateOfBirthValid && this.sumInsuredValid && this.occupationIdValid;
    }

    calculateAge(dateOfBirth : Date)
    {
      // calculate age
      var dob = new Date(dateOfBirth);
      dob = new Date(dob.toDateString()); // removing time component
      var now = new Date();
      now = new Date(now.toDateString()); // removing time component
      var age = now.getUTCFullYear() - dob.getUTCFullYear();
      // handle leap years
      var leapCheck = new Date(now);
      leapCheck.setUTCFullYear(now.getUTCFullYear()-age);
      if (dob > leapCheck)
      {
        age--;
      }
      
      return age;
    }
}
