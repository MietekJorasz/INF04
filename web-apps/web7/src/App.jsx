import { useState } from "react";
import "bootstrap/dist/css/bootstrap.css";
import "./App.css";
import data from "./data/data";

data[0].wyswietlenia = data[0].wyswietlenia + 1;

const App = () => {
  const [filmData, setFilmData] = useState(data);
  const [index, setIndex] = useState(0);

  const addViews = (id) => {
    setFilmData((filmData) =>
      filmData.map((item, index) =>
        index == id ? { ...item, wyswietlenia: item.wyswietlenia + 1 } : item,
      ),
    );
  };

  const addLike = (id) => {
    setFilmData((filmData) =>
      filmData.map((item, index) =>
        index == id ? { ...item, polubienia: item.polubienia + 1 } : item,
      ),
    );
  };

  return (
    <div style={{ padding: "48px" }} class="container text-center">
      <div class="row">
        <div class="col">
          <video
            style={{ width: "100%" }}
            src={filmData[index].plik}
            controls
          ></video>
          <h2>{filmData[index].tytul}</h2>
          <p>
            Dodany przez: {filmData[index].autor}, polubień:{" "}
            {filmData[index].polubienia}, wyświetleń{" "}
            {filmData[index].wyswietlenia}
          </p>
          <p>
            <button
              type="button"
              class="btn btn-primary"
              onClick={() => {
                addLike(index);
              }}
            >
              Lubię to!
            </button>
          </p>
        </div>
        <div class="col">
          <h2>Zobacz też inne filmy</h2>
          <ul class="list-group">
            {filmData.map((item) => (
              <li
                key={item.id}
                class="list-group-item"
                onClick={() => {
                  setIndex(item.id - 1);
                  addViews(item.id - 1);
                }}
              >
                {item.tytul}
              </li>
            ))}
          </ul>
        </div>
      </div>
    </div>
  );
};

export default App;
