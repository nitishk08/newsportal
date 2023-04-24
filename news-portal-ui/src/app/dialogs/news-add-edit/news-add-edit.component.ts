import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CoreService } from 'src/app/core/core.service';
import { NewsPortalService } from 'src/app/services/news-portal.service';

@Component({
  selector: 'app-news-add-edit',
  templateUrl: './news-add-edit.component.html',
  styleUrls: ['./news-add-edit.component.scss']
})
export class NewsAddEditComponent implements OnInit{
  newsPortalForm: FormGroup;

  category: string[] = [

  ];
  constructor(
    private _fb: FormBuilder,
    private _newsPortalService: NewsPortalService,
    private _dialogRef: MatDialogRef<NewsAddEditComponent>,
    private _coreService: CoreService,
    @Inject(MAT_DIALOG_DATA) public data: any 
  ) {
    this.newsPortalForm = this._fb.group({
      id:0,
      title: new FormControl("", Validators.required),
      description: new FormControl("", Validators.required),
      categoryName: new FormControl("", Validators.required)
    });
  }

  ngOnInit(): void {
    this.newsPortalForm.patchValue(this.data);
    this._newsPortalService.getCategoryList().subscribe({
      next: (res : any[]) =>{
        console.log(res.map(item => item.name));
        this.category = res.map(item => item.name);
        console.log(this.category);
      }
    });
  }
  onFormSubmit() {
    if (this.newsPortalForm.valid) {
      if (this.data) {
        this._newsPortalService
          .updateArticle(this.newsPortalForm.value)
          .subscribe({
            next: (val: any) => {
              this._coreService.openSnackBar('News Article detail updated!');
              this._dialogRef.close(true);
            },
            error: (err: any) => {
              console.error(err);
            },
          });
      } else {   
        this._newsPortalService.addNewsArticle(this.newsPortalForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('News Article added successfully');
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }

    }
  }
}
