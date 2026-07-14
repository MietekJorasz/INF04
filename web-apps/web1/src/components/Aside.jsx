const Aside = ({ data, setCurrentFilm }) => {
  return (
    <>
      <aside
        style={{
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
          alignItems: "center",
          gap: "10px",
        }}
      >
        {data.map((item) => (
          <div
            key={item.id}
            style={{ cursor: "pointer" }}
            onClick={() => setCurrentFilm(item.id - 1)}
          >
            <img
              style={{
                width: "180px",
                height: "180px",
                border: "1px solid black",
                borderRadius: "20px",
              }}
              src={item.icon}
              alt={item.alt}
            />
          </div>
        ))}
      </aside>
    </>
  );
};

export default Aside;
