
-- statistics graphs

-- The number of players that created a type of weapon
/*
This information can help us 
identify potential issues with
level design and make adjustments 
to provide more varied and balanced
challenges. If a particular weapon 
is consistently favored, it may 
indicate that certain level layouts 
or enemy encounters heavily favor 
that use of that weapon. 

It can also help us identify player preferences 
and allow us to design more enjoyable gameplays.
*/

CREATE VIEW weapons_created_by_players AS
SELECT weapon_name, player_count FROM weapon INNER JOIN
(SELECT weapon_id, COUNT(DISTINCT player_id) AS player_count
FROM Player_Weapon
GROUP BY weapon_id)
AS weapons_by_players
USING (weapon_id); 


-- The number of deaths registered under a type of death

/*
By categorizing and storing the type of death,
 we could analyze the patterns and trends
 in player deaths. This information can highlight
 common causes of death and help identify potential
 issues in gameplay mechanics, level design, or 
 enemy behavior.
*/

CREATE VIEW number_of_player_death_types AS
SELECT death_type, Player_Count FROM Death_Type INNER JOIN
(SELECT death_type_id, COUNT(DISTINCT(player_status_id)) as Player_Count
FROM Player_Death GROUP BY death_type_id) AS Player_Deaths
USING (death_type_id);


-- The number of deaths registered in every checkpoint

/*
If a particular checkpoint consistently records a high number of deaths,
 it may indicate a difficulty spike or a challenging section within the 
 level. This information help us revisit and fine-tune 
 that specific segment to ensure a more balanced and enjoyable experience for players.
*/

CREATE VIEW checkpoint_deaths AS
SELECT checkpoint, SUM(player_lose_count) AS total_lose_count
FROM Checkpoint_Death
GROUP BY checkpoint;


-- The number of upgrades registered for every weapon

/*
By tracking the number of upgrades registered for each weapon, 
we could potentially assess the popularity and effectiveness of 
different weapons throughout the game. This information can help 
us balance the progression system by ensuring that all weapons 
have meaningful upgrades and remain viable options for players at 
different stages of the game.
*/

CREATE VIEW number_of_weapon_upgrades AS
SELECT weapon_name, upgrade_count FROM Weapon;














