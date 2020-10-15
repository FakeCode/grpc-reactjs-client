import {STUDENT_INFO, UserAction, UserState} from '../actions/types'

const initialState: UserState = { userId: null };


export default (state = initialState, action: UserAction)=> {
    switch(action.type){
        case STUDENT_INFO:
            return {...state, userId: action.payload};
        default:
            return state;
        }
}