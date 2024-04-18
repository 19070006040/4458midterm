# SE4485 Midterm Project
## API Project for Mobile Provider Bill Payment System

### Introduction:
   This project aims to create an integrated system for managing phone bill invoices across multiple platforms: mobile provider applications, banking applications, and a website interface. Through the implementation of API invoice controllers, clients can efficiently check their phone bills, make payments, and manage their invoices seamlessly.

### Design: 
   The design of the project follows a typical RESTful API architecture using ASP.NET Core. Each module (mobile provider, banking app, and website) has its own set of API controllers responsible for handling various invoice-related operations. The project utilizes Entity Framework Core for database interactions, allowing seamless integration with different database providers.

### Issues:
 #### Payment Processing: 
   I had trouble while trying to implement the payment processing logic, especially ensuring that payments are marked as complete and updating the remaining amount if the payment is partial. This requirement needed
to accurately updating the bill's status and handling incomplete payments.
 #### Admin-Add Bill Functionality: 
   Another problem i encountered was the implementing the admin functionality to add bills for a given subscriber. This requirement needed authorization and authentication mechanisms to add bills, which i had some trouble.


### Data Model (ER Diagram):
![Ekran Görüntüsü (175)](https://github.com/19070006040/4458midterm/assets/149877163/c96fb708-0217-4d32-bc30-8c8a2a285da6)


### Mobil Provider App:


