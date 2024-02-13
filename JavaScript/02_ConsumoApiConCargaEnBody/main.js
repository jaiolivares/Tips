console.log($.fn.jquery);

$("#customer").on("submit", (e) => {
  e.preventDefault();
  //const data = $("#customer").serialize();
  const data = $("#customer").serializeArray();
  const dataHtml = data.reduce(
    (ac, e) => (ac += `<p>${e.name}: ${e.value}</p>`),
    ""
  );
  $("#content").prepend(dataHtml);
});

$("#btnRequest").on("click", () => {
  $.ajax({
    url: "https://jsonplaceholder.typicode.com/todos",
    method: "GET",
    // data: {title: "foo", body: "bar", userId: 1 }
    beforeSend: () => {
      $("#content").html("Loading...");
    },
    success: (data) => {
      const dataHtml = data.reduce(
        (ac, e) => (ac += `<p>${e.title}: ${e.value}</p>`),
        ""
      );
      $("#content").prepend(dataHtml);
    },
  });
});
