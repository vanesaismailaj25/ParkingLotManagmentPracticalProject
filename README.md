# ParkingLotManagmentPracticalProject

SCENARIO
There is the need to create an app that will help manage a parking lot. The parking lot is quite
big, and the employees are having trouble keeping track of the car check ins/outs and
receipts.
What needs to be done is to digitalize this scenario.
MAIN FUNCTIONALITIES
PARKING SPOTS
The first thing to be done is to keep track of the total parking spots. These spots are divided
into two categories: regular spots which can be used by anyone, reserved spots which are
used by people who have an active subscription.
Fields
Parking Spots
Id
Total Spots
NOTE! For simplicity initially the number of free and reserved spots is entered manually in the
database. The reason behind this is that the parking lot structure is very rigid, which means
that is likely to be changed frequently.
Operations
1. View
a. View the total number of spots, reserved and regular spots
b. The number of reserved spots is calculated by the number of active
memberships (which will be explained later)
c. The number of regular spots is the difference between total spots minus
reserved spots
(Total – reserved = regular)
2. Update
PRICING PLANS
There should be two main pricing plans: the weekday pricing plan and the weekend pricing
plan.
Fields
Pricing Plans
Id
Hourly Pricing
Daily Pricing
Minimum Hours
Type (weekday, weekend)
NOTE! For simplicity initially the pricing plans are entered manually in the database. The
reason behind this is that the parking lot prices plans are very few and very simple in
structure.
Operations
1. View
a. View the pricing plans
2. Update
a. Change the pricing details
SUBSCRIBERS
People can subscribe monthly to the parking lot. This means that the parking lot will reserve a
spot for them at any time, hence their spot cannot be considered available. They can check
in and out of the parking lot multiple times in a day without an extra fee.
Fields
Subscriber
First Name
Last Name
Id Card Number
Email
Phone number
Birthday
Plate number
Is deleted (If this field is true, it means that the person is no longer a subscriber)
1. Create
a. All fields are required
b. Need to be checked if a person with the same Id card number already exists
2. View / List
a. Search members from the list by name/surname/id card number/email
b. View the details of a specific member
3. Update
4. Delete
a. A member can be only soft deleted
SUBSCRIPTIONS
Registered members aka subscribers can have one active subscription at a time. Parking lot
subscriptions are fairly straightforward. Their price is calculated by the number of days times
the weekday price (day * weekday price). This price is suggested at the moment of
subscription. To make the system a bit more flexible in case someone is a regular subscriber,
it is possible to input a discount value which will be subtracted from the regular price.
Fields
Subscriptions
Id
Code
Subscriber Id
Price
Discount Value
Start date
End date
Is deleted (If this field is true, it means that the subscription is no longer valid)
Operations
1. Create
a. All fields are required
b. Do not allow more than subscription with the same code
2. View / List
a. Search subscription from the list by code/subscriber name
b. View the details of a specific subscription
3. Update
4. Delete
a. A subscription can be only soft deleted
Daily Logs
One crucial point of this app is registering the daily check ins/checkouts in the parking lot. For
each log, the price to be paid is calculated on fly at checkout time. This value is stored in the
database as well.
As mentioned earlier, the cars that own a subscription are not subject to payment.
Fields
Logs
Id
Code
Subscription Id
Check in Time
Check out Time
Price
Operations
1. Create
2. View / List
a. View the details of logs for a specific day
b. Search logs from the list by code/subscriber name
3. Update
a. No updates allowed
4. Delete
a. A subscription can be only soft deleted
If the subscription Id is present that means that the price is 0, otherwise it is calculated
according to the following formula:
1. Step 1 -> Check if the check in has happened on a weekday or weekend.
2. Step 2 -> Calculate the total number of hours the car has spent in the parking lot.
3. Step 3 -> Check the minimum hours of the payment plan.
4. Step 4/1 -> If the car has spent less or equal to the minimum the formula would be:
Total to be paid = Number of hours * hourly rate
5. Step 4/2 => If the car has spent more than the minimum hours the formula would be:
Find the number of full days
If there are remaining hours then
- if they are less than the minimum hours, calculate the price for these hours like in
step 4/1.
Total = Number of days * daily rate + Number of hours * hourly rate
- else add more day to the full numbers of days
Total = (Number of days + 1) * daily rate
Examples
Price plan:
Weekday, hourly rate: €1, minimum hours: 3, daily rate: €5
Car 1 has checked in at 2022-09-01: 11: 01 and check out at 2022-09-01: 11: 54
The system should calculate the price for 1 hour => €1
Car 2 has checked in at 2022-09-01: 10: 27 and check out at 2022-09-01: 12: 54
The system should calculate the price for (2 hours, 27 minutes) 2.45 hours => €2.45
Car 3 has checked in at 2022-09-01: 08: 15 and check out at 2022-09-01: 14: 14
The system should calculate the price for (5 hours, 59 minutes) 5.983 hours. Since the
minimum hours is 3, it means that this person is going to be paying for the whole day => €5
Car 4 has checked in at 2022-09-01: 08: 01 and check out at 2022-09-02: 10: 15
The system should calculate the price for (1 day, 2 hours, 14 minutes), so one day and 2.233
hours =>
1 * €5 + 2.233 * €1 =€7.233
Car 5 has checked in at 2022-09-01: 08: 14 and check out at 2022-09-02: 19: 07
The system should calculate the price for 1 day, 10 hours, 53 minutes, so for 2 days => 2 * €5 =
€10
Car 6 has checked in at 2022-09-01: 07: 02 and check out at 2022-09-01: 19: 30 but it has a
subscription
The system should calculate €0
NOTE! The system should be able to display the following information:
Total spots
Total regular spots => Free spots + Occupied spots
Total reserved spots => Free spots + Occupied spots
NOTE! When a car is checked out, the number of free spots is automatically increased with
one and the occupied are decreased with one. This information is not stored in the database
but should be calculated on the fly.
UP FOR A CHALLENGE?
If you feel like you are up for a challenge, consider the following additional features
Grace period (Extended Pricing Plans)
Extend the calculations for the price with the grace period of 15 minutes. That means that if a
car checks in and out the parking lot in 15 or less, it shouldn’t be charged.
Car 7 has checked in at 2022-09-01: 07: 02 and check out at 2022-09-01: 07: 10
The system should calculate €0
