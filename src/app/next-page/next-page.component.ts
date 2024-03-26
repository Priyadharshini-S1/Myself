import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-next-page',
  templateUrl: './next-page.component.html',
  styleUrl: './next-page.component.css'
})
export class NextPageComponent implements OnInit{
  imageUrl!: string;
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.imageUrl = history.state.imageUrl;
    }
  }

