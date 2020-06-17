-- Primero creamos la base de datos
create database hotel5;

-- Luego especificamos la base de datos que vamos a usar
use hotel5;

-- Creamos todas las tablas esenciales para la base de datos con sus columnas y relaciones
create table usuario(
email varchar(30) not null primary key,
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
idHabitacion int identity(1,1) not null primary key,
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
idEmpleado int identity(1,1) not null primary key,
nombre varchar(20) not null,
apellido_pat varchar(15) not null,
apellido_mat varchar(15) not null,
sexo varchar(15) not null,
telefono varchar(20) not null,
correo varchar(30) not null,
rfc varchar(15) not null,
);
go
create table registro(
idRegistro int identity(1,1) not null primary key,
idHuesped int not null,
idHabitacion int not null,
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
drop table factura;
create table factura(
numFactura int identity(1,1) not null primary key,
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



-- Hacemos la inserciones de datos

--Ingresamos los datos de los huespedes
INSERT INTO huesped([nombres],[apellido_pat],[apellido_mat],[edad],[sexo],[fecha_nac],[lugar_nac],[direccion],[tel_casa],[tel_celular],[correo],[rfc],[numVisita]) 
VALUES
('Hayley','Carver','Jackson',29,'F','1980-05-16','Banda Aceh','Gardenia 982, valle verde','01855725499','167605035000','consectetuer@Proin.net','EHKV432719FG',7),
('Nissim','Stuart','Gallagher',22,'M','1981-06-11','Diyarbakır','Apdo.:301-1526 Integer Ctra.','03898186799','168002210006','Vivamus@Quisque.com','PWND647914SU',3),
('Caldwell','Sparks','Mcgowan',28,'F','1974-05-28','Goslar','1842 Metus Carretera','71662389399','160903046514','a@placeratCras.net','IQWQ468198GX',20),
('Zachary','Kirkland','Everett',37,'F','1995-03-23','Ternitz','Apdo.:195-2981 Duis C.','22357902199','160304146277','euismod@risusIn.org','NIFA872119JF',19),
('Kasimir','Mcintosh','Morse',29,'F','2001-06-07','Tijuana','Apdo.:428-5149 Non, Avenida','95753172099','162607055171','dapibus.id@eratse.org','HPBL742552SA',0),
('Owen','Morris','Shepherd',43,'M','1971-08-10','Wells','Apdo.:735-6143 Egestas, Avenida','71581950299','166403109017','iaculis@utodiovel.co.uk','CMMU765976NR',14),
('Leonard','Holden','Aguirre',45,'M','1989-04-24','Barcelona','Apartado núm.: 455, 1565 Sem ','75369436099','162009274198','consectetuer@non.ca','DSBC953574YK',5),
('Kennan','Harrison','Knapp',50,'F','1982-09-06','Bornival','137-9080 Netus Avenida','30384504099','160208015743','pellentesque@Maecenas.com','EXOF848441UC',14),
('Graham','Dyer','Bass',29,'F','1992-10-10','Lille','119-8746 Diam Avenida','94288062299','16151206 3684','Fusce@malesuada.ca','FBTI527554PU',14),
('Merritt','Bradley','Olson',43,'M','1999-12-03','Stavoren','Apartado núm.: 564, 8453 Mi Av.','99292913199','166802165289','.Donec@enim.ca','SAAE418844YV',10);

-- -----------------------------------------------------------------------------------------------------
--Ingresamos los datos de los empleados
INSERT INTO empleado([nombre],[apellido_pat],[apellido_mat],[sexo],[telefono],[correo],[rfc]) 
VALUES
('Branden','Holt','Hunt','F','61887250799','interdum@ceuismodin','QGSJ239993DJ'),
('Uriah','Swanson','Long','F','79339226199','semper@Integer.com','AZGJ322811UG'),
('Connor','Ramirez','Ratliff','F','16554984699','et@ulla.org','UIEN435855SO'),
('Fredericka','Sweeney','Carter','F','41766729699','viverra.Donec@mi.net','PGXT613586VE'),
('Mallory','Cox','Acevedo','M','90704246699','et.magnis@sitame.ca','TSXF156364RP'),
('Hiram','Herman','Burt','M','78831274699','nulla.magna@quama.com','VUTK291583DJ'),
('Kaitlin','Barron','Buchanan','M','24206643999','cursus@amagna.org','TTQR928874BI'),
('Graham','Kim','Hansen','M','67923900899','ipsum.nunc@felis.net','SBMB759556OI'),
('Shelly','Griffin','Kramer','M','43514586499','vel.arcu@nullaCras.net','IHWI924954CL'),
('Scott','Jarvis','Middleton','F','51273803999','amet.metus@pharetra.co.uk','QQVY439714UX'),
('Mary','Mclaughlin','Clark','M','81915086799','nec.tempus@atsem.edu','XCJP749119VN'),
('Tatiana','Rodgers','Stewart','F','04272174399','pede@ullamcorp.net','XVIU189594IH'),
('Hanae','Gilbert','Rosario','M','26836355199','arcu@Pellentesque.com','OYPT754349VG'),
('Travis','Hale','Miles','M','57745911799','vestibulum@justo.co.uk','KGCN122639CQ'),
('Mercedes','Pate','Huff','F','77537676299','rhoncus@magna.net','HTXR936782YV'),
('Leslie','Beach','Warner','F','57737293699','fringilla@incept.uk','CLNE499818LW'),
('Kelly','Davenport','Summers','F','88731566099','amet@risusDonec.co.uk','RABS314499PH'),
('Rashad','Simmons','Bates','F','53998498699','Quisque.libero@cursus.edu','SESL848317XH'),
('Lynn','Strong','Alvarez','F','07630171899','magnis.parturient@Donec.net','ELAW331746EK'),
('Zelenia','West','Maddox','M','97607388799','amet.ultricies@a.net','VTBS234314WK'),
('Ina','Sandoval','Mcmahon','F','49735064599','vel.vulputate@montes','BZKD227165VS'),
('Cooper','Hart','Douglas','M','07449127199','Nulla.eu@amet.net','FVZU426699YR'),
('Hu','Pate','Carr','M','17968507599','nisi@Morbi.com','WCHV137858FT'),
('Ulric','William','Henderson','F','82236059099','enim.commodo@leo','IURB761995MD'),
('Vernon','Stokes','Hanson','F','61817424199','nec@miDuisrisus.org','UUJN159836CW'),
('Blake','Tate','Oneal','M','30932095299','tempus@ele.org','WBML876329BB'),
('Wyatt','Woods','Sutton','F','97666726599','elit@vitaeodio','YZTA725297XN'),
('Tanya','Maxwell','Lott','F','67617005399','nulla.In@etrutrum.edu','TSFM639622SA'),
('Moses','Ferrell','Humphrey','F','19365865599','congue@est.net','MQFG238737CW'),
('Odysseus','Everett','Stuart','F','60628802899','pharetra@co.uk','PCQP718971OX');
select * from empleado;

-- -------------------------------------------------------------------------------------
-- Ingresamos los datos de las habitaciones
select * from habitacion;
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Indivudual','1 persona',1,2500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Indivudual','1 persona',1,2500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Indivudual','1 persona',1,2500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Indivudual','1 persona',1,2500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Indivudual','1 persona',1,2500);

insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Doble','2 personas',1,4500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Doble','2 personas',1,4500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Doble','2 personas',1,4500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Doble','2 personas',1,4500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Doble','2 personas',1,4500);


insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Triple','3 personas',1,7000);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Triple','3 personas',1,7000);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Triple','3 personas',1,7000);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Triple','3 personas',1,7000);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Triple','3 personas',1,7000);


insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Master Suite','20 personas',1,12500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Master Suite','20 personas',1,12500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Master Suite','20 personas',1,12500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Master Suite','20 personas',1,12500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Master Suite','20 personas',1,12500);


insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Junior Suite','10 personas',1,10000);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Junior Suite','10 personas',1,10000);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Junior Suite','10 personas',1,10000);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Junior Suite','10 personas',1,10000);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Junior Suite','10 personas',1,10000);

insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Quad','4 personas',1,8500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Quad','4 personas',1,8500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Quad','4 personas',1,8500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Quad','4 personas',1,8500);
insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Quad','4 personas',1,8500);

insert into habitacion([tipo],[capacidad],[disponibilidad],[precio]) values ('Suite Presidencial','50 personas',1,20000);



-- ---------------------------------------------------------------------------------
-- Ingresamos los datos de los servicio del hotel
select * from servicio;
insert into servicio values ('interno','spa',null,'19:00:00',800);
insert into servicio values ('interno','gimnasio',null,null,1000);
insert into servicio values ('interno','restaurante',null,null,700);
insert into servicio values ('interno','salon de eventos',null,null,1500);
insert into servicio values ('interno','bar',null,'20:00:00.00',200);
insert into servicio values ('interno','discoteque',null,'20:00:00.00',250);
insert into servicio values ('interno','campo de golf',null,null,700);
insert into servicio values ('interno','servicio de alimentos al cuarto',null,null,100);
insert into servicio values ('interno','casino',null,null,200);

insert into servicio values ('externo','Tours de parques de entretenimiento',null,null,100);
insert into servicio values ('externo','museos',null,null,100);
insert into servicio values ('externo','festivales','2020-08-18','17:00:00',100);
insert into servicio values ('externo','zonas históricas',null,null,100);
insert into servicio values ('externo','servicios de traslados',null,null,500);


create proc PROC_01(
@nombreEmiso varchar(20)='dasd',
@telEmisor as varchar(20),
)
as
begin


insert into factura values()
end
;
select * from servicio;

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