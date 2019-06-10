export const GET_WORKS_LIST_REQUEST = '@works/GET_WORKS_LIST_REQUEST';
export const SET_WORKS_LIST = '@works/SET_WORKS_LIST';
export const GET_COMPANY_WORKS_LIST_REQUEST = '@works/GET_COMPANY_WORKS_LIST_REQUEST';
export const SET_COMPANY_WORKS_LIST = '@works/SET_COMPANY_WORKS_LIST';
export const GET_WORK_DETAILS_REQUEST = '@works/GET_WORK_DETAILS_REQUEST';
export const SET_WORK_DETAILS = '@works/SET_WORK_DETAILS';
export const SET_COMP_WORK_TO_SCHEMA_REQUEST = '@works/SET_COMP_WORK_TO_SCHEMA_REQUEST';

export const getWorksListRequest = () => ({
    type: GET_WORKS_LIST_REQUEST,
    payload: {
    }
});

export const setWorksList = ({ worksList }) => ({
    type: SET_WORKS_LIST,
    payload: {
        worksList
    }
});

export const getCompanyWorksListRequest = ({workId}) => ({
    type: GET_COMPANY_WORKS_LIST_REQUEST,
    payload: {
        workId
    }
});

export const setCompanyWorksList = ({ compWorksList }) => ({
    type: SET_COMPANY_WORKS_LIST,
    payload: {
        compWorksList
    }
});

export const getWorkDetailsRequest = ({ workId }) => ({
    type: GET_WORK_DETAILS_REQUEST,
    payload: {
        workId
    }
});

export const setWorkDetails = (workDetails) => ({
    type: SET_WORK_DETAILS,
    payload: {
        workDetails
    }
});

export const setCompWorkToSchemaRequest = ({ workId, schemaId }) => ({
    type: SET_COMP_WORK_TO_SCHEMA_REQUEST,
    payload: {
        workId,
        schemaId
    }
});