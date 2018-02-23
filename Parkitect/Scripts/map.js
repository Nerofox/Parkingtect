function addMarker(coordinates, title, className) {
    // create the popup
    var popup = new mapboxgl.Popup({ closeOnClick: false }).setHTML(title);

    // create DOM element for the marker
    var el = document.createElement('div');
    el.className = className;

    // create the marker
    new mapboxgl.Marker(el)
        .setLngLat(coordinates)
        .setPopup(popup) // sets a popup on this marker
        .addTo(map);
}

function addLayer(id, geometry, color) {
    map.addLayer({
        'id': id,
        'type': 'line',
        "source": {
            "type": "geojson",
            "data": {
                "type": "Feature",
                "properties": {},
                "geometry": geometry
            }
        },
        "layout": {
            "line-join": "round",
            "line-cap": "round"
        },
        "paint": {
            "line-color": color,
            "line-width": 4
        }
    });
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
    //search iti
    $.get("/ApiMap/BestItiParking?lon=" + e.result.geometry.coordinates[0] + "&lat=" + e.result.geometry.coordinates[1], function (data) {
        data = JSON.parse(data);
        addLayer(data[0].Id, data[0].GeometryIti, "#34C924");
        addLayer(data[1].Id, data[1].GeometryIti, "#0080FF");
        addLayer(data[2].Id, data[2].GeometryIti, "#0080FF");
    });
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