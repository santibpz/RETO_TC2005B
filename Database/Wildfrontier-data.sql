-- Wildfrontier data
use wildfrontier;

SET AUTOCOMMIT=0;
INSERT INTO Player (username, password, email) VALUES
('player1', 'password1', 'player1@example.com'),
('player2', 'password2', 'player2@example.com'),
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
('Bow', 'Long range', 2),
('Spear', 'Short range', 4),
('Boomerang', 'Short range', 7);


SET AUTOCOMMIT=0;
INSERT INTO Player_Weapon (player_id, weapon_id, weapon_damage, weapon_speed, weapon_reload) VALUES
(1, 1, 50, 80, 2),
(2, 2, 40, 90, 3),
(3, 3, 60, 70, 2),
(4, 4, 70, 60, 3),
(5, 2, 45, 85, 2),
(6, 1, 55, 75, 3),
(7, 1, 50, 80, 2),
(1, 4, 50, 180, 20),
(8, 2, 40, 90, 3),
(9, 2, 60, 70, 2),
(10, 3, 70, 60, 3);

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
INSERT INTO Player_Status (player_id, completed_levels, current_level, last_checkpoint) VALUES
(1, 5, 6, 3),
(2, 3, 4, 2),
(3, 6, 7, 5),
(4, 4, 5, 3),
(5, 7, 8, 4),
(6, 2, 3, 1),
(7, 8, 9, 6),
(8, 4, 5, 2),
(9, 6, 7, 4),
(10, 3, 4, 2);

SET AUTOCOMMIT=0;
INSERT INTO Game_Level (lvl_name, difficulty, level_lose_count) VALUES
('Level 1', 'Easy', 15),
('Level 2', 'Medium', 21);


SET AUTOCOMMIT=0;
INSERT INTO Player_level (player_id, level_id, player_lose_count) VALUES
(1, 1, 4),
(2, 2, 1),
(3, 2, 2),
(4, 1, 1),
(5, 2, 3),
(6, 1, 7),
(7, 2, 2),
(8, 1, 1),
(9, 1, 2),
(10, 2, 3);

SET AUTOCOMMIT=0;
INSERT INTO Death_Type (death_type) VALUES
('wolf_death'), 
('player_death');

SET AUTOCOMMIT=0;
INSERT INTO Player_Death (player_status_id, death_type_id, death_type_count) VALUES
(2, 2, 5), 
(3, 1, 2), 
(1, 2, 1), 
(1, 1, 6),
(4, 2, 8), 
(5, 1, 9),
(6, 2, 1),
(6, 1, 3),
(2, 1, 2);




