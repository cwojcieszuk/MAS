import { Component, OnInit } from '@angular/core';
import { AuthFacade } from './auth/+state/auth.facade';
import { MatDialog } from '@angular/material/dialog';
import { LoginDialogComponent } from './auth/dialogs/login-dialog/login-dialog.component';
import { BaseComponent } from './shared/components/base.component';
import { RegisterDialogComponent } from './auth/dialogs/register-dialog/register-dialog.component';
import { filter } from 'rxjs';
import { AddMoneyDialogComponent } from './auth/dialogs/add-money-dialog/add-money-dialog.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent extends BaseComponent implements OnInit {

  constructor(
    public authFacade: AuthFacade,
    private dialog: MatDialog
  ) {
    super();
  }

  ngOnInit(): void {
    this.observe(this.authFacade.user$)
      .pipe(filter(Boolean))
      .subscribe(() => this.authFacade.init());
  }

  login(): void {
    const dialog = this.dialog.open(LoginDialogComponent, {
      minWidth: '500px',
    });

    this.observe(dialog.afterClosed())
      .pipe(filter(Boolean))
      .subscribe(obj => this.authFacade.login({ email: obj.email, password: obj.password }))
  }

  register(): void {
    const dialog = this.dialog.open(RegisterDialogComponent, {
      minWidth: '650px',
      minHeight: '200px',
    });

    this.observe(dialog.afterClosed())
      .pipe(filter(Boolean))
      .subscribe(result => this.authFacade.register(result));
  }

  addMoney(): void {
    const dialog = this.dialog.open(AddMoneyDialogComponent, {
      minWidth: '400px',
    });

    this.observe(dialog.afterClosed())
      .pipe(filter(Boolean))
      .subscribe(result => this.authFacade.addMoney(+result.amount));
  }
}
