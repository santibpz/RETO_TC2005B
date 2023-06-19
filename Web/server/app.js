"use strict";

import cors from "cors";
import express from "express";
import mysql from "mysql2/promise";
import fs from "fs";
import { Console } from "console";

const app = express();
const port = 3000;

// middlewares

app.use(cors({ origin: "http://127.0.0.1:3000" }));

app.use(express.json());

app.use(express.static("./client"));

const connectToDB = async () => {
  return await mysql.createConnection({
    host: "localhost",
    user: "videogame_user",
    password: "wildfrontier.tec",
    database: "WildFrontier",
  });
};


// website
app.get("/", (request, response) => {
  fs.readFile("./client/pages/index.html", "utf8", (err, html) => {
    if (err) response.status(500).send("There was an error: " + err);
    console.log("Loading page...");
    response.send(html);
  });
});


// endpoint to create a new player account

app.post("/api/signup", async (req, res) => {
  //console.log("body of request: ", req.body)
  const newPlayer = req.body;
  const { username, password, email } = newPlayer;
  let connection = null;
  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(
      "insert into Player(username, password, email) values(?, ?, ?)",
      [username, password, email]
    );
    // res.json(results)
    console.log(results);
    if (results.serverStatus == 2) {
      res.status(200).send("Account Successfully Created");
    }
    console.log("results of post op: ", results);
  } catch (err) {
    res
      .status(500)
      .send("There was an error creating the account.\n Try again later.");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

app.post("/api/login", async (req, res) => {
  const credentials = req.body;
  const { username, password } = credentials;
  let connection = null;
  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(
      "select player_id, username from Player where username = ? and password = ?",
      [username, password]
    );

    console.log(results);

    const playerFound = results ? results[0] : null; // player, if exists
    // console.log("these are results", results)

    !playerFound // if no player was found, send message `invalid credentials`
      ? res.status(400).send("invalid credentials") // invalid credentials message
      : res.status(200).json(playerFound); // send player if found
  } catch (err) {
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end(); 
      console.log("Connection closed succesfully!");
    }
  }
});


// Endpoint to fetch the player items/resources

app.get("/api/playerItems/:id", async (req, res) => {
  let connection = null;
  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(
      "CALL player_items(?)",
      Number(req.params.id)
    );
    console.log(results);
    const playerItems = results ? results[0] : null;
    console.log(playerItems);
    !playerItems ? res.sendStatus(404) : res.status(200).json(playerItems);
  } catch (err) {
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

// Endpoint to fetch the player weapons

app.get("/api/playerWeapons/:id", async (req, res) => {
  let connection = null;
  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(
      "CALL player_weapons(?)",
      Number(req.params.id)
    );
    const playerWeapons = results ? results[0] : null;
    console.log(playerWeapons);
    !playerWeapons ? res.sendStatus(404) : res.status(200).json(playerWeapons);
  } catch (err) {
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});



// endpoint to add one resource to the database

app.put("/api/addResource", async (req, res) => {
  const update = req.body;
  const { player_id, item_id, quantity } = update;

  console.log(update);

  let connection = null;
  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(
      "CALL add_resource(?, ?, ?)",
      [player_id, item_id, quantity]
    );

    console.log("update results", results);
    results.affectedRows == 1 // when one row is affected, the update operation was successful
      ? res.status(200).send("ok")
      : res.status(400).send("Error updating database");
  } catch (err) {
    console.log("err in catch", err);
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

// endpoint to add a weapon of a player to the database

app.post("/api/addWeapon", async (req, res) => {
  const data = req.body;
  const { player_id, weapon_id, weapon_damage } = data;

  let connection = null;
  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(
      "CALL add_weapon(?, ?, ?)",
      [player_id, weapon_id, weapon_damage]
    );

    results.affectedRows == 1 // when one row is affected, the update operation was successful
      ? res.status(200).send("ok")
      : res.status(400).send("Bad Request");
  } catch (err) {
    console.log("err in catch", err);
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

// Endpoint to update the player resources

app.put("/api/updateResources", async (req, res) => {
  const update = req.body;
  const { player_id, item_id, quantity } = update;

  console.log(update);

  let connection = null;
  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(
      "CALL update_resources(?, ?, ?)",
      [player_id, item_id, quantity]
    );

    console.log("update results", results);
    results.affectedRows == 1 // when one row is affected, the update operation was successful
      ? res.status(200).send("ok")
      : res.status(400).send("Error updating database");
  } catch (err) {
    console.log("err in catch", err);
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

// Endpoint to register checkpoint deaths

app.post("/api/checkpointDeath", async (req, res) => {
  let connection = null;
  const data = req.body;

  const { checkpoint, player_id, player_lose_count } = data;

  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(
      "call player_death_on_checkpoint(?, ?, ?)",
      [checkpoint, player_id, player_lose_count]
    );

    console.log("ress are", results);
    results ? res.status(200).json(results) : res.sendStatus(404);
  } catch (err) {
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

// Endpoint to register a type of death

app.post("/api/addDeathType", async (req, res) => {
  let connection = null;
  const data = req.body;

  const { player_id, death_type_id } = data;

  console.log("daskam", data);

  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(
      "call add_death_type(?, ?)",
      [player_id, death_type_id]
    );

    console.log("ress are", results);
    results ? res.status(200).json(results) : res.sendStatus(404);
  } catch (err) {
    console.log(err);
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

// Endpoint to register a type of death

app.post("/api/addWeaponUpgrade", async (req, res) => {
  let connection = null;
  const data = req.body;

  const { weapon_id } = data;

  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(   
      "call add_weapon_upgrade(?)",
      [weapon_id]
    );

    console.log("ress are", results);
    results ? res.status(200).json(results) : res.sendStatus(404);
  } catch (err) {
    console.log(err);
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});


// Endpoint to add a weapon upgrade of a player

app.post("/api/addPlayerWeaponUpgrade", async (req, res) => {
  let connection = null;
  const data = req.body;

  const { player_id, weapon_id, weapon_damage } = data;

  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(   
      "call add_player_weapon_upgrade(?, ?, ?)",
      [player_id, weapon_id, weapon_damage]
    );

    console.log("results are: ", results);
    results ? res.status(200).json(results) : res.sendStatus(404);
  } catch (err) {
    console.log(err);
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});


//  Game statistics endpoint

// Most created weapons by players

app.get("/api/createdWeaponsChart", async (req, res) => {
  let connection = null;

  try {
    connection = await connectToDB();
    const [results, fields] = await connection.execute(
      "select * from weapons_created_by_players"
    );

    results ? res.status(200).json(results) : res.sendStatus(404);
  } catch (err) {
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

// endpoint to fetch information on the number of deaths registered on each type

app.get("/api/playerDeathTypes", async (req, res) => {
  let connection = null;

  try {
    connection = await connectToDB();
    const [results, fields] = await connection.execute(
      "select * from number_of_player_death_types"
    );

    results ? res.status(200).json(results) : res.sendStatus(404);
  } catch (err) {
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

// endpoint to fetch information on the upgrades or the weapons of all player

app.get("/api/weaponUpgrades", async (req, res) => {
  let connection = null;

  try {
    connection = await connectToDB();
    const [results, fields] = await connection.execute(
      "select * from number_of_weapon_upgrades"
    );

    results ? res.status(200).json(results) : res.sendStatus(404);
  } catch (err) {
    res.status(500).send("internal server error");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

// endpoint to fetch information on the deaths in every checkpoint

app.get("/api/checkpointDeaths", async (req, res) => {
  let connection = null;

  try {
    connection = await connectToDB();
    const [results, fields] = await connection.execute(
      "select * from checkpoint_deaths"
    );

    results ? res.status(200).json(results) : res.sendStatus(404);
  } catch (err) {
    res.status(500).send("internal server error");
  } finally { 
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
})

let PORT = 3000
app.listen(PORT, () => {
  console.log(`listening on port ${PORT}`)
})