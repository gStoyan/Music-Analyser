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
  public isClicked = false;
  public pauseInterval = 50000;
  private router : Router
    ngOnInit() {
  let x = 0;
	let dataPoints = [];
  let dataPoints1 = [1,2,3,4,5,6,7]
  let Blocks: Object
    this.blockServices.GetBlocks()
    .subscribe(data=>{
      Blocks = data
      console.log(data)
      
      
      let chart = new CanvasJS.Chart("chartContainer", {
        animationEnabled: true,
        exportEnabled: true,
        title: {
          text: "Notes"
        },
        backgroundColor: "Grey",
        labelFontColor: "White",
        toolTip: {
          fontColor: "red",
          Content: "{x} : {y}"
        },
        axisX:{                    
          margin: 3,             
          lineThickness: 0,
          tickThickness: 0          
        },
        axisY:{      
          
          hoverBorderColor: "Black",         
          margin: 3,            
          lineThickness: 0,
          gridThickness: 0,
          tickLength: 0
        },
        data: [{
          type: "rangeColumn",
          dataPoints: dataPoints,
          backgroundColor: "rgba(159,170,174,0.8)",
          borderWidth: 1,
          hoverBackgroundColor: "rgba(232,105,90,0.8)",
          hoverBorderColor: "Black",
          scaleStepWidth: 1,
          fill:false
        }],
        navigator: {
          data: [{
            dataPoints: dataPoints1
          }],
          slider: {
            minimum: 0,
            maximum: 5
          }
        }
        
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
      
      dataPoints.push( { y: [yStart,yEnd], label: name,color: color, x:x++})   
      if(i>50){
        dataPoints.splice(0, 1)
      }     
      chart.render();      
      i++
      setTimeout(function(){updateChart(i)}, time + pause);
      }}) 
    }           
}
