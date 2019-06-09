import { 
    SET_WORKS_LIST
} from './../actions/worksActions';

const initialState = {
    worksList: [],
};

export default function worksReducer (state = initialState, action) {
    switch (action.type) {
        case SET_WORKS_LIST:
            return {
            ...state,
            worksList: action.payload.worksList,
            };
        default:
            return state;
    }
}