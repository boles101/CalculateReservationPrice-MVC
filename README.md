# Hotel-Reservation-API
A simple system for calculating hotel reservations.
 Dynamically calculating costs based on seasonality, and ensuring capacity constraints. Developed using ASP.NET MVC and Entity Framework.

### `CalculateReservation` Method

**Purpose**:
Calculates the total cost of a hotel stay based on multiple factors including the stay duration, room type, and meal plan, adjusting for seasonal pricing variations.

**Parameters**:
- `checkIn` (DateOnly): The check-in date of the reservation.
- `checkOut` (DateOnly): The check-out date of the reservation.
- `numberOfAdults` (int): The total number of adults included in the reservation.
- `numberOfChildren` (int): The total number of children included in the reservation.
- `roomTypeId` (int): Identifier for the type of room booked.
- `mealPlanId` (int): Identifier for the chosen meal plan.

**Returns**: 
- Returns the total cost of the stay as a `decimal` and the number of rooms booked as `int`.

