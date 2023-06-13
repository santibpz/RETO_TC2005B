-- The most created weapon by players
use wildfrontier;
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


  
