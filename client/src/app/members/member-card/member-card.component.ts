import { Component, input } from '@angular/core';
import { Member } from '../../_modules/member';

@Component({
  selector: 'app-member-card',
  imports: [],
  templateUrl: './member-card.component.html',
  styleUrl: './member-card.component.css'
})

export class MemberCardComponent {
member = input.required<Member>();
}
