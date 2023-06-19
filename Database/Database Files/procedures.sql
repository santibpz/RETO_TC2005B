
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
         SELECT weapon_name, weapon_damage
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


-- procedure to add a resource
DELIMITER //
CREATE PROCEDURE add_resource(IN in_player_id INT, IN in_item_id INT, IN in_quantity INT)

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
        VALUES (in_player_id, in_item_id, 1);
    ELSE
        -- Perform the desired UPDATE operation
        UPDATE player_item
        SET quantity = quantity + 1
		WHERE player_id = in_player_id
		AND item_id = in_item_id;
    END IF;
    
END //
DELIMITER 

-- procedure to add a weapon
DELIMITER //
CREATE PROCEDURE add_weapon(IN in_player_id INT, IN in_weapon_id INT, IN in_weapon_damage INT)

BEGIN
    DECLARE row_count INT; 
    
    -- Check if the row exists
    SELECT COUNT(*) INTO row_count
    FROM player_weapon
    WHERE player_id = in_player_id AND weapon_id = in_weapon_id; -- Use the parameters in the condition

    -- If the row doesn't exist, insert a new row
    IF row_count = 0 THEN
        -- Insert the new row using the parameter values
        INSERT INTO player_weapon (player_id, weapon_id, weapon_damage)
        VALUES (in_player_id, in_weapon_id, in_weapon_damage);
    END IF;
    
END //
DELIMITER 

-- Procedure to store player deaths on every checkpoint

DELIMITER //
CREATE PROCEDURE player_death_on_checkpoint(IN in_checkpoint INT, IN in_player_id INT, IN in_player_lose_count INT)

BEGIN
    DECLARE row_count INT; 
    
    -- Check if the row exists
    SELECT COUNT(*) INTO row_count
    FROM checkpoint_death
    WHERE checkpoint = in_checkpoint AND player_id = in_player_id; -- Use the parameters in the condition

    -- If the row doesn't exist, insert a new row
    IF row_count = 0 THEN
        -- Insert the new row using the parameter values
        INSERT INTO checkpoint_death (checkpoint, player_id, player_lose_count)
        VALUES (in_checkpoint, in_player_id, in_player_lose_count);
	ELSE
        UPDATE checkpoint_death
        SET player_lose_count = player_lose_count + in_player_lose_count
		WHERE checkpoint = in_checkpoint
        AND player_id = in_player_id;
    END IF;
END //
DELIMITER 


-- procedure to add a death type 
DELIMITER //
CREATE PROCEDURE add_death_type(IN in_player_id INT, IN in_death_type_id INT)

BEGIN
    DECLARE row_count INT; 
    
    -- Check if the row exists
    SELECT COUNT(*) INTO row_count
    FROM player_death
    WHERE player_id = in_player_id AND death_type_id = in_death_type_id; -- Use the parameters in the condition

    -- If the row doesn't exist, insert a new row
    IF row_count = 0 THEN
        -- Insert the new row using the parameter values
        INSERT INTO player_death (player_id, death_type_id, death_type_count)
        VALUES (in_player_id, in_death_type_id, 1);
	ELSE
        UPDATE player_death
        SET death_type_count = death_type_count + 1
		WHERE player_id = in_player_id
        AND death_type_id = in_death_type_id;
    END IF;
END //
DELIMITER 


-- procedure to register a weapon upgrade
DELIMITER //
CREATE PROCEDURE add_weapon_upgrade(IN in_weapon_id INT)

BEGIN
        UPDATE weapon
        SET upgrade_count = upgrade_count + 1
		WHERE weapon_id = in_weapon_id;
END //
DELIMITER 


-- procedure to register a weapon upgrade
DELIMITER //
CREATE PROCEDURE add_player_weapon_upgrade(IN in_player_id INT, IN in_weapon_id INT, IN in_weapon_damage INT)

BEGIN
        UPDATE player_weapon
        SET weapon_damage = in_weapon_damage
		WHERE player_id = in_player_id AND 
        weapon_id = in_weapon_id;
END //
DELIMITER 


