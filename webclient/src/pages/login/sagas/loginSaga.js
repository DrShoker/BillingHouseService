import { put, takeEvery, call } from 'redux-saga/effects';
import http from './../../../services/http';
import history from './../../../utils/history';
import { setAuthData } from './../../../common/actions/authActions';
import { SIGNIN_REQUEST, SIGNUP_REQUEST, successRegister } from '../actions/loginActions';

export function* Authorize(action) {
    try {
        const responseData = yield call(http, {
            url: "auth/singIn",
            method: "post",
            data: action.payload
        });
        yield put(setAuthData(responseData.data));
        history.push('/profile');
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
}

export function* Register(action) {
    try {
        const responseData = yield call(http, {
            url: "auth/signUp",
            method: "post",
            data: action.payload
        });
        yield put(successRegister());
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
}


export default function* LoginRootSaga() {
    yield takeEvery(SIGNIN_REQUEST, Authorize);
    yield takeEvery(SIGNUP_REQUEST, Register);
}