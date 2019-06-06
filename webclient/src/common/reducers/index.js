import {combineReducers} from 'redux';
import authReducer from './authReducer';
import loginReducer from './../../pages/login/reducers/loginReducers'

export default combineReducers({
    authReducer,
    loginReducer
});