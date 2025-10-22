USE CiberCheck;
GO

INSERT INTO Users (FullName, Email, Role, PasswordHash) VALUES
('Juan Pérez', 'juan.perez@instituto.edu', 'profesor', '$2a$12$a4/15tNZryeIdDd7nKzo2uWM3tC7Qbbi03O3jGO76ZvEEGReMeeW6'), -- Password: profe123
('María González', 'maria.gonzalez@instituto.edu', 'profesor', '$2a$12$a4/15tNZryeIdDd7nKzo2uWM3tC7Qbbi03O3jGO76ZvEEGReMeeW6'), -- Password: profe123
('Carlos Rodríguez', 'carlos.rodriguez@instituto.edu', 'profesor', '$2a$12$a4/15tNZryeIdDd7nKzo2uWM3tC7Qbbi03O3jGO76ZvEEGReMeeW6'), -- Password: profe123
('Roberto Fernández', 'roberto.fernandez@instituto.edu', 'profesor', '$2a$12$a4/15tNZryeIdDd7nKzo2uWM3tC7Qbbi03O3jGO76ZvEEGReMeeW6'), -- Password: profe123
('Ana López', 'ana.lopez@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Luis Martínez', 'luis.martinez@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Carmen Sánchez', 'carmen.sanchez@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Miguel Torres', 'miguel.torres@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Laura Ramírez', 'laura.ramirez@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Pedro Flores', 'pedro.flores@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Sofia Morales', 'sofia.morales@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Diego Castro', 'diego.castro@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Valentina Ruiz', 'valentina.ruiz@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Javier Mendoza', 'javier.mendoza@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Isabella Vargas', 'isabella.vargas@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Andrés Silva', 'andres.silva@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Camila Ortiz', 'camila.ortiz@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Sebastián Reyes', 'sebastian.reyes@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Daniela Herrera', 'daniela.herrera@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'), -- Password: estudiante123
('Mateo Jiménez', 'mateo.jimenez@instituto.edu', 'estudiante', '$2a$12$sDIyJPxIp3/hkt34lKVHtOOWKIc2hD0giexx/ltkQm1YOwYKS5Awi'); -- Password: estudiante123
GO

INSERT INTO Courses (Name, Code, Slug) VALUES
('Desarrollo de Aplicaciones Móviles I', 'DAM-I', 'desarrollo-de-aplicaciones-moviles-i'),
('Seguridad de Aplicaciones', 'SEG-APP', 'seguridad-de-aplicaciones'),
('Experiencias Formativas en Situaciones Reales de Trabajo IV', 'EFSRT-IV', 'experiencias-formativas-en-situaciones-reales-de-trabajo-iv'),
('Lenguaje de Programación II', 'LP-II', 'lenguaje-de-programacion-ii'),
('Desarrollo de Servicios Web I', 'DSW-I', 'desarrollo-de-servicios-web-i'),
('Desarrollo de Aplicaciones Web I', 'DAW-I', 'desarrollo-de-aplicaciones-web-i'),
('Base de Datos Avanzado I', 'BDA-I', 'base-de-datos-avanzado-i'),
('Análisis y Diseño de Sistemas I', 'ADS-I', 'analisis-y-diseno-de-sistemas-i');
GO

INSERT INTO Sections (CourseId, TeacherId, Name, Slug) VALUES
(1, 1, 'Sección A', 'seccion-a'),
(1, 1, 'Sección B', 'seccion-b'),
(2, 2, 'Sección A', 'seccion-a'),
(2, 2, 'Sección B', 'seccion-b'),
(3, 3, 'Sección A', 'seccion-a'),
(4, 1, 'Sección A', 'seccion-a'),
(4, 4, 'Sección B', 'seccion-b'),
(5, 2, 'Sección A', 'seccion-a'),
(6, 3, 'Sección A', 'seccion-a'),
(6, 4, 'Sección B', 'seccion-b'),
(7, 1, 'Sección A', 'seccion-a'),
(8, 2, 'Sección A', 'seccion-a'),
(8, 3, 'Sección B', 'seccion-b');
GO

INSERT INTO StudentsSections (StudentId, SectionId) VALUES
(5, 1), (6, 1), (7, 1), (8, 1), (9, 1), (10, 1),
(11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2),
(5, 3), (7, 3), (9, 3), (11, 3), (13, 3), (15, 3),
(6, 4), (8, 4), (10, 4), (12, 4), (14, 4), (16, 4),
(17, 5), (18, 5), (19, 5), (20, 5),
(5, 6), (6, 6), (7, 6), (8, 6), (9, 6),
(10, 7), (11, 7), (12, 7), (13, 7), (14, 7),
(15, 8), (16, 8), (17, 8), (18, 8), (19, 8), (20, 8),
(5, 9), (7, 9), (9, 9), (11, 9), (13, 9),
(6, 10), (8, 10), (10, 10), (12, 10), (14, 10),
(15, 11), (16, 11), (17, 11), (18, 11), (19, 11), (20, 11),
(5, 12), (6, 12), (7, 12), (8, 12), (9, 12), (10, 12),
(11, 13), (12, 13), (13, 13), (14, 13), (15, 13), (16, 13);
GO

INSERT INTO Sessions (SectionId, SessionNumber, Date, StartTime, EndTime, Topic) VALUES
(1, 1, '2025-10-14', '08:00', '10:00', 'Introducción a Android Studio'),
(1, 2, '2025-10-21', '08:00', '10:00', 'Componentes de UI en Android'),
(1, 3, '2025-10-28', '08:00', '10:00', 'Actividades e Intents'),
(2, 1, '2025-10-15', '10:00', '12:00', 'Layouts y ViewGroups'),
(2, 2, '2025-10-22', '10:00', '12:00', 'RecyclerView y Adaptadores'),
(3, 1, '2025-10-16', '14:00', '16:00', 'Criptografía y Cifrado'),
(3, 2, '2025-10-23', '14:00', '16:00', 'Autenticación y Autorización'),
(4, 1, '2025-10-17', '08:00', '10:00', 'SQL Injection y Prevención'),
(4, 2, '2025-10-24', '08:00', '10:00', 'OWASP Top 10'),
(5, 1, '2025-10-18', '09:00', '11:00', 'Metodologías Ágiles en la Práctica'),
(6, 1, '2025-10-14', '14:00', '16:00', 'Programación Orientada a Objetos'),
(6, 2, '2025-10-21', '14:00', '16:00', 'Estructuras de Control Avanzadas'),
(7, 1, '2025-10-15', '16:00', '18:00', 'Herencia y Polimorfismo'),
(7, 2, '2025-10-22', '16:00', '18:00', 'Interfaces y Clases Abstractas'),
(8, 1, '2025-10-16', '10:00', '12:00', 'Introducción a REST API'),
(8, 2, '2025-10-23', '10:00', '12:00', 'Métodos HTTP y Códigos de Estado'),
(9, 1, '2025-10-17', '14:00', '16:00', 'HTML5 y CSS3 Avanzado'),
(9, 2, '2025-10-24', '14:00', '16:00', 'JavaScript y DOM Manipulation'),
(10, 1, '2025-10-18', '16:00', '18:00', 'Responsive Design y Bootstrap'),
(10, 2, '2025-10-25', '16:00', '18:00', 'Frameworks Frontend'),
(11, 1, '2025-10-14', '10:00', '12:00', 'Procedimientos Almacenados'),
(11, 2, '2025-10-21', '10:00', '12:00', 'Triggers y Funciones'),
(12, 1, '2025-10-15', '08:00', '10:00', 'Diagramas UML'),
(12, 2, '2025-10-22', '08:00', '10:00', 'Casos de Uso'),
(13, 1, '2025-10-16', '16:00', '18:00', 'Diagramas de Clases'),
(13, 2, '2025-10-23', '16:00', '18:00', 'Patrones de Diseño');
GO

INSERT INTO Attendance (StudentId, SessionId, Status, Notes) VALUES
(5, 1, 'presente', NULL),
(6, 1, 'ausente', 'Enfermo'),
(7, 1, 'tarde', 'Tráfico'),
(8, 1, 'presente', NULL),
(9, 1, 'presente', NULL),
(10, 1, 'justificado', 'Trámite personal'),
(5, 2, 'presente', NULL),
(6, 2, 'presente', NULL),
(7, 2, 'presente', NULL),
(8, 2, 'tarde', 'Problemas de transporte'),
(9, 2, 'presente', NULL),
(10, 2, 'presente', NULL),
(11, 4, 'presente', NULL),
(12, 4, 'presente', NULL),
(13, 4, 'ausente', 'No justificado'),
(14, 4, 'presente', NULL),
(15, 4, 'tarde', 'Retraso'),
(16, 4, 'presente', NULL),
(5, 6, 'presente', NULL),
(7, 6, 'presente', NULL),
(9, 6, 'presente', NULL),
(11, 6, 'ausente', 'Enfermedad'),
(13, 6, 'presente', NULL),
(15, 6, 'justificado', 'Justificación médica'),
(6, 8, 'presente', NULL),
(8, 8, 'tarde', 'Problema familiar'),
(10, 8, 'presente', NULL),
(12, 8, 'presente', NULL),
(14, 8, 'presente', NULL),
(16, 8, 'ausente', 'No asistió'),
(17, 10, 'presente', NULL),
(18, 10, 'presente', NULL),
(19, 10, 'tarde', 'Transporte'),
(20, 10, 'presente', NULL),
(5, 11, 'presente', NULL),
(6, 11, 'presente', NULL),
(7, 11, 'ausente', 'Enfermo'),
(8, 11, 'presente', NULL),
(9, 11, 'presente', NULL),
(5, 12, 'presente', NULL),
(6, 12, 'tarde', 'Llegó tarde'),
(7, 12, 'presente', NULL),
(8, 12, 'presente', NULL),
(9, 12, 'justificado', 'Cita médica'),
(10, 13, 'presente', NULL),
(11, 13, 'presente', NULL),
(12, 13, 'presente', NULL),
(13, 13, 'ausente', 'Sin justificar'),
(14, 13, 'presente', NULL),
(15, 15, 'presente', NULL),
(16, 15, 'presente', NULL),
(17, 15, 'tarde', 'Problemas técnicos'),
(18, 15, 'presente', NULL),
(19, 15, 'presente', NULL),
(20, 15, 'presente', NULL),
(5, 17, 'presente', NULL),
(7, 17, 'presente', NULL),
(9, 17, 'ausente', 'Enfermedad'),
(11, 17, 'presente', NULL),
(13, 17, 'tarde', 'Tráfico pesado'),
(6, 19, 'presente', NULL),
(8, 19, 'presente', NULL),
(10, 19, 'presente', NULL),
(12, 19, 'justificado', 'Documentos médicos'),
(14, 19, 'presente', NULL),
(15, 21, 'presente', NULL),
(16, 21, 'tarde', 'Problema personal'),
(17, 21, 'presente', NULL),
(18, 21, 'presente', NULL),
(19, 21, 'ausente', 'No asistió'),
(20, 21, 'presente', NULL),
(15, 22, 'presente', NULL),
(16, 22, 'presente', NULL),
(17, 22, 'presente', NULL),
(18, 22, 'tarde', 'Llegó 15 min tarde'),
(19, 22, 'presente', NULL),
(20, 22, 'presente', NULL),
(5, 23, 'presente', NULL),
(6, 23, 'presente', NULL),
(7, 23, 'ausente', 'Asunto familiar'),
(8, 23, 'presente', NULL),
(9, 23, 'presente', NULL),
(10, 23, 'tarde', 'Retraso en bus'),
(5, 24, 'presente', NULL),
(6, 24, 'presente', NULL),
(7, 24, 'presente', NULL),
(8, 24, 'presente', NULL),
(9, 24, 'justificado', 'Certificado médico'),
(10, 24, 'presente', NULL),
(11, 25, 'presente', NULL),
(12, 25, 'presente', NULL),
(13, 25, 'tarde', 'Problemas de tráfico'),
(14, 25, 'presente', NULL),
(15, 25, 'presente', NULL),
(16, 25, 'ausente', 'No justificado');
GO
