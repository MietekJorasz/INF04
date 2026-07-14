const express = require("express");
const nodemailer = require("nodemailer");
const session = require("express-session");
const { parse } = require("csv-parse/sync");
const multer = require("multer");
const bcrypt = require("bcryptjs");
const bodyParser = require("body-parser");
const fs = require("fs");
const db = require("./db");

const app = express();
const port = 3000;
const upload = multer({ storage: multer.memoryStorage() });

app.use(express.static("./resources/"));
app.use("/bootstrap", express.static("node_modules/bootstrap/dist"));
app.use("/icons", express.static("node_modules/bootstrap-icons/font"));

app.use(bodyParser.urlencoded({ extended: false }));
app.use(express.json());

app.use(
  session({
    secret: "tajny_klucz_sesji",
    resave: false,
    saveUninitialized: false,
  })
);

/* LANDING PAGE - START */

let navigation = fs
  .readFileSync("./assets/html/components/navigation.html")
  .toString();

let footer = fs.readFileSync("./assets/html/components/footer.html").toString();

app.get("/", (req, res) => {
  let mainPage = fs.readFileSync("./assets/html/index.html").toString();

  mainPage = mainPage
    .replace("{{CONTENT}}", navigation)
    .replace("{{ACTIVE}}", "active")
    .replace("{{FOOTER}}", footer);

  res.send(mainPage);
});

app.get("/templates", (req, res) => {
  let aboutPage = fs.readFileSync("./assets/html/templates.html").toString();

  aboutPage = aboutPage
    .replace("{{CONTENT}}", navigation)
    .replace("{{ACTIVE1}}", "active");

  res.send(aboutPage);
});

app.get("/campaign", (req, res) => {
  let campaignPage = fs.readFileSync("./assets/html/campaign.html").toString();

  campaignPage = campaignPage
    .replace("{{CONTENT}}", navigation)
    .replace("{{ACTIVE2}}", "active");

  res.send(campaignPage);
});

app.get("/recipients", (req, res) => {
  let campaignPage = fs
    .readFileSync("./assets/html/recipients.html")
    .toString();

  campaignPage = campaignPage
    .replace("{{CONTENT}}", navigation)
    .replace("{{ACTIVE3}}", "active");

  res.send(campaignPage);
});

/* LANDING PAGE - END */

/* REGISTER, LOG - START */

app.get("/signup", (req, res) => {
  if (req.session.user) {
    return res.redirect("/dashboard");
  }
  let mainPage = fs
    .readFileSync("./assets/html/signup.html")
    .toString()
    .replace("{{ERROR}}", "");

  res.send(mainPage);
});

app.post("/signup", (req, res) => {
  let mainPage = fs.readFileSync("./assets/html/signup.html").toString();
  const { email, password, subscription_plan, company_name } = req.body;

  console.log(req.body);

  db.query(
    `SELECT email FROM users WHERE email = '${email}'`,
    async (err, results) => {
      if (results.length > 0) {
        return res.send(
          mainPage.replace(
            "{{ERROR}}",
            "Użytkownik o podanym emailu już istnieje."
          )
        );
      }

      const hashedPassword = await bcrypt.hash(password, 10);

      let query = `INSERT INTO users(email, password, company_name, subscription_plan) VALUES ('${email}','${hashedPassword}','${company_name}','${subscription_plan}')`;

      db.query(query, (err) => {
        if (err) throw err;
        res.redirect("/signin");
      });
    }
  );
});

app.get("/signin", (req, res) => {
  if (req.session.user) {
    return res.redirect("/dashboard");
  }
  let mainPage = fs
    .readFileSync("./assets/html/signin.html")
    .toString()
    .replace("{{ERROR1}}", "")
    .replace("{{ERROR2}}", "");

  res.send(mainPage);
});

app.post("/signin", (req, res) => {
  let mainPage = fs.readFileSync("./assets/html/signin.html").toString();
  const { email, password } = req.body;

  db.query(
    "SELECT * FROM users WHERE email = ?",
    email,
    async (err, results) => {
      if (results.length === 0) {
        return res.send(
          mainPage
            .replace("{{ERROR1}}", "Nie znaleziono użytkownika.")
            .replace("{{ERROR2}}", "")
        );
      }

      const user = results[0];
      const isMatch = await bcrypt.compare(password, user.password);

      if (!isMatch)
        return res.send(
          mainPage
            .replace("{{ERROR2}}", "Nieprawidłowe hasło.")
            .replace("{{ERROR1}}", "")
        );

      req.session.user = { id: user.id, email: user.email };
      res.redirect("/dashboard");
    }
  );
});

/* REGISTER, LOG - END */

/* DASHBOARD - START */

let navigation_dashboard = fs
  .readFileSync("./assets/html/components/navigation_dashboard.html")
  .toString();

let sidebar_dashboard = fs
  .readFileSync("./assets/html/components/sidebar_dashboard.html")
  .toString();

let my_campaigns = fs
  .readFileSync("./assets/html/components/my_campaigns.html")
  .toString();

let my_templates = fs
  .readFileSync("./assets/html/components/my_templates.html")
  .toString();

let my_recipents = fs
  .readFileSync("./assets/html/components/my_recipents.html")
  .toString();

app.get("/dashboard", (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }

  let content = "";
  let temp = "";

  console.log(req.session.user.id);

  db.query(
    `SELECT * FROM campaigns WHERE user_id = ${req.session.user.id}`,
    (err, result, field) => {
      if (result < 1) {
        content =
          "<a href='/addCampaign'><div class='box add'><i class='bi bi-plus-circle'></i></div></a>";
      } else {
        result.forEach((element) => {
          if (element.title.length <= 21) {
            content += `<a href='/campaign/${element.email_template_id}'><div class='box bg-primary'>
                            <div class='image bg-primary'></div>
                            <div class='details'>${element.title}</div>
                          </div></a>`;
          } else {
            temp = element.title.substring(0, 20) + "...";
            content += `<a href='/campaign/${element.email_template_id}'><div class='box bg-primary'>
                                <div class='image'></div>
                                <div class='details'>${temp}</div>
                          </div></a>`;
          }
        });

        content +=
          "<a href='/addCampaign'><div class='box add'><i class='bi bi-plus-circle'></i></div></a>";

        let mainPage = fs
          .readFileSync("./assets/html/dashboard.html")
          .toString()
          .replace("{{MAIN}}", my_campaigns)
          .replace("{{SEARCH}}", "")
          .replace("{{CONTENT}}", content)
          .replace("{{SIDEBAR}}", sidebar_dashboard)
          .replace("{{active1}}", "active")
          .replace("{{NAVIGATION}}", navigation_dashboard)
          .replace("{{USER_NAME}}", req.session.user.email);

        res.send(mainPage);
      }
    }
  );
});

app.post("/dashboardSearch", (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }

  let search = req.body.search;

  let query = `SELECT * FROM campaigns WHERE campaigns.title LIKE '%${search}%';`;

  let content = "";

  db.query(query, (err, result, field) => {
    if (result < 1) {
      content =
        "<a href='/addCampaign'><div class='box add'><i class='bi bi-plus-circle'></i></div></a>";
    } else {
      result.forEach((element) => {
        if (element.title.length <= 21) {
          content += `<a href='/campaign/${element.email_template_id}'><div class='box bg-primary'>
                            <div class='image bg-primary'></div>
                            <div class='details'>${element.title}</div>
                          </div><a>`;
        } else {
          temp = element.title.substring(0, 20) + "...";
          content += `<a href='/campaign/${element.email_template_id}'><div class='box bg-primary'>
                                <div class='image'></div>
                                <div class='details'>${temp}</div>
                          </div></a>`;
        }
      });

      content +=
        "<a href='/addCampaign'><div class='box add'><i class='bi bi-plus-circle'></i></div></a>";

      let mainPage = fs
        .readFileSync("./assets/html/dashboard.html")
        .toString()
        .replace("{{MAIN}}", my_campaigns)
        .replace(
          "{{SEARCH}}",
          `<p style='margin-bottom: 20px;'>Znaleziono ${result.length} kampanię, <a href='/dashboard' class='link-primary'>Resetuj</a></p>`
        )
        .replace("{{CONTENT}}", content)
        .replace("{{SIDEBAR}}", sidebar_dashboard)
        .replace("{{active1}}", "active")
        .replace("{{NAVIGATION}}", navigation_dashboard)
        .replace("{{USER_NAME}}", req.session.user.email);

      res.send(mainPage);
    }
  });
});

app.post("/sendCampaign", async (req, res) => {
  if (!req.session.user) return res.redirect("/");

  const userId = req.session.user.id;
  const { campaignId } = req.body;

  const query = `
    SELECT c.id AS campaign_id,
           c.title AS campaign_title,
           c.email_template_id,
           t.title AS template_title,
           t.html_template
    FROM campaigns c
    INNER JOIN emailTemplates t ON c.email_template_id = t.id
    WHERE c.user_id = ? AND c.id = ?
    LIMIT 1
  `;

  db.query(query, [userId, campaignId], (err, result) => {
    if (err) {
      console.error(err);
      return res.status(500).send("Błąd serwera");
    }

    if (result.length === 0) {
      return res.status(404).send("Kampania nie istnieje.");
    }

    const campaign = result[0];

    db.query(
      "SELECT email FROM clients WHERE user_id = ?",
      [userId],
      (err, cResult) => {
        if (err) {
          console.error(err);
          return res.status(500).send("Błąd serwera");
        }

        if (cResult.length === 0) {
          return res.status(400).send("Brak klientów.");
        }

        const transporter = nodemailer.createTransport({
          host: "smtp.gmail.com",
          port: 465,
          secure: true,
          auth: {
            user: "joraszmietek@gmail.com",
            pass: "yedjaxymjlpctwfn",
          },
        });

        let sentCount = 0;

        cResult.forEach((client) => {
          const mailOptions = {
            from: `"Twoja Aplikacja" <twoj_email@gmail.com>`,
            to: client.email,
            subject: campaign.template_title,
            html: campaign.html_template,
          };

          transporter.sendMail(mailOptions, (err) => {
            if (err) {
              console.error("Błąd wysyłania do:", client.email, err);
            } else {
              console.log("Wysłano do:", client.email);
            }

            sentCount++;

            if (sentCount === cResult.length) {
              db.query(
                "UPDATE campaigns SET status='sent' WHERE id=?",
                [campaignId],
                () => {
                  return res.redirect("/dashboard");
                }
              );
            }
          });
        });
      }
    );
  });
});

app.get("/campaign/:id_campaign", (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }
  let id = req.params.id_campaign;

  const query = `
    SELECT c.id AS campaign_id, 
           c.user_id, 
           c.title AS campaign_title, 
           c.description, 
           t.id AS template_id, 
           t.title AS template_title, 
           t.html_template
    FROM campaigns c
    INNER JOIN emailTemplates t 
      ON c.email_template_id = t.id
    WHERE c.user_id = ? AND t.id = ?
    LIMIT 1
  `;

  db.query(query, [req.session.user.id, id], (err, result) => {
    if (err) {
      console.error(err);
      return res.redirect("/dashboard");
    }

    if (result.length === 0) {
      return res.redirect("/dashboard");
    }

    const campaign = result[0];

    let content = fs
      .readFileSync("./assets/html/components/campaign_dashboard.html")
      .toString()
      .replace("{{target}}", "updateCampaign")
      .replace("{{campaignId}}", campaign.campaign_id)
      .replace("{{templateId}}", campaign.template_id)
      .replace("{{campaignTitle}}", campaign.campaign_title)
      .replace("{{campaignDescription}}", campaign.description)
      .replace("{{emailTitle}}", campaign.template_title)
      .replace("{{emailHtml}}", campaign.html_template);

    let mainPage = fs
      .readFileSync("./assets/html/dashboard.html")
      .toString()
      .replace("{{MAIN}}", content)
      .replace("{{SIDEBAR}}", sidebar_dashboard)
      .replace("{{active1}}", "active")
      .replace("{{NAVIGATION}}", navigation_dashboard)
      .replace("{{USER_NAME}}", req.session.user.email);

    res.send(mainPage);
  });
});

app.post("/updateCampaign", async (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }
  const {
    campaignId,
    templateId,
    campaignTitle,
    campaignDescription,
    emailTitle,
    emailHtml,
  } = req.body;

  db.query("UPDATE campaigns SET title=?, description=? WHERE id=?", [
    campaignTitle,
    campaignDescription,
    campaignId,
  ]);

  console.log({ emailTitle, emailHtml });

  db.query(
    "UPDATE emailTemplates SET title=?, html_template=? WHERE id=?",
    [emailTitle, emailHtml, templateId],
    (result) => {
      console.log(result);
    }
  );

  res.redirect("/dashboard");
});

app.get("/addCampaign", (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }
  let content = fs
    .readFileSync("./assets/html/components/campaign_dashboard.html")
    .toString()
    .replace("{{target}}", "addCampaign")
    .replace("{{campaignId}}", "")
    .replace("{{templateId}}", "")
    .replace("{{campaignTitle}}", "")
    .replace("{{campaignDescription}}", "")
    .replace("{{emailTitle}}", "")
    .replace("{{emailHtml}}", "");

  let mainPage = fs
    .readFileSync("./assets/html/dashboard.html")
    .toString()
    .replace("{{MAIN}}", content)
    .replace("{{SIDEBAR}}", sidebar_dashboard)
    .replace("{{active1}}", "active")
    .replace("{{NAVIGATION}}", navigation_dashboard)
    .replace("{{USER_NAME}}", req.session.user.email);

  res.send(mainPage);
});

app.post("/addCampaign", (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }
  const { campaignTitle, campaignDescription, emailTitle, emailHtml } =
    req.body;
  db.query(
    "INSERT INTO emailTemplates (title, html_template) VALUES (?, ?)",
    [emailTitle, emailHtml],
    (err, templateResult) => {
      if (err) return res.status(500).send("Błąd przy tworzeniu szablonu");

      const newTemplateId = templateResult.insertId;

      db.query(
        "INSERT INTO campaigns (user_id, title, description, email_template_id) VALUES (?, ?, ?, ?)",
        [
          req.session.user.id,
          campaignTitle,
          campaignDescription,
          newTemplateId,
        ],
        (err) => {
          if (err) return res.status(500).send("Błąd przy tworzeniu kampanii");
          res.redirect("/dashboard");
        }
      );
    }
  );
});

app.get("/dashboardTemplates", (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }

  let content = "";
  let temp = "";

  console.log(req.session.user.id);

  db.query(
    "SELECT * FROM emailtemplates WHERE emailtemplates.pre_made = 1;",
    (err, result, field) => {
      if (result < 1) {
        content = "<div class='box'>Brak gotowych templatek</div>";
      } else {
        result.forEach((element) => {
          if (element.title.length <= 21) {
            content += `<a href='/template/${element.id}'><div class='box bg-primary'>
                            <div class='image bg-primary'></div>
                            <div class='details'>${element.title}</div>
                          </div></a>`;
          } else {
            temp = element.title.substring(0, 20) + "...";
            content += `<a href='/template/${element.id}'><div class='box bg-primary'>
                                <div class='image'></div>
                                <div class='details'>${temp}</div>
                          </div></a>`;
          }
        });

        let mainPage = fs
          .readFileSync("./assets/html/dashboard.html")
          .toString()
          .replace("{{MAIN}}", my_templates)
          .replace("{{SEARCH}}", "")
          .replace("{{CONTENT}}", content)
          .replace("{{SIDEBAR}}", sidebar_dashboard)
          .replace("{{active2}}", "active")
          .replace("{{NAVIGATION}}", navigation_dashboard)
          .replace("{{USER_NAME}}", req.session.user.email);

        res.send(mainPage);
      }
    }
  );
});

app.post("/templateSearch", (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }

  let search = req.body.search;

  let query = `SELECT * FROM emailtemplates WHERE emailtemplates.title LIKE '%${search}%' AND pre_made = 1;`;

  let content = "";

  db.query(query, (err, result, field) => {
    if (result < 1) {
      content = "";
    } else {
      result.forEach((element) => {
        if (element.title.length <= 21) {
          content += `<a href='/template/${element.id}'><div class='box bg-primary'>
                            <div class='image bg-primary'></div>
                            <div class='details'>${element.title}</div>
                          </div></a>`;
        } else {
          temp = element.title.substring(0, 20) + "...";
          content += `<a href='/template/${element.id}'><div class='box bg-primary'>
                                <div class='image'></div>
                                <div class='details'>${temp}</div>
                          </div></a>`;
        }
      });
      let mainPage = fs
        .readFileSync("./assets/html/dashboard.html")
        .toString()
        .replace("{{MAIN}}", my_templates)
        .replace(
          "{{SEARCH}}",
          `<p style='margin-bottom: 20px;'>Znaleziono ${result.length}, <a href='/dashboardTemplates' class='link-primary'>Resetuj</a></p>`
        )
        .replace("{{CONTENT}}", content)
        .replace("{{SIDEBAR}}", sidebar_dashboard)
        .replace("{{active2}}", "active")
        .replace("{{NAVIGATION}}", navigation_dashboard)
        .replace("{{USER_NAME}}", req.session.user.email);

      res.send(mainPage);
    }
  });
});

app.get("/template/:id_template", (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }
  let id = req.params.id_template;

  const query =
    "SELECT * FROM emailtemplates WHERE emailtemplates.pre_made = 1 AND emailtemplates.id = ?;";

  db.query(query, [id], (err, result) => {
    if (err) {
      console.error(err);
      return res.redirect("/dashboardTemplates");
    }

    if (result.length === 0) {
      return res.redirect("/dashboardTemplates");
    }

    const template = result[0];

    let content = fs
      .readFileSync("./assets/html/components/template_dashboard.html")
      .toString()
      .replace("{{emailTitle}}", template.title)
      .replace("{{emailHtml}}", template.html_template);

    let mainPage = fs
      .readFileSync("./assets/html/dashboard.html")
      .toString()
      .replace("{{MAIN}}", content)
      .replace("{{SIDEBAR}}", sidebar_dashboard)
      .replace("{{active2}}", "active")
      .replace("{{NAVIGATION}}", navigation_dashboard)
      .replace("{{USER_NAME}}", req.session.user.email);

    res.send(mainPage);
  });
});

app.get("/dashboardRecipents", (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }

  let content = "";
  let temp = "";

  db.query(
    `SELECT * FROM clients WHERE user_id = ${req.session.user.id}`,
    (err, result, field) => {
      if (result < 1) {
        content =
          "<a href='/addRecipent'><div class='box add'><i class='bi bi-plus-circle'></i></div></a>";
      } else {
        result.forEach((element) => {
          if (element.email.length <= 21) {
            content += `<a href='#'><div class='box bg-primary'>
                            <div class='image bg-primary'></div>
                            <div class='details'>${element.email}</div>
                          </div></a>`;
          } else {
            temp = element.email.substring(0, 20) + "...";
            content += `<a href='#'><div class='box bg-primary'>
                                <div class='image'></div>
                                <div class='details'>${temp}</div>
                          </div></a>`;
          }
        });

        content +=
          "<a href='/addRecipent'><div class='box add'><i class='bi bi-plus-circle'></i></div></a>";

        let mainPage = fs
          .readFileSync("./assets/html/dashboard.html")
          .toString()
          .replace("{{MAIN}}", my_recipents)
          .replace("{{SEARCH}}", "")
          .replace("{{CONTENT}}", content)
          .replace("{{SIDEBAR}}", sidebar_dashboard)
          .replace("{{active3}}", "active")
          .replace("{{NAVIGATION}}", navigation_dashboard)
          .replace("{{USER_NAME}}", req.session.user.email);

        res.send(mainPage);
      }
    }
  );
});

app.post("/recipentSearch", (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }

  let search = req.body.search;

  let query = `SELECT * FROM clients WHERE clients.email LIKE '%${search}%' AND user_id = '${req.session.user.id}';`;

  let content = "";

  db.query(query, (err, result, field) => {
    if (result < 1) {
      content = "";
    } else {
      result.forEach((element) => {
        if (element.email.length <= 21) {
          content += `<a href='#'><div class='box bg-primary'>
                            <div class='image bg-primary'></div>
                            <div class='details'>${element.email}</div>
                          </div></a>`;
        } else {
          temp = element.email.substring(0, 20) + "...";
          content += `<a href='#'><div class='box bg-primary'>
                                <div class='image'></div>
                                <div class='details'>${temp}</div>
                          </div></a>`;
        }
      });
      let mainPage = fs
        .readFileSync("./assets/html/dashboard.html")
        .toString()
        .replace("{{MAIN}}", my_recipents)
        .replace(
          "{{SEARCH}}",
          `<p style='margin-bottom: 20px;'>Znaleziono ${result.length}, <a href='/dashboardRecipents' class='link-primary'>Resetuj</a></p>`
        )
        .replace("{{CONTENT}}", content)
        .replace("{{SIDEBAR}}", sidebar_dashboard)
        .replace("{{active2}}", "active")
        .replace("{{NAVIGATION}}", navigation_dashboard)
        .replace("{{USER_NAME}}", req.session.user.email);

      res.send(mainPage);
    }
  });
});

app.get("/addRecipent", (req, res) => {
  if (!req.session.user) {
    return res.redirect("/");
  }
  let content = fs
    .readFileSync("./assets/html/components/recipent_dashboard.html")
    .toString()
    .replace("{{file_preview}}", "");

  let mainPage = fs
    .readFileSync("./assets/html/dashboard.html")
    .toString()
    .replace("{{MAIN}}", content)
    .replace("{{SIDEBAR}}", sidebar_dashboard)
    .replace("{{active3}}", "active")
    .replace("{{NAVIGATION}}", navigation_dashboard)
    .replace("{{USER_NAME}}", req.session.user.email);

  res.send(mainPage);
});

app.post("/uploadRecipents", upload.single("file"), async (req, res) => {
  if (!req.file) return res.send("Brak pliku!");

  const fileBuffer = req.file.buffer;
  const fileName = req.file.originalname;

  console.log("Odebrano plik:", fileName);

  let emails = [];

  try {
    if (fileName.endsWith(".csv")) {
      const csvData = fileBuffer.toString("utf8");

      const rows = parse(csvData, {
        columns: true,
        skip_empty_lines: true,
      });

      emails = rows
        .map((row) => row[req.body.emailCol || "email"])
        .filter((e) => e && e.trim() !== "");
    }

    if (fileName.endsWith(".json")) {
      const jsonData = JSON.parse(fileBuffer.toString("utf8"));

      emails = jsonData
        .map((row) => row[req.body.emailCol || "email"])
        .filter((e) => e && e.trim() !== "");
    }

    if (emails.length === 0) {
      return res.send("Nie znaleziono emaili w pliku!");
    }

    for (const email of emails) {
      db.query("INSERT INTO clients (user_id, email) VALUES (?, ?)", [
        req.session.user.id,
        email,
      ]);
    }

    res.redirect("/dashboardRecipents");
  } catch (err) {
    console.error(err);
    res.status(500).send("Błąd podczas przetwarzania pliku.");
  }
});

app.get("/logout", (req, res) => {
  req.session.destroy((err) => {
    res.redirect("/");
  });
});

/* DASHBOARD - END */

app.listen(port, () => console.log(`Example app listening on port ${port}!`));
