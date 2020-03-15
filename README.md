# Project is NOT ready to run!
Project is still not working.
# OPC-UA-Collector
Server and Client for Managing and Collecting Data from OPC UA Servers.
Server Component written in C# for running on a powerful windows machine. The Connector Client connects a OPC UA Server with the OPC UA Collector Server. Later the Connecor Client should be implemented in C# and Python for runnning on Linux.
# Quickstart OPC UA Collector
- Clone the repository
- start your OPC UA Server which should be connected to the OPC UA Collector, or start the example Server.
- open OPC "UA Collector.sln" in visual studio and start the OPC UA Collector, or start the executable located in \OPC UA Collector\bin\Debug\OPC_UA_Collector.exe
# Components
- Collector Server (OPC UA server)
- Connector Client (OPC UA client)
- Test Server (OPC UA server)
## Collector Server

## Connector Client

## Test Server
Provides a simple OPC UA 
# Conzept
Collecting Data from different OPC UA Servers and representing them in it's own server model. It can be used for centralized purposes like Cloud communication through one gateway or managing machines (and their data) from one location (monitoring or control station). 
If the Machine or OPC UA Server is not easily reachable from the network, the Connector Client can connect machines OPC UA Server and the . For example, a machine provides ethnet port, but machine should connect over wifi, you can use the Connector Client in Python running on a Raspberrypi connected to the ethnet port of the machine and over wifi to the network. 
It is also possible to organize multiple OPC UA Collector Servers in the structure of one OPC UA Collector (Factory-> multiple sections).
