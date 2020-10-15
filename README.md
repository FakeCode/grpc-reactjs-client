# grpc-reactjs-client
# gRPC Asp.net Core + Reactjs
implementation of grpc in asp.net core, reactjs client including both typescript and js app
Lot of talks on gRPC and Its awesome. I have created small boilertype project which demonstrate how to create grpc service for asp.net core, created protos for javascript and typescript, tested using grpcui utility tool. Consumed gRPC service on both server side and client side applications.

Asp.net 3.1 has experimental proxy for web i.e Grpc.AspNetCore.Web, thats mean you don't need extra proxy server like envoy.
and Grpc.AspNetCore.Server.Reflection to discover grpc service
# IIS doesn't support HTTP/2, so you need to enable Kestrel light weight server:
 "Kestrel": {
    "EndpointDefaults": {
      "Protocols": [ "Http2", "Http1.1" ]
    }
  }
# startup.cs
////below line will enable all service as web grpc
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
Or
endpoints.MapGrpcService<Service>().RequireCors(AuthenticatorConstants.CorsPolicyName).EnableGrpcWeb();//as of now we are allowing all but need to restrict origin
               

#references:
1) https://github.com/grpc-ecosystem/awesome-grpc
2) https://docs.microsoft.com/en-us/dotnet/architecture/cloud-native/grpc
3) https://github.com/fullstorydev/grpcui/cmd/grpcui
4) https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-3.1

#generate protos for client app: (I have used both js and typescript proto in app and clientApp)
1) download protoc (protoc-3.13.0-win64) and generate either java script or typescript
2) $ protoc -I=./proto ./proto/student.proto --js_out=import_style=commonjs:./proto --grpc-web_out=import_style=commonjs,mode=grpcwebtext:./proto
## for typescript generate:
3) $ protoc -I=./proto ./proto/student.proto --js_out=import_style=commonjs:./proto --grpc-web_out=import_style=typescript,mode=grpcwebtext:./proto
