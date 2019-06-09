import { all } from 'redux-saga/effects';
import loginRootSaga from './../../pages/login/sagas/loginSaga'
import profileRootSaga from './../../pages/profile/sagas/profileSaga';

const sagas = function* rootSaga() {
    yield all([
      loginRootSaga(),
      profileRootSaga()
    ]);
  };
  
  export default sagas;
  