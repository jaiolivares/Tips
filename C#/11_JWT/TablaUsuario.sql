CREATE TABLE Usuario
(
	Id	INT PRIMARY KEY IDENTITY(1,1),
	Email VARCHAR(50),
	Password VARCHAR(250),
	Nombre VARCHAR(100),
	Rol	VARCHAR(20)
)

INSERT INTO Usuario VALUES ('admin@prueba.cl', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Big Boss', 'Administrador')
INSERT INTO Usuario VALUES ('invitado@prueba.cl', '20f3765880a5c269b747e1e906054a4b4a3a991259f1e16b5dde4742cec2319a', 'Visita', 'Invitado')