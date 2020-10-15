import React, { Component } from 'react'
import { connect } from 'react-redux'
import { getStudentInfo } from '../../actions'

class Student extends Component {
    // constructor(props){
    // }

    componentDidMount() {
        this.props.getStudentInfo("umesh");
    }

    render() {
        if (this.props.student === null) {
            return (<div>loading.....</div>);
        }
        return (<h3>gRPC value: {this.props.student.userId}</h3>)
    }
}


const mapStateToProps = (state) => {
    //console.log(state);
    return {
        student: state.student
    };
};

export default connect(mapStateToProps, { getStudentInfo })(Student);

