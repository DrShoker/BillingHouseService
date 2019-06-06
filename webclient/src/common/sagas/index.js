import { all } from 'redux-saga/effects';
import loginRootSaga from './../../pages/login/sagas/loginSaga'

const sagas = function* rootSaga() {
    yield all([
      loginRootSaga()
    ]);
  };
  
  export default sagas;
  