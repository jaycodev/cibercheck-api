USE CiberCheck;
GO

-- Limpieza de datos en orden de dependencias
DELETE FROM Attendance;
DELETE FROM StudentsSections;
DELETE FROM Sessions;
DELETE FROM Sections;
DELETE FROM Courses;
DELETE FROM Users;
GO

-- Usuarios (2 profesores y 4 estudiantes)
INSERT INTO Users (FullName, Email, Role, PasswordHash) VALUES
('John Smith', 'john@school.edu', 'teacher', 'hash1'),
('Maria Garcia', 'maria@school.edu', 'teacher', 'hash2'),
('Alice Brown', 'alice@school.edu', 'student', 'hash3'),
('Mark Davis', 'mark@school.edu', 'student', 'hash4'),
('Liu Wei', 'liu@school.edu', 'student', 'hash5'),
('Sara Khan', 'sara@school.edu', 'student', 'hash6');
GO

-- Cursos
INSERT INTO Courses (Name, Code) VALUES
('Mathematics I', 'MATH101'),
('Physics I', 'PHYS101');
GO

-- Secciones (asumiendo IDs generados: Teachers 1,2 y Courses 1,2)
INSERT INTO Sections (CourseId, TeacherId, Name) VALUES
(1, 1, 'A'),
(1, 1, 'B'),
(2, 2, 'A');
GO

-- Inscripciones estudiantes a secciones
-- Estudiantes con IDs 3..6
INSERT INTO StudentsSections (StudentId, SectionId) VALUES
(3, 1), (4, 1), (5, 1),
(4, 2), (6, 2),
(3, 3), (5, 3);
GO

-- Sesiones por sección
INSERT INTO Sessions (SectionId, Date, StartTime, EndTime, Topic) VALUES
(1, '2025-10-16', '08:00', '10:00', 'Linear Equations'),
(1, '2025-10-23', '08:00', '10:00', 'Quadratic Functions'),
(2, '2025-10-17', '09:00', '11:00', 'Derivatives Intro'),
(3, '2025-10-18', '10:00', '12:00', 'Kinematics Basics');
GO

-- Asistencias (asumiendo SessionId 1..4 en orden de inserción)
INSERT INTO Attendance (StudentId, SessionId, Status, Notes) VALUES
(3, 1, 'present', NULL),
(4, 1, 'absent', 'Sick'),
(5, 1, 'late', 'Traffic'),
(3, 2, 'present', NULL),
(4, 2, 'present', NULL),
(5, 2, 'excused', 'Medical'),
(4, 3, 'present', NULL),
(6, 3, 'present', NULL),
(3, 4, 'present', NULL),
(5, 4, 'absent', 'Out of town');
GO
