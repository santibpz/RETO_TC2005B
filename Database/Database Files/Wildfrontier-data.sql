-- Wildfrontier data
use wildfrontier;

SET AUTOCOMMIT=0;
INSERT INTO Player (username, password, email) VALUES
('nuevo', 'contraseña', 'sbp@gmail.com'),
('player2', 'password2', 'jugador@gmail.com'),
('player3', 'password3', 'player3@example.com'),
('player4', 'password4', 'player4@example.com'),
('player5', 'password5', 'player5@example.com'),
('player6', 'password6', 'player6@example.com'),
('player7', 'password7', 'player7@example.com'),
('player8', 'password8', 'player8@example.com'),
('player9', 'password9', 'player9@example.com'),
('player10', 'password10', 'player10@example.com');

SET AUTOCOMMIT=0;
INSERT INTO Weapon (weapon_name, weapon_type, upgrade_count) VALUES
('Sword', 'Short range', 3),
('Stone Knife', 'Long range', 6),
('Spear', 'Short range', 2);

SET AUTOCOMMIT=0;
INSERT INTO Player_Weapon (player_id, weapon_id, weapon_damage) VALUES
(1, 1, 50),
(2, 2, 40),
(3, 3, 60),
(4, 2, 70),
(5, 2, 45),
(6, 1, 55),
(7, 1, 50),
(1, 2, 50),
(8, 2, 40),
(9, 2, 60),
(10, 3, 70);

SET AUTOCOMMIT=0;
INSERT INTO Item_inventory (item_name, item_type) VALUES
('wood', 'resource'),
('rock', 'resource'),
('blue healing remedies', 'remedy'),
('red healing remedies', 'remedy'),
('blue potion', 'potion'),
('red potion', 'potion');


SET AUTOCOMMIT=0;
INSERT INTO Player_Item (player_id, item_id, quantity) VALUES
(1, 1, 5),
(2, 2, 3),
(3, 3, 2),
(4, 4, 1),
(5, 5, 4),
(6, 6, 2),
(7, 1, 3),
(8, 2, 2),
(9, 3, 1),
(10, 6, 4);



SET AUTOCOMMIT=0;
INSERT INTO Checkpoint_Death (checkpoint, player_id, player_lose_count) VALUES
(1, 2, 5),
(2, 1, 3),
(3, 3, 6),
(2, 2, 1),
(4, 4, 10),
(1, 5, 5),
(3, 6, 6),
(1, 7, 4),
(1, 8, 3),
(2, 9, 8),
(4, 3, 1),
(3, 10, 5);

SET AUTOCOMMIT=0;
INSERT INTO Death_Type (death_type) VALUES
('wolf_death'), 
('player_death');

SET AUTOCOMMIT=0;
INSERT INTO Player_Death (player_id, death_type_id, death_type_count) VALUES
(2, 2, 5), 
(3, 1, 2), 
(1, 2, 1), 
(1, 1, 6),
(4, 2, 8), 
(5, 1, 9),
(6, 2, 1),
(6, 1, 3),
(2, 1, 2);




