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

// const settings = {
// 	"async": true,
// 	"url": "https://apis.digital.gob.cl/fl/feriados	",
// 	"method": "GET"
// };


// data: "{'idsEncriptado': '" + this.id.split('_')[1] + "'}",
$.ajax({
    type: "GET",
    url: "https://randomuser.me/api/",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    async: false,
    success: function (data) {
        console.log(data);
    },
    error: function (xhr, ajaxOptions, thrownError) {
        console.log(xhr.status);
        console.log(thrownError);
    }
});