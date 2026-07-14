import { useState } from "react";
import gallery from "./data/gallery";
import "bootstrap/dist/css/bootstrap.css";
import "./App.css";

const ITEMS_PER_PAGE = 4;

const App = () => {
  const [galleryPage, setGalleryPage] = useState(1);
  const [filter, setFilter] = useState(0);

  // FILTROWANIE
  const filteredGallery =
    filter === 0 ? gallery : gallery.filter((item) => item.category === filter);

  // PAGINACJA
  const totalPages = Math.ceil(filteredGallery.length / ITEMS_PER_PAGE);

  const visibleItems = filteredGallery.slice(
    (galleryPage - 1) * ITEMS_PER_PAGE,
    galleryPage * ITEMS_PER_PAGE
  );

  return (
    <div className="container">
      {/* FILTER */}
      <div className="row mb-3">
        <label htmlFor="filter" className="form-label">
          Filtr
        </label>
        <select
          id="filter"
          className="form-select"
          onChange={(e) => {
            setFilter(Number(e.target.value));
            setGalleryPage(1);
          }}
        >
          <option value={0}>Brak</option>
          <option value={1}>Kwiaty</option>
          <option value={2}>Zwierzęta</option>
          <option value={3}>Samochody</option>
        </select>
      </div>

      {/* GALLERY */}
      <div className="row row-cols-2 row-cols-md-3 row-cols-lg-4 g-3">
        {visibleItems.map((item) => (
          <div className="col" key={item.id}>
            <div className="card h-100">
              <img
                src={item.filename}
                alt={item.alt}
                className="card-img-top img-fluid"
              />
              <div className="card-body">
                <p className="card-text">{item.alt}</p>
              </div>
            </div>
          </div>
        ))}
      </div>

      {/* PAGINATION */}
      <div className="row mt-4">
        <div className="col d-flex justify-content-center">
          <ul className="pagination">
            <li className={`page-item ${galleryPage === 1 && "disabled"}`}>
              <button
                className="page-link"
                onClick={() => setGalleryPage((p) => Math.max(p - 1, 1))}
              >
                Previous
              </button>
            </li>

            {[...Array(totalPages)].map((_, i) => (
              <li
                key={i}
                className={`page-item ${galleryPage === i + 1 && "active"}`}
              >
                <button
                  className="page-link"
                  onClick={() => setGalleryPage(i + 1)}
                >
                  {i + 1}
                </button>
              </li>
            ))}

            <li
              className={`page-item ${
                galleryPage === totalPages && "disabled"
              }`}
            >
              <button
                className="page-link"
                onClick={() =>
                  setGalleryPage((p) => Math.min(p + 1, totalPages))
                }
              >
                Next
              </button>
            </li>
          </ul>
        </div>
      </div>
    </div>
  );
};

export default App;
