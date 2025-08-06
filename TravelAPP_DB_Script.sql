CREATE DATABASE TravelAI;
GO
USE TravelAI;
CREATE TABLE UserBehavior (
    user_id VARCHAR(50) PRIMARY KEY,
    session_duration FLOAT,
    pages_visited INT,
    search_origin VARCHAR(50),
    search_destination VARCHAR(50),
    travel_dates_flexibility BIT,
    device_type VARCHAR(20),
    clicked_offer BIT,
    booking_made BIT
);

INSERT INTO UserBehavior VALUES
('U001', 12.5, 10, 'DXB', 'LHR', 1, 'Mobile', 1, 1),
('U002', 3.1, 3, 'JFK', 'CDG', 0, 'Desktop', 0, 0),
('U003', 8.4, 7, 'DEL', 'JFK', 1, 'Tablet', 1, 1),
('U004', 2.0, 2, 'SIN', 'SYD', 0, 'Mobile', 0, 0),
('U005', 15.2, 12, 'LHR', 'DXB', 1, 'Desktop', 1, 1);