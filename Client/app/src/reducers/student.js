import { STUDENT_INFO } from '../actions/types'

const initialState = { userId: null };

export default (state = initialState, action)=> {
    switch (action.type) {
        case STUDENT_INFO:
            return { ...state, userId: action.payload };
        default:
            return state;
    }
};