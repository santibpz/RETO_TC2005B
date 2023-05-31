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
    res.json(results)
  } catch (err) {
    console.log(err);
  }
});

// endpoint to create a new player account

app.post("/api/signup", async (req, res) => {
    //console.log("body of request: ", req.body)
    const newPlayer = req.body
    const {username, password, email} = newPlayer
    try {
        let connection = await connectToDB()
        const [results, fields] = connection.query("insert into Player(username, password, email) values(?, ?, ?)", [username, password, email])
        res.json(results)
    } catch(err) {
        console.log(err)
    }
})

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
