import { SUCCESS_REG, RESET_SUCCESSOR } from '../actions/loginActions';

const initialState = {
    isRegistrationSuccess: false
};

export default function loginReducer (state = initialState, action) {
    switch (action.type) {
      case SUCCESS_REG:
        return {
          ...state,
          isRegistrationSuccess: true
        };
        case RESET_SUCCESSOR:
            return {
                ...state,
                isRegistrationSuccess: false
            }
      default:
        return state;
    }
}