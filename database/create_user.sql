-- create user reservation_user
-- Step 1: Create a new role for students
CREATE ROLE restaurant_user WITH LOGIN PASSWORD 'secure_password';

-- Step 2: Grant connect and usage permissions
GRANT CONNECT ON DATABASE restaurant TO restaurant_user;
GRANT USAGE ON SCHEMA public TO restaurant_user;

-- Step 3: Grant read, write, and delete permissions
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO restaurant_user;

-- Step 4: Grant access to sequences (if needed)
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO restaurant_user;