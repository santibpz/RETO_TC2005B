-- The most created weapons by users



SELECT weapon_id, count AS `most_created_weapon` from

 AS MOST_CREATED where count = MAX(most_created_weapon);
  
SELECT max(count) from
(SELECT weapon_id, COUNT(weapon_id) AS `count` 
FROM Player_Weapon AS count_table GROUP BY weapon_id) as `count`;

  
