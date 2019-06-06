import { put, takeEvery, call } from 'redux-saga/effects';
import http from './../../../services/http';
import history from './../../../utils/history';
import { setAuthData } from './../../../common/actions/authActions';
import { SIGNIN_REQUEST } from '../actions/loginActions';

export function* Authorize(action) {
    try {
        const responseData = yield call(http, {
            url: "auth/singIn",
            method: "post",
            data: action.payload
        });
        yield put(setAuthData(responseData.data));
        history.push('/main');
    } catch (error) {

    }
}

export default function* LoginRootSaga() {
    yield takeEvery(SIGNIN_REQUEST, Authorize);
}