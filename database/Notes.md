# To create a new user on neon
CREATE ROLE restaurant_user WITH LOGIN PASSWORD 'secure_password';

Grant Permissions
## Read-only access (recommended for students):
GRANT CONNECT ON DATABASE your_database_name TO restaurant_user;
GRANT USAGE ON SCHEMA public TO restaurant_user;
GRANT SELECT ON ALL TABLES IN SCHEMA public TO restaurant_user;

## Read and write access (if students need to modify data):
GRANT CONNECT ON DATABASE your_database_name TO restaurant_user;
GRANT USAGE ON SCHEMA public TO restaurant_user;
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO restaurant_user;

### example

-- Step 1: Create a new role for students
CREATE ROLE restaurant_user WITH LOGIN PASSWORD 'secure_password';

-- Step 2: Grant connect and usage permissions
GRANT CONNECT ON DATABASE restaurant TO restaurant_user;
GRANT USAGE ON SCHEMA public TO restaurant_user;

-- Step 3: Grant read, write, and delete permissions
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO restaurant_user;

-- Step 4: Grant access to sequences (if needed)
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO restaurant_user;

-- Step 5: Test the new user
\c my_database restaurant_user

-- Test read access
SELECT * FROM your_table;

-- Test write access
INSERT INTO your_table (column1, column2) VALUES ('value1', 'value2');

-- Test delete access
DELETE FROM your_table WHERE column1 = 'value1';

-- Verify schema alteration is not allowed (should fail)
CREATE TABLE test_table (id SERIAL PRIMARY KEY);

## command executed

CREATE ROLE restaurant_user WITH LOGIN PASSWORD 'upgX7GhXrNMVjtmpmKXcaOSOQv2G24y2';
GRANT CONNECT ON DATABASE neondb TO restaurant_user;
GRANT USAGE ON SCHEMA public TO restaurant_user;
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO restaurant_user;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO restaurant_user;

-- Test the new user

-- Test read access
SELECT * FROM customers;

-- Test write access
INSERT INTO Customers (first_name, last_name, phone, email) VALUES
('Filippo', 'Albertini', '12345678901', 'filippo.albertini@ittsrimini.edu.it');

-- Test delete access
DELETE FROM Customers WHERE customer_id = 8;

-- Verify schema alteration is not allowed (should fail)
CREATE TABLE test_table (id SERIAL PRIMARY KEY);
