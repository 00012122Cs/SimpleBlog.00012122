import { Routes } from '@angular/router';
import { PostListComponent } from './post-list/post-list.component';
import { PostDetailComponent } from './post-detail/post-detail.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { PostFormComponent } from './post-form/post-form.component';

export const routes: Routes = [
    { path: '', redirectTo: '/posts', pathMatch: 'full' }, // Default route
    { path: 'posts', component: PostListComponent },
    { path: 'users', component: UserListComponent },
    { path: 'users/:id', component: UserDetailComponent },
    { path: 'posts/new', component: PostFormComponent },
    { path: 'posts/edit/:id', component: PostFormComponent },
    { path: 'posts/:id', component: PostDetailComponent },

];