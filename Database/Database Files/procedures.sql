
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

