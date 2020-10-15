import {combineReducers} from 'redux'
import student from './student'

const rootReducer = combineReducers({
    student
});

export default rootReducer;

export type RootState = ReturnType<typeof rootReducer>;