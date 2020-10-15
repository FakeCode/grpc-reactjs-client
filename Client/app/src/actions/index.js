import { STUDENT_INFO } from './types'
import { StudentRequest, StudentReply } from '../protos/student_pb'
import { StudentClient } from '../protos/student_grpc_web_pb'
export const getStudentInfo = (id) => async dispatch => {

    const request = new StudentRequest();
    request.setId("555");
    var metadata = { 'token': 'value1' };//maintian in localstorage/state/cookies
    var URL = "https://localhost/grpc"; //will maintain all servicer/api url in state/localstorage
    var client = new StudentClient(URL);
    var call = client.getStudentInformation(request, metadata, function (err, response) {

        if (err) {
            console.log(err.code);
            console.log(err.message);
        } else {
            dispatch({ type: STUDENT_INFO, payload: response.getMessage() })
        }
    });
    call.on('status', function (status) {
        //console.log(status.code);
        //   console.log(status.details);
        //   console.log(status.metadata);
    });

};