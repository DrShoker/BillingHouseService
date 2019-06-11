export const GET_PROJECTS_LIST_REQUEST = '@projects/GET_PROJECTS_LIST_REQUEST';
export const SET_PROJECTS_LIST = '@projects/SET_PROJECTS_LIST';
export const UPDATE_PROJECT_REQUEST = '@projects/UPDATE_PROJECT_REQUEST';
export const CREATE_PROJECT_REQUEST = '@projects/CREATE_PROJECT_REQUEST';
export const DELETE_PROJECT_REQUEST = '@projects/DELETE_PROJECT_REQUEST';
export const SET_UPDATED_PROJECT = '@projects/SET_UPDATED_PROJECT';
export const SET_CREATED_PROJECT = '@projects/SET_CREATED_PROJECT';
export const SET_DELETED_PROJECT = '@projects/SET_DELETED_PROJECT';
export const GET_SCHEMAS_LIST_REQUEST = '@schemas/GET_SCHEMAS_LIST_REQUEST';
export const SET_SCHEMAS_LIST = '@schemas/SET_SCHEMAS_LIST';
export const GET_SCHEMA_DETAILS_REQUEST = '@schemas/GET_SCHEMA_DETAILS_REQUEST';
export const SET_SCHEMA_DETAILS = '@schemas/SET_SCHEMA_DETAILS';
export const UPDATE_SCHEMA_REQUEST = '@projects/UPDATE_SCHEMA_REQUEST';
export const CREATE_SCHEMA_REQUEST = '@projects/CREATE_SCHEMA_REQUEST';
export const DELETE_SCHEMA_REQUEST = '@projects/DELETE_SCHEMA_REQUEST';
export const GET_SUMMARY_LIST_REQUEST = '@schemas/GET_SUMMARY_LIST_REQUEST';
export const SET_SUMMARY_LIST = '@schemas/SET_SUMMARY_LIST';

export const getProjectsListRequest = ({ userId }) => ({
    type: GET_PROJECTS_LIST_REQUEST,
    payload: {
        userId
    }
});

export const setProjectsList = ({ projectsList }) => ({
    type: SET_PROJECTS_LIST,
    payload: {
        projectsList
    }
});

export const updateProjectRequest = ({ userId, projectId, projectName  }) => ({
    type: UPDATE_PROJECT_REQUEST,
    payload: {
        userId,
        projectId,
        projectName
    }
});

export const createProjectRequest = ({ userId, projectName  }) => ({
    type: CREATE_PROJECT_REQUEST,
    payload: {
        userId,
        projectName
    }
});

export const deleteProjectRequest = ({ userId, projectId  }) => ({
    type: DELETE_PROJECT_REQUEST,
    payload: {
        userId,
        projectId
    }
});

export const getSchemasListRequest = ({ userId, projectId }) => ({
    type: GET_SCHEMAS_LIST_REQUEST,
    payload: {
        userId, 
        projectId
    }
});

export const setSchemasListRequest = ({ schemasList }) => ({
    type: SET_SCHEMAS_LIST,
    payload: {
        schemasList, 
    }
});

export const getSchemaDetailsRequest = ({ userId, projectId, schemaId }) => ({
    type: GET_SCHEMA_DETAILS_REQUEST,
    payload: {
        userId, 
        projectId, 
        schemaId
    }
});

export const setSchemaDetails = (schemaDetails) => ({
    type: SET_SCHEMA_DETAILS,
    payload: {
        schemaDetails, 
    }
});

export const updateSchemaRequest = ({ userId, projectId, schemaId, schema }) => ({
    type: UPDATE_SCHEMA_REQUEST,
    payload: {
        userId,
        projectId,
        schemaId,
        schema
    }
});

export const createSchemaRequest = ({ userId, projectId, schema }) => ({
    type: CREATE_SCHEMA_REQUEST,
    payload: {
        userId,
        projectId,
        schema
    }
});

export const deleteSchemaRequest = ({ userId, projectId, schemaId }) => ({
    type: DELETE_SCHEMA_REQUEST,
    payload: {
        userId,
        projectId,
        schemaId
    }
});

export const getSummaryListRequest = ({ userId, projectId, schemaId }) => ({
    type: GET_SUMMARY_LIST_REQUEST,
    payload: {
        userId,
        projectId,
        schemaId
    }
});

export const setSummaryList = ({ summaryList, totalSum }) => ({
    type: SET_SUMMARY_LIST,
    payload: {
        summaryList,
        totalSum
    }
});