# RabbitMQChat
It's a repository based on a .NET console app to expose my knowledge of RabbitMQ and Docker.

## Idea
The original idea of this project was to build a simple application that can establish security communication between two parts.
To do that, the users will open the ChatManager. At the first moment, they will receive a session userId (GUID). This userId is how other users would establish a connection to communicate with them.
So for two users to start a conversation, both of them will need to know the userId of each other. It's a way to guarantee that open communication has the consent of both sides.

## How it works
### Applications
The project has two .NET Console Applications: 
  - The first one, ChatManager, is responsible for the flow of the application.
  - The other one is the chat itself. It's where the rabbitMQ client is running, opening two queues, one to receive messages and another to send. My rabbitMQ server container (docker).

### Queues
   The receiver and sender queues are built on senderId:receiverId. To make it clear, let's go to an example.

   - FirstUserId -> 482abe7f5
   - SecondUserId -> 784a8d42a

They start communication on ChatManager app with the used Id of each other. After the ChatWindow app starts, two queues are opened:

- 784a8d42a:482abe7f5
- 482abe7f5:784a8d42a

The receiving:
  - FirstUser will consume messages from queue -> 784a8d42a:482abe7f5
  - SecondUser will consume messages from queue -> 482abe7f5:784a8d42a

The sending:
  - FirstUser will send messages to queue -> 482abe7f5:784a8d42a
  - SecondUser will send messages to queue -> 784a8d42a:482abe7f5
