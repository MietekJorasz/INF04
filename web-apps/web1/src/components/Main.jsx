const Main = ({ data, setData }) => {
  const handleLike = (id) => {
    setData((data) =>
      data.map((item) =>
        item.id == id ? { ...item, likes: item.likes + 1 } : item,
      ),
    );
  };

  return (
    <>
      <main
        style={{
          height: "100vh",
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <video
          autoPlay={true}
          style={{ height: "80vh", width: "30vw" }}
          src={data.film}
          controls
        ></video>
        <div
          style={{
            width: "30vw",
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
          }}
        >
          <h2>{data.likes} polubień</h2>
          <button
            className="btn btn-primary"
            onClick={() => {
              handleLike(data.id);
            }}
          >
            Polub
          </button>
        </div>
      </main>
    </>
  );
};

export default Main;
