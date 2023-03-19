CREATE TABLE Teacher (
    TeacherID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Gender CHAR(1) NOT NULL,
    Subject VARCHAR(50) NOT NULL
);
CREATE TABLE Pupil (
    PupilID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Gender CHAR(1) NOT NULL,
    Class VARCHAR(50) NOT NULL
);
CREATE TABLE TeacherPupil (
    TeacherID INT NOT NULL,
    PupilID INT NOT NULL,
    PRIMARY KEY (TeacherID, PupilID),
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID),
    FOREIGN KEY (PupilID) REFERENCES Pupil(PupilID)
);
INSERT INTO Teacher (FirstName, LastName, Gender, Subject)
VALUES ('Aniko', 'Shaverdashvili', 'F', 'Biology'),
       ('Ana', 'Shav', 'F', 'testSub'),
       ('Ani', 'shaverda', 'M', 'TestSubject');

INSERT INTO Pupil (FirstName, LastName, Gender, Class)
VALUES ('Giorgi', 'Giorgishvili', 'M', 'Grade 12'),
       ('TEST', 'Testi', 'F', 'Grade 11'),
       ('Testpupil', 'TestpupilSurname', 'M', 'Grade 10');

INSERT INTO TeacherPupil (TeacherID, PupilID)
VALUES (1, 1),
       (1, 2),
       (2, 2),
       (3, 3);

SELECT t.FirstName, t.LastName, t.Subject
FROM Teacher t
INNER JOIN TeacherPupil tp ON t.TeacherID = tp.TeacherID
INNER JOIN Pupil p ON p.PupilID = tp.PupilID
WHERE p.FirstName = 'Giorgi';
