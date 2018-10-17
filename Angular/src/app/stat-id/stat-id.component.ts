import { Component, OnInit } from '@angular/core';
import { ApiUserService } from '../api-user.service';
import { Router, ActivatedRoute } from '@angular/router';
import * as Chart from 'chart.js';

@Component({
  selector: 'app-stat-id',
  templateUrl: './stat-id.component.html',
  styleUrls: ['./stat-id.component.css']
})
export class StatIdComponent implements OnInit {
  stats: any;
  id: number;
  constructor(private service: ApiUserService, private route: ActivatedRoute) {
    this.id = parseInt(this.route.snapshot.params.id, 0);//snpshot : attribu d'active route
    console.log(this.stats);
  }
  ngOnInit() {
    this.service.getOneStat(this.id).subscribe(u => {
      this.stats = u;
      let canvas = <HTMLCanvasElement>document.getElementById("myChart");
      let ctx = canvas.getContext("2d");
      let tableauTaux = [];
      let tableauLabel = [];
      console.log(this.stats.TauxChoixReponse);
      this.stats.TauxChoixReponse.forEach(value => {
        value.Reponses.forEach(element => {
          tableauTaux.push(element.Taux)
          tableauLabel.push(element.Contenu)
        });
      })
      console.log(tableauTaux);
      console.log(tableauLabel);
      let myChart = new Chart(ctx, {
        type: 'pie',
        data: {
          labels: tableauLabel,
          datasets: [{
            label: '# of Votes',
            data: tableauTaux,
            backgroundColor: [
              'rgba(255, 99, 132, 0.2)',
              'rgba(54, 162, 235, 0.2)',
              'rgba(255, 206, 86, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(153, 102, 255, 0.2)',
              'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
              'rgba(255,99,132,1)',
              'rgba(54, 162, 235, 1)',
              'rgba(255, 206, 86, 1)',
              'rgba(75, 192, 192, 1)',
              'rgba(153, 102, 255, 1)',
              'rgba(255, 159, 64, 1)'
            ],
            borderWidth: 1
          }]
        },
        options: {
          scales: {
            yAxes: [{
              ticks: {
                beginAtZero: true
              }
            }]
          }
        }
      });
    });
  }
}



