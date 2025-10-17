CREATE DATABASE CiberCheck;
GO

USE CiberCheck;
GO

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('teacher', 'student')),
    PasswordHash NVARCHAR(255) NOT NULL
);
GO

CREATE TABLE Courses (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Code NVARCHAR(20) UNIQUE
);
GO

CREATE TABLE Sections (
    SectionId INT IDENTITY(1,1) PRIMARY KEY,
    CourseId INT NOT NULL,
    TeacherId INT NOT NULL,
    Name NVARCHAR(50),
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId) ON DELETE CASCADE,
    FOREIGN KEY (TeacherId) REFERENCES Users(UserId) ON DELETE CASCADE
);
GO

CREATE TABLE StudentsSections (
    StudentId INT NOT NULL,
    SectionId INT NOT NULL,
    PRIMARY KEY (StudentId, SectionId),
    FOREIGN KEY (StudentId) REFERENCES Users(UserId) ON DELETE CASCADE,
    FOREIGN KEY (SectionId) REFERENCES Sections(SectionId) ON DELETE CASCADE
);
GO

CREATE TABLE Sessions (
    SessionId INT IDENTITY(1,1) PRIMARY KEY,
    SectionId INT NOT NULL,
    Date DATE NOT NULL,
    StartTime TIME,
    EndTime TIME,
    Topic NVARCHAR(200),
    FOREIGN KEY (SectionId) REFERENCES Sections(SectionId) ON DELETE CASCADE
);
GO

CREATE TABLE Attendance (
    StudentId INT NOT NULL,
    SessionId INT NOT NULL,
    Status NVARCHAR(20) NOT NULL CHECK (Status IN ('present','absent','late','excused')),
    Notes NVARCHAR(MAX),
    PRIMARY KEY (StudentId, SessionId),
    FOREIGN KEY (StudentId) REFERENCES Users(UserId) ON DELETE CASCADE,
    FOREIGN KEY (SessionId) REFERENCES Sessions(SessionId) ON DELETE CASCADE
);
GO
