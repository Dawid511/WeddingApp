import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { TodoComponent } from './todo/todo.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { InspirationsComponent } from './inspirations/inspirations.component';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'lists', component: ListsComponent},
    {path: 'todo', component: TodoComponent},
    {path: 'member/:id', component: MemberDetailComponent},
    {path: 'inspirations', component: InspirationsComponent},
    {path: '**', component: HomeComponent, pathMatch: 'full'},
];
