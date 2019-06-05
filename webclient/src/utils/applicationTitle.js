export const applicationTitle = (() => {
    const titles = {
      'bh': 'Billing House ',
      'loginPage': 'Theodolite  - LogIn',
      'projects': 'Theodolite  - Projects',
      'offices': 'Theodolite  - Offices',
      'clients': 'Theodolite  - Clients',
      'employees': 'Theodolite  - Employees',
      'contracts': 'Theodolite  - Contracts',
      'manageUsers': 'Theodolite  - Manage users',
      'settings': 'Theodolite  - Settings',
      'createProject': 'Theodolite  - Create Project',
      'createEmployee': 'Theodolite  - Create Employee',
      'createClient': 'Theodolite  - Create Client',
      'addRole': 'Theodolite  - Add Role',
      'editRole': 'Theodolite  - Edit Role',
      'viewRole': 'Theodolite  - View Role',
      'addSow': 'Theodolite  - Add SOW to Project',
      'editSow': 'Theodolite  - Edit SOW in Project',
      'viewSow': 'Theodolite  - View SOW in Project',
      'addPO': 'Theodolite  - Add PO to Project',
      'editPO': 'Theodolite  - Edit PO in Project',
      'viewPO': 'Theodolite  - View PO in Project',
      'editProjectEmployees': 'Theodolite  - Edit Employees in the role',
    };
  
    return { getTitile: titleName => titles[titleName] };
  })();
  