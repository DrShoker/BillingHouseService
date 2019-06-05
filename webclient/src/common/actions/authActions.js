export const SET_AUTHDATA = '@auth/SET_AUTHDATA';
export const LOGOUT = '@auth/LOGOUT';

export const setAuthData = ({user, authToken}) => ({
    type: SET_AUTHDATA,
    payload: {
      user,
      authToken,
    }
});

export const logout = () => ({
    type: LOGOUT,
    payload: {
        user: null,
        refreshToken: null,
        authToken: null,
    }
});