function addMarker(coordinates, title, className) {
    // create the popup
    var popup = new mapboxgl.Popup().setHTML(title);

    // create DOM element for the marker
    var el = document.createElement('div');
    el.className = className;

    // create the marker
    new mapboxgl.Marker(el)
        .setLngLat(coordinates)
        .setPopup(popup) // sets a popup on this marker
        .addTo(map);
}

mapboxgl.accessToken = 'pk.eyJ1IjoibmVyb2ZveCIsImEiOiJjamR1MDVnMXAyaGEwMnFxcGNvYWJ2cjByIn0.to1lq16P7bPjs0bUn4gUjg';

var map = new mapboxgl.Map({
    container: 'map', // container id
    style: 'mapbox://styles/mapbox/streets-v9', // stylesheet location
    center: [-1.650369, 48.109998], // starting position [lng, lat]
    zoom: 11.70801835251593 // starting zoom
});

var geocoder = new MapboxGeocoder({
    accessToken: mapboxgl.accessToken
});
map.addControl(geocoder);
geocoder.on("result", function (e) {
    addMarker(e.result.geometry.coordinates, e.result.place_name, "marker marker-position");
});

$(document).ready(function () {
    //load parking in map
    $.get("/ApiParking/List", function (data) {
        data = JSON.parse(data);

        for (var i = 0; i < data.length; i++) {
            if (data[i].Name != null)
                addMarker(data[i].Geometry.coordinates, "Nom : " + data[i].Name + "<br>Place libre : " + data[i].FreePlace + "<br>Place max : " + data[i].MaxPlace, "marker")
        }
    });
});