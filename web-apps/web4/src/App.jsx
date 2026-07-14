import { useState } from "react";
import images from "./data/images";
import "bootstrap/dist/css/bootstrap.css";
import "./App.css";

const App = () => {
  const [items, setItems] = useState(images);
  const [flowers, setFlowers] = useState(true);
  const [animals, setAnimals] = useState(true);
  const [cars, setCars] = useState(true);

  const filteredItems = items.filter(
    (item) =>
      (item.category !== 1 || flowers) &&
      (item.category !== 2 || animals) &&
      (item.category !== 3 || cars)
  );

  const Box = ({ id, alt, filename, category, downloads }) => {
    return (
      <>
        <div key={id} className={"category" + category}>
          <img src={filename} alt={alt} />
          <h4>Pobrań: {downloads}</h4>
          <button
            type="button"
            className="btn btn-success"
            onClick={() => handleDownload(id)}
          >
            Pobierz
          </button>
        </div>
      </>
    );
  };

  const handleDownload = (id) => {
    setItems((prev) =>
      prev.map((item) =>
        item.id === id ? { ...item, downloads: item.downloads + 1 } : item
      )
    );
  };

  return (
    <>
      <main>
        <h1>Kategorie zdjęć</h1>
        <div style={{ display: "flex", gap: "20px" }}>
          <div className="form-check form-switch">
            <input
              checked={flowers}
              type="checkbox"
              name="flowers"
              id="flowers"
              className="form-check-input"
              onChange={() => setFlowers(!flowers)}
            />
            <label htmlFor="flowers" className="form-check-label">
              Kwiaty
            </label>
          </div>
          <div className="form-check form-switch">
            <input
              checked={animals}
              type="checkbox"
              name="animals"
              id="animals"
              className="form-check-input"
              onChange={() => setAnimals(!animals)}
            />
            <label htmlFor="animals" className="form-check-label">
              Zwierzęta
            </label>
          </div>
          <div className="form-check form-switch">
            <input
              checked={cars}
              type="checkbox"
              name="cars"
              id="cars"
              className="form-check-input"
              onChange={() => setCars(!cars)}
            />
            <label htmlFor="cars" className="form-check-label">
              Samochody
            </label>
          </div>
        </div>
        <div style={{ display: "flex", flexWrap: "wrap", gap: "10px" }}>
          {filteredItems.map((item) => (
            <Box
              key={item.id}
              id={item.id}
              alt={item.alt}
              filename={item.filename}
              category={item.category}
              downloads={item.downloads}
            />
          ))}
        </div>
      </main>
    </>
  );
};

export default App;
