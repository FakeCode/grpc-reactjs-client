/**
 * @fileoverview gRPC-Web generated client stub for student
 * @enhanceable
 * @public
 */

// GENERATED CODE -- DO NOT EDIT!


/* eslint-disable */
// @ts-nocheck



const grpc = {};
grpc.web = require('grpc-web');

const proto = {};
proto.student = require('./student_pb.js');

/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?Object} options
 * @constructor
 * @struct
 * @final
 */
proto.student.StudentClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options['format'] = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?Object} options
 * @constructor
 * @struct
 * @final
 */
proto.student.StudentPromiseClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options['format'] = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.student.StudentRequest,
 *   !proto.student.StudentReply>}
 */
const methodDescriptor_Student_GetStudentInformation = new grpc.web.MethodDescriptor(
  '/student.Student/GetStudentInformation',
  grpc.web.MethodType.UNARY,
  proto.student.StudentRequest,
  proto.student.StudentReply,
  /**
   * @param {!proto.student.StudentRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.student.StudentReply.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.student.StudentRequest,
 *   !proto.student.StudentReply>}
 */
const methodInfo_Student_GetStudentInformation = new grpc.web.AbstractClientBase.MethodInfo(
  proto.student.StudentReply,
  /**
   * @param {!proto.student.StudentRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.student.StudentReply.deserializeBinary
);


/**
 * @param {!proto.student.StudentRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.Error, ?proto.student.StudentReply)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.student.StudentReply>|undefined}
 *     The XHR Node Readable Stream
 */
proto.student.StudentClient.prototype.getStudentInformation =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/student.Student/GetStudentInformation',
      request,
      metadata || {},
      methodDescriptor_Student_GetStudentInformation,
      callback);
};


/**
 * @param {!proto.student.StudentRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.student.StudentReply>}
 *     A native promise that resolves to the response
 */
proto.student.StudentPromiseClient.prototype.getStudentInformation =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/student.Student/GetStudentInformation',
      request,
      metadata || {},
      methodDescriptor_Student_GetStudentInformation);
};


module.exports = proto.student;

