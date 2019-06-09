export const GET_WORKS_LIST_REQUEST = '@works/GET_WORKS_LIST_REQUEST';
export const SET_WORKS_LIST = '@works/SET_WORKS_LIST';

export const getProjectsListRequest = () => ({
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