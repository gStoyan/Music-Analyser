import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as CanvasJS from '../../assets/canvasjs.min.js';
import { BlocksService } from '../services/blocks.service';
import * as $ from 'jquery';
import { timer } from 'rxjs';
@Component({
  selector: 'app-draw',
  templateUrl: './draw.component.html',
  styleUrls: ['./draw.component.css']
})
export class DrawComponent implements OnInit {

  constructor(private route: ActivatedRoute, private blockServices: BlocksService) { }
  private router : Router
    ngOnInit() {
      
	let dataPoints = [];

  let Blocks: Object
	let dpsLength = 0;
    this.blockServices.GetBlocks()
    .subscribe(data=>{
      Blocks = data
      console.log(data)
      

      let chart = new CanvasJS.Chart("chartContainer", {
        animationEnabled: true,
        exportEnabled: true,
        colorSet: "green",
        title: {
          text: "Notes"
        },
        backgroundColor: "Black",
        labelFontColor: "White",
        axisX:{                       
          margin: 0, 
          lineThickness: 0,
          tickThickness: 0          
        },
        axisY:{            
          margin: 0,            
          lineThickness: 0,
          gridThickness: 0,
          tickLength: 0
        },
        data: [{
          type: "rangeColumn",
          dataPoints: dataPoints
        }]
      }); 
      let i = 0;
        chart.render();
        updateChart(i); 
    function updateChart(i: number) {	
      let yStart = Blocks[i].yStart as Number
      let yEnd = Blocks[i].yEnd as Number
      let name = Blocks[i].name as string
      let color = Blocks[i].color as string  
      let time =  Blocks[i].time as number
      let pause =  Blocks[i].pause as number
      dataPoints.push( { y: [yStart,yEnd], label: name,color: color,  })     
        dpsLength++;
     
      chart.render();
      
      i++
      setTimeout(function(){updateChart(i)}, time + pause);
      }}) 
    }           
}
