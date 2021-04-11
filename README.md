# Trading-App-Backend

Backend application for the Trading application. 

# Prerequisites to run the system
1. Visual Studio 2019 (with all the updates)
2. Docker desktop for Windows (latest)
 
# How to run services 
## Option-1: Docker-Compose
#### Click on the start.sh file
  -> start.sh
     -> build-script.sh
     -> docker-compose up 
![image](https://user-images.githubusercontent.com/2247913/114290168-859fd000-9a4b-11eb-888f-058f620d26af.png)

## Option-2: Visual Studio 2019
1. Open the solution for each service and run each of the project. 
2. Run Postman collection to validate use cases. 

# Specs

# Identified services
![image](https://user-images.githubusercontent.com/2247913/113530494-3150a800-9594-11eb-9c26-108f6bbdb70c.png)

# Postman collection to call the services on local
https://github.com/gaganpa2020/Trading-App-Backend/blob/main/Gagan_TradingApp_MicroservicesAssignment.postman_collection.json

# Entity relationship diagram
![image](https://user-images.githubusercontent.com/2247913/113530582-6230dd00-9594-11eb-988d-ddb136e67b6e.png)

# Component diagram 
![image](https://user-images.githubusercontent.com/2247913/113530661-87255000-9594-11eb-943a-af0a11819e69.png)

# Sequence diagram
![image](https://user-images.githubusercontent.com/2247913/113530685-9f956a80-9594-11eb-8a20-007adb5ac77b.png)

# Deployment diagram
![image](https://user-images.githubusercontent.com/2247913/113530757-cce21880-9594-11eb-93fc-8987f6ef575c.png)

# Branch deployment strategy with environments
![image](https://user-images.githubusercontent.com/2247913/113530791-ed11d780-9594-11eb-9603-c14d4b9d9763.png)

# Assignment use cases: 

### Assumptions 
1. Final deployment will be done on Azure cloud app service. 
2. Service will have a scale up strategy defined on the app service plan to maintain scalability. 
3. All infra is deployed under Virtual network and only API management gateway will expose the endpoints to outside world. 
4. For communication between the services, we will use private endpoints. This will take care of security. 
5. *All integration endpoints are mock in the given solution. 
6. All the DB work is mocked with static collections. In real world, each service will maintain own databases. 
7. Payment gateway (to validate customer's bank account details) would be a mock. 
8. Application is protected by JWT token. Current implementation hardcode username/password.
9. To send notification, we have a Notification service. However its code is not done. In all the services, its providers are being called. Those are empty inside. 
10. Stock Exchange will always give us live data for all the tickers. We will have a wrapper service to maintain relevant data in our system. 
11. Last but not least, each usecase have corresponding  collection defined in postman for execution (remember all services/containers should be up). 

## Use Case-1 : A customer can deposit, withdraw cash from his trading account to bank account.
1. Consumer can link his account. 
2. Consumer can credit/debit his account. 
3. Payment gatways will be used in real world application to verify user's financial data.
4. On each trancation, Transaction history service will recieve an event. These events are maintained to keep track of user's transaction. 
5. Trading cache will be populated as the result of each action, this is speedup automated transactions. 
6. Notification service will be called to notify consume on the transaction status. 

### Use Case-1 (Diagram)
![image](https://user-images.githubusercontent.com/2247913/113531336-7e357e00-9596-11eb-9d00-63670cfe7fa3.png)

## Use Case-2 : A customer can trade stocks (buy/sell) for the listed companies in the stock exchange.
1. Consumers (UI or other app) will Trade service to place Buy/Sell order.
2. Trade service will verify ticker's data (price etc) using Exchange service (our wrapper on Stock exchange).
3. Account service is being used to validate user's financial required for transaction. We will use 'read through/write behind strategy' to speedup transactions. 
4. Transaction history service will recieve an event to save it for future use. 
5. Trade service will drop a message in queue for notification service to send notifications to the user for transaction status. 

### Use Case-2 (Diagram)
![image](https://user-images.githubusercontent.com/2247913/113531946-2ac42f80-9598-11eb-8178-0a84c8cb2b65.png)

## Use Case-3 : A customer can view the live/historical stock exchange rates.
1. An azure function will listen to the stock exchange & write all the relevant data in the DB. 
2. Exchange service will be used to expose the data in desirable format to the user to see live/historical/ Graph etc. 

### Use Case-3 (Diagram)
![image](https://user-images.githubusercontent.com/2247913/113532093-8989a900-9598-11eb-8c37-e9cf18d12c6d.png)

## Use Case-4 : A customer can view his transactional history.
1. Transaction history service will get events on each transactions. 
2. Service will store the events using event sourcing pattern. 
3. Service will take periodic snapshot to create Materialized view for the user. 
4. Data in the transaction history will eventually consistant. 

### Use Case-4 (Diagram)
![image](https://user-images.githubusercontent.com/2247913/113532563-a2df2500-9599-11eb-8995-b84f4704deec.png)

## Use Case-5 : A customer can set triggers to automatically buy/sell certain stock holdings when they reach a set threshold price.
1. Consume can define trigger on the account service. 
2. Price monitoring job would be like Azure stream analytics or some similar solution to process high amount of data.
3. Each time a user will define any trigger, it will be registered as a *Rule* on the price monitoring job. 
4. Price monitoring job will process the real time data and eventually push message in queue if any conditions is met on the rule. 
5. Price monitoring job is similated through Postman call using Azure service bus. 
6. Trade service will define subscription on the queue.
7. As soon as any message is landed on the queue, it will be picked by either of the instances of Trade service and processed. 
8. Trade service will run on the premium tier in the Trading hours will maximum no of instances. 
9. Trading cache will be used/populated by the trade service using Read through/write behind mechanisum. 
10. Trade service will also initiate event for account service to update trigger status. 

### Use Case-5 (Diagram)
![image](https://user-images.githubusercontent.com/2247913/113532718-0cf7ca00-959a-11eb-9aed-bfb1c7c8bda8.png)

## Use Case-6: Notifications should be triggered for all account related activities like deposit, withdrawals, purchases, sales and triggers.
1. All above use cases have a notification provider call defined. 
2. In real world application provider will be calling the notification service to register an event to be processed. 
3. Later on, notification service will process the notification request recieved. 

### Note: all the above used cases are defined in Postman collection, services must be up in order use it. As an alternative, you can also use swagger to call services. It is enabled on all the services. 

# Cross cutting concerns 
## Logging
1. Each service will have its dedicated application insight defined. 
2. Application insight will hold all the system/custom logs, which can be further used to see the request trends. 

## Exception handling
1. Providers have defined following patterns for exception handling & resiliency: - 
    a. Retry mechanism 
    b. Circuit breaker (checkout Shared code folder for providers) 
2. Custom exception handling is also done on the module basis.  

## High Availability
1. All the instances would be Load balanced for App services and will use the Azure feature 'high-avalbility' while defining resources.
2. Always-on : This feature will be enabled for the azure services to ensure it is not going down incase of any exceptions. 
3. For deployment, we will consider Blue-Green deployment strategy to ensure absolute zero downtime. 

## Scalability 
1. Scalabilty rules will be defined at the App Service Plan level. 
2. Caching/data store would be distributed, so that system can easily support scalling. 

## Security 
1. All the service will be deployed in virtual network.
2. Services will call each other using private endpoint. 
3. API Gateway will be used to expose endpoints to the outside world. 
4. JWT token will secure the API endpoints. 
