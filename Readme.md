# Notification App: 3 Tier Architecture

## Project Structure
```
NotificationApp/
|
├── NotificationApp.ModelLibrary/
│   ├── User.cs
│   └── Notification.cs
|
├── NotificationApp.DALLibrary/
│   ├── IRepository.cs
│   ├── AbstractRepository.cs
│   ├── UserRepository.cs
│   └── NotificationRepository.cs
|
├── NotificationApp.BLLibrary/
│   ├── INotificationSender.cs
│   ├── EmailNotificationService.cs
│   ├── SmsNotificationService.cs
│   ├── NotificationService.cs
│   ├── UserService.cs
│   └── NotificationValidator.cs
|
└── NotificationApp.ConsoleApp/
    └── Program.cs
```

## Objectives

### Presentation Layer
- console application allowing users to:
    1. Add user details ✅
    2. Choose notification type ✅
       * Email ✅
       * SMS ✅
    3. Enter notification message ✅
    4. Send notification ✅
    5. Display sent notification details ✅


### Business Layer
- Validate user details ✅
- Validate message ✅
- Apply notification rules ✅
- Call the correct notification sender ✅
- Save notification details ✅
- Rules for validation
    1. Message should not be empty. ✅
    2. Message length should be at least 5 characters. ✅
    3. Email notification should be sent only if the user has a valid email. ✅
    4. SMS notification should be sent only if the user has a valid phone number. ✅
    5. SMS message should not exceed 160 characters. ✅
    6. A sent date should be added automatically. ✅
    7. The system should decide which notification class ✅ to use based on the selected notification type. ✅


### Data Access Layer
- Notification repository (required) 
   - Stores sent notifications ✅
   - Returns all sent notifications ✅
- User repository (additional feature) 
    - Stores, retrieves, updates deletes users ✅

### Expected concepts
The solution should demonstrate:

* 3-Tier Architecture ✅
* Interface ✅
* Class and object creation ✅
* Encapsulation ✅
* Interaction between layers ✅
* Basic polymorphism ✅
* Business logic validation ✅
* Collection usage ✅
* Future extensibility ✅

