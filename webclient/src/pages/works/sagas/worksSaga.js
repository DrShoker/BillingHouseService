import { put, takeEvery, call } from 'redux-saga/effects';
import http from './../../../services/http';
import {
    setWorksList,
    GET_WORKS_LIST_REQUEST
} from './../actions/worksActions';

export function* GetWorks(action) {
    try {
        const responseData = yield call(http, {
            url: 'construction_works',
            method: "GET",
        });
        yield console.log(responseData.data);
        yield put(setWorksList({projectsList: responseData.data}));
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
};

export default function* WorksRootSaga() {
    yield takeEvery(GET_WORKS_LIST_REQUEST, GetWorks);
}