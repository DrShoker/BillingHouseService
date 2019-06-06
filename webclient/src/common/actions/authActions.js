export const SET_AUTHDATA = '@auth/SET_AUTHDATA';
export const LOGOUT = '@auth/LOGOUT';

export const setAuthData = ({email, displayName, id, authToken}) => ({
    type: SET_AUTHDATA,
    payload: {
      email,
      displayName,
      id,
      authToken
    }
});

export const logout = () => ({
    type: LOGOUT,
    payload: {
        email: null,
        displayName: null,
        id: null,
        authToken: null,
    }
});