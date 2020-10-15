import {STUDENT_INFO} from './types'


export const getStudentInfo = (id) => dispatch => {
dispatch({type: STUDENT_INFO, payload:id});
}