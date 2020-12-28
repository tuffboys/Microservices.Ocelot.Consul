# ApiGateway-example
Example of API Gateway based on .NET Core, Ocelot, Consul

#Download Consul
https://www.consul.io/docs/install

after download the zip, extract the zip and move to extracted folder and run with this command in powershell:
.\consul.exe agent -dev -log-level=warn -ui

now open browser site http://localhost:8500 to view your services registered .

http://localhost:8500/v1/health/service/{service-name} 

to check instance properly registered.

