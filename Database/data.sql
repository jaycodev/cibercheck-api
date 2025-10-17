USE CiberCheck;
GO

INSERT INTO Users (FullName, Email, Role, PasswordHash)
VALUES ('John Smith', 'john@school.edu', 'teacher', '1234');

INSERT INTO Users (FullName, Email, Role, PasswordHash)
VALUES 
('Alice Brown', 'alice@school.edu', 'student', 'abcd'),
('Mark Davis', 'mark@school.edu', 'student', 'abcd');

INSERT INTO Courses (Name, Code)
VALUES ('Mathematics I', 'MATH101');

INSERT INTO Sections (CourseId, TeacherId, Name)
VALUES (1, 1, 'A');

INSERT INTO StudentsSections (StudentId, SectionId)
VALUES 
(2, 1),
(3, 1);

INSERT INTO Sessions (SectionId, Date, StartTime, EndTime, Topic)
VALUES 
(1, '2025-10-16', '08:00', '10:00', 'Linear Equations');

INSERT INTO Attendance (StudentId, SessionId, Status, Notes)
VALUES 
(2, 1, 'present', NULL),
(3, 1, 'absent', 'Sick leave');
