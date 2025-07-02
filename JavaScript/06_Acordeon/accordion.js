const accordion = document.querySelector(".accordion_content"); //segundo parrafo
const accordionItem = document.querySelector(".accordion_item"); //lista

let height = 0;

accordionItem.addEventListener("click", () => {
  if (!height) {
    height = accordion.scrollHeight;
  } else {
    height = 0;
  }

  accordion.style.height = `${height}px`;
});
