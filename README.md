# Hotel Reservation API

A simple system for calculating hotel reservations, dynamically calculating costs based on seasonality, and ensuring capacity constraints. This system is developed using ASP.NET MVC and Entity Framework.

## Features

- **Dynamic Cost Calculation**: Calculates costs based on the duration of the stay, room type, meal plan, and seasonal pricing variations.
- **Capacity Management**: Ensures that room bookings adhere to capacity constraints.(Any room type holds maximum of 2 adults and 2 children)
- **Data Seeding**: Includes initial seed data for room types, meal plans, and their respective rates to facilitate immediate usability upon setup.

## `CalculateReservation` Method

### Purpose
Calculates the total cost of a hotel stay and determines the number of rooms required based on the booking details provided.

### Parameters
- `checkIn` (DateOnly): The check-in date of the reservation.
- `checkOut` (DateOnly): The check-out date of the reservation.
- `numberOfAdults` (int): Total number of adults included in the reservation.
- `numberOfChildren` (int): Total number of children included in the reservation.
- `roomTypeId` (int): Identifier for the type of room booked.
- `mealPlanId` (int): Identifier for the chosen meal plan.

### Returns
- Returns the total cost of the stay as a `decimal`.
- Returns the number of rooms booked as an `int`.

## Views

The application provides two main views:

### 1. Reservation Form View

This view presents users with a form to input their reservation details, including the number of adults and children, check-in and check-out dates, room type, and meal plan. The form is designed to capture all necessary information required to calculate the total cost of the stay and the number of rooms needed.

### 2. Result View

After submitting the reservation form, users are redirected to the result view which displays the total cost of their reservation and the number of rooms booked. 


## Getting Started

### Prerequisites
- .NET 8.0 SDK
- Entity Framework Core
- SQL Server or any compatible database system
