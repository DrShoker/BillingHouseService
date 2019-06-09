import {combineReducers} from 'redux';
import authReducer from './authReducer';
import loginReducer from './../../pages/login/reducers/loginReducers'
import profileReducer from './../../pages/profile/reducers/profileReducer';
import worksReducer from './../../pages/works/reducers/worksReducer';

export default combineReducers({
    authReducer,
    loginReducer,
    profileReducer,
    worksReducer
});