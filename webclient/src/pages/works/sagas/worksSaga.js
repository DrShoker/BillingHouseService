import { put, takeEvery, call } from 'redux-saga/effects';
import http from './../../../services/http';
import {
    setWorksList,
    setCompanyWorksList,
    setWorkDetails,
    GET_WORK_DETAILS_REQUEST,
    GET_WORKS_LIST_REQUEST,
    GET_COMPANY_WORKS_LIST_REQUEST,
    SET_COMP_WORK_TO_SCHEMA_REQUEST
} from './../actions/worksActions';

export function* GetWorks(action) {
    try {
        const responseData = yield call(http, {
            url: 'construction_works',
            method: "GET",
        });
        yield console.log(responseData.data);
        yield put(setWorksList({worksList: responseData.data}));
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
};

export function* GetCompaniesWorks(action) {
    try {
        const responseData = yield call(http, {
            url: `construction_works/${action.payload.workId}/comp-const-works`,
            method: "GET",
        });
        yield console.log(responseData.data);
        yield put(setCompanyWorksList({compWorksList: responseData.data}));
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
};

export function* GetWorkDetails(action) {
    try {
        const responseData = yield call(http, {
            url: `construction_works/${action.payload.workId}`,
            method: "GET",
        });
        yield console.log(responseData.data);
        yield put(setWorkDetails(responseData.data));
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
};

export function* SetCompWorkToSchema(action) {
    try {
        const responseData = yield call(http, {
            url: `users/someid/projects/someId/schemas/${action.payload.schemaId}/const-work/${action.payload.workId}`,
            method: "POST",
        });
        yield console.log(responseData.data);
        //yield put(setWorkDetails(responseData.data));
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
};

export default function* WorksRootSaga() {
    yield takeEvery(GET_WORKS_LIST_REQUEST, GetWorks);
    yield takeEvery(GET_COMPANY_WORKS_LIST_REQUEST, GetCompaniesWorks);
    yield takeEvery(GET_WORK_DETAILS_REQUEST, GetWorkDetails);
    yield takeEvery(SET_COMP_WORK_TO_SCHEMA_REQUEST, SetCompWorkToSchema);
};