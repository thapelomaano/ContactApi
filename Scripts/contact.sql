-- Drop tables if they exist
DROP TABLE IF EXISTS Notes;
DROP TABLE IF EXISTS Contacts;

-- Create Contacts table
CREATE TABLE Contacts (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT NOT NULL,
    LastName TEXT NOT NULL,
    Email TEXT,
    PhoneNumber TEXT,
    Address TEXT,
    DateOfBirth DATE
);

-- Create Notes table
CREATE TABLE Notes (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Content TEXT NOT NULL,
    ContactId INTEGER NOT NULL,
    FOREIGN KEY (ContactId) REFERENCES Contacts(Id) ON DELETE CASCADE
);

-- Seed Contacts
INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber, Address, DateOfBirth) VALUES
('Alice', 'Johnson', 'alice@saco.com', '074-456-7890', '123 Maple St', '1990-05-15'),
('John', 'Smith', 'bob@saco.com', '012-567-8901', '456 Oak St', '1985-09-20'),
('Carol', 'Taylor', 'carol@saco.com', '075-678-9012', '789 Pine St', '1992-12-01'),
('David', 'Lee', 'david@saco.com', '087-789-0123', '321 Cedar St', '1980-07-07'),
('Eva', 'Martinez', 'eva@saco.com', '064-890-1234', '654 Birch St', '1995-03-30');

-- Seed Notes
INSERT INTO Notes (Content, ContactId) VALUES
('Met at conference.', 1),
('Follow up in two weeks.', 1),
('Requested product brochure.', 2),
('Potential client for Q3.', 3),
('Birthday gift sent.', 5);



---Simple join---
SELECT 
    Contacts.FirstName || ' ' || Contacts.LastName AS FullName,
    Notes.Content
FROM Contacts
JOIN Notes ON Contacts.Id = Notes.ContactId;
