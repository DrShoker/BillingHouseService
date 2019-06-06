export const SIGNIN_REQUEST = '@login/SIGNIN_REQUEST';

export const signinRequest = ({email, password}) => ({
    type: SIGNIN_REQUEST,
    payload: {
        email,
        password
    }
});