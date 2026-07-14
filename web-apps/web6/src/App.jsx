import "bootstrap/dist/css/bootstrap.css";
import { useState } from "react";
import dataImages from "./data/data";
import "./App.css";
import data from "./data/data";

const App = () => {
  const [data, setData] = useState(dataImages);
  const [filterFlower, setFilterFlower] = useState(true);
  const [filterAnimal, setFilterAnimal] = useState(true);
  const [filterCar, setFilterCar] = useState(true);
  const [iterator, setIterator] = useState(0);

  const filterData = data.filter(
    (item) =>
      (item.category !== 1 || filterFlower) &&
      (item.category !== 2 || filterAnimal) &&
      (item.category !== 3 || filterCar)
  );

  const handleButton = (id) => {
    setData((data) =>
      data.map((item) =>
        item.id == id ? { ...item, downloads: item.downloads + 1 } : item
      )
    );
  };

  return (
    <>
      <div>
        <div style={{ height: "100vh" }}>
          <h1 style={{ textAlign: "center" }}>Zdjecia</h1>
          <div
            style={{
              marginTop: "150px",
              display: "flex",
              gap: "20px",
              justifyContent: "center",
              alignItems: "center",
            }}
          >
            <button
              onClick={() => {
                setIterator(iterator == 0 ? data.length - 1 : iterator - 1);
              }}
              className="btn btn-primary"
            >
              Previous
            </button>
            <div>
              <img src={data[iterator].filename} alt={data[iterator].alt} />
            </div>
            <button
              onClick={() => {
                let value = iterator == data.length - 1 ? 0 : iterator + 1;
                setIterator(value);
              }}
              className="btn btn-primary"
            >
              Next
            </button>
          </div>
        </div>
        <h1>Kategorie zdjęć</h1>
        <div style={{ display: "flex" }}>
          <div className="form-check form-switch">
            <input
              checked={filterFlower}
              onChange={() => {
                setFilterFlower(!filterFlower);
              }}
              className="form-check-input"
              type="checkbox"
              name="flower"
              id="flower"
            />
            <label className="form-check-label" htmlFor="flower">
              Kwiaty
            </label>
          </div>
          <div className="form-check form-switch">
            <input
              checked={filterAnimal}
              onChange={() => {
                setFilterAnimal(!filterAnimal);
              }}
              className="form-check-input"
              type="checkbox"
              name="animal"
              id="animal"
            />
            <label className="form-check-label" htmlFor="animal">
              Zwierzęta
            </label>
          </div>
          <div className="form-check form-switch">
            <input
              checked={filterCar}
              onChange={() => {
                setFilterCar(!filterCar);
              }}
              className="form-check-input"
              type="checkbox"
              name="car"
              id="car"
            />
            <label className="form-check-label" htmlFor="car">
              Samochody
            </label>
          </div>
        </div>
        <div style={{ display: "flex", flexWrap: "wrap" }}>
          {filterData.map((item) => (
            <div
              style={{
                display: "flex",
                flexDirection: "column",
                padding: "5px",
              }}
              key={item.id}
            >
              <img src={item.filename} alt={item.alt} />
              <h4>Ilość pobrań: {item.downloads}</h4>
              <button
                onClick={() => {
                  handleButton(item.id);
                }}
                style={{ width: "100px" }}
                className="btn btn-success"
                type="button"
              >
                Pobierz
              </button>
            </div>
          ))}
        </div>
      </div>
    </>
  );
};

export default App;
