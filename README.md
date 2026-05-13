# Equipment Management Web App

## Project

Developed during the Fullstack course at [Programming Academy](https://www.academiadoprogramador.net) 2026

## Features

Junior is responsible for managing equipment inventory at the company where he works. He has always kept track of equipment and their maintenance history using an Excel spreadsheet.

Because of that, he asked the Programming Academy team for help in developing a software system to automate this process.

## 1. Manufacturers Management

#### Requirement 1.1:

As an employee, Junior wants to be able to register equipment manufacturers.

- Must have a unique identifier (id);
- Must have the manufacturer name;
- Must have the manufacturer email;
- Must have the manufacturer phone number;

#### Requirement 1.2:

As an employee, Junior wants to be able to view all registered manufacturers for control purposes.

- Must display the manufacturer name;
- Must display the manufacturer email;
- Must display the manufacturer phone number;
- Must display the number of equipment produced by each manufacturer;

#### Requirement 1.3:

As an employee, Junior wants to be able to edit a registered manufacturer, being able to update all fields.

- Same criteria as Requirement 3.1.

#### Requirement 1.4:

As an employee, Junior wants to be able to delete a manufacturer.

## 2. Equipment Management

#### Requirement 2.1:

As an employee, Junior wants to be able to register equipment.

- Must have a unique identifier (id);
- Must have a name with at least 6 characters;
- Must have a purchase price;
- Must have a manufacturer;
- Must have a manufacturing date;

#### Requirement 2.2:

As an employee, Junior wants to be able to view all equipment registered in his inventory.

- Must display the id;
- Must display the name;
- Must display the purchase price;
- Must display the manufacturer;
- Must display the manufacturing date;

#### Requirement 2.3:

As an employee, Junior wants to be able to edit equipment, being able to update all fields.

- Same criteria as Requirement 1.1.

#### Requirement 2.4:

As an employee, Junior wants to be able to delete a registered equipment item.

- The equipment list must be updated accordingly.

## 3. Service Tickets Management

#### Requirement 3.1:

As an employee, Junior wants to be able to register maintenance service tickets for the registered equipment.

- Must have a unique identifier (id);
- Must have a ticket title;
- Must have a ticket description;
- Must have an associated equipment;
- Must have an opening date;

#### Requirement 3.2:

As an employee, Junior wants to be able to view all registered service tickets.

- Must display the ticket title;
- Must display the equipment;
- Must display the opening date;
- Must display the number of days the ticket has been open;

#### Requirement 3.3:

As an employee, Junior wants to be able to edit a registered service ticket, being able to update all fields.

- Same criteria as Requirement 2.1.

#### Requirement 3.4:

As an employee, Junior wants to be able to delete a service ticket.

## How to Use

1. Clone the repository or download the source code.
2. Open the terminal or command prompt and navigate to the root folder.
3. Run the command below to restore project dependencies.

```bash
dotnet restore
```

4. Run the project with live compilation.

```bash
dotnet run --project GestaoDeEquipamentosWeb.ConsoleApp
```

## Requirements

- .NET 10.0 SDK