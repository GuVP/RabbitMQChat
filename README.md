# RabbitMQChat
![RabbitMQ](https://img.shields.io/badge/rabbitmq-%23FF6600.svg?&style=for-the-badge&logo=rabbitmq&logoColor=white)
![.NET|7.0](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2CA5E0?style=for-the-badge&logo=docker&logoColor=white)

It's a repository based on a .NET console app to expose my knowledge of RabbitMQ and Docker.

## Idea
The original idea of this project was to build a simple application that can establish security communication between two parts.
To do that, the users will open ChatManager. At the first moment, they will receive a session userId (GUID). This userId is how other users would establish a connection to communicate with them.
So for two users to start a conversation, both of them will need to know the userId of each other. It's a way to guarantee that open communication has the consent of both sides.

## How it works
### Applications
The project has two .NET Console Applications: 
  - The first one, ChatManager, is responsible for the flow of the application.
  - The other one is the chat itself. It's where the rabbitMQ client is running, opening two queues, one to receive messages and another to send. My rabbitMQ server container (docker).

### Queues
   Consumer (receiver) and sender queues are built on senderId:receiverId. To make it clear, let's go to an example.
   In this example, I won't use a full GUID (32 chars) to use an 8 chars hex identifier. It makes comprehension clear and less confusing.

   - FirstUserId -> 482abe7f
   - SecondUserId -> 784a8d42

They start communication on the ChatManager app with the used ID of each other. After the ChatWindow app starts, two queues are opened:

- 784a8d42:482abe7f
- 482abe7f:784a8d42

Consumer(receive):
  - FirstUser will consume messages from queue -> 784a8d42:482abe7f
  - SecondUser will consume messages from queue -> 482abe7f:784a8d42

Sender:
  - FirstUser will send messages to queue -> 482abe7f:784a8d42
  - SecondUser will send messages to queue -> 784a8d42:482abe7f

![RabbitMQArchitecture](https://github.com/GuVP/RabbitMQChat/assets/69810289/6ba445a4-19f8-4b28-9f44-70063a9b1a00)

