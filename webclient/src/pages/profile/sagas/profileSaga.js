import { put, takeEvery, call } from 'redux-saga/effects';
import http from './../../../services/http';
import { 
    setProjectsList,
    getProjectsListRequest,
    setSchemasListRequest,
    setSchemaDetails,
    getSchemasListRequest,
    GET_PROJECTS_LIST_REQUEST,
    UPDATE_PROJECT_REQUEST,
    CREATE_PROJECT_REQUEST,
    DELETE_PROJECT_REQUEST,
    GET_SCHEMAS_LIST_REQUEST,
    GET_SCHEMA_DETAILS_REQUEST,
    UPDATE_SCHEMA_REQUEST,
    CREATE_SCHEMA_REQUEST,
    DELETE_SCHEMA_REQUEST
} from './../actions/profileActions';


export function* GetUserProjects(action) {
    try {
        const responseData = yield call(http, {
            url: `users/${action.payload.userId}/projects`,
            method: "GET",
        });
        yield console.log(responseData.data);
        yield put(setProjectsList({projectsList: responseData.data}));
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
}

export function* UpdateUserProject(action) {
    try {
        const responseData = yield call(http, {
            url: `users/${action.payload.userId}/projects`,
            method: "PUT",
            data: {
                id: action.payload.projectId,
                name: action.payload.projectName
            }
        });
        yield put(getProjectsListRequest({ userId: action.payload.userId }));
        yield console.log(responseData.data);
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
}

export function* CreateUserProject(action) {
    try {
        const responseData = yield call(http, {
            url: `users/${action.payload.userId}/projects`,
            method: "POST",
            data: {
                name: action.payload.projectName
            }
        });
        yield put(getProjectsListRequest({ userId: action.payload.userId }));
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
}

export function* DeleteUserProject(action) {
    try {
        const responseData = yield call(http, {
            url: `users/${action.payload.userId}/projects/${action.payload.projectId}`,
            method: "DELETE",
            data: {
                name: action.payload.projectName
            }
        });
        yield put(getProjectsListRequest({ userId: action.payload.userId }));
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
}

export function* GetProjectSchemas(action) {
    try {
        const responseData = yield call(http, {
            url: `users/${action.payload.userId}/projects/${action.payload.projectId}/schemas`,
            method: "GET",
        });
        yield console.log(responseData.data);
        yield put(setSchemasListRequest({schemasList: responseData.data}));
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
}

export function* GetSchemaDetails(action) {
    try {
        const responseData = yield call(http, {
            url: `users/${action.payload.userId}/projects/${action.payload.projectId}/schemas/${action.payload.schemaId}`,
            method: "GET",
        });
        yield console.log(responseData.data);
        yield put(setSchemaDetails(responseData.data));
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
}

export function* UpdateProjectSchema(action) {
    try {
        const responseData = yield call(http, {
            url: `users/${action.payload.userId}/projects/${action.payload.projectId}/schemas`,
            method: "PUT",
            data: {
                id: action.payload.schemaId,
                name: action.payload.schema.name,
                wallsArea: action.payload.schema.wallsArea,
                floorArea: action.payload.schema.floorArea,
                ceilingArea: action.payload.schema.ceilingArea,
                ceilingPerimeter: action.payload.schema.ceilingPerimeter,
                floorPerimeter: action.payload.schema.floorPerimeter,
            }
        });
        yield put(getSchemasListRequest({ userId: action.payload.userId, projectId: action.payload.projectId}));
        yield console.log(responseData.data);
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
}

export function* CreateProjectSchema(action) {
    try {
        const responseData = yield call(http, {
            url: `users/${action.payload.userId}/projects/${action.payload.projectId}/schemas`,
            method: "POST",
            data: {
                name: action.payload.schema.name,
                wallsArea: action.payload.schema.wallsArea,
                floorArea: action.payload.schema.floorArea,
                ceilingArea: action.payload.schema.ceilingArea,
                ceilingPerimeter: action.payload.schema.ceilingPerimeter,
                floorPerimeter: action.payload.schema.floorPerimeter,
            }
        });
        yield put(getSchemasListRequest({ userId: action.payload.userId, projectId: action.payload.projectId}));
        yield console.log(responseData.data);
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
}

export function* DeleteProjectSchema(action) {
    try {
        const responseData = yield call(http, {
            url: `users/${action.payload.userId}/projects/${action.payload.projectId}/schemas/${action.payload.schemaId}`,
            method: "DELETE",
        });
        yield put(getSchemasListRequest({ userId: action.payload.userId, projectId: action.payload.projectId}));
    } catch (error) {
        console.log("QQQQQQQQQQQQ")
    }
}

export default function* ProfileRootSaga() {
    yield takeEvery(GET_PROJECTS_LIST_REQUEST, GetUserProjects);
    yield takeEvery(UPDATE_PROJECT_REQUEST, UpdateUserProject);
    yield takeEvery(CREATE_PROJECT_REQUEST, CreateUserProject);
    yield takeEvery(DELETE_PROJECT_REQUEST, DeleteUserProject);
    yield takeEvery(GET_SCHEMAS_LIST_REQUEST, GetProjectSchemas);
    yield takeEvery(GET_SCHEMA_DETAILS_REQUEST, GetSchemaDetails);
    yield takeEvery(UPDATE_SCHEMA_REQUEST, UpdateProjectSchema);
    yield takeEvery(CREATE_SCHEMA_REQUEST, CreateProjectSchema);
    yield takeEvery(DELETE_SCHEMA_REQUEST, DeleteProjectSchema);
}