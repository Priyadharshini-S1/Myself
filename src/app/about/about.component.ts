import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { PortfolioService } from '../portfolio.service';
@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent implements OnInit{
  ngOnInit(): void {
    const counters = document.querySelectorAll(".counter");
    counters.forEach((counter:any) => {
      counter.innerText = "0";
      const updateCounter = () => {
        const target = +counter.getAttribute("data-target");
        const count = +counter.innerText;
        const increment = target / 200;
        if (count < target) {
          counter.innerText = `${Math.ceil(count + increment)}`;
          setTimeout(updateCounter, 1);
        } else counter.innerText = target;
      };
      updateCounter();
    });
  }
}