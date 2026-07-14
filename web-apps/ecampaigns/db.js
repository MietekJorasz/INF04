const mysql = require("mysql2");

const db = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "",
  database: "ecampaigns",
});

db.connect((err) => {
  if (err) throw err;
  console.log("Połączono z bazą MySQL!");
});

module.exports = db;
