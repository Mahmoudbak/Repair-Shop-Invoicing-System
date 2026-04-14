🛠️ Repair Shop Invoicing System

A professional management and billing solution for repair businesses. Built with ASP.NET Core 8, this system focuses on automating the workflow from receiving a device to issuing the final invoice and collecting payments.
🌟 Business Value

    Workflow Tracking: Manage the lifecycle of a repair job (Received ➡️ In Progress ➡️ Fixed ➡️ Invoiced).

    Automated Invoicing: Generate professional invoices based on parts used and labor hours.

    Customer Portal: (Optional/Future) Allow customers to check their repair status and pay online.

🚀 Technical Highlights

    Clean Architecture: Strict separation between Core (Domain), Application (Logic), and Infrastructure (Data/External Services).

    Advanced Patterns: * Specification Pattern: For clean, reusable database queries.

        Unit of Work & Repository: To maintain data integrity and decouple persistence.

        Generic Repository: Minimizing boilerplate code for standard CRUD.

    Seamless Payments: Integrated with Stripe to handle secure credit card transactions.

    Fluent Validation: To ensure data integrity before it hits the database.

🛠 Tech Stack

    Framework: ASP.NET Core Web API

    ORM: Entity Framework Core (SQL Server)

    Mapping: AutoMapper

    Payment Gateway: Stripe API

    Security: JWT & Identity Framework
