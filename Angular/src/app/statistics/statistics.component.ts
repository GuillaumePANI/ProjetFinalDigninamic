import { Component, OnInit} from '@angular/core';

import { ApiUserService } from '../api-user.service';
import { ActivatedRoute, Router } from '@angular/router';
import * as Chart from 'chart.js';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  stats: any;
  id:number;
  constructor(private service: ApiUserService,private router: Router,
  private route: ActivatedRoute) {   }

  ngOnInit() {
   
   this.service.getAllStat().subscribe(u => {
      this.stats = u;
     // this.id = this.stats.IdFormulaire;
   });
    }
  }
   

 
