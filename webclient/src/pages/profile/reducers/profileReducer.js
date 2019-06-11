import { 
    SET_PROJECTS_LIST, 
    SET_SCHEMAS_LIST,
    SET_SCHEMA_DETAILS,
    SET_SUMMARY_LIST
} from './../actions/profileActions';

const initialState = {
    projectsList: [],
    schemasList: [],
    schemaDetails: {},
    summaryList: [],
    totalSum: 0,
};

export default function profileReducer (state = initialState, action) {
    switch (action.type) {
        case SET_PROJECTS_LIST:
            return {
            ...state,
            projectsList: action.payload.projectsList,
            };
        case SET_SCHEMAS_LIST:
            return {
                ...state,
                schemasList: action.payload.schemasList,
            };
        case SET_SCHEMA_DETAILS:
            return {
                ...state,
                schemaDetails: action.payload.schemaDetails
            };
            case SET_SUMMARY_LIST:
            return {
                ...state,
                summaryList: action.payload.summaryList,
                totalSum: action.payload.totalSum
            }
        default:
            return state;
    }
}