-- Wildfrontier data

INSERT INTO Player (Username, Passw, Email) VALUES
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

INSERT INTO Weapon (w_name, w_type, upgrade_count) VALUES
('Sword', 'Short range', 3),
('Bow', 'Long range', 2),
('Sword', 'Short range', 4),
('Spear', 'Short range', 1),
('Bow', 'Long range', 3),
('Spear', 'Short range', 2),
('Sword', 'Short range', 2),
('Spear', 'Short range', 1),
('Bow', 'Long range', 3),
('Sword', 'Short range', 4);

INSERT INTO Player_Weapon (Player_ID, weapon_id, damage, speed, w_reload) VALUES
(1, 1, 50, 80, 2),
(2, 2, 40, 90, 3),
(3, 3, 60, 70, 2),
(4, 4, 70, 60, 3),
(5, 5, 45, 85, 2),
(6, 6, 55, 75, 3),
(7, 7, 50, 80, 2),
(8, 8, 40, 90, 3),
(9, 9, 60, 70, 2),
(10, 10, 70, 60, 3);

INSERT INTO Item_inventory (item_name, i_type) VALUES
('Health Potion', 'Potion'),
('Mana Potion', 'Potion'),
('Shield', 'Armor'),
('Amulet', 'Accessory'),
('Key', 'Misc'),
('Scroll', 'Misc'),
('Trap', 'Misc'),
('Gloves', 'Armor'),
('Ring', 'Accessory'),
('Gem', 'Misc');

INSERT INTO Player_item (Player_ID, item_id, quantity) VALUES
(1, 1, 5),
(2, 2, 3),
(3, 3, 2),
(4, 4, 1),
(5, 5, 4),
(6, 6, 2),
(7, 7, 3),
(8, 8, 2),
(9, 9, 1),
(10, 10, 4);

INSERT INTO Player_Status (Player_ID, completed_levels, current_level, last_checkpoint) VALUES
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

INSERT INTO G_Level (lvl_name, difficulty, level_lose_count) VALUES
('Level 1', 'Easy', 0),
('Level 2', 'Medium', 1),
('Level 3', 'Hard', 2),
('Level 4', 'Medium', 1),
('Level 5', 'Hard', 3),
('Level 6', 'Easy', 0),
('Level 7', 'Medium', 2),
('Level 8', 'Hard', 3),
('Level 9', 'Medium', 1),
('Level 10', 'Hard', 4);

INSERT INTO Player_level (Player_ID, level_id, player_lose_count) VALUES
(1, 1, 0),
(2, 2, 1),
(3, 3, 2),
(4, 4, 1),
(5, 5, 3),
(6, 6, 0),
(7, 7, 2),
(8, 8, 1),
(9, 9, 2),
(10, 10, 3);

INSERT INTO Death_Count (status_id, wolf_death_count, player_death_count) VALUES
(1, 2, 1),
(2, 0, 3),
(3, 1, 2),
(4, 3, 0),
(5, 2, 2),
(6, 1, 0),
(7, 0, 1),
(8, 2, 2),
(9, 1, 1),
(10, 0, 3);
