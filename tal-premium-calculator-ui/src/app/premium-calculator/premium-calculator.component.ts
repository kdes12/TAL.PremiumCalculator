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

    occupations$ = this.occupationService.apiOccupationGetOccupationsGet();

    onOccupationChange(event : Event) {
      var occupationId = (event.target as HTMLSelectElement).value;
      var premium = this.premiumService.apiPremiumGetPremiumGet(occupationId, this.sumInsured, this.dateOfBirth.toString()).subscribe((response) => {
          console.log(response);
      });
      console.log(this.dateOfBirth.toString());
    }

}
