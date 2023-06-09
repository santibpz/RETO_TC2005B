
-- statistics graphs

-- The number of players that created a type of weapon

CREATE VIEW weapons_created_by_players AS
SELECT weapon_name, player_count FROM weapon INNER JOIN
(SELECT weapon_id, COUNT(DISTINCT player_id) AS player_count
FROM Player_Weapon
GROUP BY weapon_id)
AS weapons_by_players
USING (weapon_id);


-- The number of deaths registered under a type of death

CREATE VIEW number_of_player_death_types AS
SELECT death_type, Player_Count FROM Death_Type INNER JOIN
(SELECT death_type_id, COUNT(DISTINCT(player_status_id)) as Player_Count
FROM Player_Death GROUP BY death_type_id) AS Player_Deaths
USING (death_type_id);


-- The number of deaths registered in every checkpoint

CREATE VIEW checkpoint_deaths AS
SELECT checkpoint, SUM(player_lose_count) AS total_lose_count
FROM Checkpoint_Death
GROUP BY checkpoint;


-- The number of upgrades registered for every weapon

CREATE VIEW number_of_weapon_upgrades AS
SELECT weapon_name, upgrade_count FROM Weapon;














