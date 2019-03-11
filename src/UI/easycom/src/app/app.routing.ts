import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { EditUserComponent } from './edit-user/edit-user.component';
import { AddUserComponent } from './add-user/add-user.component';
import { ListUserComponent } from './list-user/list-user.component';

const routes: Routes = [
    { path : '', component : LoginComponent },
    { path: 'add-user', component: AddUserComponent },
    { path: 'list-user', component: ListUserComponent },
    { path: 'edit-user', component: EditUserComponent }
  ];
  
  export const routing = RouterModule.forRoot(routes);
  