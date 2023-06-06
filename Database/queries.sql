-- The most created weapon by players

CREATE VIEW most_created_weapon AS
(SELECT weapon_name from Weapon INNER JOIN 
(SELECT weapon_id, COUNT(weapon_id) AS most_created_weapon_count
FROM Player_Weapon
GROUP BY weapon_id
ORDER BY most_created_weapon_count DESC
LIMIT 1) AS Result USING(weapon_id));



-- The level where players lose the most (hardest level)

CREATE VIEW hardest_level AS
SELECT lvl_name
FROM Game_Level
ORDER BY level_lose_count DESC
LIMIT 1;

-- Which way do players lose the most? Wolf death or Player death

CREATE VIEW most_frequent_death_type AS
SELECT death_type FROM Death_Type INNER JOIN
(SELECT death_type_id, COUNT(death_type_id) AS count
FROM Player_Death GROUP BY death_type_id
ORDER BY count DESC
LIMIT 1) AS Result USING(death_type_id);


-- The two most upgraded weapons in the game

CREATE VIEW most_upgraded_weapons AS
SELECT weapon_name 
FROM Weapon
ORDER BY upgrade_count DESC 
LIMIT 2;

-- PROCEDURES --

-- procedure to fetch player status

DELIMITER //
       CREATE PROCEDURE player_status (IN in_player_id INT)
       BEGIN 
         SELECT completed_levels, current_level, last_checkpoint FROM 
         player INNER JOIN player_status 
         USING(player_id) WHERE player_id = in_player_id;
       END//
DELIMITER 
       
-- procedure to fetch player weapons 


DELIMITER //
       CREATE PROCEDURE player_weapons (IN in_player_id INT)
       BEGIN 
         SELECT weapon_name, weapon_damage, weapon_speed, weapon_reload
         FROM weapon INNER JOIN player_weapon 
         USING(weapon_id) WHERE player_id = in_player_id;
       END//
DELIMITER 

-- procedure to fetch player items

DELIMITER //
       CREATE PROCEDURE player_items (IN in_player_id INT)
       BEGIN 
         SELECT item_name, quantity FROM 
         item_inventory INNER JOIN player_item 
         USING(item_id) WHERE player_id = in_player_id;
       END//
DELIMITER 

-- procedure to update player resources

DELIMITER //
CREATE PROCEDURE update_resources(IN in_player_id INT, IN in_item_id INT, IN in_quantity INT)
BEGIN
    DECLARE row_count INT; 
    
    -- Check if the row exists
    SELECT COUNT(*) INTO row_count
    FROM player_item
    WHERE player_id = in_player_id AND item_id = in_item_id; -- Use the parameters in the condition

    -- If the row doesn't exist, insert a new row
    IF row_count = 0 THEN
        -- Insert the new row using the parameter values
        INSERT INTO player_item (player_id, item_id, quantity)
        VALUES (in_player_id, in_item_id, in_quantity);
    ELSE
        -- Perform the desired UPDATE operation
        UPDATE player_item
        SET quantity = in_quantity
		WHERE player_id = in_player_id
		AND item_id = in_item_id;
    END IF;
    
END //
DELIMITER 



-- statistics graphs

-- The number of player that created a type of weapon

CREATE VIEW weapons_created_by_players AS
SELECT weapon_name, player_count FROM weapon INNER JOIN
(SELECT weapon_id, COUNT(DISTINCT player_id) AS player_count
FROM Player_Weapon
GROUP BY weapon_id)
AS weapons_by_players
USING (weapon_id);


-- The number of players that died a certain way

CREATE VIEW number_of_player_death_types AS
SELECT death_type, Player_Count FROM Death_Type INNER JOIN
(SELECT death_type_id, COUNT(DISTINCT(player_status_id)) as Player_Count
FROM Player_Death GROUP BY death_type_id) AS Player_Deaths
USING (death_type_id);

-- Amount of players that have upgraded a weapon


-- The most collected resource


select * from weapons_created_by_players









