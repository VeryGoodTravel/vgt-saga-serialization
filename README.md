# vgt-saga-serialization

Library used by the saga microservices to specify communication object mapping.

## Contents:
- Custom Json converter
- Message containing basic SAGA informations
  - transactionId
  - messageId of the transaction
  - current status of the saga
  - microservice concerned
  - content of the message adjusted to microservice concerned
- MessageBody implementing IMessageBody and specifying different types of messages with their content

## Implementation documentation
XML docs of the project available in the repository in the
file [SagaMessagesDocumentation.xml](SagaMessagesDocumentation.xml)