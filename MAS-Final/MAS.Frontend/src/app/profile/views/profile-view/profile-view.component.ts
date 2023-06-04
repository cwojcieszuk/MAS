import { Component } from '@angular/core';
import { ProfileFacade } from '../../+state/profile.facade';

export interface MenuItem {
  id: number;
  name: string;
}

@Component({
  selector: 'app-profile-view',
  templateUrl: './profile-view.component.html',
  styleUrls: ['./profile-view.component.scss']
})
export class ProfileViewComponent {
  menuItems: MenuItem[];

  constructor(
    public facade: ProfileFacade
  ) {
    this.menuItems = [{ id: 1, name: 'Moje dane' }, { id: 2, name: 'Adres' }, { id: 3, name: 'Konto' }, { id: 4, name: 'Transakcje' }];
  }
}
