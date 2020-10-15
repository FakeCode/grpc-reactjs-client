import React, {Component} from 'react'

import {compose} from 'redux'
import {connect} from 'react-redux'
import {getStudentInfo}  from '../../actions'

class Student extends Component{

    constructor(props){
        super(props);
        props.getStudentInfo("umesh");

    }


    render() {
        console.log(this.props);
        // if (this.props.student.userId == null)
        // {
        // return (<h3>service loading</h3>)
        // }

        return (
        <h3>Service Return Data:</h3>
        )
    }
}

const mapStateToProps = (state) =>{
    console.log(state);
    return{
        student:state.student
    };
};

export default connect(mapStateToProps, {getStudentInfo})(Student)