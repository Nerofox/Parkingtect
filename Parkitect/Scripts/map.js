var map, geocoder;

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

function initMap(container) {
    map = new mapboxgl.Map({
        container: container, // container id
        style: 'mapbox://styles/mapbox/streets-v9', // stylesheet location
        center: [-1.650369, 48.109998], // starting position [lng, lat]
        zoom: 11.70801835251593 // starting zoom
    });

    geocoder = new MapboxGeocoder({
        accessToken: mapboxgl.accessToken
    });

    mapboxgl.accessToken = 'pk.eyJ1IjoibmVyb2ZveCIsImEiOiJjamR1MDVnMXAyaGEwMnFxcGNvYWJ2cjByIn0.to1lq16P7bPjs0bUn4gUjg';

    map.addControl(geocoder);
}


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
