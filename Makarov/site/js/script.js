var platform=new H.service.Platform({'app_id':'{icDUzRIlkkoHxVh3ZWBc}','app_code':'{xzPGxFrpDl1aStROU6d7jA}'});

// Obtain the default map types from the platform object:
var defaultLayers = platform.createDefaultLayers();

// Instantiate (and display) a map object:
var map = new H.Map(
  document.getElementById('mapContainer'),
  defaultLayers.normal.map,
  {
    zoom: 10,
    center: { lat: 52.5, lng: 13.4 }
  });