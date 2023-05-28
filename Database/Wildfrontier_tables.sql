-- Wild Frontier Database

create schema WildFrontier;
use wildfrontier;

create table Player(
Player_ID tinyint unsigned not null auto_increment,
Username varchar(30) not null,
Passw varchar(30) not null,
Email varchar (45) not null, 
primary key (Player_ID)
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Weapon(
weapon_id tinyint unsigned not null auto_increment,
w_name varchar(30) not null,
w_type varchar(30) not null,
upgrade_count smallint not null,
primary key (weapon_id) 
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Player_Weapon(
player_weapon_id tinyint unsigned not null auto_increment,
Player_ID tinyint unsigned not null,
weapon_id tinyint unsigned not null,
damage smallint not null,
speed smallint not null,
w_reload smallint not null,
primary key (player_weapon_id),
foreign key (Player_ID) references Player (Player_ID) ON DELETE RESTRICT ON UPDATE CASCADE,
foreign key (weapon_id) references Weapon (weapon_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Item_inventory (
item_id tinyint unsigned not null auto_increment,
item_name varchar(30) not null,
i_type varchar(30) not null,
primary key (item_id)
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Player_item(
player_item_id tinyint unsigned not null auto_increment,
Player_ID tinyint unsigned not null,
item_id tinyint unsigned not null,
quantity smallint not null,
primary key (player_item_id),
foreign key (player_id) references Player (Player_ID) ON DELETE RESTRICT ON UPDATE CASCADE,
foreign key (item_id) references Item_inventory (item_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Player_Status(
status_id tinyint unsigned not null auto_increment,
Player_ID tinyint unsigned not null,
completed_levels smallint not null,
current_level smallint not null,
last_checkpoint smallint not null,
primary key (status_id),
foreign key (Player_ID) references Player (Player_ID) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table G_Level(
level_id tinyint unsigned not null auto_increment,
lvl_name varchar(30) not null,
difficulty varchar(30) not null,
level_lose_count smallint not null,
primary key (level_id)
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Player_level(
player_lvl_id tinyint unsigned not null auto_increment,
Player_ID tinyint unsigned not null,
level_id tinyint unsigned not null,
player_lose_count smallint not null,
primary key (player_lvl_id),
foreign key (Player_ID) references Player (Player_ID) ON DELETE RESTRICT ON UPDATE CASCADE,
foreign key (level_id) references G_Level (level_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Death_Count(
death_count_id tinyint unsigned not null auto_increment,
status_id tinyint unsigned not null,
wolf_death_count smallint not null,
player_death_count smallint not null,
primary key (death_count_id),
foreign key (status_id) references Player_Status (status_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

