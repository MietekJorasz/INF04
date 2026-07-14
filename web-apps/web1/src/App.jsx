import { useState } from "react";
import "bootstrap/dist/css/bootstrap.css";
import "./App.css";
import Aside from "./components/aside";
import Main from "./components/main";
import dataFilm from "./data/data";

const App = () => {
  const [data, setData] = useState(dataFilm);
  const [currentFilm, setCurrentFilm] = useState(0);

  return (
    <div style={{ display: "flex", gap: "10px", height: "100vh" }}>
      <Main data={data[currentFilm]} setData={setData} />
      <Aside data={data} setCurrentFilm={setCurrentFilm} />
    </div>
  );
};

export default App;
