-- Wild Frontier Database

drop schema if exists WildFrontier;
create schema WildFrontier;
use wildfrontier;

create table Player(
player_id int unsigned not null auto_increment,
username varchar(30) not null,
password varchar(30) not null,
email varchar (45) not null, 
primary key (player_id)
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Weapon(
weapon_id tinyint unsigned not null auto_increment,
weapon_name varchar(30) not null,
weapon_type varchar(30) not null,
upgrade_count smallint not null,
primary key (weapon_id) 
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Player_Weapon(
player_weapon_id tinyint unsigned not null auto_increment,
player_id int unsigned not null,
weapon_id tinyint unsigned not null,
weapon_damage smallint not null,
weapon_speed smallint not null,
weapon_reload smallint not null,
primary key (player_weapon_id),
foreign key (player_id) references Player (player_id) ON DELETE RESTRICT ON UPDATE CASCADE,
foreign key (weapon_id) references Weapon (weapon_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Item_inventory (
item_id int unsigned not null auto_increment,
item_name varchar(30) not null,
item_type varchar(30) not null,
primary key (item_id)
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Player_Item(
player_item_id tinyint unsigned not null auto_increment,
player_id int unsigned not null,
item_id int unsigned not null,
quantity smallint not null,
primary key (player_item_id),
foreign key (player_id) references Player (player_id) ON DELETE RESTRICT ON UPDATE CASCADE,
foreign key (item_id) references Item_inventory (item_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Player_Status(
player_status_id tinyint unsigned not null auto_increment,
player_id int unsigned not null,
completed_levels smallint not null,
current_level smallint not null,
last_checkpoint smallint not null,
primary key (player_status_id),
foreign key (player_id) references Player (player_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Game_Level(
level_id tinyint unsigned not null auto_increment,
lvl_name varchar(30) not null,
difficulty varchar(30) not null,
level_lose_count smallint not null,
primary key (level_id)
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Player_level(
player_lvl_id tinyint unsigned not null auto_increment,
player_id int unsigned not null,
level_id tinyint unsigned not null,
player_lose_count smallint not null,
primary key (player_lvl_id),
foreign key (player_id) references Player (player_id) ON DELETE RESTRICT ON UPDATE CASCADE,
foreign key (level_id) references Game_Level (level_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


create table Death_Type(
death_type_id tinyint unsigned not null auto_increment,  
death_type varchar(15) not null,
primary key (death_type_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Player_Death(
player_death_id tinyint unsigned not null auto_increment,
player_status_id tinyint unsigned not null,
death_type_id tinyint unsigned not null,
death_type_count smallint not null,
primary key (player_death_id),
foreign key (player_status_id) references Player_Status (player_status_id) ON DELETE RESTRICT ON UPDATE CASCADE,
foreign key (death_type_id) references Death_Type (death_type_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

