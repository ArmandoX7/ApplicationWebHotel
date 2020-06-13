-- Primero creamos la base de datos
create database hotel5;

-- Luego especificamos la base de datos que vamos a usar
use hotel5;

-- Creamos todas las tablas esenciales para la base de datos con sus columnas y relaciones
create table usuario(
idUser int identity(1,1) not null primary key,
email varchar(30) not null,
password varchar(30) not null
);

create table huesped(
idHuesped int identity(1,1) not null primary key,
nombres varchar(25) not null,
apellido_pat varchar(15) not null,
apellido_mat varchar(15) not null,
edad int not null,
sexo varchar(15),
fecha_nac date not null,
lugar_nac varchar(25) not null,
direccion varchar(50) not null,
tel_casa varchar(25) not null,
tel_celular varchar(25) not null,
correo varchar(30) not null,
rfc varchar(15) not null,
numVisita int null
);

create table habitacion(
idHabitacion nvarchar(10) not null primary key,
tipo varchar(30) not null,
capacidad varchar(20) not null,
disponibilidad varchar(15) null,
precio int not null
);

create table servicio(
idServicio int identity(1,1) not null primary key,
tipo varchar(10) not null,
descripcion varchar(25) not null,
fecha date null,
hora time null,
costo int not null
);
 
create table queja(
idQueja int identity(1,1) not null primary key,
descripcion nvarchar(100),
fecha date, 
hora time
);

create table satisfaccion(
idSatisfaccion int identity(1,1) not null primary key,
descripcion nvarchar(100),
calificacion int,
fecha date, 
hora time
);

create table empleado(
idEmpleado int not null primary key,
nombre varchar(20) not null,
apellido_pat varchar(15) not null,
apellido_mat varchar(15) not null,
sexo varchar(15) not null,
telefono varchar(20) not null,
correo varchar(30) not null,
rfc varchar(15) not null,
);

create table registro(
idRegistro int identity(1,1) not null primary key,
idHuesped int not null,
idHabitacion nvarchar(10) not null,
fecha date not null,
hora time not null,
dias int not null,
descuento int null,
constraint fk_idHuesped foreign key (idHuesped) references huesped(idHuesped),
constraint fk_idHabitacion foreign key (idHabitacion) references habitacion(idHabitacion)
);

create table consumo(
idConsumo int identity(1,1) not null primary key,
idHuesped int not null,
idServicio int not null,
cantidad int not null,
fecha date not null,
hora time not null,
constraint fk_idHuesped2 foreign key (idHuesped) references huesped(idHuesped),
constraint fk_idServicio foreign key (idServicio) references servicio(idServicio)
);

create table factura(
numFactura int not null primary key,
nombreEmisor varchar(50) not null,
telEmisor varchar(20) not null,
fecha date,
hora time,
idHuesped int not null,
idRegistro int not null,
idConsumo int not null,
total int not null,
constraint fk_idHuesped3 foreign key (idHuesped) references huesped(idHuesped),
constraint fk_idRegistro foreign key (idRegistro) references registro(idRegistro),
constraint fk_idConsumo foreign key (idConsumo) references consumo(idConsumo)
);


-------------------------------------------------------------------------------------
-- Creamos los triggers que el proyecto lo requiera
/* [ a ]  Selección de un tipo de habitación y que esta permita sugerirle múltiples 
	  	  paquetes de servicios interno o externos al cliente. */
/*create trigger TG_01 on select
as
begin 
end
*/

/* [ b ] Cancelación de una reservación que ya se había completado.
*/

/* [ c ] Modificación de los paquetes que había seleccionado el huésped.

*/

/* [ d ]  Realizar una auditoría de los agentes de mostrador, los cuales presente el nombre del
agente, el tipo de habitación que registro, cuantos días mantendrá dicho registro, y que
paquetes de servicios internos y externos dio de alta con el registro de habitación, si el
agente hizo registros de clientes con más de 3 días de hospedaje, obtiene un bono de
$380.00 por registro, si es de 5 días tendrá un bono de $500.00 pesos por registro y si es
de 10 días en adelante obtendrá un bono de $1500.00 por hospedaje. 
*/