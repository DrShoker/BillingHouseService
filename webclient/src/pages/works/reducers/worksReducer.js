import { 
    SET_WORKS_LIST,
    SET_COMPANY_WORKS_LIST,
    SET_WORK_DETAILS
} from './../actions/worksActions';

const initialState = {
    worksList: [],
    compWorksList: [],
    workDetails: {}
};

export default function worksReducer (state = initialState, action) {
    switch (action.type) {
        case SET_WORKS_LIST:
            return {
            ...state,
            worksList: action.payload.worksList,
            };
        case SET_COMPANY_WORKS_LIST:
            return {
            ...state,
            compWorksList: action.payload.compWorksList,
            };
        case SET_WORK_DETAILS:
            return {
            ...state,
            workDetails: action.payload.workDetails,
            };
        default:
            return state;
    }
}