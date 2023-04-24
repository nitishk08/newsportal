import { Component, ElementRef, ViewChild } from '@angular/core';
import { NewsPortalService } from './services/news-portal.service';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { NewsArticle } from './models/newsArticle';
import { MatTableDataSource } from '@angular/material/table';
import { CoreService } from './core/core.service';
import {NewsAddEditComponent} from './dialogs/news-add-edit/news-add-edit.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'news-portal';

  displayedColumns = ['id', 'title', 'description','categoryName', 'createdDateTime','action'];
  exampleDatabase: NewsPortalService | null;
  index: number;
  id: number;
  isLoading = false;  
  totalRows = 0;
  pageSize = 5;
  currentPage = 0;
  pageSizeOptions: number[] = [5,10];

  dataSource: MatTableDataSource<NewsArticle> = new MatTableDataSource();

  constructor(private _coreService: CoreService,
              private _dialogService: MatDialog,
              private _dataService: NewsPortalService) {}

  @ViewChild(MatPaginator, {static: true}) paginator!: MatPaginator;
  @ViewChild('filter',  {static: true}) filter: ElementRef;

  ngOnInit() {
    this.loadData();
    this.getAllNewsArticlesCount();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  loadData(){
    this.isLoading = true;
    this._dataService.getNewsArticles(this.currentPage + 1, this.pageSize).subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        setTimeout(() => {
          this.paginator.pageIndex = this.currentPage;
          this.paginator.length = this.totalRows;
        });
        this.isLoading = false;
      },
      error: (ex) => {
        console.log(ex);
        this.isLoading = false;
      },
      
    });
  }
  openAddEditNewsForm(){
    const dialogRef = this._dialogService.open(NewsAddEditComponent, {
      height:'50%',
      width:'40%'
    });
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.loadData();
          this.getAllNewsArticlesCount();
        }
      },
    });
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
   this._dataService.applyFilter(filterValue.trim().toLowerCase()).subscribe({
    next: (res) =>{
      this.dataSource = new MatTableDataSource(res);
        this.dataSource.paginator = this.paginator;
    }
   })
  }

  deleteArticle(id: number) {
    this._dataService.deleteArticle(id).subscribe({
      next: (res) => {
        this._coreService.openSnackBar('News Article deleted!', 'done');
        this.loadData();
        this.getAllNewsArticlesCount();
      },
      error: console.log,
    });
  }

  openEditForm(data: any) {
    const dialogRef = this._dialogService.open(NewsAddEditComponent, {
     
        height:'50%',
        width:'40%',
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.loadData();
        }
      },
    });

  }
  
  pageChanged(event: PageEvent) {
    console.log({ event });
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex;
    this.loadData();
  }

  getAllNewsArticlesCount(){
    this._dataService.getCount().subscribe({
      next:(value)=> {
        this.totalRows = value;
      },
    });
  }

}

