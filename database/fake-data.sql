-- Insert fake customers
INSERT INTO Customers (first_name, last_name, phone, email) VALUES
('John', 'Doe', '1234567890', 'john.doe@example.com'),
('Jane', 'Smith', '0987654321', 'jane.smith@example.com'),
('Alice', 'Brown', '1112223333', 'alice.brown@example.com'),
('Robert', 'Johnson', '2223334444', 'robert.johnson@example.com'),
('Emily', 'Davis', '3334445555', 'emily.davis@example.com'),
('Michael', 'Wilson', '4445556666', 'michael.wilson@example.com');

-- Insert fake tables
INSERT INTO Tables (table_number, seats) VALUES
(1, 4),
(2, 2),
(3, 6),
(4, 8),
(5, 4),
(6, 2);

-- Insert fake reservations
INSERT INTO Reservations (reservation_date, reservation_time, number_of_people, customer_id, status) VALUES
('2025-04-01', '18:30:00', 2, 1, 'confirmed'),
('2025-04-02', '19:00:00', 4, 2, 'pending'),
('2025-04-03', '20:15:00', 6, 3, 'canceled'),
('2025-04-04', '21:00:00', 2, 4, 'confirmed'),
('2025-04-05', '18:45:00', 3, 5, 'confirmed'),
('2025-04-06', '19:30:00', 5, 6, 'pending');

-- Insert fake table assignments
INSERT INTO Table_Assignments (reservation_id, table_id) VALUES
(1, 2),
(2, 1),
(4, 5),
(5, 6),
(6, 3);
