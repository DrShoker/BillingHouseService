import { SET_AUTHDATA, LOGOUT } from './../actions/authActions';

const initialState = {
    id: null,
    email: null,
    displayName: null,
    authToken: null,
};
  
export default function authReducer (state = initialState, action) {
    switch (action.type) {
      case SET_AUTHDATA:
      case LOGOUT:
        return {
          ...state,
          id: action.payload.id,
          email: action.payload.email,
          displayName: action.payload.displayName,
          authToken: action.payload.authToken,
        };
      default:
        return state;
    }
}
  
