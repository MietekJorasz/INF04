import { useState } from "react";
import "bootstrap/dist/css/bootstrap.css";
import "./App.css";

const content = [
  "Programowanie w C#",
  "Angular dla początkujących",
  "Kurs Django",
];

const App = () => {
  const [fullName, setFullName] = useState("");
  const [courseID, setcourseID] = useState("");

  return (
    <>
      <div>
        <h2>Liczba kursów: {content.length}</h2>
        <ol>
          {content.map((content, index) => (
            <li key={index}>{content}</li>
          ))}
        </ol>
        <form
          onSubmit={(e) => {
            e.preventDefault();
            console.log(fullName);
            if (0 <= courseID && courseID < content.length)
              console.log(content[courseID]);
            else console.log("Nieprawidłowy numer kursu");
          }}
        >
          <div className="form-group">
            <label htmlFor="fullName">Imię i nazwisko:</label>
            <input
              className="form-control"
              type="text"
              id="fullName"
              onChange={(e) => {
                setFullName(e.target.value);
              }}
            />
          </div>

          <div className="form-group">
            <label htmlFor="courseID">Numer kursu:</label>
            <input
              className="form-control"
              type="number"
              id="courseID"
              onChange={(e) => {
                setcourseID(e.target.value - 1);
              }}
            />
          </div>

          <div className="form-group">
            <button
              className="btn btn-primary"
              // type="button"
              // onClick={(e) => {
              //   console.log(fullName);
              //   if (0 <= courseID && courseID < content.length)
              //     console.log(content[courseID]);
              //   else console.log("Nieprawidłowy numer kursu");
              // }}
            >
              Zapisz do kursu
            </button>
          </div>
        </form>
      </div>
    </>
  );
};

export default App;
