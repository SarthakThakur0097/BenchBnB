(async() =>{
    const baseURL = 'http://localhost:49834/api/benches';

    async function getBenches()
    {
        return await fetch(baseURL);
    };

    const response = await getBenches();
    const benchInfo = await response.json();
    const markers = [];

   
    var baseMapLayer = new ol.layer.Tile({
        source: new ol.source.OSM()
    });
    var map = new ol.Map({
        target: 'map',
        layers: [ baseMapLayer],
        view: new ol.View({
            center: ol.proj.fromLonLat([-74.0061,40.712]), 
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
    console.log(mousePosition);
    //Adding a marker on the map
    
    map.on('singleclick', async function(event)
    {
        console.log(event.coordinate);
        event.coordinate = ol.proj.transform(event.coordinate, 'EPSG:3857', 'EPSG:4326')
        const latitude = event.coordinate[0];
        const longitude = event.coordinate[1];
        print();
        
     
        window.location.href = "/Bench/Create?lat="+latitude+"&lon="+longitude;
       
    });


    
    
    async function print()
    {
        console.log(latitude);
        console.log(longitude);
    }
    async function putMarkers(benchInfo)
    {
        var marker = new ol.Feature({
            geometry: new ol.geom.Point(
              ol.proj.fromLonLat([benchInfo.Latitude,benchInfo.Longitude])
            ),  // Cordinates of New York's Town Hall
        });
        markers.push(marker);
    }
    benchInfo.forEach(putMarkers)
    

    var vectorSource = new ol.source.Vector({
        features: markers
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

})();
