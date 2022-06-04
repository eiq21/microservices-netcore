import { Component, OnInit } from '@angular/core';
import { IReport } from '../models/ireport';
import { PoliciesService } from '../services/data/policies/policies.service';

const ELEMENT_DATA: IReport[] = [
  { Number: 'Safe Traveller', ProductCode: 'TRI', AgainLogin: 'Erick', ProductName: "Product name" }
];

@Component({
  selector: 'app-policies',
  templateUrl: './policies.component.html',
  styleUrls: ['./policies.component.scss']
})
export class PoliciesComponent implements OnInit {
  reports: IReport[] = [];
  displayedColumns: string[] = ['Number', 'ProductCode', 'AgainLogin', 'ProductName'];
  dataSource = ELEMENT_DATA;
  constructor(private policiesService: PoliciesService) { }

  ngOnInit(): void {
    this.getReports();
  }

  getReports() {
    this.policiesService.getReport().subscribe((response: IReport[]) => {
      this.reports = response;
      console.log(response);
    })
  }

}
