
var baseMapLayer = new ol.layer.Tile({
    source: new ol.source.OSM()
});
var map = new ol.Map({
    target: 'map',
    layers: [baseMapLayer],
    view: new ol.View({
        center: ol.proj.fromLonLat([-74.0061, 40.712]),
        zoom: 15 //Initial Zoom Level
    })
});
var mousePosition = new ol.control.MousePosition({
    coordinateFormat: ol.coordinate.createStringXY(2),
    projection: 'EPSG:4326',
    target: document.getElementById('myposition'),
    undefinedHTML: '&nbsp;'
});
map.addControl(mousePosition);

console.log("Pos is: " + mousePosition.coordinateFormat);

//Adding a marker on the map
var marker = new ol.Feature({
    geometry: new ol.geom.Point(
      ol.proj.fromLonLat([4-.7644, 73.9235])
    ),  // Cordinates of New York's Town Hall
});
var vectorSource = new ol.source.Vector({
    features: [marker]
});
var markerVectorLayer = new ol.layer.Vector({
    source: vectorSource,
});
map.addLayer(markerVectorLayer);

var iconFeatures = [];

var iconFeature = new ol.Feature({
    geometry: new ol.geom.Point(ol.proj.transform([-72.0704, 46.678], 'EPSG:4326',
    'EPSG:3857')),
    name: 'Null Island',
    population: 4000,
    rainfall: 500
});

var iconFeature1 = new ol.Feature({
    geometry: new ol.geom.Point(ol.proj.transform([-73.1234, 45.678], 'EPSG:4326',
    'EPSG:3857')),
    name: 'Null Island Two',
    population: 4001,
    rainfall: 501
});

iconFeatures.push(iconFeature);
iconFeatures.push(iconFeature1);

var vectorSource = new ol.source.Vector({
    features: iconFeatures //add an array of features
});


var iconStyle = new ol.style.Style({
    image: new ol.style.Icon(/** @type {olx.style.IconOptions} */({
        anchor: [0.5, 46],
        anchorXUnits: 'fraction',
        anchorYUnits: 'pixels',
        opacity: 0.75,
        src: 'data/icon.png'
    }))
});
