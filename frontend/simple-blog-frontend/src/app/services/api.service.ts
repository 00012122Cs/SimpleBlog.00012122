import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    API_URL = 'http://localhost:5290/api';

    constructor(private http: HttpClient) { }

    getPosts() {
        return this.http.get(`${this.API_URL}/Post`);
    }

    getPostById(id: number) {
        return this.http.get(`${this.API_URL}/Post/${id}`);
    }

    createPost(post: any) {
        return this.http.post(`${this.API_URL}/Post`, post);
    }

    updatePost(id: number, post: any) {
        return this.http.put(`${this.API_URL}/Post/${id}`, post);
    }

    deletePost(id: number) {
        return this.http.delete(`${this.API_URL}/Post/${id}`);
    }

    getUsers() {
        return this.http.get(`${this.API_URL}/User`);
    }

    getUserById(id: number) {
        return this.http.get(`${this.API_URL}/User/${id}`);
    }
    createUser(user: any) {
        return this.http.post(`${this.API_URL}/User`, user);
    }

}