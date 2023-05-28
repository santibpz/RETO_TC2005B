-- The most created weapons by players

CREATE VIEW most_created_weapon AS
(SELECT w_name from Weapon INNER JOIN 
(SELECT weapon_id, COUNT(weapon_id) AS most_created_weapon_count
FROM Player_Weapon
GROUP BY weapon_id
ORDER BY most_created_weapon_count DESC
LIMIT 1) AS Result USING(weapon_id));


-- El nivel en el que más pierden los jugadores

SELECT lvl_name, COUNT(level_lose_count) AS max_level_lose_count 
FROM G_Level GROUP BY level_lose_count;


-- The two most upgraded weapons in the game
SELECT w.w_name, w.w_type, w.upgrade_count 
FROM Weapon w 
ORDER BY w.upgrade_count DESC 
LIMIT 2;

  
