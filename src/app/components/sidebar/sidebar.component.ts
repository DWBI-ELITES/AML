import { Component, OnInit } from '@angular/core';

declare const $: any;
// declare interface RouteInfo {
//     path: string;
//     title: string;
//     icon: string;
//     class: string;   
// }

interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
  submenu?: SubmenuItem[]; // Notice the "?" to indicate it's optional
}


interface SubmenuItem {
  label: string;
  icon: string;
  items?: SubmenuItem[];
  
}


export const ROUTES: RouteInfo[] = [
    // { path: '/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '' },
    // // { path: '/user-profile', title: 'User Profile',  icon:'person', class: '' },
    // { path: ' ', title: 'Excel Upload',  icon:'library_books', class: '' },
    // { path: '/user-profile', title: 'Admin Portal',  icon:'person', class: '' },
    // { path: ' ', title: 'Reports',  icon:'content_paste', class: '' },
    // { path: '/user-profile', title: 'Request Demo',  icon:'language', class: '' },
    // { path: '/user-profile', title: 'Logout',  icon:'directions_run', class: '' },
    { path: '', title: 'CDD',  icon:'language', class: '' },
    { path: '/notifications', title: 'CTR',  icon:'content_paste', class: '' },
    // {
    //     path: '',
    //     title: 'Hierarchy',
    //     icon: 'pi pi-fw pi-bookmark',
    //     class: '',
    //     submenu: [
    //         {
    //             label: 'Submenu 1', icon: 'pi pi-fw pi-bookmark',
    //             items: [
    //                 {
    //                     label: 'Submenu 1.1', icon: 'pi pi-fw pi-bookmark',
    //                     items: [
    //                         { label: 'Submenu 1.1.1', icon: 'pi pi-fw pi-bookmark' },
    //                         { label: 'Submenu 1.1.2', icon: 'pi pi-fw pi-bookmark' },
    //                         { label: 'Submenu 1.1.3', icon: 'pi pi-fw pi-bookmark' },
    //                     ]
    //                 },
    //                 {
    //                     label: 'Submenu 1.2', icon: 'pi pi-fw pi-bookmark',
    //                     items: [
    //                         { label: 'Submenu 1.2.1', icon: 'pi pi-fw pi-bookmark' }
    //                     ]
    //                 },
    //             ]
    //         },
    //         {
    //             label: 'Submenu 2', icon: 'pi pi-fw pi-bookmark',
    //             items: [
    //                 {
    //                     label: 'Submenu 2.1', icon: 'pi pi-fw pi-bookmark',
    //                     items: [
    //                         { label: 'Submenu 2.1.1', icon: 'pi pi-fw pi-bookmark' },
    //                         { label: 'Submenu 2.1.2', icon: 'pi pi-fw pi-bookmark' },
    //                     ]
    //                 },
    //                 {
    //                     label: 'Submenu 2.2', icon: 'pi pi-fw pi-bookmark',
    //                     items: [
    //                         { label: 'Submenu 2.2.1', icon: 'pi pi-fw pi-bookmark' },
    //                     ]
    //                 },
    //             ]
    //         }
    //     ]
    // },


    // { path: '/table-list', title: 'Table List',  icon:'content_paste', class: '' },
    // { path: '/typography', title: 'Typography',  icon:'library_books', class: '' },
    // { path: '/icons', title: 'Icons',  icon:'bubble_chart', class: '' },
    // { path: '/maps', title: 'Maps',  icon:'location_on', class: '' },
    // { path: '/notifications', title: 'Notifications',  icon:'notifications', class: '' },
    // { path: '/upgrade', title: 'Upgrade to PRO',  icon:'unarchive', class: 'active-pro' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];
  isDropdownOpen: boolean = false; // Add this line
  isReportDropdownOpen: boolean = false; // Add this line
  isKYCDropdownOpen: boolean = false; // Add this line
 

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);

  }

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  reportDropdown() {
    this.isReportDropdownOpen = !this.isReportDropdownOpen;
  }

  kycDropdown() {
    this.isKYCDropdownOpen = !this.isKYCDropdownOpen;
  }


  

  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
