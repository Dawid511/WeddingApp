import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { TodoComponent } from './todo/todo.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { InspirationsComponent } from './inspirations/inspirations.component';
import { authGuard } from './_guards/auth.guard';
import { MemberListComponent } from './members/member-list/member-list.component';
import { GuestComponent } from './guest/guest.component';
import { VendorComponent } from './vendor/vendor.component';
import { VendorAddComponent } from './vendor-add/vendor-add.component';
import { RoleComponent } from './role/role.component';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [authGuard],
        children: [
            {path: 'lists', component: ListsComponent},
            {path: 'guest', component: GuestComponent},
            {path: 'todo', component: TodoComponent},
            {path: 'role', component: RoleComponent},
            {path: 'vendor', component: VendorComponent},
            {path: 'vendor-add', component: VendorAddComponent},
            {path: 'members/member-list', component: MemberListComponent},
            {path: 'members/:id', component: MemberDetailComponent},
            {path: 'inspirations', component: InspirationsComponent},
           
        ]
    },
    {path: '**', component: HomeComponent, pathMatch: 'full'},
];
