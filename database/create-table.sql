CREATE TABLE Customers (
    customer_id SERIAL PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    phone VARCHAR(15) UNIQUE NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE Tables (
    table_id SERIAL PRIMARY KEY,
    table_number INT UNIQUE NOT NULL,
    seats INT NOT NULL CHECK (seats > 0)
);

CREATE TABLE Reservations (
    reservation_id SERIAL PRIMARY KEY,
    reservation_date DATE NOT NULL,
    reservation_time TIME NOT NULL,
    number_of_people INT NOT NULL CHECK (number_of_people > 0),
    customer_id INT NOT NULL,
    status VARCHAR(20) NOT NULL CHECK (status IN ('confirmed', 'pending', 'canceled')),
    CONSTRAINT fk_customer FOREIGN KEY (customer_id) REFERENCES Customers(customer_id) ON DELETE CASCADE
);

CREATE TABLE Table_Assignments (
    assignment_id SERIAL PRIMARY KEY,
    reservation_id INT NOT NULL,
    table_id INT NOT NULL,
    CONSTRAINT fk_reservation FOREIGN KEY (reservation_id) REFERENCES Reservations(reservation_id) ON DELETE CASCADE,
    CONSTRAINT fk_table FOREIGN KEY (table_id) REFERENCES Tables(table_id) ON DELETE CASCADE,
    CONSTRAINT unique_table_per_reservation UNIQUE (reservation_id, table_id)
);

CREATE INDEX idx_reservations_date ON Reservations(reservation_date);
CREATE INDEX idx_reservations_customer ON Reservations(customer_id);
CREATE INDEX idx_available_tables ON Tables(table_id);
