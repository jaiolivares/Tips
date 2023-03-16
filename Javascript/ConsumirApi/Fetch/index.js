// const settings = {
// 	"async": true,
// 	"crossDomain": true,
// 	"url": "https://open-weather-map27.p.rapidapi.com/weather",
// 	"method": "GET",
// 	"headers": {
// 		"X-RapidAPI-Key": "SIGN-UP-FOR-KEY",
// 		"X-RapidAPI-Host": "open-weather-map27.p.rapidapi.com"
// 	}
// };

const urlApi = "https://randomuser.me/api/";

//fetch(urlApi).then(res => console.log(res));
// fetch(urlApi, settings)
fetch(urlApi)
.then(res => res.json())
.then(response => {
    console.log(response);
})
.catch(err => console.log("error JO:" + err));