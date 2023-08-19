import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-post-card',
  templateUrl: './post-card.component.html',
  styleUrls: ['./post-card.component.css']
})
export class PostCardComponent {
  @Input() slug!: string;
  @Input() image!: string;
  @Input() date!: string;
  @Input() title!: string;
  @Input() summary!: string;
  @Input() authorImage!: string;
  @Input() authorName!: string;
  
  constructor() {
  }
}
