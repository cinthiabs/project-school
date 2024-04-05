Use DB_School

create table aluno
(
    id int primary key identity,
    nome varchar(255),
	usuario varchar(45),
    senha char(64),
	ativo bit,
	data_criacao Datetime
);

create table turma 
(
    id int primary key identity,
    curso_id int,
    turma varchar(45),
    ano int,
	ativo bit,
	data_criacao Datetime
	
);

create table aluno_turma
(
	id int primary key identity,
    aluno_id int,
    turma_id int,
	ativo bit,
	data_criacao Datetime
    foreign key (aluno_id) references aluno(id),
    foreign key (turma_id) references turma(id)
);
