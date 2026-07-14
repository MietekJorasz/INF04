import { useState } from "react";
import "bootstrap/dist/css/bootstrap.css";
import "./App.css";

const App = () => {
  const [filmTitle, setfilmTitle] = useState("");
  const [filmGenre, setfilmGenre] = useState(0);

  const content = ["", "Komedia", "Obyczajowy", "Sensacyjny", "Horror"];

  return (
    <>
      <form>
        <div className="form-group">
          <label htmlFor="filmTitle">Tytuł filmu</label>
          <input
            className="form-control"
            type="text"
            name="filmTitle"
            id="filmTitle"
            onChange={(e) => setfilmTitle(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="filmGenre">Rodzaj</label>
          <select
            className="form-control"
            name="filmGenre"
            id="filmGenre"
            onChange={(e) => setfilmGenre(e.target.value)}
          >
            {content.map((item, index) => (
              <option key={index} value={index}>
                {item}
              </option>
            ))}
          </select>
        </div>

        <button
          className="btn btn-primary"
          type="button"
          onClick={() =>
            console.log("tytul: " + filmTitle + "; rodzaj: " + filmGenre)
          }
        >
          Dodaj
        </button>
      </form>
    </>
  );
};

export default App;
