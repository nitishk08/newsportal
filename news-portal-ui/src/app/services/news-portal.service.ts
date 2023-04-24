import { Injectable } from '@angular/core';
import { NewsArticle } from '../models/newsArticle';
import {BehaviorSubject, Observable} from 'rxjs';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class NewsPortalService {

  private readonly API_URL = 'https://localhost:7268/api/NewsArticle/';


  constructor(private httpClient: HttpClient) {}



  getNewsArticles(currentPage:number, pageSize:number){
   return this.httpClient.get<NewsArticle[]>(this.API_URL + 'GetArticles?currentPage='+ currentPage +'&pageSize='+ pageSize);
    
  }

  addNewsArticle(data: any): Observable<any> {
    return this.httpClient.post(this.API_URL + 'Create', data);
  }

  updateArticle(data: any): Observable<any> {
    return this.httpClient.put(this.API_URL + 'Update', data);
  }

  deleteArticle(id: number): Observable<any> {
    return this.httpClient.delete(this.API_URL + `Delete?newsArticleId=${id}`);
  }
  applyFilter(searchWord:string){
    return this.httpClient.get<NewsArticle[]>(this.API_URL + 'Search?search='+ searchWord);
  }

  getCount(){
    return this.httpClient.get<number>(this.API_URL + 'GetNewsArticleCount');
  }

  getCategoryList(){
    return this.httpClient.get<string[]>(this.API_URL + 'GetCategories');
  }
  
}
