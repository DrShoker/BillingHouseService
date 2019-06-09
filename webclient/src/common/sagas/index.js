import { all } from 'redux-saga/effects';
import loginRootSaga from './../../pages/login/sagas/loginSaga'
import profileRootSaga from './../../pages/profile/sagas/profileSaga';
import worksRootSaga from './../../pages/works/sagas/worksSaga';

const sagas = function* rootSaga() {
    yield all([
      loginRootSaga(),
      profileRootSaga(),
      worksRootSaga()
    ]);
  };
  
  export default sagas;
  