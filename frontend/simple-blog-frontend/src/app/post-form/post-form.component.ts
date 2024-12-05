import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-post-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './post-form.component.html',
  styleUrls: ['./post-form.component.css'],
})
export class PostFormComponent implements OnInit {
  post: any = { title: '', content: '', userId: null };
  isEdit: boolean = false;

  constructor(
    private apiService: ApiService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEdit = true;
      this.apiService.getPostById(Number(id)).subscribe({
        next: (data) => (this.post = data),
        error: (error) => console.error('Error fetching post:', error),
      });
    }
  }

  submitForm(): void {
    if (this.isEdit) {
      this.apiService.updatePost(this.post.id, this.post).subscribe(() => {
        this.router.navigate(['/posts']);
      });
    } else {
      this.apiService.createPost(this.post).subscribe(() => {
        this.router.navigate(['/posts']);
      });
    }
  }
}
