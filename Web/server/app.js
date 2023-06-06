"use strict";

import express from "express";
import mysql from "mysql2/promise";
import fs from "fs";

const app = express();
const port = 3000;

// middlewares
app.use(express.json());
// app.use(express.static('./public'))

const connectToDB = async () => {
  return await mysql.createConnection({
    host: "localhost",
    user: "videogame_user",
    password: "wildfrontier.tec",
    database: "WildFrontier",
  });
};

// endpoint to fetch all players
app.get("/api/players", async (req, res) => {
  try {
    let connection = await connectToDB();
    const [results, fields] = await connection.execute("select * from Player");
    res.json(results);
  } catch (err) {
    console.log(err);
  }
});

// endpoint to create a new player account

app.post('/api/signup', async (req, res) => {
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
    res.status(500).send("There was an error creating the account.\n Try again later.");
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

app.post('/api/login', async (req, res) => {
  const credentials = req.body;
  const { username, password } = credentials;
  let connection = null;
  try {
    connection = await connectToDB();
    const [results, fields] = await connection.query(
      "select player_id, username from Player where username = ? and password = ?",
      [username, password]
    );

    console.log(results)

    const playerFound = results ? results[0] : null // player, if exists
    // console.log("these are results", results)

    !playerFound  // if no player was found, send message `invalid credentials`
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

// Endpoint to fetch the player status

app.get('/api/playerStatus/:id', async (req, res) => {
  let connection = null
  console.log(req.params.id)
  try {
    connection = await connectToDB()
    const [results, fields] = await connection.query("CALL player_status(?)", Number(req.params.id))
    const playerStatus = results ? results[0][0] : null
    console.log(playerStatus)                
    !playerStatus ?
    res.status(400).send("No player status was found") :
    res.status(200).json(playerStatus)

  } catch(err) {
    res.status(500).send("internal server error");
 
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
})

// Endpoint to fetch the player items/resources

app.get('/api/playerItems/:id', async (req, res) => {
  let connection = null
  try {
    connection = await connectToDB()
    const [results, fields] = await connection.query("CALL player_items(?)", Number(req.params.id))
    const playerItems = results ? results[0][0] : null
    console.log(playerItems)                
    !playerItems ?
    res.status(400).send("No player items were found") :
    res.status(200).json(playerItems)

  } catch(err) {
    res.status(500).send("internal server error");
 
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
})

// Endpoint to fetch the player weapons

app.get('/api/playerWeapons/:id', async (req, res) => {
  let connection = null
  try {
    connection = await connectToDB()
    const [results, fields] = await connection.query("CALL player_weapons(?)", Number(req.params.id))
    const playerWeapons = results ? results[0][0] : null
    console.log(playerWeapons)                
    !playerWeapons ?
    res.status(400).send("No player weapons was found") :
    res.status(200).json(playerWeapons)

  } catch(err) {
    res.status(500).send("internal server error");
 
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
})


// Endpoint to update the player resources
 
app.put('/api/updateResources', async (req, res) => {
  const update = req.body
  const { player_id, item_id, quantity } = update

  console.log(update)

  let connection = null   
  try {
    
    connection = await connectToDB()
    const [results, fields] = await connection.query("CALL update_resources(?, ?, ?)", [player_id, item_id, quantity])
    
    console.log("update results", results)
    results.affectedRows == 1 ? // when one row is affected, the update operation was successful
    res.status(200).send('ok') :
    res.status(400).send('Error updating database')

  } catch(err) {  
    console.log("err in catch", err)
    res.status(500).send("internal server error");
 
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
})


//  Game statistics endpoint

// Most created weapons by players 





// app.get("/", (request, response) => {
//   fs.readFile("./public/html/mysqlUseCases.html", "utf8", (err, html) => {
//     if (err) response.status(500).send("There was an error: " + err);
//     console.log("Loading page...");
//     response.send(html);
//   });
// });

// app.get("/api/users", async (request, response) => {
//   let connection = null;

//   try {
//     connection = await connectToDB();
//     const [results, fields] = await connection.execute("select * from users");

//     console.log(`${results.length} rows returned`);
//     response.json(results);
//   } catch (error) {
//     response.status(500);
//     response.json(error);
//     console.log(error);
//   } finally {
//     if (connection !== null) {
//       connection.end();
//       console.log("Connection closed succesfully!");
//     }
//   }
// });

// app.get("/api/users/:id", async (request, response) => {
//   let connection = null;

//   try {
//     connection = await connectToDB();

//     const [results_user, _] = await connection.query(
//       "select * from users where id_users= ?",
//       [request.params.id]
//     );

//     console.log(`${results.length} rows returned`);
//     response.json(results);
//   } catch (error) {
//     response.status(500);
//     response.json(error);
//     console.log(error);
//   } finally {
//     if (connection !== null) {
//       connection.end();
//       console.log("Connection closed succesfully!");
//     }
//   }
// });

// app.post("/api/users", async (request, response) => {
//   let connection = null;

//   try {
//     connection = await connectToDB();

//     const [results, fields] = await connection.query(
//       "insert into users set ?",
//       request.body
//     );

//     console.log(`${results.affectedRows} row inserted`);
//     response.json({
//       message: "Data inserted correctly.",
//       id: results.insertId,
//     });
//   } catch (error) {
//     response.status(500);
//     response.json(error);
//     console.log(error);
//   } finally {
//     if (connection !== null) {
//       connection.end();
//       console.log("Connection closed succesfully!");
//     }
//   }
// });

// app.put("/api/users", async (request, response) => {
//   let connection = null;

//   try {
//     connection = await connectToDB();

//     const [results, fields] = await connection.query(
//       "update users set name = ?, surname = ? where id_users= ?",
//       [request.body["name"], request.body["surname"], request.body["userID"]]
//     );

//     console.log(`${results.affectedRows} rows updated`);
//     response.json({
//       message: `Data updated correctly: ${results.affectedRows} rows updated.`,
//     });
//   } catch (error) {
//     response.status(500);
//     response.json(error);
//     console.log(error);
//   } finally {
//     if (connection !== null) {
//       connection.end();
//       console.log("Connection closed succesfully!");
//     }
//   }
// });

// app.delete("/api/users/:id", async (request, response) => {
//   let connection = null;

//   try {
//     connection = await connectToDB();

//     const [results, fields] = await connection.query(
//       "delete from users where id_users= ?",
//       [request.params.id]
//     );

//     console.log(`${results.affectedRows} row deleted`);
//     response.json({
//       message: `Data deleted correctly: ${results.affectedRows} rows deleted.`,
//     });
//   } catch (error) {
//     response.status(500);
//     response.json(error);
//     console.log(error);
//   } finally {
//     if (connection !== null) {
//       connection.end();
//       console.log("Connection closed succesfully!");
//     }
//   }
// });

app.listen(port, () => {
  console.log(`App listening at http://localhost:${port}`);
});
