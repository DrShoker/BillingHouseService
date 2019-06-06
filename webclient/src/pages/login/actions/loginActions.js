export const SIGNIN_REQUEST = '@login/SIGNIN_REQUEST';
export const SIGNUP_REQUEST = '@login/SIGNUP_REQUEST';
export const SUCCESS_REG = '@login/SUCCESS_REG';
export const RESET_SUCCESSOR = '@login/RESET_SUCCESSOR';

export const signinRequest = ({email, password}) => ({
    type: SIGNIN_REQUEST,
    payload: {
        email,
        password
    }
});

export const signupRequest = ({email, password, repeatedPassword}) => ({
    type: SIGNUP_REQUEST,
    payload: {
        email,
        password,
        repeatedPassword
    }
});

export const successRegister = () => ({
    type: SUCCESS_REG
});

export const resetSuccessor = () => ({
    type: RESET_SUCCESSOR
});
